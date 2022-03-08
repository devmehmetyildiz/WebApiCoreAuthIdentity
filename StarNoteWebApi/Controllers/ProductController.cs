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
    public class ProductController : ApiController
    {

        IDAO dao;
        ProductController()
        {
            dao = DAOBase.GetDAO();
        }
        public List<ParameterModel> Getlist()
        {
            List<ParameterModel> list = new List<ParameterModel>();
            list = dao.GetAllProduct();
            return list;
        }

        [HttpPost]
        public bool Add(ParameterModel obj)
        {
            bool IsAdded = false;
         
                IsAdded = dao.GenericAdd(obj,0,3);
          
            return IsAdded;
        }

        [HttpPost]
        public bool Update(ParameterModel obj)
        {
            bool Isupdated = false;
           
                Isupdated = dao.GenericUpdate(obj,3);
           
            return Isupdated;
        }

        [HttpPost]
        public bool Delete(ParameterModel obj)
        {
            bool IsDeleted = false;           
                IsDeleted = dao.GenericDelete(obj,3);           
            return IsDeleted;
        }
    }
}
