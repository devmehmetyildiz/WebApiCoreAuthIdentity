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
    public class CostumerDAO : BaseDAO 
    {
       
        public List<CostumerModel> Filllist()
        {
            List<CostumerModel> list = new List<CostumerModel>();
            try
            {
             list = objcontext.tbl_costumer.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public bool Add(CostumerModel obj)
        {
            bool IsAdded = false;
            try
            {               
                objcontext.tbl_costumer.Add(obj);
                var NoOFRowsAffected = objcontext.SaveChanges();
                IsAdded = NoOFRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsAdded;
        }

        public bool Update(CostumerModel obj)
        {
            bool isUpdated = false;
            try
            {
                using (objcontext)
                {
                    CostumerModel ekle = objcontext.tbl_costumer.First(i => i.Id == (obj.Id));
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

        public bool Delete(CostumerModel obj)
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