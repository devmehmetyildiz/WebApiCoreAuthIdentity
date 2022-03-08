using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StarNoteWebAPICore.DataAccess;
using StarNoteWebAPICore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;


namespace StarNoteWebAPICore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IDAO dao;
        UserController()
        {
            dao = DAOBase.GetDAO();
        }

        public List<UsersModel> GetUserList()
        {
            List<UsersModel> userlist = new List<UsersModel>();
            userlist = dao.Fillusermodel();
            return userlist;
        }

        [HttpPost]
        public bool AddUser(UsersModel objuser)
        {
            bool IsAdded = false;
           
            IsAdded = dao.GenericAdd(objuser);
            
            return IsAdded;
        }

        [HttpPost]
        public bool UpdateUser(UsersModel objuser)
        {
            bool Isupdated = false;           
                Isupdated = dao.GenericUpdate(objuser);            
            return Isupdated;
        }

        [HttpPost]
        public bool DeleteUser(UsersModel objuser)
        {
            bool IsDeleted = false;
          
                IsDeleted = dao.GenericDelete(objuser);
            
            return IsDeleted;
        }

        [HttpPost]
        public bool Pwchange(UsersModel objuser)
        {
            bool IsAdded = false;

            IsAdded = dao.Passwordchange(objuser);

            return IsAdded;
        }
    }
}
