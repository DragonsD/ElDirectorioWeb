using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class CouponSetController
    {
        public bool Save(int franchiseeId, int advertiserId, int couponSetId, string name, string description, int personalId)
        {
            bool result = false;

            CouponSet couponSet = this.FetchById(couponSetId);

            if (couponSet == null)
            {
                couponSet = new CouponSet();
                this.db.CouponSets.InsertOnSubmit(couponSet);

                couponSet.FranchiseeId = franchiseeId;
                couponSet.AdvertiserId = advertiserId;
                couponSet.CreatedBy = personalId;
                couponSet.CreatedOn = DateTime.Now;
                couponSet.Deleted = false;
            }

            couponSet.Name = name;
            couponSet.Description = description;
            couponSet.ModifiedBy = personalId;
            couponSet.ModifiedOn = DateTime.Now;

            Advertiser adv = new AdvertiserController(this.db).FetchById(advertiserId, franchiseeId);
            if (adv != null)
            {
                adv.ModifiedOn = DateTime.Now;
                adv.UserModifiedOn = personalId;
            }

            try
            {
                this.db.SubmitChanges();
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }

            return result;
        }

        public bool Delete(int couponSetId, int personalId)
        {
            bool result = false;

            CouponSet set = this.FetchById(couponSetId);
            if (set == null)
            {
                this.Errors.Add("El elemento no existe");
                return false;
            }

            set.Advertiser.ModifiedOn = DateTime.Now;
            set.Advertiser.UserModifiedOn = personalId;

            try
            {
                set.Deleted = true;

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
