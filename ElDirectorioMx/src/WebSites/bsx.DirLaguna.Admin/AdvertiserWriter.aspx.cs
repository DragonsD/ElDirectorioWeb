using System;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Admin
{
    public partial class AdvertiserWriter : WriterBase
    {
        public int ExternalId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["EsternalKey"]))
                    return int.Parse(this.Request["EsternalKey"]);
                return -1;
            }
        }

        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["Name"]))
                    return this.Request["Name"];
                return null;
            }
        }

        public string Description
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["Description"]))
                    return this.Request["Description"];
                return "Pendiente";
            }
        }

        public string Street
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["Address"]))
                    return this.Request["Address"];
                return string.Empty;
            }
        }

        public string Number
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["Number"]))
                    return this.Request["Number"];
                return string.Empty;
            }
        }

        public string Neighborhod
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["Matriz_Colony"]))
                    return this.Request["Matriz_Colony"];
                return string.Empty;
            }
        }

        public string ZipCode
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["Matriz_ZipCode"]))
                    return this.Request["Matriz_ZipCode"];
                return string.Empty;
            }
        }

        public int ExternalFranchiseeId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["Franchisee_ExternalKey"]))
                    return int.Parse(this.Request["Franchisee_ExternalKey"]);
                return -1;
            }
        }

        public int EstadoId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["EstadoId"]))
                    return int.Parse(this.Request["EstadoId"]);
                return -1;
            }
        }

        public int MunicipioId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["MunicipioId"]))
                    return int.Parse(this.Request["MunicipioId"]);
                return -1;
            }
        }

        public string Contact
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["Contact"]))
                    return this.Request["Contact"];
                return null;
            }
        }

        public string NumberKey
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["numberKey"]))
                    return this.Request["numberKey"];
                return null;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.IsPostBack)
            {
                if (this.ExternalId <= 0 || this.ExternalFranchiseeId <= 0)
                {
                    this.ReturnResult(false);
                    return;
                }

                AdvertiserController controller = new AdvertiserController();
                Advertiser adv = new AdvertiserController().FetchByExternalId(this.ExternalId, this.ExternalFranchiseeId);

                int franchiseeId = new FranchiseeController().FetchByExternalId(this.ExternalFranchiseeId).FranchiseeId;
                int personalId = Properties.Settings.Default.DefaultPersonalId;

                if (franchiseeId == 0 || personalId == 0)
                {
                    this.ReturnResult(false);
                    return;
                }

                Personal personal = new PersonalController().FetchById(personalId);

                int newAdvertiserId = 0;
                if (!controller.Save(
                        personal.UserId.Value, 
                        this.ExternalId,
                        adv != null ? adv.AdvertiserId : 0,
                        this.Name,
                        this.NumberKey,
                        this.Street,
                        this.Neighborhod,
                        this.ZipCode,
                        this.Number,
                        franchiseeId,
                        personalId,
                        this.MunicipioId,
                        out newAdvertiserId))
                    this.ReturnResult(false);
                else
                    this.ReturnResult(true);
            }
        }
    }
}