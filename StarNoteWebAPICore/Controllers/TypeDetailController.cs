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
    public class TypeDetailController : ControllerBase
    {
        private readonly ILogger<TypeDetailController> _logger;
        private readonly StarNoteEntity _context;
        UnitOfWork unitOfWork;
        public TypeDetailController(ILogger<TypeDetailController> logger, StarNoteEntity context)
        {
            _logger = logger;
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }
        [Route("GetTürdetayList")]
        [HttpGet]
        public List<TypedetailModel> GetTürdetayList()
        {
            return unitOfWork.TypedetailRepository.GetAll();
        }
        [Route("AddTürdetay")]
        [HttpPost]
        public bool AddTürdetay(TypedetailModel objtür)
        {
            bool IsAdded = false;
            unitOfWork.TypedetailRepository.Add(objtür);
            if (unitOfWork.Complate() > 0)
                IsAdded = true;
            return IsAdded;
        }
        [Route("UpdateTürdetay")]
        [HttpPost]
        public bool UpdateTürdetay(TypedetailModel objtür)
        {
            bool Isupdated = false;
            unitOfWork.TypedetailRepository.update(unitOfWork.TypedetailRepository.Getbyid(objtür.Id), objtür);
            if (unitOfWork.Complate() > 0)
                Isupdated = true;
            return Isupdated;
        }
        [Route("DeleteTürdetay")]
        [HttpPost]
        public bool DeleteTürdetay(TypedetailModel objtür)
        {
            bool IsDeleted = false;
            unitOfWork.TypedetailRepository.Remove(objtür.Id);
            if (unitOfWork.Complate() > 0)
                IsDeleted = true;
            return IsDeleted;
        }
    }
}
