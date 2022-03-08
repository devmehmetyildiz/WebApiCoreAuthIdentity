using StarNoteWebApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StarNoteWebApi.Models;
using StarNoteWebApi.DataAccess;
namespace StarNoteWebApi.Controllers
{
   
    [Authorize]
    public class CompanyController : ApiController
    {
        IDAO dao;
        CompanyController()
        {
            dao = DAOBase.GetDAO();
        }
        //CompanyDAO dataaccess = new CompanyDAO();
            public List<CompanyModel> GetAll()
            {
                List<CompanyModel> list = new List<CompanyModel>();
                list = dao.GetAllCompany();
                return list;
            }
    
            [HttpPost]
            public bool Add(CompanyModel obj)
            {
                bool IsAdded = false;
               
                    IsAdded = dao.GenericAdd(obj);
               
                return IsAdded;
            }

        [HttpPost]
        public bool Update(CompanyModel obj)
        {
            bool Isupdated = false;
           
                Isupdated = dao.GenericUpdate(obj);
           
            return Isupdated;
        }

        [HttpPost]
        public bool Delete(CompanyModel obj)
        {
            bool IsDeleted = false;
          
                IsDeleted = dao.GenericDelete(obj);
           
            return IsDeleted;
        }
    }
    }
