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
    public class CostumerController : ControllerBase
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
