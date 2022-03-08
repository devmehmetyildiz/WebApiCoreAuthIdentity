using StarNoteWebApi.EntitiyDB;
using StarNoteWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.DataAccess
{
    public class ProductDAO : BaseDAO
    {
        public List<ParameterModel> GetAll()
        {
            List<ParameterModel> obj = new List<ParameterModel>();
            try
            {
                using (objcontext)
                {
                    foreach (var entitiycontext in objcontext.tbl_product)
                    {
                        obj.Add(new ParameterModel
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
            return obj;
        }

        public bool Add(ParameterModel obj)
        {
            bool IsAdded = false;
            try
            {
                var Objenttiy = new tbl_product();
                //Objenttiy.ID = objnewstok.Id;
                Objenttiy.Value = obj.Parameter;
                objcontext.tbl_product.Add(Objenttiy);
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
                    tbl_product güncelle = objcontext.tbl_product.First(i => i.Id == (obj.Id));
                    güncelle.Value = obj.Parameter;
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
                    var salesmanrecord = new tbl_product { Id = obj.Id };
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