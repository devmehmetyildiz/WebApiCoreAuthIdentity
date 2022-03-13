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

    public class TypeController : ControllerBase 
    {
        private readonly ILogger<TypeController> _logger;
        private readonly StarNoteEntity _context;
        UnitOfWork unitOfWork;
        public TypeController(ILogger<TypeController> logger, StarNoteEntity context)
        {
            _logger = logger;
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }
        [Route("GetTürList")]
        [HttpGet]
        public List<TypeModel> GetTürList()
        {
            return unitOfWork.TypeRepository.GetAll();
        }
        [Route("AddTür")]
        [HttpPost]
        public bool AddTür(TypeModel objtür)
        {
            bool IsAdded = false;
            unitOfWork.TypeRepository.Add(objtür);
            if (unitOfWork.Complate() > 0)
                IsAdded = true;
            return IsAdded;
        }
        [Route("UpdateTür")]
        [HttpPost]
        public bool UpdateTür(TypeModel objtür)
        {
            bool Isupdated = false;
            unitOfWork.TypeRepository.update(unitOfWork.TypeRepository.Getbyid(objtür.Id), objtür);
            if (unitOfWork.Complate() > 0)
                Isupdated = true;
            return Isupdated;
        }
        [Route("DeleteTür")]
        [HttpPost]
        public bool DeleteTür(TypeModel objtür)
        {
            bool IsDeleted = false;
            unitOfWork.TypeRepository.Remove(objtür.Id);
            if (unitOfWork.Complate() > 0)
                IsDeleted = true;
            return IsDeleted;
        }
    }
}
