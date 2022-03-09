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
    public class TypeDAO : BaseDAO
    {
        public List<TypeModel> GetTürAll()
        {
            List<TypeModel> list = new List<TypeModel>();
            try
            {
                list = objcontext.tbl_type.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public bool AddTür(TypeModel objtür)
        {
            bool IsAdded = false;
            try
            {
               
                objcontext.tbl_type.Add(objtür);
                var NoOFRowsAffected = objcontext.SaveChanges();
                IsAdded = NoOFRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsAdded;
        }

        public bool UpdateTür(TypeModel objtür)
        {
            bool isUpdated = false;
            try
            {
                using (objcontext)
                {
                    TypeModel güncelle = objcontext.tbl_type.First(i => i.Id == (objtür.Id));

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

        public bool DeleteTür(TypeModel objtür)
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