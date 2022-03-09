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
        public List<TypedetailModel> GetTürdetayList()
        {
            List<TypedetailModel> türlist = new List<TypedetailModel>();
            türlist = dao.GetTürdetayAll();
            return türlist;
        }

        [HttpPost]
        public bool AddTürdetay(TypedetailModel objtür)
        {
            bool IsAdded = false;

            IsAdded = dao.GenericAdd(objtür,0,BaseDAO.TypeDetail);

            return IsAdded;
        }

        [HttpPost]
        public bool UpdateTürdetay(TypedetailModel objtür)
        {
            bool Isupdated = false;

            Isupdated = dao.GenericUpdate(objtür, BaseDAO.TypeDetail);

            return Isupdated;
        }

        [HttpPost]
        public bool DeleteTürdetay(TypedetailModel objtür)
        {
            bool IsDeleted = false;

            IsDeleted = dao.GenericDelete(objtür, BaseDAO.TypeDetail);
            return IsDeleted;
        }
    }
}
