using StarNoteWebApi.EntitiyDB;
using StarNoteWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.DataAccess
{
    public class StokDAO : BaseDAO
    {       
        public List<StokModel> GetStokAll()
        {
            List<StokModel> objstoklist = new List<StokModel>();
            try
            {
                using (objcontext)
                {
                    foreach (var entitiycontext in objcontext.tbl_stok)
                    {
                        objstoklist.Add(new StokModel
                        {
                            Id = entitiycontext.Id,
                            Stokkod = entitiycontext.Code,
                            Stokadı = entitiycontext.Name,
                            Birim = entitiycontext.Unit,                          
                            Miktar = (int)entitiycontext.Amount,
                            Alışfiyat = (double)entitiycontext.Incomerice,
                            Satışfiyat = (double)entitiycontext.Outcomeprice,
                            Kdv = entitiycontext.Kdv,
                            İskonto = (double)entitiycontext.Discount
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

        public bool AddStok(StokModel objnewstok)
        {
            bool IsAdded = false;
            try
            {
                var Objenttiy = new tbl_stok();

                //Objenttiy.ID = objnewstok.Id;
                Objenttiy.Code = objnewstok.Stokkod;
                Objenttiy.Name = objnewstok.Stokadı;
                Objenttiy.Unit = objnewstok.Birim;
                Objenttiy.Amount = objnewstok.Miktar;               
                Objenttiy.Incomerice = objnewstok.Alışfiyat;
                Objenttiy.Outcomeprice = objnewstok.Satışfiyat;
                Objenttiy.Kdv = objnewstok.Kdv;
                Objenttiy.Discount = objnewstok.İskonto;
                objcontext.tbl_stok.Add(Objenttiy);
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
                    tbl_stok ekle = objcontext.tbl_stok.First(i => i.Id == (objupdatestok.Id));

                    ekle.Code = objupdatestok.Stokkod;
                    ekle.Name = objupdatestok.Stokadı;
                    ekle.Unit = objupdatestok.Birim;                
                    ekle.Amount = objupdatestok.Miktar;
                    ekle.Incomerice = objupdatestok.Alışfiyat;
                    ekle.Outcomeprice = objupdatestok.Satışfiyat;
                    ekle.Kdv = objupdatestok.Kdv;
                    ekle.Discount = objupdatestok.İskonto;
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
                        birimsource.Add(entitiycontext.Value.ToString());
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
                        kdvsource.Add(entitiycontext.Value.ToString());
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
                    tbl_stok record = objcontext.tbl_stok.First(i => i.Name == name);
                    source = new StokModel()
                    {
                        Stokkod = record.Code,
                        Stokadı = record.Name,
                        Alışfiyat = (double)record.Incomerice,
                        Satışfiyat = (double)record.Outcomeprice,                       
                        Birim = record.Unit,
                        Kdv = record.Kdv,
                        Miktar = (int)record.Amount,
                        İskonto = (double)record.Discount
                    };


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