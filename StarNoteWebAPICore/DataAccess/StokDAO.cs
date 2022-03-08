using StarNoteWebAPICore.EntityDB;
using StarNoteWebAPICore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebAPICore.DataAccess
{
    public class StokDAO : BaseDAO
    {       
        public List<StokModel> GetStokAll()
        {
            List<StokModel> objstoklist = new List<StokModel>();
            try
            {
                objstoklist = objcontext.tbl_stok.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objstoklist;
        }

        public bool AddStok(StokModel objnewstok)
        {
            bool IsAdded = false;
            try
            {
         
                objcontext.tbl_stok.Add(objnewstok);
                var NoOFRowsAffected = objcontext.SaveChanges();
                IsAdded = NoOFRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsAdded;
        }

        public bool UpdateStok(StokModel objupdatestok)
        {
            bool isUpdated = false;

            try
            {
                using (objcontext)
                {
                    StokModel ekle = objcontext.tbl_stok.First(i => i.Id == (objupdatestok.Id));

                    ekle = objupdatestok;
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

        public List<string> BirimStokSourcelist()
        {
            List<string> birimsource = new List<string>();
            try
            {
                using (objcontext)
                {
                    foreach (var entitiycontext in objcontext.tbl_product)
                    {
                        birimsource.Add(entitiycontext.Parameter.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return birimsource;
        }     

        public List<string> KdvStokSourcelist()
        {
            List<string> kdvsource = new List<string>();
            try
            {
                using (objcontext)
                {
                    foreach (var entitiycontext in objcontext.tbl_kdvsource)
                    {
                        kdvsource.Add(entitiycontext.Parameter.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return kdvsource;
        }

        public StokModel Getselectedstok(string name)
        {
            StokModel source = new StokModel();
            try
            {
                using (objcontext)
                {
                     source = objcontext.tbl_stok.First(i => i.Stokadı == name);
                   


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return source;
        }

       
    }
}