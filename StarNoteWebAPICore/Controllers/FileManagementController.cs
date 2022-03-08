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
    public class FileManagementController : ControllerBase
    {
        IDAO dao;
        FileManagementController()
        {
            dao = DAOBase.GetDAO();
        }

        public List<FilemanagementModel> Getfilelist()
        {
            List<FilemanagementModel> filelist = new List<FilemanagementModel>();
            filelist = dao.GetFileListAll();
            return filelist;
        }

        [HttpPost]
        public bool AddFile(FilemanagementModel objfile)
        {
            bool IsAdded = false;
           
                IsAdded = dao.GenericAdd(objfile);
           
            return IsAdded;
        }

        [HttpPost]
        public bool Delete(FilemanagementModel obj)
        {
            bool IsDeleted = false;
           
                IsDeleted = dao.GenericDelete(obj);
           
            return IsDeleted;
        }
        
    }
}
