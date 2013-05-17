using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using NLog;

namespace bsx.DirLaguna.CommonWeb
{
    public class ThumbnailHelper
    {
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private long compression;

        private long quality;

        public ThumbnailHelper(long compression, long quality)
        {
            this.compression = compression;
            this.quality = quality;
        }

        public void ProcessNewImage(Stream file, string destiny, decimal desiredMaxSize)
        {
            //Image original = Image.FromFile(file);
            Image original = Image.FromStream(file);
            int maxSize = 0;
            int minSize = 0;

            if (original.Width > original.Height)
            {
                maxSize = original.Width;
                minSize = original.Height;
            }
            else
            {
                maxSize = original.Height;
                minSize = original.Width;
            }

            decimal factor = maxSize / desiredMaxSize;

            Bitmap bitmap = this.GetImage(
                file,
                (int)(original.Width / factor),
                (int)(original.Height / factor));

            /* ESTA SECCION DE CODIGO ES PARA SI QUEREMOS CORTAR EL ARCHIVO A UN TAMAÑO ESPECIFICO.
             * ASI COMO ESTA, UNICAMENTE SE REDIMENSIONA AL TAMAÑO ESPECIFICADO ACORDE AL TAMAÑO MAXIMO*/

            //DimensionJudge judge = new DimensionJudge(bitmap, 120, 100);
            //bitmap = this.CropBitmap(bitmap, judge.CropX, judge.CropY, judge.DesiredWidht, judge.DesiredHeight);

            ImageCodecInfo jpegCodec = this.getEncoderInfo("image/jpeg");

            if (jpegCodec == null)
                return;

            EncoderParameters parms = new EncoderParameters(2);
            parms.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, this.compression);
            parms.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, this.quality);

            try
            {
                bitmap.Save(destiny, jpegCodec, parms);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);   
            }
            
        }

        private ImageCodecInfo getEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }

        private Bitmap CropBitmap(Bitmap bitmap, int cropX, int cropY, int cropWidth, int cropHeight)
        {
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            Bitmap cropped = bitmap.Clone(rect, bitmap.PixelFormat);
            return cropped;
        }

        private Bitmap GetImage(Stream file, int thumbWidht, int thumbHeight)
        {
            Image image = Image.FromStream(file);
            int tw, th, tx, ty;
            int w = image.Width;
            int h = image.Height;
            double whRatio = (double)w / h;

            if (image.Width >= image.Height)
            {
                tw = thumbWidht;
                th = (int)(tw / whRatio);
            }
            else
            {
                th = thumbHeight;
                tw = (int)(th * whRatio);
            }

            tx = (thumbWidht - tw) / 2;
            ty = (thumbHeight - th) / 2;

            Bitmap thumb = new Bitmap(thumbWidht, thumbHeight, PixelFormat.Format24bppRgb);

            Graphics g = Graphics.FromImage(thumb);
            g.Clear(Color.White);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.DrawImage(image,
                new Rectangle(tx, ty, tw, th),
                new Rectangle(0, 0, w, h),
                GraphicsUnit.Pixel);
            return thumb;
        }
    }

}
