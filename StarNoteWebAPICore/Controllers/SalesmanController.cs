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
    public class SalesmanController : ControllerBase
    {
        IDAO dao;
        SalesmanController()
        {
            dao = DAOBase.GetDAO();
        }
        //Starbase1DAO db1dataaccess = new Starbase1DAO();
        public List<SalesmanModel> GetSalesmanList()
        {
            List<SalesmanModel> salesmanlist = new List<SalesmanModel>();
            salesmanlist = dao.GetSalesmanAll();
            return salesmanlist;
        }

        [HttpPost]
        public bool AddSalesman(SalesmanModel objsalesman)
        {
            bool IsAdded = false;
          
                IsAdded = dao.GenericAdd(objsalesman,0,BaseDAO.Salesman);
           
            return IsAdded;
        }

        [HttpPost]
        public bool UpdateSalesman(SalesmanModel objsalesman)
        {
            bool Isupdated = false;
          
                Isupdated = dao.GenericUpdate(objsalesman,BaseDAO.Salesman);
           
            return Isupdated;
        }

        [HttpPost]
        public bool DeleteSalesman(SalesmanModel objsalesman)
        {
            bool IsDeleted = false;
           
                IsDeleted = dao.GenericDelete(objsalesman,BaseDAO.Salesman);
           
            return IsDeleted;
        }
    }
}
