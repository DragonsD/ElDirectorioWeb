using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bsx.DirLaguna.CommonWeb;
using System.Configuration;

namespace bsx.DirLaguna.Public.Code
{
    public class PublicityHelper
    {
        public static string PublicityPictureUrl(int publicityId)
        {
            return string.Format("{0}?{1}={2}", ConfigurationManager.AppSettings["UrlPublicityHandler"], QueryKeys.PublicityId, publicityId);
        }
    }
}