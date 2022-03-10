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
    public class TypeDetailDAO : BaseDAO
    {       
        public List<TypedetailModel> GetTürAll()
        {
            List<TypedetailModel> objstoklist = new List<TypedetailModel>();
            try
            {
                objstoklist = objcontext.tbl_typedetail.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objstoklist;
        }

        public bool AddTür(TypedetailModel objtür)
        {
            bool IsAdded = false;
            try
            {
              
                objcontext.tbl_typedetail.Add(objtür);
                var NoOFRowsAffected = objcontext.SaveChanges();
                IsAdded = NoOFRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsAdded;
        }

        public bool UpdateTür(TypedetailModel objtür)
        {
            bool isUpdated = false;
            try
            {
                using (objcontext)
                {
                    ParameterModel güncelle = objcontext.tbl_typedetail.First(i => i.Id == (objtür.Id));

                    güncelle.Parameter = objtür.Parameter;

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

        public bool DeleteTür(TypedetailModel objtür)
        {
            bool isDeleted = false;
            try
            {
                using (objcontext)
                {
                   
                    objcontext.Entry(objtür).State = EntityState.Deleted;
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