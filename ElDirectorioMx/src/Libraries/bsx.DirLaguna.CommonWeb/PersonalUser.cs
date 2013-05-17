using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using bsx.DirLaguna.Dal;
using System.Configuration;
using bsx.DirLaguna.Dal.PublicContent;

namespace bsx.DirLaguna.CommonWeb
{
    public class PersonalUser
    {
        public List<string> Errors;

        public PersonalUser()
        {
            this.Errors = new List<string>();
        }

        public bool CreateUserAdminAndPersonal(string userName, string newPassword, string email, int franchiseeId, bool approved, PersonalTypeEnum personalType, out int newPersonalId, out Guid userId)
        {
            MembershipUser memUser;
            userId = Guid.NewGuid();
            newPersonalId = -1;

            MembershipCreateStatus status = new MembershipCreateStatus();
            memUser = Membership.Providers[MembershipProviders.MembershipAdmin].GetUser(userName, false);
            if (memUser != null)
            {
                this.Errors.Add("El usuario ya Existe");
                return false;
            }


            MembershipUser user = Membership.Providers[MembershipProviders.MembershipAdmin].CreateUser(userName, newPassword, email, "Cual es tu color favorito?", "red", approved, null, out status);

            if (status != MembershipCreateStatus.Success)
            {
                this.Errors.Add("Error en el status de Membership");

                switch (status)
                {
                    case MembershipCreateStatus.DuplicateEmail:
                        this.Errors.Add("email duplicado.");
                        break;
                    case MembershipCreateStatus.DuplicateProviderUserKey:
                        this.Errors.Add("Duplicado UserKey");
                        break;
                    case MembershipCreateStatus.DuplicateUserName:
                        this.Errors.Add("Nombre de usuario duplicado");
                        break;
                    case MembershipCreateStatus.InvalidAnswer:
                        this.Errors.Add("Respuesta incorrecta.");
                        break;
                    case MembershipCreateStatus.InvalidEmail:
                        this.Errors.Add("Email NO Válido.");
                        break;
                    case MembershipCreateStatus.InvalidPassword:
                        this.Errors.Add("Contraseña NO Válida.");
                        break;
                    case MembershipCreateStatus.InvalidProviderUserKey:
                        this.Errors.Add("User Key NO Válido.");
                        break;
                    case MembershipCreateStatus.InvalidQuestion:
                        this.Errors.Add("Pregunta NO Válida.");
                        break;
                    case MembershipCreateStatus.InvalidUserName:
                        this.Errors.Add("Nombre de usuario no valido.");
                        break;
                    //case MembershipCreateStatus.ProviderError:
                    //    this.Errors.Add("");
                    //    break;
                    //case MembershipCreateStatus.Success:
                    //    this.Errors.Add("");
                    //    break;
                    case MembershipCreateStatus.UserRejected:
                        this.Errors.Add("Usuario Rechazado.");
                        break;
                    default: this.Errors.Add(string.Format("Estatus {0}", status));
                        break;
                }

                return false;
            }

            //memUser = Membership.Providers[MembershipProviders.MembershipAdmin].GetUser(userName, false);
            int personalIdTemp = -1;
            //if (memUser == null)
            //{
            //    this.Errors.Add("No se encontro el usuario");
            //    return false;
            //}

            UserController controller = new UserController();
            bsx.DirLaguna.Dal.aspnet_Membership membership = controller.FetchByUser(userName);
            if (membership == null)
            {
                this.Errors.Add("No se encontro el usuario.");
                return false;
            }

            this.Errors.Add("Antes de SaveUser");
            if (!controller.SaveUser(userName, franchiseeId, membership.UserId.ToString(), personalType, out personalIdTemp))
            {
                this.Errors.AddRange(controller.Errors);
                this.Errors.Add("Se agregaron errores de SaveUser");
                return false;
            }

            userId = membership.UserId;
            newPersonalId = personalIdTemp;

            return true;
        }

