using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Admin.Code;
using System.Web.Security;
using bsx.DirLaguna.Dal.Carrier;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class FranchiseeForm : SimpleFormPage<Franchisee>
    {
        public int CurrentFranchiseeId
        {
            get
            {
                if (this.Request.QueryString[QueryKeys.FranchiseeId] != null)
                    return int.Parse(this.Request.QueryString[QueryKeys.FranchiseeId]);
                return -1;
            }
        }

        public int EstadoId
        {
            get
            {
                if (this.EstadoDropDownList.SelectedIndex <= 0)
                    return -1;
                return int.Parse(this.EstadoDropDownList.SelectedValue);
            }
            set
            {
                this.EstadoDropDownList.SelectedIndex = this.EstadoDropDownList.Items.IndexOf(this.EstadoDropDownList.Items.FindByValue(value.ToString()));
            }
        }

        public int MunicipioId
        {
            get
            {
                if (this.MunicipioDropDownList.SelectedIndex <= 0)
                    return -1;
                return int.Parse(this.MunicipioDropDownList.SelectedValue);
            }
            set
            {
                this.MunicipioDropDownList.SelectedIndex = this.MunicipioDropDownList.Items.IndexOf(this.MunicipioDropDownList.Items.FindByValue(value.ToString()));
            }
        }

        public int ShareNivelId
        {
            get
            {
                if (this.ShareLevelDropDownList.SelectedIndex <= 0)
                    return -1;
                return int.Parse(this.ShareLevelDropDownList.SelectedValue);
            }
            set
            {
                this.ShareLevelDropDownList.SelectedIndex = this.ShareLevelDropDownList.Items.IndexOf(this.ShareLevelDropDownList.Items.FindByValue(value.ToString()));
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.RequiredInvoiceCheckBox.CheckedChanged += new EventHandler(RequiredInvoiceCheckBox_CheckedChanged);
            this.EstadoDropDownList.SelectedIndexChanged += new EventHandler(EstadoDropDownList_SelectedIndexChanged);
            if (!IsPostBack)
            {
                //this.IsNewUser = this.FranchiseeId == -1 ? true :false;
                this.BackButton.PostBackUrl = this.SuccessUrl;
                var estados = new EstadoController().FetchAll();
                this.FillComboBox(this.EstadoDropDownList,
                        from x in estados orderby x.Name ascending select x,
                        Estado.ColumnNames.EstadoId,
                        Estado.ColumnNames.Name);

                this.FillComboBox(this.ShareLevelDropDownList,
                        new ShareLevelController().FetchAll(),
                        ShareLevel.ColumnNames.ShareLevelId,
                        "NameComplete");

                if (this.Request.QueryString[QueryKeys.FranchiseeId] != null)
                {
                    this.ConfirmPlaceHolder.Visible = string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.FranchiseeId].ToString());
                    this.NameTextBox.Enabled = string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.FranchiseeId].ToString());
                    this.NameTextBox.Text = string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.FranchiseeId].ToString()) ? string.Empty : this.Request.QueryString[QueryKeys.FranchiseeId].ToString();
                    this.IsNewUser = false;
                }
                else
                {
                    this.ConfirmPlaceHolder.Visible = true;
                    this.NameTextBox.Enabled = true;
                    this.NameTextBox.Text = string.Empty;
                    this.IsNewUser = true;
                    this.FiscalDetailPlaceHolder.Visible = false;
                }

            }
        }

        void EstadoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cities = new MunicipioController().FetchAllByEstadoId(this.EstadoId);
            this.FillComboBox(this.MunicipioDropDownList,
                    from x in cities orderby x.Name ascending select x,
                    Municipio.ColumnNames.MunicipioId,
                    Municipio.ColumnNames.Name);

        }

        public override Franchisee Source
        {
            get { return new FranchiseeController().FetchById(this.CurrentFranchiseeId); }
        }

        public override string SuccessUrl
        {
            get { return this.ResolveUrl(Navigation.FranchiseeDisplay); }
        }

        protected override LinkButton PageSaveButton
        {
            get { return this.SaveButton; }
        }

        void RequiredInvoiceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.FiscalDetailPlaceHolder.Visible = this.RequiredInvoiceCheckBox.Checked;
            if (!this.RequiredInvoiceCheckBox.Checked)
            {
                this.FiscalDetailCtrl1.FiscalDeailId = -1;
                this.FiscalDetailCtrl1.LoadData();
            }
        }

        public override void LoadViewFromModel(Franchisee source)
        {
            this.NameTextBox.Enabled = source.FranchiseeId == 0;

            this.NameTextBox.Text = source.Name;
            this.AddressTextBox.Text = source.Address;
            this.PhoneTextBox.Text = source.Phone;
            this.EmailTextBox.Text = source.Email;
            this.CellTextBox.Text = source.CellPhone;

            this.FiscalDetailPlaceHolder.Visible = source.FiscalDetailId.HasValue;
            this.RequiredInvoiceCheckBox.Checked = source.FiscalDetailId.HasValue;

            this.FiscalDetailCtrl1.FiscalDeailId = source.FiscalDetailId.HasValue ? (int)source.FiscalDetailId : -1;
            this.FiscalDetailCtrl1.LoadData();

            this.EstadoId = source.Municipio.EstadoId;
            var cities = new MunicipioController().FetchAllByEstadoId(this.EstadoId);
            this.FillComboBox(this.MunicipioDropDownList,
                    from x in cities orderby x.Name ascending select x,
                    Municipio.ColumnNames.MunicipioId,
                    Municipio.ColumnNames.Name);

            this.MunicipioId = source.MunicipioId;
            this.ShareNivelId = source.ShareLevelId;

            UserController controller = new UserController();

            aspnet_Membership member = controller.FetchByUser(source.Name);
            if (member != null)
            {
                this.EmailTextBox.Text = member.Email;
                this.Approved = member.IsApproved;
                this.Blocked = member.IsLockedOut;
            }

            //var user = (from x in source.Personals where x.PersonalTypeId == (int)PersonalTypeEnum.UserAdmin select x).FirstOrDefault();
            //var membership = Membership.GetUser(user.UserId);
            //if(member!=null)
            //{
            //    this.PasswordLabel.Text = membership.GetPassword();
            //}            
        }

        public bool IsNewUser
        {
            get
            {
                if (this.ViewState["_isNewUser"] != null)
                    return bool.Parse(this.ViewState["_isNewUser"].ToString());
                return true;
            }
            set { this.ViewState["_isNewUser"] = value; }
        }

        public bool Approved
        {
            get { return this.AprovedCheckBox.Checked; }
            set { this.AprovedCheckBox.Checked = value; }
        }

        public bool Blocked
        {
            get { return this.LockoutCheckBox.Checked; }
            set { this.LockoutCheckBox.Checked = value; }
        }

        public string FranchiseeName
        {
            get
            {
                return this.NameTextBox.Text;
            }
        }

        public string NewPassword
        {
            get { return this.PasswordTextBox.Text; }
        }

        public string Email
        {
            get { return this.EmailTextBox.Text; }
            set { this.EmailTextBox.Text = value; }
        }

        public override bool SaveMethod()
        {
            MembershipUser memUser;
            //if (!this.IsNewUser)
            //{
            //    memUser = Membership.GetUser(this.FranchiseeName);
            //    if (memUser != null)
            //    {
            //        UpdateUserData(memUser);
            //    }


            //    FranchiseeController controllerFran = new FranchiseeController();
            //    int franchiseeId = -1;
            //    if (controllerFran.Save(this.Carrier, this.FiscalDetailCtrl1.Carrier, out franchiseeId))
            //    {
            //        this.ShowMessage("Se ha creado correctamente", CommonWeb.Enum.MessageTypes.Success);
            //    }
            //    else
            //    {
            //        foreach (string item in controllerFran.Errors)
            //        {
            //            this.Errors.Add(item);
            //        }
            //    }
            //}
            //else
            //{
            //    MembershipCreateStatus status = new MembershipCreateStatus();
            //    Membership.CreateUser(this.FranchiseeName, this.NewPassword, this.Email, "Cual es tu color favorito?", "red", this.Approved, out status);


            //    if (status == MembershipCreateStatus.Success)
            //    {
            //        memUser = Membership.GetUser(this.FranchiseeName);
            //        if (memUser != null)
            //        {
            //            UpdateUserData(memUser);

            //            UserController controller = new UserController();
            //            aspnet_Membership membership = controller.FetchByUser(this.FranchiseeName);
            //            if (membership != null)
            //            {
            //                FranchiseeController controllerFran = new FranchiseeController();
            //                int franchiseeId = -1;
            //                if (controllerFran.Save(this.Carrier, this.FiscalDetailCtrl1.Carrier, out franchiseeId))
            //                {
            //                    if (controller.SaveUser(-1, this.FranchiseeName, franchiseeId, membership.UserId.ToString(), PersonalTypeEnum.UserAdmin))
            //                    {
            //                        this.ShowMessage("Se ha creado correctamente", CommonWeb.Enum.MessageTypes.Success);
            //                    }

            //                }
            //                else
            //                {
            //                    foreach (string item in controller.Errors)
            //                    {
            //                        this.Errors.Add(item);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        switch (status)
            //        {
            //            case MembershipCreateStatus.DuplicateEmail:
            //                this.Errors.Add("email duplicado.");
            //                break;
            //            case MembershipCreateStatus.DuplicateProviderUserKey:
            //                this.Errors.Add("Duplicado UserKey");
            //                break;
            //            case MembershipCreateStatus.DuplicateUserName:
            //                this.Errors.Add("Nombre de usuario duplicado");
            //                break;
            //            case MembershipCreateStatus.InvalidAnswer:
            //                this.Errors.Add("Respuesta incorrecta.");
            //                break;
            //            case MembershipCreateStatus.InvalidEmail:
            //                this.Errors.Add("Email NO Válido.");
            //                break;
            //            case MembershipCreateStatus.InvalidPassword:
            //                this.Errors.Add("Contraseña NO Válida.");
            //                break;
            //            case MembershipCreateStatus.InvalidProviderUserKey:
            //                this.Errors.Add("User Key NO Válido.");
            //                break;
            //            case MembershipCreateStatus.InvalidQuestion:
            //                this.Errors.Add("Pregunta NO Válida.");
            //                break;
            //            case MembershipCreateStatus.InvalidUserName:
            //                this.Errors.Add("Nombre de usuario no valido.");
            //                break;
            //            //case MembershipCreateStatus.ProviderError:
            //            //    this.Errors.Add("");
            //            //    break;
            //            //case MembershipCreateStatus.Success:
            //            //    this.Errors.Add("");
            //            //    break;
            //            case MembershipCreateStatus.UserRejected:
            //                this.Errors.Add("Usuario Rechazado.");
            //                break;
            //            default:
            //                break;
            //        }
            //        bResult = false;
            //    }
            //}

            MembershipCreateStatus status = new MembershipCreateStatus();
            bool bCreateUser = false;
            if (!this.IsNewUser)
            {
                memUser = Membership.GetUser(this.FranchiseeName);
                if (memUser == null)
                {
                    this.Errors.Add("No se encontro al usuario");
                    return false;
                }
                UpdateUserData(memUser);
            }
            else
            {
                Guid newUserId;
                PersonalUser personalUser = new PersonalUser();
                if (!personalUser.CreateOnlyUserAdmin(this.FranchiseeName, this.NewPassword, this.Email, this.Approved, PersonalTypeEnum.UserNormal, out newUserId))
                {
                    foreach (string item in personalUser.Errors)
                    {
                        this.Errors.Add(item);
                    }
                    return false;
                }

                bCreateUser = true;
            }

            FranchiseeController controllerFran = new FranchiseeController();
            int franchiseeId = -1;
            if (!controllerFran.Save(this.Carrier, this.FiscalDetailCtrl1.Carrier, out franchiseeId))
            {
                foreach (string item in controllerFran.Errors)
                {
                    this.Errors.Add(item);
                    Logger.Error(item);
                }

                return false;
            }

            if (IsNewUser && bCreateUser)
            {
                UserController controller = new UserController();
                aspnet_Membership membership = controller.FetchByUser(this.FranchiseeName);
                if (membership == null)
                {
                    this.Errors.Add("No se encontro al usuario");
                    Logger.Error("No se encontró al usuario");
                    return false;
                }
                
                int newPersonalId;
                if (!controller.SaveUser(this.FranchiseeName, franchiseeId, membership.UserId.ToString(), PersonalTypeEnum.UserAdmin, out newPersonalId))
                {
                    foreach (string item in controller.Errors)
                    {
                        this.Errors.Add(item);
                        Logger.Error(item);
                    }
                    return false;
                }
            }

            return true;
        }

        public SimpleFranchiseeCarrier Carrier
        {
            get
            {
                SimpleFranchiseeCarrier carrier = new SimpleFranchiseeCarrier();

                carrier.FranchiseeId = this.CurrentFranchiseeId;
                carrier.Name = this.NameTextBox.Text;
                carrier.Email = this.EmailTextBox.Text;
                carrier.Phone = this.PhoneTextBox.Text;
                carrier.Address = this.AddressTextBox.Text;
                carrier.CellPhone = this.CellTextBox.Text;
                carrier.MunicipioId = this.MunicipioId;
                carrier.ShareNivelId = this.ShareNivelId;

                return carrier;
            }
        }

        public override void FillCatalogues()
        {

        }

        public override void SetMaxLenght()
        {
            this.NameTextBox.MaxLength = Franchisee.Columns.NameColumn.MaxLength;
        }

        private void UpdateUserData(MembershipUser memUser)
        {
            memUser.Email = this.Email;
            memUser.IsApproved = this.Approved;
            memUser.Comment = string.Empty;

            try
            {
                Membership.UpdateUser(memUser);
            }
            catch (Exception ex)
            {
                this.Errors.Add("Ha ocurrido un error al actualizar el usuario");
            }
        }
    }
}