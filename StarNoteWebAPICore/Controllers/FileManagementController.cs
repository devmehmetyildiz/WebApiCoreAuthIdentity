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
    public class FileManagementController : ControllerBase
    {
        private readonly ILogger<FileManagementController> _logger;
        private readonly StarNoteEntity _context;
        UnitOfWork unitOfWork;
        public FileManagementController(ILogger<FileManagementController> logger, StarNoteEntity context)
        {
            _logger = logger;
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }
        [Route("Getfilelist")]
        [HttpGet]
        public List<FilemanagementModel> Getfilelist()
        {
            List<FilemanagementModel> filelist = new List<FilemanagementModel>();
            filelist =  unitOfWork.FilemanagementRepository.GetAll();
            return filelist;
        }

        [HttpPost]
        [Route("AddFile")]
        public bool AddFile(FilemanagementModel objfile)
        {
            bool IsAdded = false;
            unitOfWork.FilemanagementRepository.Add(objfile);
            if (unitOfWork.Complate() > 0)
                IsAdded = true;
            return IsAdded;
        }

        [HttpPost]
        [Route("Delete")]
        public bool Delete(FilemanagementModel obj)
        {
            bool IsDeleted = false;
            unitOfWork.FilemanagementRepository.Remove(obj.Id);
            if (unitOfWork.Complate() > 0)
                IsDeleted = true;
            return IsDeleted;
        }
        
    }
}
