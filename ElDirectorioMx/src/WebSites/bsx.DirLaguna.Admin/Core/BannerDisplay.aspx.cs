using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class BannerDisplay : SimpleDisplayPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public override ObjectDataSource MainDataSource
        {
            get { return this.XDataSource; }
        }

        public override GridView MainGridView
        {
            get { return this.XGridView; }
        }

        public override LinkButton MainNewButton
        {
            get { return this.NewAdvertiserButton; }
        }

        public override LinkButton MainSearchButton
        {
            get { return null; }
        }

        public override LinkButton MainCleanButton
        {
            get { return null; }
        }

        public override string ElementFormUrl
        {
            get { return Navigation.BannerForm; } //return string.Format(id > 0 ? "{0}?{1}={2}" : "{0}", this.ResolveUrl(Navigation.AdvertiserForm), QueryKeys.AdvertiserId, id); } } //return string.Format(id > 0 ? "{0}?{1}={2}" : "{0}", this.ResolveUrl(Navigation.AdvertiserForm), QueryKeys.AdvertiserId, id); }
        }

        public override void MainGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ("delBanner".Equals(e.CommandName))
            {
                int id = int.Parse(e.CommandArgument.ToString());
                BannerController con = new BannerController();
                con.Delete(id);
                this.MainGridView.DataBind();
            }
        }

        public override void MainDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            
        }

        public override void CleanFilterControls()
        {
            
        }

        public override void MainGridView_DataBound(object sender, EventArgs e)
        {            
        }
    }
}