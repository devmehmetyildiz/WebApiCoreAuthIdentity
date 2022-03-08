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
    public class StokController : Controller
    {
        IDAO dao;
        StokController()
        {
            dao = DAOBase.GetDAO();
        }
        [HttpGet]
        public List<StokModel> GetStokAll()
        {
            List<StokModel> response = new List<StokModel>();
            response = dao.GetStokAll();
            return response;
        }

        [HttpPost]
        public bool AddStok(StokModel objstok)
        {
            bool IsAdded = false;
            
                IsAdded = dao.GenericAdd(objstok);
           
            return IsAdded;
        }

        [HttpPost]
        public bool UpdateStok(StokModel objstok)
        {
            bool Isupdated = false;
           
                Isupdated = dao.GenericUpdate(objstok);
           
            return Isupdated;
        }

        [HttpGet]
        public List<string> GetBirimStokSource()
        {
            List<string> source = new List<string>();
            source = dao.BirimStokSourcelist();
            return source;
        }

        [HttpGet]
        public List<string> GetKdvStokSource()
        {
            List<string> source = new List<string>();
            source = dao.KdvStokSourcelist();
            return source;
        }
    }
}
