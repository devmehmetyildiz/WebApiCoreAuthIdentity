using StarNoteWebApi.EntitiyDB;
using StarNoteWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.DataAccess
{
    public class RemindingDAO : BaseDAO
    {
 
        public List<string> Filljoborderlist()
        {
            List<string> list = new List<string>();
                         
                var result = (from s in objcontext.tbl_customerorder
                         where s.State != "TAMAMLANDI" && s.Savetype==0
                         select s).ToList();
                foreach (var item in result)
                {
                    string txt = "";
                    txt += item.ID +" - ";
                    txt += item.Orderno + " - ";
                    txt += item.Name + " - ";
                    
                    list.Add(txt);
                }
            
            return list;
        }

        public List<RemindingModel> getoldremindingsforid(int id)
        {
            List<RemindingModel> list = new List<RemindingModel>();
            using (objcontext)
            {
                var items = objcontext.tbl_remember.Where(u => u.Upperid == id).ToList();
                foreach (var item in items)
                {
                    RemindingModel model = new RemindingModel()
                    {
                        ID = item.Id,
                        Anakayıtid = item.Upperid,
                        AnaKayıt = item.Record,
                        AnaKayıtdetay = item.Recorddetail,
                        Hatırlatmadurumu = item.Remindingstatus,
                        Hatırlatmamesajı = item.Remindingmsg,
                        Hatırlatmatipi = item.Remindingtype
                    };
                    list.Add(model);
                }
            }
            return list;
        }

        public List<RemindingModel> Getoldremidings()
        {
            List<RemindingModel> list = new List<RemindingModel>();
            using (objcontext)
            {
                var items = objcontext.tbl_remember.Where(u => u.Remindingstatus == "TAMAMLANDI").ToList();
                foreach (var item in items)
                {
                    RemindingModel model = new RemindingModel()
                    {
                        ID=item.Id,
                        Anakayıtid=item.Upperid,
                        AnaKayıt=item.Record,
                        AnaKayıtdetay=item.Recorddetail,
                        Hatırlatmadurumu=item.Remindingstatus,
                        Hatırlatmamesajı=item.Remindingmsg,
                        Hatırlatmatipi=item.Remindingtype
                    };
                    list.Add(model);
                }
            }
            return list;
        }
        
        public List<RemindingModel> GetselectedRemindingrecords(int Id)
        {
            List<RemindingModel> list = new List<RemindingModel>();
            var result = (from s in objcontext.tbl_remember
                          where s.Remindingstatus != "TAMAMLANDI" && s.Upperid == Id
                          select s).ToList();
            foreach (var entitiycontext in result)
            {
                list.Add(new RemindingModel
                {
                    ID = entitiycontext.Id,
                    AnaKayıt = entitiycontext.Record,
                    Hatırlatmamesajı = entitiycontext.Remindingmsg,
                    AnaKayıtdetay = entitiycontext.Recorddetail,
                    Hatırlatmadurumu = entitiycontext.Remindingstatus,
                    Hatırlatmatipi = entitiycontext.Remindingtype,
                    Anakayıtid = entitiycontext.Upperid
                });
            }
            return list;
        }      

        public List<RemindingModel> GetAllRecords()
        {            
            List<RemindingModel> list = new List<RemindingModel>();           
            try
            {
                var items = objcontext.tbl_remember.Where(u => u.Remindingstatus != "TAMAMLANDI");
                foreach (var entitiycontext in items)
                {
                    list.Add(new RemindingModel
                    {
                        ID = entitiycontext.Id,
                        AnaKayıt = entitiycontext.Record,
                        Hatırlatmamesajı = entitiycontext.Remindingmsg,
                        AnaKayıtdetay = entitiycontext.Recorddetail,
                        Hatırlatmadurumu = entitiycontext.Remindingstatus,
                        Hatırlatmatipi = entitiycontext.Remindingtype,
                        Anakayıtid = entitiycontext.Upperid
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public List<string> Filltypesource()
        {
            List<string> list = new List<string>();
            using (objcontext)
            {
                foreach (var item in objcontext.tbl_remembertype)
                {
                    list.Add(item.Value);
                }
            }
            return list;
        }

        public List<string> Fillstatussource()
        {
            List<string> list = new List<string>();
            using (objcontext)
            {
                foreach (var item in objcontext.tbl_rememberstatus)
                {
                    list.Add(item.Value);                    
                }
            }
            return list;
        }

       

        public bool Add(RemindingModel obj)
        {
            bool IsAdded = false;
            try
            {
                var Objenttiy = new tbl_remember();
                //Objenttiy.ID = objnewstok.Id;
                Objenttiy.Upperid = obj.Anakayıtid;
                Objenttiy.Record = obj.AnaKayıt;
                Objenttiy.Recorddetail = obj.AnaKayıtdetay;
                Objenttiy.Remindingmsg = obj.Hatırlatmamesajı;
                Objenttiy.Remindingstatus = obj.Hatırlatmadurumu;
                Objenttiy.Remindingtype = obj.Hatırlatmatipi;                
                objcontext.tbl_remember.Add(Objenttiy);
                var NoOFRowsAffected = objcontext.SaveChanges();
                IsAdded = NoOFRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsAdded;
        }

        public bool Update(RemindingModel obj)
        {
            bool isUpdated = false;
            try
            {
                using (objcontext)
                {
                    tbl_remember Objenttiy = objcontext.tbl_remember.First(i => i.Id == (obj.ID));

                    Objenttiy.Upperid = obj.Anakayıtid;
                    Objenttiy.Record = obj.AnaKayıt;
                    Objenttiy.Recorddetail = obj.AnaKayıtdetay;
                    Objenttiy.Remindingmsg = obj.Hatırlatmamesajı;
                    Objenttiy.Remindingstatus = obj.Hatırlatmadurumu;
                    Objenttiy.Remindingtype = obj.Hatırlatmatipi;
                    objcontext.SaveChanges();
                    isUpdated = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isUpdated;
        }

      
    }
}