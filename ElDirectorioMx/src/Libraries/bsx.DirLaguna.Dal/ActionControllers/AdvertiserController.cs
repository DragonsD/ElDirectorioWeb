using System;
using System.Collections.Generic;
using System.Linq;
using bsx.DirLaguna.Dal.Carrier;
using bsx.DirLaguna.Dal.Enum;

namespace bsx.DirLaguna.Dal
{
    public partial class AdvertiserController
    {
        public bool Save(Guid userId, int externalKey, int advertiserId, string name, string numberKey, string street, string neighbornhod, string zipCode, string number, int franchiseeId, int personalId, int municipioId, out int usedId)
        {
            usedId = 0;
            bool result = false;
            //bool isNew = false;

            Advertiser adv = this.FetchById(advertiserId, franchiseeId);
            try
            {
                if (adv == null)
                {
                    //isNew = true;
                    adv = new Advertiser();
                    adv.UserId = userId;
                    adv.CreatedOn = DateTime.Now;
                    //adv.StatusId = (int)StatusEnum.Pending;
                    //adv.ShowInWebsite = false;
                    //adv.ShowInIOs = false;
                    adv.Priority = 0;
                    adv.PersonalId = personalId;
                    adv.ExternalKey = externalKey;
                    this.db.Advertiser.InsertOnSubmit(adv);
                }

                var municipio = new MunicipioController().FetchById(municipioId);
                string mixName = string.Format("{0}, {1}", municipio.Name, municipio.Estado.Name);

                City ct = new CityController(this.db).FetchByName(mixName);
                if (ct == null)
                {
                    ct = new City();
                    this.db.City.InsertOnSubmit(ct);
                    ct.Name = mixName;
                }

                adv.City = ct;
                adv.Description = "Pendiente";
                adv.Name = name;
                adv.NumberKey = numberKey;
                adv.Address = street;
                adv.ModifiedOn = DateTime.Now;
                adv.UserModifiedOn = personalId;
                adv.FranchiseeId = franchiseeId;
                adv.MunicipioId = municipioId;
                adv.EstadoId = municipio.EstadoId;
                adv.Featured = false;

                Office office = null;
                if (adv.ActiveOffices.Count() > 0)
                {
                    OfficeController controller = new OfficeController(this.db);
                    office = controller.FetchMatriz(advertiserId);
                    //var offices = controller.FetchAdvertiserOffices(adv.AdvertiserId, franchiseeId);
                    //office = (from x in offices where x.Name.Equals("Matriz") select x).FirstOrDefault();
                }

                if (office == null)
                {
                    office = new Office();
                    adv.Office.Add(office);
                }

                office.Address = street;
                office.ZipCode = zipCode;
                office.Neibornhod = neighbornhod;
                office.Number = number;
                office.MunicipioId = municipio.MunicipioId;
                office.City = ct;
                office.Name = Office.MatrizName;
                office.FranchiseeId = franchiseeId;

                string allTags = string.Empty;
                adv.Tags = allTags;

                this.db.SubmitChanges();
                //if (isNew)
                //{
                //    ContractController contractController = new ContractController();
                //    int newContractId = -1;
                //    contractController.Save(-1, adv.AdvertiserId, personalId, false, accountDetailCarrier, out newContractId);
                //}

                usedId = adv.AdvertiserId;
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }

            return result;
        }

