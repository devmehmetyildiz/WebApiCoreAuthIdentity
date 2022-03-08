using StarNoteWebApi.EntitiyDB;
using StarNoteWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.DataAccess
{
    public class CostumerDAO : BaseDAO 
    {
      
        public List<CostumerModel> Filllist()
        {
            List<CostumerModel> list = new List<CostumerModel>();
            try
            {
                using (objcontext)
                {
                    foreach (var entitiycontext in objcontext.tbl_costumer)
                    {
                        list.Add(new CostumerModel
                        {
                            Id = entitiycontext.Id,
                            İsim = entitiycontext.Name,
                            Tckimlik = entitiycontext.Tc,
                            Telefon = entitiycontext.Phone,
                            Adres = entitiycontext.Address,
                            Eposta = entitiycontext.Email,
                            İlçe = entitiycontext.Town,
                            Şehir = entitiycontext.City
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

        public bool Add(CostumerModel obj)
        {
            bool IsAdded = false;
            try
            {
                var Objenttiy = new tbl_costumer();
                //Objenttiy.ID = objnewstok.Id;
                Objenttiy.Name = obj.İsim;
                Objenttiy.Tc = obj.Tckimlik;
                Objenttiy.Phone = obj.Telefon;
                Objenttiy.Email = obj.Eposta;
                Objenttiy.City = obj.Şehir;
                Objenttiy.Town = obj.İlçe;
                Objenttiy.Address = obj.Adres;               
                objcontext.tbl_costumer.Add(Objenttiy);
                var NoOFRowsAffected = objcontext.SaveChanges();
                IsAdded = NoOFRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsAdded;
        }

        public bool Update(CostumerModel obj)
        {
            bool isUpdated = false;
            try
            {
                using (objcontext)
                {
                    tbl_costumer ekle = objcontext.tbl_costumer.First(i => i.Id == (obj.Id));
                    ekle.Name = obj.İsim;
                    ekle.Tc = obj.Tckimlik;
                    ekle.Phone = obj.Telefon;
                    ekle.Email = obj.Eposta;
                    ekle.City = obj.Şehir;
                    ekle.Town = obj.İlçe;
                    ekle.Address = obj.Adres;                   
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

        public bool Delete(CostumerModel obj)
        {
            bool isDeleted = false;
            try
            {
                using (objcontext)
                {
                    var record = new tbl_costumer { Id = obj.Id };
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