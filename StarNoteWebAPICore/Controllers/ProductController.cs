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
    public class ProductController : ControllerBase
    {

        IDAO dao;
        ProductController()
        {
            dao = DAOBase.GetDAO();
        }
        public List<ProductModel> Getlist()
        {
            List<ProductModel> list = new List<ProductModel>();
            list = dao.GetAllProduct();
            return list;
        }

        [HttpPost]
        public bool Add(ProductModel obj)
        {
            bool IsAdded = false;
         
                IsAdded = dao.GenericAdd(obj,0,3);
          
            return IsAdded;
        }

        [HttpPost]
        public bool Update(ProductModel obj)
        {
            bool Isupdated = false;
           
                Isupdated = dao.GenericUpdate(obj,3);
           
            return Isupdated;
        }

        [HttpPost]
        public bool Delete(ProductModel obj)
        {
            bool IsDeleted = false;           
                IsDeleted = dao.GenericDelete(obj,3);           
            return IsDeleted;
        }
    }
}
