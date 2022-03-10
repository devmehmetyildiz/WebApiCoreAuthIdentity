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
    public class CostumerController : ControllerBase
    {
        private readonly ILogger<CostumerController> _logger;
        private readonly StarNoteEntity _context;
        UnitOfWork unitOfWork;
        public CostumerController(ILogger<CostumerController> logger, StarNoteEntity context)
        {
            _logger = logger;
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }
        [Route("GetAll")]
        [HttpGet]
        public List<CostumerModel> GetAll()
        {
            List<CostumerModel> list = new List<CostumerModel>();
            unitOfWork.CostumerRepository.GetAll();
            return list;
        }

        [HttpPost]
        [Route("Add")]
        public bool Add(CostumerModel obj)
        {
            bool IsAdded = false;
            unitOfWork.CostumerRepository.Add(obj);
            if (unitOfWork.Complate() > 0)
                IsAdded = true;
            return IsAdded;
        }

        [HttpPost]
        [Route("Update")]
        public bool Update(CostumerModel obj)
        {
            bool Isupdated = false;
            unitOfWork.CostumerRepository.update(unitOfWork.CostumerRepository.Getbyid(obj.Id), obj);
            if (unitOfWork.Complate() > 0)
                Isupdated = true;
            return Isupdated;
        }

        [HttpPost]
        [Route("Delete")]
        public bool Delete(CostumerModel obj)
        {
            bool IsDeleted = false;
            unitOfWork.CostumerRepository.Remove(obj.Id);
            if (unitOfWork.Complate() > 0)
                IsDeleted = true;
            return IsDeleted;
        }
    }
}
