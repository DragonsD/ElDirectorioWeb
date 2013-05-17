using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using bsx.DirLaguna.Dal.Enum;

namespace bsx.DirLaguna.Dal
{
    public partial class Advertiser
    {

        /*partial void OnCreated()
        {
            // Do the extra stuff here;
            this.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Advertiser_PropertyChanged);
        }*/


        /*void Advertiser_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (string.Equals(e.PropertyName, Advertiser.ColumnNames.WebPage))
            {
                if (this.WebPage.IndexOf("http://") < 0)
                {
                    this.WebPage = string.Format("http://{0}", this.WebPage);
                }
            }
        }*/

        public string FixedWebPage
        {
            get
            {
                if (this.WebPage.IndexOf("http://") < 0 && this.WebPage.Length > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("http://{0}", this.WebPage);
                    return sb.ToString();
                }
                return this.WebPage;
            }
        }

        public static string LogoFileNameMask(int id) { return string.Format("{0}", id); }

        public static string LogoThumbFileNameMask(int id) { return string.Format("{0}_thumb", id); }

        #region ISqlLite

        public const string Separator = "*|@";

        //string ISqLiteData.LogoName { get { return Advertiser.LogoThumbFileNameMask(this.AdvertiserId); } }

        public float SqlitePointX { get { return (float)(this.MapReferenceX.HasValue ? this.MapReferenceX.Value : 0); } }

        public float SqlitePointY { get { return (float)(this.MapReferenceY.HasValue ? this.MapReferenceY.Value : 0); } }

        public string SqlitePhones
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (var item in this.Phone.Where(x => !x.Deleted))
                {
                    builder.AppendFormat("{0}{1}|{2}", Advertiser.Separator, item.PhoneType.Name, item.PhoneNumber);
                }
                return builder.ToString();
            }
        }

        public string SqliteEmails
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (var item in this.Email.Where(x => !x.Deleted))
                    builder.AppendFormat("{0}{1}", Advertiser.Separator, item.Address);
                return builder.ToString();
            }
        }

        public string SqliteCategories
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (var item in this.AdvertiserCategory.Where(x => !x.Deleted))
                    builder.AppendFormat("{0}{1}|{2}", Advertiser.Separator, item.CategoryId, item.Category.Name);
                return builder.ToString();
            }
        }

        #endregion

        public string GetLogo(string path) { return FileHelper.GetFile(path, string.Format("{0}.*", LogoThumbFileNameMask(this.AdvertiserId))); }

        public int ActiveOfficesCount
        {
            get
            {
                OfficeController controller = new OfficeController();
                return controller.FetchAdvertiserOffices(this.AdvertiserId).Count();
            }
        }

        public IQueryable<Office> ActiveOffices
        {
            get
            {
                OfficeController controller = new OfficeController();
                return controller.FetchAdvertiserOffices(this.AdvertiserId);
            }
        }

        public static string PictureFileNameMask(int id) { return string.Format("{0}", id); }

        public static string PictureThumbFileNameMask(int id) { return string.Format("{0}_thumb", id); }

        public IQueryable<Gallery> ActiveGalleries
        {
            get
            {
                GalleryController controller = new GalleryController();
                return controller.FetchAllByAdvertiserId(this.AdvertiserId, this.FranchiseeId);
            }
        }

        public IQueryable<Coupon> ActiveCoupons
        {
            get
            {
                CouponController controller = new CouponController();
                return controller.FetchAdvertiserCoupons(this.AdvertiserId, true);
            }
        }


        public IQueryable<Coupon> ActiveCoupon
        {
            get
            {
                CouponController controller = new CouponController();
                return controller.FetchAdvertiserCoupon(this.AdvertiserId);
            }
        }

        public int ActiveGalleriesCount
        {
            get
            {
                GalleryController controller = new GalleryController();
                return controller.FetchAllByAdvertiserId(this.AdvertiserId, this.FranchiseeId).Count(); ;
            }
        }

        public string MagazineAnounceUrl { get { return string.Empty; } }

        public string HtmlAddress { get { return TextHelper.HtmlCleaner(this.Address); } }

        public Contract CurrentContract
        {
            get
            {
                ContractController controller = new ContractController();
                var contract = controller.FetchCurrentContractFor(this.AdvertiserId);
                return contract;
            }
        }

        public int CouponClubCount
        {
            get
            {
                CouponController controller = new CouponController();
                int coupon = controller.FetchAdvertiserCoupons(this.AdvertiserId,true).Count();
                return coupon;
            }
        }

        public int FetchTotalFor(AccountConceptKeyEnum key)
        {
            AccountDetailController controller = new AccountDetailController();
            var detail = controller.FetchTotalFor(this.AdvertiserId, key);
            return detail;
        }

        public Office Matriz
        {
            get
            {
                OfficeController controller = new OfficeController();
                var office = controller.FetchMatriz(this.AdvertiserId);
                return office;
            }
        }

        public string BankKey(string bankAccount)
        {
            if (string.IsNullOrEmpty(this.DV))
                return string.Empty;

            return string.Format("{0}-{1}-{2}-{3}-{4}",
                bankAccount.Trim(),
                this.Franchisee.BankReference,
                this.Franchisee.DV,
                this.NumberKey,
                this.DV);
        }

        public bool AllowNewOffices
        {
            get
            {
                var accDetail = new AccountDetailController().FetchTotalFor(this.AdvertiserId, Dal.Enum.AccountConceptKeyEnum.Sucursales);
                return this.ActiveOfficesCount < (accDetail + 1);
            }
        }

        public bool AllowNewCouponSet
        {
            get
            {
                var accDetail = new AccountDetailController().FetchTotalFor(this.AdvertiserId, Dal.Enum.AccountConceptKeyEnum.Coupons);
                return this.ActiveCouponSetCount < accDetail;
            }
        }

        public bool AllowNewGalleries
        {
            get
            {
                var accDetail = new AccountDetailController().FetchTotalFor(this.AdvertiserId, Dal.Enum.AccountConceptKeyEnum.Galerias);
                return this.ActiveGalleriesCount < accDetail;
            }
        }

        public int ActiveCouponSetCount
        {
            get
            {
                CouponSetController controller = new CouponSetController();
                return controller.FetchActiveCouponSets(this.AdvertiserId).Count();
            }
        }

        public CouponSet ActiveCouponSet
        {
            get
            {
                CouponSetController controller = new CouponSetController();
                var couponset = controller.fetchActiveCouponSets(this.AdvertiserId);
                return couponset;
            }
        }

        public Contract MinCurrentContract
        {
            get
            {
                ContractController controller = new ContractController();
                return controller.MinCurrentContractFor(this.AdvertiserId);
            }
        }

        public Contract MaxCurrentContract
        {
            get
            {
                ContractController controller = new ContractController();
                return controller.MaxCurrentContractFor(this.AdvertiserId);
            }
        }
    }
}
