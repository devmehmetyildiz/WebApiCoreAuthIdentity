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
    public class FileManagementController : ApiController
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
