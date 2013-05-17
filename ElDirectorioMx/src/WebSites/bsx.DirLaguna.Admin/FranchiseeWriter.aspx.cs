using System;
using System.Web.Security;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Dal.Carrier;

namespace bsx.DirLaguna.Admin
{
    public partial class FranchiseeWriter : WriterBase
    {
        public int? ExternalKey
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["ExternalKey"]))
                    return int.Parse(this.Request["ExternalKey"]);
                return null;
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

        public int LegalMunicipioId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["FiscalDetail_MunicipioId"]))
                    return int.Parse(this.Request["FiscalDetail_MunicipioId"]);
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

        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["Name"]))
                    return this.Request["Name"];
                return null;
            }
        }

        public string Email
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["Email"]))
                    return this.Request["Email"];
                return null;
            }
        }

        public string Phone
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["Phone"]))
                    return this.Request["Phone"];
                return null;
            }
        }

        public int ShareLevelId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["ShareLevelId"]))
                    return int.Parse(this.Request["ShareLevelId"]);
                return -1;
            }
        }

        public string Address
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["Address"]))
                    return this.Request["Address"];
                return string.Empty;
            }
        }

        public string CellPhone
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["CellPhone"]))
                    return this.Request["CellPhone"];
                return string.Empty;
            }
        }

        public string Rfc
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["FiscalDetail_Rfc"]))
                    return this.Request["FiscalDetail_Rfc"];
                return string.Empty;
            }
        }

        public string LegalName
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["FiscalDetail_Name"]))
                    return this.Request["FiscalDetail_Name"];
                return string.Empty;
            }
        }

        public string BankReference
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["Reference"]))
                    return this.Request["Reference"];
                return string.Empty;
            }
        }

        public string Street
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["Calle"]))
                    return this.Request["Calle"];
                return string.Empty;
            }
        }

        public string IntNumber
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["FiscalDetail_IntNumber"]))
                    return this.Request["FiscalDetail_IntNumber"];
                return null;
            }
        }

        public string ExtNumber
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["FiscalDetail_ExtNumber"]))
                    return this.Request["FiscalDetail_ExtNumber"];
                return null;
            }
        }

        public string Colony
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["FiscalDetail_Colony"]))
                    return this.Request["FiscalDetail_Colony"];
                return null;
            }
        }

        public string Poblacion
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["FiscalDetail_Poblacion"]))
                    return this.Request["FiscalDetail_Poblacion"];
                return null;
            }
        }

        public string ZipCode
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["FiscalDetail_ZipCode"]))
                    return this.Request["FiscalDetail_ZipCode"];
                return null;
            }
        }

        public string ContactEmail
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["FiscalDetail_ContactEmail"]))
                    return this.Request["FiscalDetail_ContactEmail"];
                return null;
            }
        }

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

        public string DV
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request["DV"]))
                    return this.Request["DV"];
                return null;
            }
        }

        //public int ExternalId
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(this.Request["UniqId"]))
        //            return int.Parse(this.Request["UniqId"]);
        //        return -1;
        //    }
        //}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.IsPostBack)
                this.ReturnResult(this.SaveMethod());
        }

        private SimpleFranchiseeCarrier FillFranchiseeCarrier()
        {
            SimpleFranchiseeCarrier carrier = new SimpleFranchiseeCarrier()
            {
                ExternalKey = this.ExternalKey,
                Address = this.Address,
                CellPhone = this.CellPhone,
                Email = this.Email,
                MunicipioId = this.MunicipioId,
                Name = this.Name,
                Phone = this.Phone,
                ShareNivelId = this.ShareLevelId,
                BankReference = this.BankReference,
                DV = this.DV
            };

            return carrier;
        }

        private SimpleFiscalDetailCarrier FillFiscalCarrier()
        {
            Municipio mp = new MunicipioController().FetchById(this.LegalMunicipioId);

            if (mp == null)
                return new SimpleFiscalDetailCarrier();

            SimpleFiscalDetailCarrier carrier = new SimpleFiscalDetailCarrier()
            {
                Colony = this.Colony,
                ContactEmail = this.ContactEmail,
                EstadoId = mp.EstadoId,
                MunicipioId = this.LegalMunicipioId,
                ExteriorNumber = this.ExtNumber,
                InteriorNumber = this.IntNumber,
                ZipCode = this.ZipCode,
                Street = this.Street,
                RFC = this.Rfc,
                FiscalName = this.LegalName,
                Poblacion = this.Poblacion,
                FiscalDetailId = 0
            };

            return carrier;
        }

        private void UpdateUserData(MembershipUser memUser)
        {
            memUser.Email = this.Email;
            memUser.IsApproved = true;
            memUser.Comment = string.Empty;
            if (!string.IsNullOrEmpty(this.Password))
                memUser.ChangePassword(memUser.GetPassword(), this.Password);

            try
            {
                Membership.UpdateUser(memUser);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private bool IsNewUser
        {
            get
            {
                if (!this.ExternalKey.HasValue)
                    return true;

                var franchisee = new FranchiseeController().FetchByExternalId(this.ExternalKey.Value);
                return franchisee == null;
            }
        }

        public bool SaveMethod()
        {
            Logger.Info("Guardando un franquiciatario");
            MembershipUser memUser;

            MembershipCreateStatus status = new MembershipCreateStatus();
            bool bCreateUser = false;
            bool isNewUser = this.IsNewUser;
            if (!isNewUser)
            {
                Logger.Info("El ususario no es nuevo");
                memUser = Membership.GetUser(this.UserName);
                if (memUser == null)
                {
                    Logger.Error("No se encontro al usuario");
                    return false;
                }
                UpdateUserData(memUser);
            }
            else
            {
                Logger.Info("El franquiciatario es nuevo. Intentando crear su usuario");
                Membership.CreateUser(this.UserName, this.Password, this.Email, "Cual es tu color favorito?", "red", true, out status);
                bCreateUser = true;

                if (status != MembershipCreateStatus.Success)
                {
                    switch (status)
                    {
                        case MembershipCreateStatus.DuplicateEmail:
                            Logger.Error("email duplicado.");
                            break;
                        case MembershipCreateStatus.DuplicateProviderUserKey:
                            Logger.Error("Duplicado UserKey");
                            break;
                        case MembershipCreateStatus.DuplicateUserName:
                            Logger.Error("Nombre de usuario duplicado");
                            break;
                        case MembershipCreateStatus.InvalidAnswer:
                            Logger.Error("Respuesta incorrecta.");
                            break;
                        case MembershipCreateStatus.InvalidEmail:
                            Logger.Error("Email NO Válido.");
                            break;
                        case MembershipCreateStatus.InvalidPassword:
                            Logger.Error("Contraseña NO Válida.");
                            break;
                        case MembershipCreateStatus.InvalidProviderUserKey:
                            Logger.Error("User Key NO Válido.");
                            break;
                        case MembershipCreateStatus.InvalidQuestion:
                            Logger.Error("Pregunta NO Válida.");
                            break;
                        case MembershipCreateStatus.InvalidUserName:
                            Logger.Error("Nombre de usuario no valido.");
                            break;
                        //case MembershipCreateStatus.ProviderError:
                        //    Logger.Error("");
                        //    break;
                        //case MembershipCreateStatus.Success:
                        //    Logger.Error("");
                        //    break;
                        case MembershipCreateStatus.UserRejected:
                            Logger.Error("Usuario Rechazado.");
                            break;
                        default:
                            break;
                    }

                    return false;
                }
            }
            Logger.Info("Usuario creado, guardando su información de franquiciatario.");

            FranchiseeController controllerFran = new FranchiseeController();
            var franchisee = controllerFran.FetchByExternalId(this.ExternalKey.Value);
            int franchiseeId = this.ExternalKey.HasValue && franchisee != null ? franchisee.FranchiseeId : 0;

            Logger.Info("Identificador del franquiciatario: {0}", franchiseeId);

            if (!controllerFran.Save(this.FillFranchiseeCarrier(), this.FillFiscalCarrier(), out franchiseeId))
            {
                foreach (string item in controllerFran.Errors)
                    Logger.Error(item);

                return false;
            }
            Logger.Info("El metodo para guardar al franquiciatario ha sido exitoso");

            if (isNewUser && bCreateUser)
            {
                UserController controller = new UserController();
                aspnet_Membership membership = controller.FetchByUser(this.UserName);
                if (membership == null)
                {
                    Logger.Error("No se encontró al usuario");
                    return false;
                }
                int newPersonalId;
                if (!controller.SaveUser(this.UserName, franchiseeId, membership.UserId.ToString(), PersonalTypeEnum.UserAdmin, out newPersonalId))
                {
                    foreach (string item in controller.Errors)
                        Logger.Error(item);
                    return false;
                }
            }

            return true;
        }

    }
}