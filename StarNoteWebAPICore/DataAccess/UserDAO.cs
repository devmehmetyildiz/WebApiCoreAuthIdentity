using Microsoft.EntityFrameworkCore;
using StarNoteWebAPICore.EntityDB;
using StarNoteWebAPICore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StarNoteWebAPICore.DataAccess
{
    public class UserDAO : BaseDAO
    {
        public List<UsersModel> Fillusermodel()
        {
            List<UsersModel> userlist = new List<UsersModel>();
            try
            {
                userlist = objcontext.tbl_users.ToList();
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
           
               

                objcontext.tbl_users.Add(objnewuser);
                var NoOFRowsAffected = objcontext.SaveChanges();
                IsAdded = NoOFRowsAffected > 0;
           
            return IsAdded;
        }

        public bool UpdateUser(UsersModel objuser)
        {
            bool isUpdated = false;
            
                using (objcontext)
                {
                    UsersModel ekle = objcontext.tbl_users.First(i => i.Id == (objuser.Id));

                    ekle = objuser;
                    objcontext.SaveChanges();
                    isUpdated = true;
                }
           
            return isUpdated;
        }

        public bool DeleteUser(UsersModel objuser)
        {
            bool isDeleted = false;
            
                using (objcontext)
                {
                    
                    objcontext.Entry(objuser).State = EntityState.Deleted;
                    objcontext.SaveChanges();
                    isDeleted = true;
                }
            
            return isDeleted;
        }

        public bool Passwordchange(UsersModel password)
        {
            bool isUpdated = false;
            
                UsersModel ekle = objcontext.tbl_users.First(i => i.Kullanıcıadi == (password.Kullanıcıadi));
                ekle.Şifre = password.Şifre;
                objcontext.SaveChanges();
                isUpdated = true;
            
            return isUpdated;
        }

        public UsersModel Finduser(string UserName, string Password)
        {
            return objcontext.tbl_users.First(i => i.Kullanıcıadi == UserName && i.Şifre == Password);
        }
    }
}