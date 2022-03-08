using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StarNoteWebAPICore.EntityDB;
using StarNoteWebAPICore.Models;
namespace StarNoteWebAPICore.DataAccess
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
                            Id = entitiycontext.Id,
                            LisansAdı = entitiycontext.LisansAdı,
                            Durum = entitiycontext.Durum,
                            Sonaermetarihi = entitiycontext.Sonaermetarihi,
                            Ürünanahtarı = entitiycontext.Ürünanahtarı                     
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
                    LisanceModel ekle = objcontext.tbl_lisance.First(i => i.Id == (Id));

                    ekle.Durum = status;                   
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
                objcontext.tbl_lisance.Add(oblisance);
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