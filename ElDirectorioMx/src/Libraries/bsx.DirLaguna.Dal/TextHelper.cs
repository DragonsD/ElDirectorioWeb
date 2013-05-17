using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public static class TextHelper
    {
        public static string HtmlCleaner(string htmlText)
        {
            string aux = htmlText.Replace('\n', '|');
            aux = aux.Replace('\r', ' ');
            aux = aux.Replace("|", "<br/>");
            return aux;
        }

        public static string FullCleaner(string htmlText)
        {
            string aux = htmlText.Replace('\n', '|');
            aux = aux.Replace('\r', ' ');
            aux = aux.Replace("|", string.Empty);
            return aux;
        }

    }
}
