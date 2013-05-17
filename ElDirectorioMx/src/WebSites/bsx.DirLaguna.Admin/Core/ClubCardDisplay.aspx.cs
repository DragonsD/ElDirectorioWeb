using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.Dal.Carrier;
using bsx.DirLaguna.CommonWeb.Session;
using System.IO;
using bsx.DirLaguna.Dal.SelectControllers;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class ClubCardDisplay : SimpleFormPage<ClubCard>
    {

        private DirLagunaModelDataContext db;

        public int CardId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["0"]))
                    return int.Parse(this.Request.QueryString["0"]);
                return -1;
            }
        }

        public override ClubCard Source
        {
            get
            {
                ClubCard cc = new ClubCardController().FetchById(this.CardId);
                return cc;
            }
        }

        public override string SuccessUrl { get { return string.Format("{0}", this.ResolveUrl(Navigation.ClubCardForm)); } }
        
        protected override LinkButton PageSaveButton { get { return this.InsertButton; } }

        public override void LoadViewFromModel(ClubCard source)
        {
 
        }

        public SimpleCardClubCarrier Carrier
        {
            get
            {
                int advertiserid = int.Parse(this.ddlAdvertiser.SelectedValue);
                long folio = long.Parse(this.FolioTextBox.Text);
                SimpleCardClubCarrier carrier = new SimpleCardClubCarrier()
                {
                    AdvertiserId = advertiserid,
                    Folio = folio,
                    FechaExpedicion = FechaExpedicionCalendar.SelectedDate,
                };

                return carrier;
            }
        }

        public override bool SaveMethod()
        {
            ClubCardController controller = new ClubCardController();
            bool result = controller.Save(this.Carrier);

            if (!result)
                this.Errors = controller.Errors;
            
            if (result) 
            {
                FolioTextBox.Text = "";
                ddlAdvertiser.SelectedIndex = 0;
                tbCard.Visible = false;
            }

            return result;
            
        }

        public override void FillCatalogues()
        {

        }

        public override void SetMaxLenght()
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            db = new DirLagunaModelDataContext();
        }

        protected void NewCardButton_Click(object sender, EventArgs e)
        {
            this.tbCard.Visible = true;
        }

        protected void AdvertiserDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            var advertisers = (from adv in db.VwAdvertiser
                               where adv.Featured == true
                               select new { adv.AdvertiserId, adv.Name }).Distinct();
            e.Result = advertisers;
        }
    }
}