        public bool Save(SimpleAdvertiserCarrier carrier, out int usedId)
        {
            usedId = 0;
            bool result = false;
            bool isNew = false;

            if (carrier.Categories.Count <= 0)
            {
                this.Errors.Add("No ha especificado al menos una categoría para el anunciante.");
                return result;
            }

            Advertiser adv = this.FetchById(carrier.AdvertiserId, carrier.FranchiseeId);
            try
            {
                if (adv == null)
                {
                    isNew = true;
                    adv = new Advertiser();
                    adv.UserId = carrier.UserId;
                    adv.CreatedOn = DateTime.Now;
                    //adv.StatusId = (int)StatusEnum.Pending;
                    //adv.ShowInWebsite = false;
                    //adv.ShowInIOs = false;
                    adv.Priority = 0;
                    adv.PersonalId = carrier.PersonalId;
                    adv.UserCreatedOn = carrier.PersonalId;
                    this.db.Advertiser.InsertOnSubmit(adv);
                }

                var municipio = new MunicipioController().FetchById(carrier.MunicipioId);
                string mixName = string.Format("{0}, {1}", municipio.Name, municipio.Estado.Name);

                City ct = new CityController(this.db).FetchByName(mixName);
                if (ct == null)
                {
                    ct = new City();
                    this.db.City.InsertOnSubmit(ct);
                    ct.Name = mixName;
                }

                adv.City = ct;
                adv.Name = carrier.Name;
                adv.Description = carrier.Description;
                adv.PromocionesClub = carrier.PromocionesClub;
                adv.Address = carrier.Street;
                adv.WebPage = carrier.WebPage;
                adv.Facebook = carrier.Facebook;
                adv.Twitter = carrier.Twitter;
                adv.ModifiedOn = DateTime.Now;
                adv.UserModifiedOn = carrier.PersonalId;

                adv.AditionalInfo = carrier.AditionalInfo;
                adv.FranchiseeId = carrier.FranchiseeId;
                adv.EstadoId = carrier.EstadoId;
                adv.MunicipioId = carrier.MunicipioId;
                adv.Featured = false;

                if (!string.IsNullOrEmpty(carrier.YouTubeVideo))
                    adv.YoutubeVideo = carrier.YouTubeVideo;

                Office office = null;
                if (adv.ActiveOffices.Count() > 0)
                {
                    OfficeController controller = new OfficeController(this.db);
                    office = controller.FetchMatriz(carrier.AdvertiserId);
                    //var offices = controller.FetchAdvertiserOffices(adv.AdvertiserId, carrier.FranchiseeId);
                    //office = (from x in offices where x.Name.Equals(Office.MatrizName) select x).FirstOrDefault();
                }

                if (office == null)
                {
                    office = new Office();
                    adv.Office.Add(office);
                }

                office.Address = carrier.Street;
                office.ZipCode = carrier.ZipCode;
                office.Neibornhod = carrier.Neighbornhod;
                office.Number = carrier.Number;
                office.MunicipioId = carrier.MunicipioId;
                office.City = ct;
                office.Name = Office.MatrizName;
                office.FranchiseeId = carrier.FranchiseeId;
                office.Featured = false;

                if (carrier.mapX.HasValue)
                {
                    adv.MapReferenceX = (double)carrier.mapX.Value;
                    office.MapReferenceX = (double)carrier.mapX.Value;
                }

                if (carrier.mapY.HasValue)
                {
                    adv.MapReferenceY = (double)carrier.mapY.Value;
                    office.MapReferenceY = (double)carrier.mapY.Value;
                }

                foreach (var item in carrier.Phones)
                {
                    if (!item.Deleted && item.Id <= 0)
                    {
                        Phone ph = new Phone() { Advertiser = adv, PhoneNumber = item.Description, PhoneTypeId = item.TypeId, FranchiseeId = carrier.FranchiseeId };
                        this.db.Phones.InsertOnSubmit(ph);
                    }

                    if (item.Deleted && item.Id > 0)
                    {
                        PhoneController phoneController = new PhoneController(this.db);
                        Phone phone = phoneController.FetchById(item.Id, carrier.FranchiseeId);
                        phone.Deleted = true;
                    }
                }

                foreach (var item in carrier.Emails)
                {
                    if (!item.Deleted && item.Id <= 0)
                    {
                        Email em = new Email() { Advertiser = adv, Address = item.Description };
                        this.db.Emails.InsertOnSubmit(em);
                    }

                    if (item.Deleted && item.Id > 0)
                    {
                        EmailController emailController = new EmailController(this.db);
                        Email email = emailController.FetchById(item.Id);
                        email.Deleted = true;
                    }
                }

                foreach (var item in carrier.Categories)
                {
                    if (item.Deleted && item.Id <= 0)
                        continue;

                    var aCategory = adv.AdvertiserCategory.Where(x => x.AdvertiserCategoryId == item.Id).FirstOrDefault();

                    if (aCategory == null || (aCategory != null && aCategory.AdvertiserCategoryId == 0))
                    {
                        aCategory = new AdvertiserCategory()
                        {
                            CategoryId = item.ExternalId,
                            FranchiseeId = carrier.FranchiseeId,
                            CreatedOn = DateTime.Now
                        };
                        adv.AdvertiserCategory.Add(aCategory);
                    }
                    aCategory.Deleted = item.Deleted;
                }

                string allTags = string.Empty;

                foreach (var item in carrier.Tags)
                {
                    if (!item.Deleted)
                        allTags = allTags + item.Description + ", ";

                    if (!item.Deleted && item.Id <= 0)
                    {
                        Tag tg = new Tag() { Advertiser = adv, Name = item.Description, FranchiseeId = carrier.FranchiseeId };
                        this.db.Tags.InsertOnSubmit(tg);
                    }

                    if (item.Deleted && item.Id > 0)
                    {
                        TagController tagController = new TagController(this.db);
                        Tag tag = tagController.FetchById(item.Id, carrier.FranchiseeId);
                        tag.Deleted = true;
                    }
                }

                adv.Tags = allTags;

                if (carrier.FiscalCarrier != null)
                {
                    FiscalDetail detail = new FiscalDetailController(this.db).FetchById(carrier.FiscalCarrier.FiscalDetailId);

                    if (detail == null)
                    {
                        detail = new FiscalDetail()
                        {
                            Name = carrier.FiscalCarrier.FiscalName,
                            RFC = carrier.FiscalCarrier.RFC,
                            IsMoralPerson = carrier.FiscalCarrier.RFC.Length == 12 ? false : true,
                            EstadoId = carrier.FiscalCarrier.EstadoId,
                            MunicipioId = carrier.FiscalCarrier.MunicipioId,
                            Poblacion = carrier.FiscalCarrier.Poblacion,
                            Street = carrier.FiscalCarrier.Street,
                            ExteriorNumber = carrier.FiscalCarrier.ExteriorNumber,
                            InteriorNumber = carrier.FiscalCarrier.InteriorNumber,
                            Colony = carrier.FiscalCarrier.Colony,
                            ZipCode = carrier.FiscalCarrier.ZipCode,
                            ContactEmail = carrier.FiscalCarrier.ContactEmail,
                            Id = adv.AdvertiserId
                        };
                    }
                    else
                    {
                        detail.Name = carrier.FiscalCarrier.FiscalName;
                        detail.RFC = carrier.FiscalCarrier.RFC;
                        detail.IsMoralPerson = carrier.FiscalCarrier.RFC.Length == 12 ? false : true;
                        detail.EstadoId = carrier.FiscalCarrier.EstadoId;
                        detail.MunicipioId = carrier.FiscalCarrier.MunicipioId;
                        detail.Poblacion = carrier.FiscalCarrier.Poblacion;
                        detail.Street = carrier.FiscalCarrier.Street;
                        detail.ExteriorNumber = carrier.FiscalCarrier.ExteriorNumber;
                        detail.InteriorNumber = carrier.FiscalCarrier.InteriorNumber;
                        detail.Colony = carrier.FiscalCarrier.Colony;
                        detail.ZipCode = carrier.FiscalCarrier.ZipCode;
                        detail.ContactEmail = carrier.FiscalCarrier.ContactEmail;
                        detail.Id = adv.AdvertiserId;
                    }

                    adv.FiscalDetail = detail;
                }
                else
                {
                    if (adv.FiscalDetailId.HasValue)
                    {
                        FiscalDetail detail = new FiscalDetailController(this.db).FetchById((int)adv.FiscalDetailId);
                        if (detail != null)
                        {
                            detail.Deleted = true;
                            adv.FiscalDetailId = null;
                            this.db.SubmitChanges();
                        }
                    }
                }
                this.db.SubmitChanges();

                if (isNew)
                {
                    ContractController contractController = new ContractController();
                    int newContractId = -1;
                    contractController.Save(-1, adv.AdvertiserId, carrier.PersonalId, false, null, false, carrier.AccountCarrier, null, null, out newContractId);
                }
                this.db.SubmitChanges();

                usedId = adv.AdvertiserId;
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }

            return result;
        }

