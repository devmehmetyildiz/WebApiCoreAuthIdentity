using Microsoft.EntityFrameworkCore;
using StarNoteWebAPICore.EntitiyDB;
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
        public List<ParameterModel> GetAll()
        {
            List<ParameterModel> obj = new List<ParameterModel>();
            obj = objcontext.tbl_product.ToList();
            return obj;
        }

        public bool Add(ParameterModel obj)
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

        public bool Update(ParameterModel obj)
        {
            bool isUpdated = false;
            try
            {
                using (objcontext)
                {
                    ParameterModel güncelle = objcontext.tbl_product.First(i => i.Id == (obj.Id));
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

        public bool Delete(ParameterModel obj)
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