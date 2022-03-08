using StarNoteWebApi.EntitiyDB;
using StarNoteWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.DataAccess
{
    public class UserDAO : BaseDAO
    {
        public List<UsersModel> Fillusermodel()
        {
            List<UsersModel> userlist = new List<UsersModel>();
            try
            {
                using (objcontext)
                {
                    foreach (var entity in objcontext.tbl_users)
                    {
                        userlist.Add(new UsersModel
                        {
                            Id = entity.Id,
                            İsim = entity.Name,
                            Soyisim = entity.Surname,
                            Kullanıcıadi = entity.Users,
                            Şifre = entity.Password,
                            Mailadres = entity.Mail,
                            Yetki = entity.Authority,
                            Isactive = entity.Isactive,
                            Kayıttarihi = entity.Reg_Date,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userlist;
        }

        public bool AddUser(UsersModel objnewuser)
        {
            bool IsAdded = false;
            try
            {
                var Objenttiy = new tbl_users();
                //Objenttiy.ID = 1;
                Objenttiy.Users = objnewuser.Kullanıcıadi;
                Objenttiy.Name = objnewuser.İsim;
                Objenttiy.Surname = objnewuser.Soyisim;
                Objenttiy.Password = objnewuser.Şifre;
                Objenttiy.Mail = objnewuser.Mailadres;
                Objenttiy.Authority = objnewuser.Yetki;
                Objenttiy.Isactive = objnewuser.Isactive;
                Objenttiy.Reg_Date = objnewuser.Kayıttarihi;

                objcontext.tbl_users.Add(Objenttiy);
                var NoOFRowsAffected = objcontext.SaveChanges();
                IsAdded = NoOFRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsAdded;
        }

        public bool UpdateUser(UsersModel objuser)
        {
            bool isUpdated = false;
            try
            {
                using (objcontext)
                {
                    tbl_users ekle = objcontext.tbl_users.First(i => i.Id == (objuser.Id));

                    ekle.Users = objuser.Kullanıcıadi;
                    //ekle.Password = objuser.Şifre;
                    ekle.Authority = objuser.Yetki;
                    ekle.Isactive = objuser.Isactive;
                    ekle.Name = objuser.İsim;
                    ekle.Surname = objuser.Soyisim;
                    ekle.Reg_Date = objuser.Kayıttarihi;
                    ekle.Mail = objuser.Mailadres;
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

        public bool DeleteUser(UsersModel objuser)
        {
            bool isDeleted = false;
            try
            {
                using (objcontext)
                {
                    var userrecord = new tbl_users { Id = objuser.Id };
                    objcontext.Entry(userrecord).State = EntityState.Deleted;
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

        public bool Passwordchange(UsersModel password)
        {
            bool isUpdated = false;
            try
            {
                tbl_users ekle = objcontext.tbl_users.First(i => i.Users == (password.Kullanıcıadi));
                ekle.Password = password.Şifre;
                objcontext.SaveChanges();
                isUpdated = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isUpdated;
        }
    }
}