        public bool Delete(int advertiserId, int franchiseeId, int personalId)
        {
            bool result = false;

            Advertiser adv = this.FetchById(advertiserId, franchiseeId);
            if (adv == null)
            {
                this.Errors.Add("El elemento no existe");
                return false;
            }

            try
            {
                adv.ModifiedOn = DateTime.Now;
                adv.Deleted = true;
                adv.UserModifiedOn = personalId;

                foreach (var item in adv.Phone)
                    item.Deleted = true;

                foreach (var item in adv.Email)
                    item.Deleted = true;

                foreach (var item in adv.Tag)
                    item.Deleted = true;

                foreach (var item in adv.AdvertiserCategory)
                    item.Deleted = true;

                this.db.SubmitChanges();
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }

            return result;
        }

        //this.ShowInWebsiteCheckbox.Checked,
        //this.ShowInIOsCheckBox.Checked,
        //this.FeaturedCheckBox.Checked,
        //int.Parse(this.PriorityTextBox.Text),

        public bool UpdateAdvertiserPrimary(int advertiserId, int priority, int personalId, out int usedId)
        {
            usedId = 0;
            bool result = false;

            Advertiser adv = this.FetchById(advertiserId);
            try
            {
                if (adv == null)
                {
                    this.Errors.Add("No se encontro al anunciante.");
                    return result;
                }

                //adv.StatusId = statusId;
                adv.ModifiedOn = DateTime.Now;
                adv.UserModifiedOn = personalId;
                //adv.ShowInWebsite = showInWebsite;
                //adv.ShowInIOs = showInIOs;
                adv.Priority = priority;

                this.db.SubmitChanges();
                usedId = adv.AdvertiserId;
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }

            return result;
        }

