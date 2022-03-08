using StarNoteWebApi.EntitiyDB;
using StarNoteWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.DataAccess
{
    public class SalesmanDAO : BaseDAO
    {
        public List<ParameterModel> GetSalesmanAll()
        {
            List<ParameterModel> objstoklist = new List<ParameterModel>();
            try
            {
                using (objcontext)
                {
                    foreach (var entitiycontext in objcontext.tbl_salesman)
                    {
                        objstoklist.Add(new ParameterModel
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
            return objstoklist;
        }

        public bool Add(ParameterModel objnewsalesman)
        {
            bool IsAdded = false;
            try
            {
                var Objenttiy = new tbl_salesman();
                //Objenttiy.ID = objnewstok.Id;
                Objenttiy.Value = objnewsalesman.Parameter;
                objcontext.tbl_salesman.Add(Objenttiy);
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
                    tbl_salesman güncelle = objcontext.tbl_salesman.First(i => i.Id == (objsalesman.Id));

                    güncelle.Value = objsalesman.Parameter;

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
                    var salesmanrecord = new tbl_salesman { Id = objsalesman.Id };
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