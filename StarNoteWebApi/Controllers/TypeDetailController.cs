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
    public class TypeDetailController : ApiController
    {
        IDAO dao;
        TypeDetailController()
        {
            dao = DAOBase.GetDAO();
        }
        public List<ParameterModel> GetTürdetayList()
        {
            List<ParameterModel> türlist = new List<ParameterModel>();
            türlist = dao.GetTürdetayAll();
            return türlist;
        }

        [HttpPost]
        public bool AddTürdetay(ParameterModel objtür)
        {
            bool IsAdded = false;

            IsAdded = dao.GenericAdd(objtür,0,BaseDAO.TypeDetail);

            return IsAdded;
        }

        [HttpPost]
        public bool UpdateTürdetay(ParameterModel objtür)
        {
            bool Isupdated = false;

            Isupdated = dao.GenericUpdate(objtür, BaseDAO.TypeDetail);

            return Isupdated;
        }

        [HttpPost]
        public bool DeleteTürdetay(ParameterModel objtür)
        {
            bool IsDeleted = false;

            IsDeleted = dao.GenericDelete(objtür, BaseDAO.TypeDetail);
            return IsDeleted;
        }
    }
}
