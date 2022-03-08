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
            try
            {
               

                objcontext.tbl_users.Add(objnewuser);
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
                    UsersModel ekle = objcontext.tbl_users.First(i => i.Id == (objuser.Id));

                    ekle = objuser;
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
                    
                    objcontext.Entry(objuser).State = EntityState.Deleted;
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
                UsersModel ekle = objcontext.tbl_users.First(i => i.Kullanıcıadi == (password.Kullanıcıadi));
                ekle.Şifre = password.Şifre;
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