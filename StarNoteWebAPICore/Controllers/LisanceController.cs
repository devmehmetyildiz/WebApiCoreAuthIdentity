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

    public class LisanceController : ControllerBase
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
