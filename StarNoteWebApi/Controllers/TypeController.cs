using StarNoteWebApi.DataAccess;
using StarNoteWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StarNoteWebApi.Controllers
{
    [Authorize]

    public class TypeController : ApiController 
    {
        IDAO dao;
        TypeController()
        {
            dao = DAOBase.GetDAO();
        }
        //Starbase1DAO db1dataaccess = new Starbase1DAO();
        public List<ParameterModel> GetTürList()
        {
            List<ParameterModel> türlist = new List<ParameterModel>();
            türlist = dao.GetTypeAll();
            return türlist;
        }

        [HttpPost]
        public bool AddTür(ParameterModel objtür)
        {
            bool IsAdded = false;
          
                IsAdded = dao.GenericAdd(objtür,0,BaseDAO.Type);
           
            return IsAdded;
        }

        [HttpPost]
        public bool UpdateTür(ParameterModel objtür)
        {
            bool Isupdated = false;
            
                Isupdated = dao.GenericUpdate(objtür, BaseDAO.Type);

            return Isupdated;
        }

        [HttpPost]
        public bool DeleteTür(ParameterModel objtür)
        {
            bool IsDeleted = false;
           
                IsDeleted = dao.GenericDelete(objtür, BaseDAO.Type);

            return IsDeleted;
        }
    }
}
