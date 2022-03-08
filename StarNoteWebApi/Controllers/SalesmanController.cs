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
    public class SalesmanController : ApiController
    {
        IDAO dao;
        SalesmanController()
        {
            dao = DAOBase.GetDAO();
        }
        //Starbase1DAO db1dataaccess = new Starbase1DAO();
        public List<ParameterModel> GetSalesmanList()
        {
            List<ParameterModel> salesmanlist = new List<ParameterModel>();
            salesmanlist = dao.GetSalesmanAll();
            return salesmanlist;
        }

        [HttpPost]
        public bool AddSalesman(ParameterModel objsalesman)
        {
            bool IsAdded = false;
          
                IsAdded = dao.GenericAdd(objsalesman,0,BaseDAO.Salesman);
           
            return IsAdded;
        }

        [HttpPost]
        public bool UpdateSalesman(ParameterModel objsalesman)
        {
            bool Isupdated = false;
          
                Isupdated = dao.GenericUpdate(objsalesman,BaseDAO.Salesman);
           
            return Isupdated;
        }

        [HttpPost]
        public bool DeleteSalesman(ParameterModel objsalesman)
        {
            bool IsDeleted = false;
           
                IsDeleted = dao.GenericDelete(objsalesman,BaseDAO.Salesman);
           
            return IsDeleted;
        }
    }
}
