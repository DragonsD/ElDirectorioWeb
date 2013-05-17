using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class PageController
    {
        public bool Save(int pageId, int pageNumber, out int newPageId)
        {
            bool result = false;
            newPageId = -1;

            Page page = this.FetchById(pageId);
            if (page == null)
            {
                page = new Page();
                page.CreatedOn = DateTime.Now;
                this.db.Pages.InsertOnSubmit(page);
            }
            else
            {
                page.ModiefiedOn = DateTime.Now;
            }

            page.Number = pageNumber;
            page.SyncNumber = -1;
            page.Deleted = false;

            try
            {
                this.db.SubmitChanges();
                newPageId = page.PageId;
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
                newPageId = -1;
            }

            return result;
        }

        public bool Delete(int pageId)
        {
            bool result = false;

            Page page = this.FetchById(pageId);
            if (page == null)
            {
                this.Errors.Add("El elemento no existe");
                return false;
            }

            try
            {
                page.Deleted = true;
                page.ModiefiedOn = DateTime.Now;

                this.db.SubmitChanges();
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }

            return result;
        }

        public bool UpdatePages(List<Page> pages)
        {
            bool result = false;
            try
            {
                foreach (var item in pages)
                {
                    Page page = this.FetchById(item.PageId);
                    page.SyncNumber = item.SyncNumber;
                    page.SyncDate = DateTime.Now;
                }
                this.db.SubmitChanges();
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }
            return result;
        }
    }
}
