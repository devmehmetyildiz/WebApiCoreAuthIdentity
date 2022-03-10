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

    public class LisanceController : ControllerBase
    {
       
        private readonly ILogger<LisanceController> _logger;
        private readonly StarNoteEntity _context;
        UnitOfWork unitOfWork;
        public LisanceController(ILogger<LisanceController> logger, StarNoteEntity context)
        {
            _logger = logger;
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }

        [Route("GetAll")]
        [HttpGet]
        public List<LisanceModel> GetAll()
        {
            List<LisanceModel> response = new List<LisanceModel>();
            unitOfWork.LisanceRepository.GetAll();
            return response;
        }
        [Route("AddLisance")]
        [HttpPost]
        public bool AddLisance(LisanceModel lisancemodel)
        {
            bool IsAdded = false;
            unitOfWork.LisanceRepository.Add(lisancemodel);
            if (unitOfWork.Complate() > 0)
                IsAdded = true;
            return IsAdded;
        }

    }
}
