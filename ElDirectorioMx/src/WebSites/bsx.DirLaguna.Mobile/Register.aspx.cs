using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Dal.PublicContent;
using bsx.DirLaguna.Mobile.Code;
using System.Web.Security;
using System.Text;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Base;
using System.Collections;

namespace bsx.DirLaguna.Mobile
{
    public partial class Register : System.Web.UI.Page
    {
        private List<string> Errors = new List<string>();

        public string TextIos
        {
            get
            {
                if (this.Request.QueryString[QueryKeys.ParamAdicional] == null)
                    return string.Empty;

                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.ParamAdicional].ToString()))
                    return this.Request.QueryString[QueryKeys.ParamAdicional].ToString();
                return string.Empty;
            }
        }

        public string UserName
        {
            get
            {
                return this.UserNameTextBox.Text;
            }
        }

        public string OldPassword
        {
            get
            {
                if (this.ViewState["_oldPassword"] != null)
                    return this.ViewState["_oldPassword"].ToString();
                return string.Empty;
            }
            set { this.ViewState["_oldPassword"] = value; }
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

        public string Name
        {
            get { return this.NameTextBox.Text; }
        }

        public int StateId
        {
            get { return int.Parse(this.StatesDropDownList.SelectedItem.Value); }
        }

        public string City
        {
            get { return this.CitiesDropDownList.SelectedItem.Text; }
        }

        public short Age
        {
            get { return short.Parse(this.AgeTextBox.Text); }
        }

        public bool Approved
        {
            get { return true; }
        }

        public bool Lockout
        {
            get { return false; }
        }

        public bool AceptInfoCoupons
        {
            get { return this.AcceptCouponsCheckBox.Checked; }
            set { this.AcceptCouponsCheckBox.Checked = value; }
        }

        public bsx.DirLaguna.Dal.PublicContent.aspnet_Membership Source
        {
            get
            {
                return new UserPublicController().FetchByUserName(this.UserName);
            }
        }

        public string SuccessUrl
        {
            get { return this.ResolveUrl(Navigation.CouponDisplay); }
        }


        public bool SaveMethod()
        {
            MembershipUser memUser;
            memUser = Membership.GetUser(this.UserName);
            if (memUser != null)
            {
                this.Errors.Add("El usuario ya Existe");
                return false;
            }

            PersonalUser personal = new PersonalUser();
            Guid newUserId;
            if (!personal.CreateUserGuest(this.UserName, this.NewPassword, this.Email, this.Approved, this.AceptInfoCoupons, Name, City, Age, out newUserId))
            {
                foreach (string item in personal.Errors)
                {
                    this.Errors.Add(item);
                }
                return false;
            }

            return true;
        }

        private void UpdateUserData(MembershipUser memUser)
        {
            memUser.Email = this.Email;
            memUser.IsApproved = this.Approved;

            try
            {
                Membership.UpdateUser(memUser);
            }
            catch (Exception ex)
            {
                this.Errors.Add("Ha ocurrido un error al actualizar el usuario");
            }
        }

        public void FillCatalogues()
        {
            this.FillComboBox(this.StatesDropDownList,
                    new EstadoController().FetchAll(),
                    Estado.ColumnNames.EstadoId,
                    Estado.ColumnNames.Name);

        }

        public void SetMaxLenght()
        {
            this.UserNameTextBox.MaxLength = bsx.DirLaguna.Dal.PublicContent.aspnet_Users.Columns.UserNameColumn.MaxLength;
            this.PasswordTextBox.MaxLength = bsx.DirLaguna.Dal.PublicContent.aspnet_Membership.Columns.PasswordColumn.MaxLength;
            this.EmailTextBox.MaxLength = bsx.DirLaguna.Dal.PublicContent.aspnet_Membership.Columns.EmailColumn.MaxLength;
            this.NameTextBox.MaxLength = bsx.DirLaguna.Dal.PublicContent.Guest.Columns.NameColumn.MaxLength;
            this.AgeTextBox.MaxLength = bsx.DirLaguna.Dal.PublicContent.Guest.Columns.AgeColumn.MaxLength;
        }


        void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.SaveMethod())
            {
                if (string.IsNullOrEmpty(TextIos))
                {
                    FormsAuthentication.Authenticate(this.UserName, this.NewPassword);
                    this.Response.Redirect(this.ResolveUrl(Navigation.CouponDisplay));
                }
                else
                {
                    if (TextIos == "1")
                        this.Response.Redirect(this.ResolveUrl(string.Format("{0}?username={1}&{2}=1", Navigation.RegisterIos, this.UserName, QueryKeys.ParamAdicional)));
                    else
                        this.Response.Redirect(this.ResolveUrl(Navigation.CouponDisplay));
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (string item in this.Errors)
            {
                sb.Append(item);
            }
            this.Msg.Text = sb.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SaveButton.Click += new EventHandler(SaveButton_Click);
            this.StatesDropDownList.SelectedIndexChanged += new EventHandler(StatesDropDownList_SelectedIndexChanged);
            if (!IsPostBack)
            {
                this.FillCatalogues();
                var cities = new MunicipioController().FetchAllByEstadoId(-1);
                this.FillComboBox(this.CitiesDropDownList,
                        from x in cities orderby x.Name ascending select x,
                        Municipio.ColumnNames.MunicipioId,
                        Municipio.ColumnNames.Name);
                this.ConfirmPlaceHolder.Visible = true;
                this.UserNameTextBox.Enabled = true;
                this.UserNameTextBox.Text = string.Empty;
                //this.BackButton.PostBackUrl = this.ResolveUrl(Navigation.Default);
            }
        }

        private void StatesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cities = new MunicipioController().FetchAllByEstadoId(this.StateId);
            this.FillComboBox(this.CitiesDropDownList,
                    from x in cities orderby x.Name ascending select x,
                    Municipio.ColumnNames.MunicipioId,
                    Municipio.ColumnNames.Name);
        }

        protected void FillComboBox(DropDownList dropdown, IEnumerable collection, string dataValueField, string dataTextField)
        {
            dropdown.DataSource = collection;
            dropdown.DataValueField = dataValueField;
            dropdown.DataTextField = dataTextField;
            dropdown.DataBind();

            dropdown.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", string.Empty));
        }

    }
}