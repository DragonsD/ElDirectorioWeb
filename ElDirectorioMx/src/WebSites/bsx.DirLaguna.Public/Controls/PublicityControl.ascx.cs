using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Public.Code;
using bsx.DirLaguna.Dal.SelectControllers;

namespace bsx.DirLaguna.Public.Controls
{
    public partial class PublicityControl : System.Web.UI.UserControl
    {
        private const int PageSize = 5;

        public int StartIndex
        {
            get
            {
                if (this.ViewState["startIndex"] != null)
                    return (int)this.ViewState["startIndex"];
                return 0;
            }
            set { this.ViewState["startIndex"] = value; }
        }

        public int AdvertiserId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.AdvertiserId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.AdvertiserId]);
                return -1;
            }
        }

        public int CityId
        {
            get
            {
                if (this.ViewState["cityId"] != null)
                    return (int)this.ViewState["cityId"];
                return -1;
            }
            set { this.ViewState["cityId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.PublicityDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(PublicityDataSource_Selecting);


            if (!this.IsPostBack)
            {
                this.StartIndex = 0;
                this.SetupPager();
                this.PublicityDataList.DataBind();
            }
        }

        public string PublicityPictureUrl(int publicityId)
        {
            return PublicityHelper.PublicityPictureUrl(publicityId);
        }

        protected void PublicityDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["cityid"] = this.CityId;
        }

        private void SetupPager()
        {
            int totalCount = new PublicityController().FetchByCityId(this.CityId).Count();

            PageCounter counter = new PageCounter(totalCount, PageSize);
        }

        public void RefreshData()
        {
            this.SetupPager();
            this.PublicityDataList.DataBind();
        }


    }
}