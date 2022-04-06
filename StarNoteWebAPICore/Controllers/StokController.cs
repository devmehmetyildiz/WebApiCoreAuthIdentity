using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<StokController> _logger;
        private readonly StarNoteEntity _context;
        UnitOfWork unitOfWork;
        public StokController(ILogger<StokController> logger, StarNoteEntity context)
        {
            _logger = logger;
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }
        [Route("GetStokAll")]
        [HttpGet]
        public List<StokModel> GetStokAll()
        {
            return unitOfWork.StokRepository.GetAll();
        }

        [Route("GetSelectedStock")]
        [HttpGet]
        public StokModel GetStokAll(int ID)
        {
            return unitOfWork.StokRepository.Getbyid(ID);
        }

        [Route("AddStok")]
        [HttpPost]
        public bool AddStok(StokModel objstok)
        {
            bool IsAdded = false;
            unitOfWork.StokRepository.Add(objstok);
            if (unitOfWork.Complate() > 0)
                IsAdded = true;
            return IsAdded;
        }
        [Route("UpdateStok")]
        [HttpPost]
        public bool UpdateStok(StokModel objstok)
        {
            bool Isupdated = false;
            unitOfWork.StokRepository.update(unitOfWork.StokRepository.Getbyid(objstok.Id), objstok);
            if (unitOfWork.Complate() > 0)
                Isupdated = true;
            return Isupdated;
        }
        [Route("GetBirimStokSource")]
        [HttpGet]
        public List<string> GetBirimStokSource()
        {
            return unitOfWork.UnitRepository.GetAll().Select(u => u.Parameter).ToList();
        }
        [Route("GetKdvStokSource")]
        [HttpGet]
        public List<string> GetKdvStokSource()
        {
            return unitOfWork.KdvRepository.GetAll().Select(u => u.Parameter).ToList();
        }
    }
}
