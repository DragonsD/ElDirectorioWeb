using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class BannerController
    {

        public bool Save(int id, string link, int pos, out int finalId)
        {
            bool result = false;            
            try
            {
                Banner item = this.FetchById(id);
                
                if (item == null)
                {
                    item = new Banner();
                    this.db.Banners.InsertOnSubmit(item);
                }
                item.Link = link;
                item.Priority = pos;
                this.db.SubmitChanges();
                result = true;
                finalId = item.BannerId;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
                finalId = -1;
            }
            return result;        
        }

        public bool UpdatePath(int id, string path)
        {
            if (string.IsNullOrEmpty(path))
                return true;
            Banner item = this.FetchById(id);
            if (item == null)
                return true;
            try
            {
                item.Picture = path;
                this.db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Banner item = this.FetchById(id);
                if (item == null)
                {
                    this.Errors.Add("El elemento no existe");
                    return false;
                }
                item.Deleted = true;
                this.db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
                return false;
            }
        }
    }
}
