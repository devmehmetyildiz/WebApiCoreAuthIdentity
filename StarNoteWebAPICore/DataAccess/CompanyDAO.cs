using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StarNoteWebAPICore.Models;
using StarNoteWebAPICore.DataAccess;
using StarNoteWebAPICore.EntityDB;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace StarNoteWebAPICore.DataAccess
{

    public class CompanyDAO : BaseDAO
    {
       
        public List<CompanyModel> Filllist()
        {
            List<CompanyModel> list = new List<CompanyModel>();
            try
            {
               list = objcontext.tbl_company.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public bool Add(CompanyModel obj)
        {
            bool IsAdded = false;
            try
            {
                objcontext.tbl_company.Add(obj);
                var NoOFRowsAffected = objcontext.SaveChanges();
                IsAdded = NoOFRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsAdded;
        }

        public bool Update(CompanyModel obj)
        {
            bool isUpdated = false;
            try
            {
                using (objcontext)
                {
                    CompanyModel ekle = objcontext.tbl_company.First(i => i.Id == (obj.Id));
                    ekle = obj;            
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

        public bool Delete(CompanyModel obj)
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