using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StarNoteWebApi.Models;
using StarNoteWebApi.DataAccess;
using StarNoteWebApi.EntitiyDB;
using System.Data;

namespace StarNoteWebApi.DataAccess
{
    public class CompanyDAO : BaseDAO
    {      

        public List<CompanyModel> Filllist()
        {
            List<CompanyModel> list = new List<CompanyModel>();
            try
            {
                using (objcontext)
                {
                    foreach (var entitiycontext in objcontext.tbl_company)
                    {
                        list.Add(new CompanyModel
                        {
                            Id = entitiycontext.Id,
                            Companyname = entitiycontext.Name,
                            Companyadress = entitiycontext.Address,
                            Taxname = entitiycontext.Taxname,
                            Taxno = entitiycontext.Taxno,
                           
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

        public bool Add(CompanyModel obj)
        {
            bool IsAdded = false;
            try
            {
                var Objenttiy = new tbl_company();
                //Objenttiy.ID = objnewstok.Id;
                Objenttiy.Address = obj.Companyadress;
                Objenttiy.Name = obj.Companyname;
                Objenttiy.Taxname = obj.Taxname;
                Objenttiy.Taxno = obj.Taxno;         
                objcontext.tbl_company.Add(Objenttiy);
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
                    tbl_company ekle = objcontext.tbl_company.First(i => i.Id == (obj.Id));
                    ekle.Address = obj.Companyadress;
                    ekle.Name = obj.Companyname;
                    ekle.Taxname = obj.Taxname;
                    ekle.Taxno = obj.Taxno;                   
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
                    var record = new tbl_company { Id = obj.Id };
                    objcontext.Entry(record).State = EntityState.Deleted;
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