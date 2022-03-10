using Microsoft.EntityFrameworkCore;
using StarNoteWebAPICore.EntityDB;
using StarNoteWebAPICore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StarNoteWebAPICore.DataAccess
{
    public class ProductDAO : BaseDAO
    {
        public List<ProductModel> GetAll()
        {
            List<ProductModel> obj = new List<ProductModel>();
            obj = objcontext.tbl_product.ToList();
            return obj;
        }

        public bool Add(ProductModel obj)
        {
            bool IsAdded = false;
            try
            {
                
                objcontext.tbl_product.Add(obj);
                var NoOFRowsAffected = objcontext.SaveChanges();
                IsAdded = NoOFRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsAdded;
        }

        public bool Update(ProductModel obj)
        {
            bool isUpdated = false;
            try
            {
                using (objcontext)
                {
                    ProductModel güncelle = objcontext.tbl_product.First(i => i.Id == (obj.Id));
                    güncelle = obj;
                    objcontext.SaveChanges();
                    isUpdated = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isUpdated;
        }

        public bool Delete(ProductModel obj)
        {
            bool isDeleted = false;
            try
            {
                using (objcontext)
                {
                    
                    objcontext.Entry(obj).State = EntityState.Deleted;
                    objcontext.SaveChanges();
                    isDeleted = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isDeleted;
        }
    }
}