using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace bsx.DirLaguna.iOsDataStorage
{
    public class GzipHelper
    {
        public static void Compress(FileInfo fi)
        {
            // Get the stream of the source file.
            using (FileStream inFile = fi.OpenRead())
            {
                // Prevent compressing hidden and already compressed files.
                if ((File.GetAttributes(fi.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & fi.Extension != ".gz")
                {
                    // Create the compressed file.
                    using (FileStream outFile = File.Create(fi.FullName + ".gz"))
                    {
                        using (GZipStream Compress = new GZipStream(outFile,
                                CompressionMode.Compress))
                        {
                            // Copy the source file into the compression stream.
                            byte[] buffer = new byte[4096];
                            int numRead;
                            while ((numRead = inFile.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                Compress.Write(buffer, 0, numRead);
                            }
                            Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
                                fi.Name, fi.Length.ToString(), outFile.Length.ToString());
                        }
                    }
                }
            }
        }

        public static void Compress2Gz(FileInfo fi)
        {
            // A.
            // Write string to temporary file.
            //string temp = Path.GetTempFileName();
            //File.WriteAllText(temp, value);

            // B.
            // Read file into byte array buffer.
            byte[] b;
            using (FileStream f = new FileStream(fi.FullName, FileMode.Open))
            {
                b = new byte[f.Length];
                f.Read(b, 0, (int)f.Length);
            }

            // C.
            // Use GZipStream to write compressed bytes to target file.
            using (FileStream f2 = new FileStream(fi.FullName + ".gz", FileMode.Create))
            using (GZipStream gz = new GZipStream(f2, CompressionMode.Compress, false))
            {
                gz.Write(b, 0, b.Length);
            }
        }
    }
}
