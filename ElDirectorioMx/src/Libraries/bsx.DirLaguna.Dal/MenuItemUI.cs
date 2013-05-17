using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.CommonWeb
{
    public class MenuItemUI
    {
        public string URL { get; set; }
        public string SecondURL { get; set; }
        public string Text { get; set; }
        public string Text2 { get; set; }
        public string CssClass { get; set; }

        public MenuItemUI()
        {
            this.SecondURL = "#";
        }
    }
}
