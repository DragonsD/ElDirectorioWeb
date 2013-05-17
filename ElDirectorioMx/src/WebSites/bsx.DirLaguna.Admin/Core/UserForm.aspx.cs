using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal.SelectControllers;
using System.Web.Security;
using bsx.DirLaguna.Dal.Enum;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class UserForm : SimpleFormPage<aspnet_Membership>
    {
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

        public bool Lockout
        {
            get { return this.LockoutCheckBox.Checked; }
            set { this.LockoutCheckBox.Checked = value; }
        }

        public string Comment
        {
            get { return this.CommentTextBox.Text; }
            set { this.CommentTextBox.Text = value; }
        }

        public override aspnet_Membership Source
        {
            get
            {
                return new UserController().FetchByUser(this.UserName);
            }
        }

        public override string SuccessUrl
        {
            get { return this.ResolveUrl(Navigation.UserDisplay); }
        }

        protected override LinkButton PageSaveButton
        {
            get { return this.SaveButton; }
        }

        public override void LoadViewFromModel(aspnet_Membership source)
        {
            this.OldPassword = source.Password;
            this.Email = source.Email;
            this.Approved = source.IsApproved;
            this.Lockout = source.IsLockedOut;
            this.Comment = source.Comment;

            if (source.aspnet_User != null)
                this.Title = string.Format("Editando a {0}", source.aspnet_User.UserName);
        }

        public override bool SaveMethod()
        {
            bool bResult = true;
            
            MembershipUser memUser;
            if (!this.IsNewUser)
            {
                memUser = Membership.GetUser(this.UserName);
                if (memUser == null)
                    bResult = false;
                else
                    UpdateUserData(memUser);
            }
            else
            {
                Guid newUserId;
                int newPersonalId;
                PersonalUser personalUser = new PersonalUser();
                if (!personalUser.CreateUserAdminAndPersonal(this.UserName, this.NewPassword, this.Email, this.FranchiseeId, this.Approved, PersonalTypeEnum.UserNormal, out newPersonalId, out newUserId))
                {
                    foreach (string item in personalUser.Errors)
                    {
                        this.Errors.Add(item);
                    }
                    bResult = false;
                }
            }

            return bResult;
        }

        private void UpdateUserData(MembershipUser memUser)
        {
            memUser.Email = this.Email;
            memUser.IsApproved = this.Approved;
            memUser.Comment = this.Comment;

            try
            {
                Membership.UpdateUser(memUser);
            }
            catch (Exception ex)
            {
                this.Errors.Add("Ha ocurrido un error al actualizar el usuario");
            }
        }

        public override void FillCatalogues()
        {
        }

        public override void SetMaxLenght()
        {
            this.UserNameTextBox.MaxLength = aspnet_Users.Columns.UserNameColumn.MaxLength;
            this.PasswordTextBox.MaxLength = aspnet_Membership.Columns.PasswordColumn.MaxLength;
            this.EmailTextBox.MaxLength = aspnet_Membership.Columns.EmailColumn.MaxLength;
            this.CommentTextBox.MaxLength = aspnet_Membership.Columns.CommentColumn.MaxLength;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack)
            {
                if (this.Request.QueryString[QueryKeys.UserName] != null)
                {
                    this.ConfirmPlaceHolder.Visible = string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.UserName].ToString());
                    this.UserNameTextBox.Enabled = string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.UserName].ToString());
                    this.UserNameTextBox.Text = string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.UserName].ToString()) ? string.Empty : this.Request.QueryString[QueryKeys.UserName].ToString();
                    this.IsNewUser = false;
                }
                else
                {
                    this.ConfirmPlaceHolder.Visible = true;
                    this.UserNameTextBox.Enabled = true;
                    this.UserNameTextBox.Text = string.Empty;
                    this.IsNewUser = true;
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!this.IsPostBack)
                this.BackButton.PostBackUrl = this.ResolveUrl(Navigation.UserDisplay);
        }

    }
}