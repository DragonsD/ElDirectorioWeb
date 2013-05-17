using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bsx.DirLaguna.Mobile.Code
{
    public class PageCounter
    {
        public List<PageItem> Items { get; set; }

        public PageCounter(int totalItems, int pageSize)
        {
            int inserted = 0;
            int count = 0;
            this.Items = new List<PageItem>();

            do
            {
                this.Items.Add(new PageItem() { PageIndex = count + 1, StartIndex = pageSize * count });
                count = count + 1;
                inserted += pageSize;
            } while (inserted < totalItems);

            //for (int i = 0; i < totalItems / pageSize; i++)
            //{
            //    this.Items.Add(new PageItem() { PageIndex = i + 1, StartIndex = pageSize * i });
            //}
        }

        public class PageItem
        {
            public int PageIndex { get; set; }

            public int StartIndex { get; set; }
        }
    }
    
}