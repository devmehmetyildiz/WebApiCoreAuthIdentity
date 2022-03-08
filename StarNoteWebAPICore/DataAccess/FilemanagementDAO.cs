using Microsoft.EntityFrameworkCore;
using StarNoteWebAPICore.EntityDB;
using StarNoteWebAPICore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StarNoteWebAPICore.DataAccess
{
    public class FilemanagementDAO : BaseDAO
    {
        public List<FilemanagementModel> GetFileListAll()
        {
            List<FilemanagementModel> objfile = new List<FilemanagementModel>();
            try
            {
                objfile = objcontext.tbl_filemanagement.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objfile;
        }

        public bool AddFile(FilemanagementModel model)
        {
            bool IsAdded = false;
            try
            {               
                objcontext.tbl_filemanagement.Add(model);
                var NoOFRowsAffected = objcontext.SaveChanges();
                IsAdded = NoOFRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsAdded;
        }

        public bool DeleteFile(FilemanagementModel obj)
        {
            bool isDeleted = false;
            try
            {
                using (objcontext)
                {                   
                    objcontext.Entry(obj).State = EntityState.Deleted;
                    objcontext.SaveChanges();
                    isDeleted = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isDeleted;
        }

        public List<FilemanagementModel> Getselectedfilelist(int id)
        {
            List<FilemanagementModel> list = new List<FilemanagementModel>();
            list = objcontext.tbl_filemanagement.Where(u => u.Mainid == id).ToList();           
            return list;
        }
    }
}