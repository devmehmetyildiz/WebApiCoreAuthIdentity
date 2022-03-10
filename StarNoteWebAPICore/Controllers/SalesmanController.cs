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
    public class SalesmanController : ControllerBase
    {
        private readonly ILogger<SalesmanController> _logger;
        private readonly StarNoteEntity _context;
        UnitOfWork unitOfWork;
        public SalesmanController(ILogger<SalesmanController> logger, StarNoteEntity context)
        {
            _logger = logger;
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }
        [Route("GetAll")]
        [HttpGet]
        public List<SalesmanModel> GetSalesmanList()
        {
           return unitOfWork.SalesmanRepository.GetAll();
        }
        [HttpPost]
        [Route("AddSalesman")]
        public bool AddSalesman(SalesmanModel objsalesman)
        {
            bool IsAdded = false;
            unitOfWork.SalesmanRepository.Add(objsalesman);
            if (unitOfWork.Complate() > 0)
                IsAdded = true;
            return IsAdded;
        }

        [Route("UpdateSalesman")]
        [HttpPost]
        public bool UpdateSalesman(SalesmanModel objsalesman)
        {
            bool Isupdated = false;
            unitOfWork.SalesmanRepository.update(unitOfWork.SalesmanRepository.Getbyid(objsalesman.Id), objsalesman);
            if (unitOfWork.Complate() > 0)
                Isupdated = true;
            return Isupdated;
        }

        [Route("DeleteSalesman")]
        [HttpPost]
        public bool DeleteSalesman(SalesmanModel objsalesman)
        {
            bool IsDeleted = false;
            unitOfWork.CompanyRepository.Remove(objsalesman.Id);
            if (unitOfWork.Complate() > 0)
                IsDeleted = true;
            return IsDeleted;
        }
    }
}
