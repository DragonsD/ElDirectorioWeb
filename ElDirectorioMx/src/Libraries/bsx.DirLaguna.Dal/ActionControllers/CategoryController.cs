using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class CategoryController
    {
        public bool Save(int categoryId, string name, bool featured, out int newCategoryId)
        {
            bool result = false;
            newCategoryId = -1;

            Category cat = this.FetchById(categoryId);
            if (cat == null)
            {
                cat = new Category();
                this.db.Categories.InsertOnSubmit(cat);
            }

            cat.Name = name;
            cat.Letter = name.Substring(0, 1).ToUpper();
            cat.Featured = featured;
            cat.Weight = 0;

            try
            {
                this.db.SubmitChanges();
                newCategoryId = cat.CategoryId;
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }

            return result;
        }

        public bool Delete(int categoryId)
        {
            bool result = false;

            Category cat = this.FetchById(categoryId);
            if (cat == null)
            {
                this.Errors.Add("El elemento no existe");
                return false;
            }

            try
            {
                cat.Deleted = true;
                foreach (var item in cat.CatPublicities)
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
    }
}
