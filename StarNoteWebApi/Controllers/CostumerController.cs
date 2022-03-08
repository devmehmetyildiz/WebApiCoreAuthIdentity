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
    public class CostumerController : ApiController
    {
        IDAO dao;
        CostumerController()
        {
            dao = DAOBase.GetDAO();
        }
        public List<CostumerModel> GetAll()
        {
            List<CostumerModel> list = new List<CostumerModel>();
            list = dao.GetAllCostumer();
            return list;
        }

        [HttpPost]
        public bool Add(CostumerModel obj)
        {
            bool IsAdded = false;
           
                IsAdded = dao.GenericAdd(obj);
            
            return IsAdded;
        }

        [HttpPost]
        public bool Update(CostumerModel obj)
        {
            bool Isupdated = false;
           
                Isupdated = dao.GenericUpdate(obj);
           
            return Isupdated;
        }

        [HttpPost]
        public bool Delete(CostumerModel obj)
        {
            bool IsDeleted = false;
           
                IsDeleted = dao.GenericDelete(obj);
            
            return IsDeleted;
        }
    }
}
