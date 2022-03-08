using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StarNoteWebApi.EntitiyDB;
using StarNoteWebApi.Models;
namespace StarNoteWebApi.DataAccess
{
    public class LisanceDAO : BaseDAO
    {      

        public List<LisanceModel> GetAll()
        {
            List<LisanceModel> lisancelist = new List<LisanceModel>();
            try
            {
                using (objcontext)
                {
                    foreach (var entitiycontext in objcontext.tbl_lisance)
                    {
                        lisancelist.Add(new LisanceModel
                        {
                            Id = entitiycontext.ID,
                            LisansAdı = entitiycontext.NAME,
                            Durum = entitiycontext.STATUS,
                            Sonaermetarihi = entitiycontext.END_DATE,
                            Ürünanahtarı = entitiycontext.PRODUCTID                     
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lisancelist;
        }

        public bool Updatelisance(int Id,string status)
        {
            bool isUpdated = false;
            try
            {
                using (objcontext)
                {
                    tbl_lisance ekle = objcontext.tbl_lisance.First(i => i.ID == (Id));

                    ekle.STATUS = status;                   
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

        public bool Addlisance(LisanceModel oblisance)
        {
            bool IsAdded = false;
            try
            {
                tbl_lisance Objenttiy = new tbl_lisance();

                //Objenttiy.ID = 1;
                Objenttiy.NAME = oblisance.LisansAdı;
                Objenttiy.PRODUCTID = oblisance.Ürünanahtarı;
                Objenttiy.STATUS = oblisance.Durum;
                Objenttiy.END_DATE = oblisance.Sonaermetarihi;         
                objcontext.tbl_lisance.Add(Objenttiy);
                var NoOFRowsAffected = objcontext.SaveChanges();
                IsAdded = NoOFRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsAdded;
        }
    }
}