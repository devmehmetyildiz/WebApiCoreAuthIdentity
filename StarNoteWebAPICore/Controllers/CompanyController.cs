using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using StarNoteWebAPICore.Models;
using StarNoteWebAPICore.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace StarNoteWebAPICore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly StarNoteEntity _context;
        UnitOfWork unitOfWork;
        public CompanyController(ILogger<CompanyController> logger, StarNoteEntity context)
        {
            _logger = logger;
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }
       
        [Route("GetAll")]
        [HttpGet]
        public List<CompanyModel> GetAll()
        {          
            return unitOfWork.CompanyRepository.GetAll();
        }

        [HttpPost]
        [Route("Add")]
        public bool Add(CompanyModel obj)
        {
            bool IsAdded = false;
            unitOfWork.CompanyRepository.Add(obj);
            if (unitOfWork.Complate() > 0)
                IsAdded = true;
            return IsAdded;
        }
        [Route("Update")]
        [HttpPost]
        public bool Update(CompanyModel obj)
        {
            bool Isupdated = false;
            unitOfWork.CompanyRepository.update(unitOfWork.CompanyRepository.Getbyid(obj.Id), obj);
            if (unitOfWork.Complate() > 0)
                Isupdated = true;
            return Isupdated;
        }
        [Route("Delete")]
        [HttpPost]
        public bool Delete(CompanyModel obj)
        {
            bool IsDeleted = false;
            unitOfWork.CompanyRepository.Remove(obj.Id);
            if (unitOfWork.Complate() > 0)
                IsDeleted = true;
            return IsDeleted;
        }
    }
    }
