using System;
using System.Web.Security;
using bsx.DirLaguna.Admin.Code;

namespace bsx.DirLaguna.Admin
{
    public partial class fupd : WriterBase
    {
        public string UserName
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["UserName"]))
                    return this.Request["UserName"];
                return null;
            }
        }

        public string Password
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["Password"]))
                    return this.Request["Password"];
                return null;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.IsPostBack)
                this.ReturnResult(this.SaveMethod());
        }

        private void UpdateUserData(MembershipUser memUser)
        {
            memUser.IsApproved = true;
            memUser.Comment = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(this.Password))
                    memUser.ChangePassword(memUser.ResetPassword(), this.Password);
                Membership.UpdateUser(memUser);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            Logger.Error("El password de {0} se ha cambiado exiosamente", this.UserName);
        }

        public bool SaveMethod()
        {
            if (string.IsNullOrEmpty(this.UserName) || string.IsNullOrEmpty(this.Password))
            {
                Logger.Info("No llegaron todos los datos necesarios para cambiar el password de una cuenta");
                return false;
            }

            Logger.Info("Guardando un franquiciatario");
            MembershipUser memUser;

            Logger.Info("El ususario no es nuevo");
            memUser = Membership.GetUser(this.UserName);
            if (memUser == null)
            {
                Logger.Error("No se encontro al usuario");
                return false;
            }
            UpdateUserData(memUser);

            return true;
        }
    }
}