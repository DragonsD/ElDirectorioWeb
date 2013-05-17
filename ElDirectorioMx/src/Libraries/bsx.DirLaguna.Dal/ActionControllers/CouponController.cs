using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bsx.DirLaguna.Dal.Carrier;

namespace bsx.DirLaguna.Dal
{
    public partial class CouponController
    {
        public bool Save(SimpleCouponCarrier carrier, out int usedId)
        {
            bool result = false;
            usedId = -1;

            if (carrier.Categories.Count == 0)
            {
                this.Errors.Add("Debe definir al menos una categoría para el cupón");
                return result;
            }

            Coupon cp = this.FetchById(carrier.CouponId);

            if (cp == null)
            {
                cp = new Coupon();
                this.db.Coupon.InsertOnSubmit(cp);

                cp.FranchiseeId = carrier.FranchiseeId;
                cp.AdvertiserId = carrier.AdvertiserId;
                cp.CouponSetId = carrier.CouponSetId;
                cp.CreatedBy = carrier.PersonalId;
                cp.CreatedOn = DateTime.Now;
                cp.isClub = carrier.isClub;
            }

            if (cp.FranchiseeId != carrier.FranchiseeId)
            {
                this.Errors.Add("La entidad a guardar no corresponden a la franquicia");
                usedId = -1;
                return false;
            }

            cp.CouponStatusId = carrier.CouponStatusId;
            cp.Name = carrier.Name;
            cp.Description = carrier.Description;
            cp.Conditions = carrier.Conditions;
            cp.HowToCash = carrier.HowToCash;
            cp.StartDate = carrier.StartDate;
            cp.EndDate = carrier.EndDate;
            cp.IsExpirable = carrier.IsExpirable;
            cp.IsNationale = carrier.IsNational;
            cp.ModifiedBy = carrier.PersonalId;
            cp.ModifiedOn = DateTime.Now;
            cp.Deleted = false;
            cp.isClub = carrier.isClub;

            CouponCategoryController ccController = new CouponCategoryController(this.db);
            foreach (var item in carrier.Categories)
            {
                if (item.Deleted && item.CategoryId == 0)
                    continue;

                CouponCategory cc = ccController.FetchRelation(item.CouponId, item.CategoryId);
                if (cc == null || (cc != null && cc.CouponCategoryId == 0))
                {
                    cc = new CouponCategory();
                    cc.CreatedBy = carrier.PersonalId;
                    cc.CreatedOn = DateTime.Now;
                    cc.CategoryId = item.CategoryId;
                    cp.CouponCategory.Add(cc);
                }
                cc.Deleted = item.Deleted;
                cc.ModifiedBy = carrier.PersonalId;
                cc.ModifiedOn = DateTime.Now;
            }

            Advertiser adv = new AdvertiserController(this.db).FetchById(cp.AdvertiserId, cp.FranchiseeId);
            if (adv != null)
            {
                adv.ModifiedOn = DateTime.Now;
                adv.UserModifiedOn = carrier.PersonalId;
            }

            try
            {
                this.db.SubmitChanges();
                usedId = cp.CouponId;
                result = true;
            }
            catch (Exception ex)
            {
                usedId = -1;
                this.Errors.Add(ex.Message);
            }

            return result;
        }

        public bool UpdateHasImage(int couponId, int personalId)
        {
            bool bResult = true;
            Coupon cupon = this.FetchById(couponId);
            if (cupon == null)
            {
                this.Errors.Add("El registro No existe.");
                return false;
            }

            cupon.HasPicture = true;
            Advertiser adv = new AdvertiserController(this.db).FetchById(cupon.AdvertiserId, cupon.FranchiseeId);
            if (adv != null)
            {
                adv.ModifiedOn = DateTime.Now;
                adv.UserModifiedOn = personalId;
            }

            try
            {
                this.db.SubmitChanges();
            }
            catch (Exception ex)
            {
                this.Errors.Add("Error al actualizar el registro.");
                bResult = false;
            }

            return bResult;
        }

        public bool Delete(int couponId, int personalId)
        {
            bool result = false;

            Coupon cupon = this.FetchById(couponId);
            if (cupon == null)
            {
                this.Errors.Add("El elemento no existe");
                return false;
            }

            cupon.Advertiser.ModifiedOn = DateTime.Now;
            cupon.Advertiser.UserModifiedOn = personalId;
            try
            {
                cupon.Deleted = true;

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
