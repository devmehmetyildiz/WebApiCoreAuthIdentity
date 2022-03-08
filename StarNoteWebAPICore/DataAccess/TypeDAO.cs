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
        public List<ParameterModel> GetTürAll()
        {
            List<ParameterModel> list = new List<ParameterModel>();
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

        public bool AddTür(ParameterModel objtür)
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

        public bool UpdateTür(ParameterModel objtür)
        {
            bool isUpdated = false;
            try
            {
                using (objcontext)
                {
                    ParameterModel güncelle = objcontext.tbl_type.First(i => i.Id == (objtür.Id));

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

        public bool DeleteTür(ParameterModel objtür)
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