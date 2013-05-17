using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace bsx.DirLaguna.Advertiser.Code
{
    public class BannerItem
    {
        public BannerItem()
        {
            //
            // TODO: Add constructor logic here
            //
            this.image = string.Empty;
            this.video = string.Empty;
            this.content = string.Empty;
            this.link = string.Empty;
            this.Width = 0;
            this.Height = 0;
            this.realContent = string.Empty;
        }

        public string image { get; set; }
        public string video { get; set; }
        public string content { get; set; }
        public string link { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        private string realContent;
        public string RealContent
        {
            get
            {
                if (string.IsNullOrEmpty(realContent))
                {
                    StringBuilder sb = new StringBuilder();
                    bool useLink = false;

                    string temp = string.Empty;
                    if (!string.IsNullOrEmpty(link))
                    {
                        useLink = true;
                        temp = link.Contains("~") ? VirtualPathUtility.ToAbsolute(link) : link;
                        sb.AppendFormat("<a href='{0}'>", temp);
                    }
                    if (!string.IsNullOrEmpty(image))
                    {
                        temp = image.Contains("~") ? VirtualPathUtility.ToAbsolute(image) : image;
                        sb.AppendFormat("<img alt='' src='{0}' />", temp);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(video))
                        {

                            temp = video.Contains("~") ? VirtualPathUtility.ToAbsolute(video) : video;
                            sb.AppendFormat(@"<OBJECT classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000'
                        codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0'
                        WIDTH='{1}' HEIGHT='{2}' id='myMovieName'><PARAM NAME=movie VALUE='{0}'>
                        <PARAM NAME=quality VALUE=high><PARAM NAME=bgcolor VALUE=#FFFFFF>
                        <EMBED src='{0}' quality=high bgcolor=#FFFFFF WIDTH='{1}' HEIGHT='{2}' 
                        NAME='myMovieName' ALIGN='' TYPE='application/x-shockwave-flash' PLUGINSPAGE='http://www.macromedia.com/go/getflashplayer'></EMBED></OBJECT>",
                            temp, this.Width, this.Height);
                        }
                        else
                        {
                            sb.Append(content);
                        }
                    }
                    if (useLink)
                    {
                        sb.Append("</a>");
                    }
                    this.realContent = sb.ToString();
                }
                return this.realContent;

            }
        }

        public BannerItemType Type
        {
            get
            {
                if (!string.IsNullOrEmpty(image))
                    return BannerItemType.Image;
                else if (!string.IsNullOrEmpty(content))
                    return BannerItemType.Content;
                return BannerItemType.Video;
            }
        }

    }

    public enum BannerItemType
    {
        Image = 0,
        Content = 1,
        Video = 2
    }
}