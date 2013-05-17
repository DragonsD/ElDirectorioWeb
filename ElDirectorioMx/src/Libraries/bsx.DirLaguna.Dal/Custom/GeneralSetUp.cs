using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class GeneralSetUp
    {
        public GeneralSetUp FetchGeneralSetup()
        {
            GeneralSetUpController controller = new GeneralSetUpController();
            return controller.FetchAll().FirstOrDefault();
        }

        public string FixFrontPageMarkup(string url)
        {
            if (string.IsNullOrEmpty(this.FrontPageMarkup))
                return this.FrontPageMarkup;
            return this.FrontPageMarkup.Replace("/content/inblogpost/", string.Format("{0}/content/inblogpost/",url));
        }

        public string FixFrontPageMarkupMovil(string url)
        {
            if (string.IsNullOrEmpty(this.FrontPageMarkupIphone))
                return this.FrontPageMarkupIphone;
            return this.FrontPageMarkupIphone.Replace("/content/inblogpost/", string.Format("{0}/content/inblogpost/", url));
        }

        public string FixPageMarkup(string url, string markup)
        {
            if (string.IsNullOrEmpty(markup))
                return markup;
            return markup.Replace("/content/inblogpost/", string.Format("{0}/content/inblogpost/", url));
        }
    }
}
