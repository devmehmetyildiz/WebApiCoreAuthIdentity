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
    //[Authorize]

    public class LisanceController : ApiController
    {
        IDAO dao;
        LisanceController()
        {
            dao = DAOBase.GetDAO();
        }

        [HttpGet]
        public List<LisanceModel> GetLisanceAll()
        {
            List<LisanceModel> response = new List<LisanceModel>();
            response = dao.GetAllLisance();
            return response;
        }

        [HttpGet]
        public List<LisanceModel> Updatestatus(int id,string status)
        {
            List<LisanceModel> response = new List<LisanceModel>();
            //response = dataaccess.GetAll(count);
            return response;
        }

        [HttpPost]
        public bool AddLisance(LisanceModel lisancemodel)
        {
            bool IsAdded = false;
            IsAdded = dao.GenericAdd(lisancemodel);
            return IsAdded;
        }

    }
}
