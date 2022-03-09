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
    public class SalesmanDAO : BaseDAO
    {
        public List<SalesmanModel> GetSalesmanAll()
        {
            List<SalesmanModel> objstoklist = new List<SalesmanModel>();
            try
            {
                objstoklist = objcontext.tbl_salesman.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objstoklist;
        }

        public bool Add(SalesmanModel objnewsalesman)
        {
            bool IsAdded = false;
            try
            {
               
                objcontext.tbl_salesman.Add(objnewsalesman);
                var NoOFRowsAffected = objcontext.SaveChanges();
                IsAdded = NoOFRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsAdded;
        }

        public bool Update(SalesmanModel objsalesman)
        {
            bool isUpdated = false;
            try
            {
                using (objcontext)
                {
                    SalesmanModel güncelle = objcontext.tbl_salesman.First(i => i.Id == (objsalesman.Id));

                    güncelle = objsalesman;

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

        public bool Delete(SalesmanModel objsalesman)
        {
            bool isDeleted = false;
            try
            {
                using (objcontext)
                {
                   
                    objcontext.Entry(objsalesman).State = EntityState.Deleted;
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