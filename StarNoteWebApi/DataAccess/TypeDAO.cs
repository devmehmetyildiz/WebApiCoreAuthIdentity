using StarNoteWebApi.EntitiyDB;
using StarNoteWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.DataAccess
{
    public class TypeDAO : BaseDAO
    {
        public List<ParameterModel> GetTürAll()
        {
            List<ParameterModel> list = new List<ParameterModel>();
            try
            {
                using (objcontext)
                {
                    foreach (var entitiycontext in objcontext.tbl_type)
                    {
                        list.Add(new ParameterModel
                        {
                            Id = entitiycontext.Id,
                            Parameter = entitiycontext.Value
                        });
                    }
                }
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
                var Objenttiy = new tbl_type();
                //Objenttiy.ID = objnewstok.Id;
                Objenttiy.Value = objtür.Parameter;
                objcontext.tbl_type.Add(Objenttiy);
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
                    tbl_type güncelle = objcontext.tbl_type.First(i => i.Id == (objtür.Id));

                    güncelle.Value = objtür.Parameter;

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
                    var salesmanrecord = new tbl_type { Id = objtür.Id };
                    objcontext.Entry(salesmanrecord).State = EntityState.Deleted;
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