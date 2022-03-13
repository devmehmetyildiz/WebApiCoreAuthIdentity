using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<UserController> _logger;
        private readonly StarNoteEntity _context;
        UnitOfWork unitOfWork;
        public UserController(ILogger<UserController> logger, StarNoteEntity context)
        {
            _logger = logger;
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }
        [Route("GetUserList")]
        [HttpGet]
        public List<UsersModel> GetUserList()
        {
            return unitOfWork.UserRepository.GetAll();
        }
        [Route("AddUser")]
        [HttpPost]
        public bool AddUser(UsersModel objuser)
        {
            bool IsAdded = false;
            unitOfWork.UserRepository.Add(objuser);
            if (unitOfWork.Complate() > 0)
                IsAdded = true;
            return IsAdded;
        }
        [Route("UpdateUser")]
        [HttpPost]
        public bool UpdateUser(UsersModel objuser)
        {
            bool Isupdated = false;
            unitOfWork.UserRepository.update(unitOfWork.UserRepository.Getbyid(objuser.Id), objuser);
            if (unitOfWork.Complate() > 0)
                Isupdated = true;
            return Isupdated;
        }
        [Route("DeleteUser")]
        [HttpPost]
        public bool DeleteUser(UsersModel objuser)
        {
            bool IsDeleted = false;
            unitOfWork.UserRepository.Remove(objuser.Id);
            if (unitOfWork.Complate() > 0)
                IsDeleted = true;
            return IsDeleted;
        }
        [Route("Pwchange")]
        [HttpPost]
        public bool Pwchange(UsersModel objuser)
        {
            bool Isupdated = false;
            unitOfWork.UserRepository.update(unitOfWork.UserRepository.Getbyid(objuser.Id), objuser);
            if (unitOfWork.Complate() > 0)
                Isupdated = true;
            return Isupdated;
        }
    }
}
