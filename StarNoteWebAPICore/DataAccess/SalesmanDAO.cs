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
        public List<ParameterModel> GetSalesmanAll()
        {
            List<ParameterModel> objstoklist = new List<ParameterModel>();
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

        public bool Add(ParameterModel objnewsalesman)
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

        public bool Update(ParameterModel objsalesman)
        {
            bool isUpdated = false;
            try
            {
                using (objcontext)
                {
                    ParameterModel güncelle = objcontext.tbl_salesman.First(i => i.Id == (objsalesman.Id));

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

        public bool Delete(ParameterModel objsalesman)
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