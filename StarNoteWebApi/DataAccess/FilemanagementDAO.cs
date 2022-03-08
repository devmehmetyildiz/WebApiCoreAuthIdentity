using StarNoteWebApi.EntitiyDB;
using StarNoteWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.DataAccess
{
    public class FilemanagementDAO : BaseDAO
    {
        public List<FilemanagementModel> GetFileListAll()
        {
            List<FilemanagementModel> objfile = new List<FilemanagementModel>();
            try
            {
                using (objcontext)
                {
                    foreach (var entitiycontext in objcontext.tbl_filemanagement)
                    {
                        objfile.Add(new FilemanagementModel
                        {
                            Id = entitiycontext.ID,
                            Mainid = (int)entitiycontext.MainID,
                            Türdetay = entitiycontext.TypeDetail,
                            Kayıtdetay = entitiycontext.OrderDetail,
                            Türadı = entitiycontext.Typename,
                            Firmadı = entitiycontext.Companyname,
                            Dosyaadı = entitiycontext.Filename,
                            Müşteriadı = entitiycontext.Costumername,
                            Klasörno = entitiycontext.Fileno
                        });
                    }
                }
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
                var Objenttiy = new tbl_filemanagement()
                {
                    Typename = model.Türadı,
                    OrderDetail = model.Kayıtdetay,
                    TypeDetail = model.Türdetay,
                    MainID = model.Mainid,
                    Companyname = model.Firmadı,
                    Costumername = model.Müşteriadı,
                    Filename = model.Dosyaadı,
                    Fileno = model.Klasörno
                };
                objcontext.tbl_filemanagement.Add(Objenttiy);
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
                    var salesmanrecord = new tbl_filemanagement { ID = obj.Id };
                    objcontext.Entry(salesmanrecord).State = EntityState.Deleted;
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
            var items = objcontext.tbl_filemanagement.Where(u => u.MainID == id);
            foreach (var item in items)
            {
                FilemanagementModel model = new FilemanagementModel()
                {
                    Id = item.ID,
                    Dosyaadı = item.Filename,
                    Firmadı = item.Companyname,
                    Kayıtdetay = item.OrderDetail,
                    Mainid = (int)item.MainID,
                    Müşteriadı = item.Costumername,
                    Türadı = item.Typename,
                    Türdetay = item.TypeDetail,
                    Klasörno = item.Fileno
                };
                list.Add(model);
            }
            return list;
        }
    }
}