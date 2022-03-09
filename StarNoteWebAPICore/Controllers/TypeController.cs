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

    public class TypeController : ControllerBase 
    {
        IDAO dao;
        TypeController()
        {
            dao = DAOBase.GetDAO();
        }
        //Starbase1DAO db1dataaccess = new Starbase1DAO();
        public List<TypeModel> GetTürList()
        {
            List<TypeModel> türlist = new List<TypeModel>();
            türlist = dao.GetTypeAll();
            return türlist;
        }

        [HttpPost]
        public bool AddTür(TypeModel objtür)
        {
            bool IsAdded = false;
          
                IsAdded = dao.GenericAdd(objtür,0,BaseDAO.Type);
           
            return IsAdded;
        }

        [HttpPost]
        public bool UpdateTür(TypeModel objtür)
        {
            bool Isupdated = false;
            
                Isupdated = dao.GenericUpdate(objtür, BaseDAO.Type);

            return Isupdated;
        }

        [HttpPost]
        public bool DeleteTür(TypeModel objtür)
        {
            bool IsDeleted = false;
           
                IsDeleted = dao.GenericDelete(objtür, BaseDAO.Type);

            return IsDeleted;
        }
    }
}
