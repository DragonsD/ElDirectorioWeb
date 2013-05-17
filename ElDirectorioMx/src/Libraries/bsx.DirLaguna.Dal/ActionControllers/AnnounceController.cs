using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class AnnounceController
    {
        public bool Save(int announceId, int advertiserId, int pageId, int franchiseeId, out int newAnnounceId)
        {
            bool result = false;
            newAnnounceId = -1;

            Announce announce = this.FetchById(announceId, franchiseeId);
            if (announce == null)
            {
                announce = new Announce();
                announce.CreatedOn = DateTime.Now;
                this.db.Announces.InsertOnSubmit(announce);
            }

            announce.AdvertiserId = advertiserId;
            announce.PageId = pageId;
            announce.FranchiseeId = franchiseeId;
            announce.Deleted = false;

            try
            {
                this.db.SubmitChanges();
                newAnnounceId = announce.AnnounceId;
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
                newAnnounceId = -1;
            }

            return result;
        }

        public bool Delete(int announceId, int franchiseeId)
        {
            bool result = false;

            Announce announce = this.FetchById(announceId, franchiseeId);
            if (announce == null)
            {
                this.Errors.Add("El elemento no existe");
                return false;
            }
            else
            {
                announce.ModifiedOn = DateTime.Now;
            }

            try
            {
                announce.Deleted = true;
                announce.ModifiedOn = DateTime.Now;

                this.db.SubmitChanges();
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }

            return result;
        }
    }
}
