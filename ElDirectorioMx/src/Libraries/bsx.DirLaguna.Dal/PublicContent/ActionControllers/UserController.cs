using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bsx.DirLaguna.Dal.SelectControllers;
using System.Web;

namespace bsx.DirLaguna.Dal.PublicContent
{
    public partial class UserPublicController
    {

        public bool SaveGuest(Guid userId, bool sendPublicity, string name, string cityName, short bornYear)
        {
            bool bResult = true;

            Guest guest = this.FetchGuestByUserId(userId);

            if(guest== null)
            {
                guest = new Guest();
                guest.UserId = userId;
                guest.Deleted= false;
                this.db.Guest.InsertOnSubmit(guest);
            }

            guest.SendPublicity = sendPublicity;
            guest.Name = name;
            guest.City = cityName;
            guest.BornYear = bornYear;

            try
            {
                this.db.SubmitChanges();
            }
            catch (Exception ex)
            {
                this.Errors.Add("Error al guardar el registro del usuario.");
                this.Errors.Add(ex.Message);
                bResult = false;
            }

            return bResult;
        }

        public bool RegisterClubCard(string userName,long folio)
        {
            bool bResult = true;
            bsx.DirLaguna.Dal.PublicContent.aspnet_Membership membership = this.FetchByUserName(userName);
            Guest guest = this.FetchGuestByUserId(membership.UserId);
            if (guest == null)
            {
                guest = new Guest();
                guest.Name = userName;
                guest.Folio = folio;
            }
            else
            {
                bsx.DirLaguna.Dal.ClubCard clubcard = new ClubCardController().FetchByFolio(folio);
                if (clubcard.Folio == null && clubcard.GuestId != null)
                {
                    this.Errors.Add("Folio No valido o ya lo tiene asignado otro usuario");
                }
                else
                {
                    ClubCardController cc = new ClubCardController();
                    cc.SaveGuestId(folio, guest.GuestId);
                    guest.Folio = folio;
                }
                
            }

            try
            {
                    this.db.SubmitChanges();
                
            }
            catch (Exception ex)
            {
                this.Errors.Add("Error al guardar el registro de la Tarjeta de Club El Directorio.");
                this.Errors.Add(ex.Message);
                bResult = false;
            }
            return bResult;
        } 
    }

}
