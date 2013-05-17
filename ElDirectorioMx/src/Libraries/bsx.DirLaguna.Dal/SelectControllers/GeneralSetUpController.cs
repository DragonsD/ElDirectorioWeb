using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class GeneralSetUpController : BaseController<GeneralSetUp>
    {
        public override GeneralSetUp FetchById(int id)
        {
            return (from x in this.db.GeneralSetUps
                    where x.GeneralSetUpId == id
                    select x).FirstOrDefault();
        }

        public GeneralSetUp FetchFirst()
        {
            return (from x in this.db.GeneralSetUps
                    select x).FirstOrDefault();
        }

        public override IQueryable<GeneralSetUp> FetchAll()
        {
            return from x in this.db.GeneralSetUps
                   select x;
        }

        public bool SaveFrontPageMarkup(string content)
        {
            GeneralSetUp data = this.FetchFirst();
            if (data == null)
                return false;
            bool result = false;
            try
            {
                data.FrontPageMarkup = content;
                this.db.SubmitChanges();
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
                throw;
            }
            return result;
        }


        public bool SaveFrontPageMarkupIphone(string content)
        {
            GeneralSetUp data = this.FetchFirst();
            if (data == null)
                return false;
            bool result = false;
            try
            {
                data.FrontPageMarkupIphone = content;
                this.db.SubmitChanges();
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
                throw;
            }
            return result;
        }


        public bool SaveFranchiseeContent(string content)
        {
            GeneralSetUp data = this.FetchFirst();
            if (data == null)
                return false;
            bool result = false;
            try
            {
                data.FranchiseeMarkup = content;
                this.db.SubmitChanges();
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
                throw;
            }
            return result;
        }

        public bool SaveAdYourSelfContent(string content)
        {
            GeneralSetUp data = this.FetchFirst();
            if (data == null)
                return false;
            bool result = false;
            try
            {
                data.AdvertiserMarkup = content;
                this.db.SubmitChanges();
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
                throw;
            }
            return result;
        }
    }
}