        public bool SavePublic(Guid userId, int advertiserId, string name, string description, string address, int franchiseeId, int personalId, int estadoId, int municipioId, SimpleAccountDetailCarrier accountDetailCarrier, decimal? paymentAmount, SimpleFiscalDetailCarrier carrier, out int newAdvertiserId, out int newContractId, out bool isNew)
        {
            newAdvertiserId = 0;
            bool result = false;
            bool isNewTemp = false;
            newContractId = -1;
            isNew = false;

            Advertiser adv = this.FetchById(advertiserId, franchiseeId);
            try
            {
                if (adv == null)
                {
                    isNewTemp = true;
                    adv = new Advertiser();
                    adv.UserId = userId;
                    adv.CreatedOn = DateTime.Now;
                    //adv.StatusId = (int)StatusEnum.Pending;
                    //adv.ShowInWebsite = false;
                    //adv.ShowInIOs = false;
                    adv.Priority = 0;
                    adv.PersonalId = personalId;
                    this.db.Advertiser.InsertOnSubmit(adv);
                }

                var municipio = new MunicipioController().FetchById(municipioId);
                string mixName = string.Format("{0}, {1}", municipio.Name, municipio.Estado.Name);

                City ct = new CityController(this.db).FetchByName(mixName);
                if (ct == null)
                {
                    ct = new City();
                    this.db.City.InsertOnSubmit(ct);
                    ct.Name = mixName;
                }

                adv.City = ct;
                adv.Name = name;
                adv.Description = description;
                adv.Address = address;
                adv.WebPage = null;
                adv.Facebook = null;
                adv.Twitter = null;
                adv.ModifiedOn = DateTime.Now;
                adv.UserModifiedOn = personalId;
                adv.AditionalInfo = null;
                adv.FranchiseeId = franchiseeId;
                adv.EstadoId = estadoId;
                adv.MunicipioId = municipioId;
                adv.Featured = false;

                Office office = null;
                if (adv.ActiveOffices.Count() > 0)
                {
                    OfficeController controller = new OfficeController(this.db);
                    var offices = controller.FetchAdvertiserOffices(adv.AdvertiserId, franchiseeId);
                    office = (from x in offices where x.Name.Equals("Matriz") select x).FirstOrDefault();
                }

                if (office == null)
                {
                    office = new Office();
                    adv.Office.Add(office);
                }

                office.Address = address;
                office.MunicipioId = municipioId;
                office.City = ct;
                office.Name = "Matriz";
                office.FranchiseeId = franchiseeId;

                adv.MapReferenceX = null;
                office.MapReferenceX = null;
                adv.MapReferenceY = null;
                office.MapReferenceY = null;

                adv.Tags = string.Empty;


                //adv.FiscalDetail = null;
                this.db.SubmitChanges();
                int newContractIdTemp = -1;
                if (carrier.IsValid)
                {
                    FiscalDetail detail = new FiscalDetailController(this.db).FetchById(carrier.FiscalDetailId);

                    if (detail == null)
                        detail = new FiscalDetail();

                    detail.Name = carrier.FiscalName;
                    detail.RFC = carrier.RFC;
                    detail.IsMoralPerson = carrier.RFC.Length == 12 ? false : true;
                    detail.EstadoId = carrier.EstadoId;
                    detail.MunicipioId = carrier.MunicipioId;
                    detail.Poblacion = carrier.Poblacion;
                    detail.Street = carrier.Street;
                    detail.ExteriorNumber = carrier.ExteriorNumber;
                    detail.InteriorNumber = carrier.InteriorNumber;
                    detail.Colony = carrier.Colony;
                    detail.ZipCode = carrier.ZipCode;
                    detail.ContactEmail = carrier.ContactEmail;
                    detail.Id = adv.AdvertiserId;

                    adv.FiscalDetail = detail;
                }
                else
                {
                    if (adv.FiscalDetailId.HasValue)
                    {
                        FiscalDetail detail = new FiscalDetailController(this.db).FetchById((int)adv.FiscalDetailId);
                        if (detail != null)
                        {
                            detail.Deleted = true;
                            adv.FiscalDetailId = null;
                        }
                    }
                }

                this.db.SubmitChanges();

                if (isNewTemp)
                {
                    ContractController contractController = new ContractController();
                    if (!contractController.Save(-1, adv.AdvertiserId, personalId, false, null, false, accountDetailCarrier, paymentAmount, null, out newContractIdTemp))
                    {
                        foreach (string item in contractController.Errors)
                        {
                            this.Errors.Add(item);
                        }
                    }

                }
                newContractId = newContractIdTemp;
                isNew = isNewTemp;
                newAdvertiserId = adv.AdvertiserId;
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
                result = false;
            }

            return result;
        }

        public bool UpdateDV(int advertiserId, string dv, int personalId)
        {
            bool result = false;

            Advertiser adv = this.FetchById(advertiserId);
            if (adv == null)
            {
                this.Errors.Add("El anunciante NO Existe.");
                return false;
            }

            adv.ModifiedOn = DateTime.Now;
            adv.UserModifiedOn = personalId;

            try
            {
                adv.DV = dv;
                this.db.SubmitChanges();
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }

            return result;
        }


    }
}
