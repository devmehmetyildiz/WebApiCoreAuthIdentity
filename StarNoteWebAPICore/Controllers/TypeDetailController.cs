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
    public class TypeDetailController : ControllerBase
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