        public bool CreateUserGuest(string userName, string newPassword, string email, bool approved, bool aceptInfoCoupons, string name, string cityName, short age, out Guid userId)
        {
            MembershipUser memUser;
            userId = Guid.NewGuid();

            MembershipCreateStatus status = new MembershipCreateStatus();
            memUser = Membership.Providers[MembershipProviders.MembershipPublic].GetUser(userName, false);
            if (memUser != null)
            {
                this.Errors.Add("El usuario ya Existe");
                return false;
            }

            MembershipUser user = Membership.Providers[MembershipProviders.MembershipPublic].CreateUser(userName, newPassword, email, "Cual es tu color favorito?", "red", approved, null, out status);

            if (status != MembershipCreateStatus.Success)
            {
                switch (status)
                {
                    case MembershipCreateStatus.DuplicateEmail:
                        this.Errors.Add("email duplicado.");
                        break;
                    case MembershipCreateStatus.DuplicateProviderUserKey:
                        this.Errors.Add("Duplicado UserKey");
                        break;
                    case MembershipCreateStatus.DuplicateUserName:
                        this.Errors.Add("Nombre de usuario duplicado");
                        break;
                    case MembershipCreateStatus.InvalidAnswer:
                        this.Errors.Add("Respuesta incorrecta.");
                        break;
                    case MembershipCreateStatus.InvalidEmail:
                        this.Errors.Add("Email NO Válido.");
                        break;
                    case MembershipCreateStatus.InvalidPassword:
                        this.Errors.Add("Contraseña NO Válida.");
                        break;
                    case MembershipCreateStatus.InvalidProviderUserKey:
                        this.Errors.Add("User Key NO Válido.");
                        break;
                    case MembershipCreateStatus.InvalidQuestion:
                        this.Errors.Add("Pregunta NO Válida.");
                        break;
                    case MembershipCreateStatus.InvalidUserName:
                        this.Errors.Add("Nombre de usuario no valido.");
                        break;
                    //case MembershipCreateStatus.ProviderError:
                    //    this.Errors.Add("");
                    //    break;
                    //case MembershipCreateStatus.Success:
                    //    this.Errors.Add("");
                    //    break;
                    case MembershipCreateStatus.UserRejected:
                        this.Errors.Add("Usuario Rechazado.");
                        break;
                    default: this.Errors.Add(string.Format("Estatus {0}", status));
                        break;
                }

                return false;
            }

            memUser = Membership.Providers[MembershipProviders.MembershipPublic].GetUser(userName, false);
            UserPublicController controller = new UserPublicController();
            bsx.DirLaguna.Dal.PublicContent.aspnet_Membership membership = controller.FetchByUserName(userName);

            if (memUser == null)
            {
                this.Errors.Add("No se encontro el usuario recien creado.");
                return false;
            }

            if (!controller.SaveGuest(membership.UserId, aceptInfoCoupons, name, cityName, age))
            {
                foreach (var item in controller.Errors)
                {
                    this.Errors.Add(item);
                }
                return false;
            }

            return true;
        }

        public bool CreateOnlyUserAdmin(string userName, string newPassword, string email, bool approved, PersonalTypeEnum personalType, out Guid userId)
        {
            MembershipUser memUser;
            userId = Guid.NewGuid();

            MembershipCreateStatus status = new MembershipCreateStatus();
            memUser = Membership.Providers[MembershipProviders.MembershipAdmin].GetUser(userName, false);
            if (memUser != null)
            {
                this.Errors.Add("El usuario ya Existe");
                return false;
            }

            MembershipUser user = Membership.Providers[MembershipProviders.MembershipAdmin].CreateUser(userName, newPassword, email, "Cual es tu color favorito?", "red", approved, null, out status);

            if (status != MembershipCreateStatus.Success)
            {
                switch (status)
                {
                    case MembershipCreateStatus.DuplicateEmail:
                        this.Errors.Add("Email duplicado.");
                        break;
                    case MembershipCreateStatus.DuplicateProviderUserKey:
                        this.Errors.Add("Duplicado UserKey");
                        break;
                    case MembershipCreateStatus.DuplicateUserName:
                        this.Errors.Add("Nombre de usuario duplicado");
                        break;
                    case MembershipCreateStatus.InvalidAnswer:
                        this.Errors.Add("Respuesta incorrecta.");
                        break;
                    case MembershipCreateStatus.InvalidEmail:
                        this.Errors.Add("Email NO Válido.");
                        break;
                    case MembershipCreateStatus.InvalidPassword:
                        this.Errors.Add("Contraseña NO Válida.");
                        break;
                    case MembershipCreateStatus.InvalidProviderUserKey:
                        this.Errors.Add("User Key NO Válido.");
                        break;
                    case MembershipCreateStatus.InvalidQuestion:
                        this.Errors.Add("Pregunta NO Válida.");
                        break;
                    case MembershipCreateStatus.InvalidUserName:
                        this.Errors.Add("Nombre de usuario no valido.");
                        break;
                    //case MembershipCreateStatus.ProviderError:
                    //    this.Errors.Add("");
                    //    break;
                    //case MembershipCreateStatus.Success:
                    //    this.Errors.Add("");
                    //    break;
                    case MembershipCreateStatus.UserRejected:
                        this.Errors.Add("Usuario Rechazado.");
                        break;
                    default: this.Errors.Add(string.Format("Estatus {0}", status));
                        break;
                }

                return false;
            }

            memUser = Membership.Providers[MembershipProviders.MembershipAdmin].GetUser(userName, false);
            if (memUser == null)
            {
                this.Errors.Add("El usuario No se Encontro.");
                return false;
            }

            UserController controller = new UserController();
            bsx.DirLaguna.Dal.aspnet_Membership membership = controller.FetchByUser(userName);
            if (membership == null)
            {
                this.Errors.Add("No se encontro el usuario.");
                return false;
            }

            userId = membership.UserId;

            return true;
        }

        public PersonalTypeEnum GetUserType(int userTypeId)
        {
            PersonalTypeEnum type = PersonalTypeEnum.UserNormal;
            switch (userTypeId)
            {
                case 1: type = PersonalTypeEnum.UserSuperAdmin;
                    break;
                case 2: type = PersonalTypeEnum.UserAdmin;
                    break;
                case 3: type = PersonalTypeEnum.UserNormal;
                    break;
                case 4: type = PersonalTypeEnum.UserIndependent;
                    break;
                default: type = PersonalTypeEnum.UserNormal;
                    break;
            }

            return type;
        }

    }
}
