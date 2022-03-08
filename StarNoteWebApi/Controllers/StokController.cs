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
    public class StokController : ApiController
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
