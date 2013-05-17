using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Dal.Carrier;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Admin.Controls
{
    public partial class CategoriesAdvertiserControl : System.Web.UI.UserControl
    {
        //public int AdvertiserId
        //{
        //    get
        //    {
        //        if(this.ViewState["_advertiserId"] == null)
        //            return -1;

        //        return int.Parse(this.ViewState["_advertiserId"].ToString());
        //    }
        //    set { this.ViewState["_advertiserId"] = value; }
        //}

        public int CouponId
        {
            get
            {
                if(this.ViewState["_couponId"] == null)
                    return -1;

                return int.Parse(this.ViewState["_couponId"].ToString());
            }
            set { this.ViewState["_couponId"] = value; }
        }

        public List<SimpleCouponCategoryCarrier> CouponCategories
        {
            get
            {
                if (this.ViewState["CategoryList"] != null)
                {
                    List<SimpleCouponCategoryCarrier> temp = ((List<SimpleCouponCategoryCarrier>)this.ViewState["CategoryList"]);
                    foreach (ListItem item in this.CategoriesCheckBoxList.Items)
                    {
                        foreach (SimpleCouponCategoryCarrier tax in temp)
                        {
                            if (tax.CouponCategoryId.ToString() == item.Value)
                                tax.SelectedCurrent = item.Selected;
                        }
                    }
                    return temp;
                }
                return null;
            }
            set { this.ViewState["CategoryList"] = value; }
        }

        private List<int> DeletedElements
        {
            get
            {
                if (this.ViewState["DelElements"] != null)
                    return (List<int>)this.ViewState["DelElements"];
                return null;
            }
            set { this.ViewState["DelElements"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.DeletedElements = new List<int>();
                this.CouponCategories = new List<SimpleCouponCategoryCarrier>();

                Coupon coupon = new CouponController().FetchById(this.CouponId);
                if(coupon != null)
                    this.LoadCategories(coupon.CouponCategory.Where(x=> !x.Deleted).ToList());
            }
        }

        private void LoadCategories(List<CouponCategory> categories)
        {
            Coupon coupon = new CouponController().FetchById(this.CouponId);

            var list = coupon.Advertiser.AdvertiserCategory;
            List<SimpleCouponCategoryCarrier> listCategory = new List<SimpleCouponCategoryCarrier>();

            foreach (AdvertiserCategory item in list)
            {
                listCategory.Add(new SimpleCouponCategoryCarrier()
                {
                    CouponId = this.CouponId,
                    CategoryId = item.CategoryId,
                    Name = item.Category.Name,
                    Id = Guid.NewGuid().ToString(),
                    Deleted = false,
                    SelectedRead = false,
                    SelectedCurrent = false
                });
            }

            foreach (CouponCategory cat in categories)
            {
                for (int i = 0; i <= listCategory.Count - 1; i++)
                {
                    if (cat.CategoryId == listCategory[i].CategoryId)
                    {
                        listCategory[i].SelectedRead = true;
                        listCategory[i].SelectedCurrent = true;
                        listCategory[i].CouponCategoryId= cat.CouponCategoryId;
                    }
                }
            }
            this.CategoriesCheckBoxList.DataSource = listCategory;
            this.CategoriesCheckBoxList.DataBind();
            foreach (ListItem item in this.CategoriesCheckBoxList.Items)
            {
                foreach (SimpleCouponCategoryCarrier cat in listCategory)
                {
                    if (cat.SelectedCurrent)
                    {
                        if (item.Value == cat.CategoryId.ToString())
                            item.Selected = cat.SelectedCurrent;
                    }
                }
            }

            this.CouponCategories = listCategory;
        }

    }
}