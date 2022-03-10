using StarNoteWebAPICore.EntityDB;
using StarNoteWebAPICore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebAPICore.DataAccess
{
    public class MainDAO : BaseDAO
    {      

        public List<OrderModel> GetAll()
        {
            List<OrderModel> list = new List<OrderModel>();
            List<CostumerOrderModel> costumerlist = new List<CostumerOrderModel>();
            List<JobOrderModel> joborderlist = new List<JobOrderModel>();
            costumerlist = objcontext.tbl_customerorder.ToList();
            joborderlist = objcontext.tbl_joborder.ToList();

            foreach (var item in costumerlist)
            {
                list.Add(new OrderModel
                {
                   Costumerorder = item,
                   Joborder = joborderlist.Where(u=>u.Üstid==item.Id).ToList()
                });;
            }
            return list;
        }

        public List<JobOrderModel> GetSelectedJoborders(int Id)
        {
            List<JobOrderModel> joborderlist = new List<JobOrderModel>();
            try
            {
                joborderlist = objcontext.tbl_joborder.Where(u => u.Üstid == Id).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return joborderlist;
        }

        public int lastmainid()
        {
            int id = 0;
            try
            {                
                var latestId = objcontext.tbl_customerorder.Max(p => p.Id);             
                id = latestId;
            }
            catch (Exception ex)
            {
                throw;
            }            
            return id;
        }

        public bool AddMain(OrderModel model,int savetype)
        {
            bool IsAdded = false;
            bool isdava = false;
            if (model.Costumerorder.Tür != "ÖZEL MÜŞTERİLER" && model.Costumerorder.Tür != "ŞİRKETLER")
                isdava = true;
            try
            {
               
                objcontext.tbl_customerorder.Add(model.Costumerorder);
                int newid = objcontext.tbl_customerorder.Max(u => (int?)u.Id) ?? 0;

                string joborder = "";
                if (!isdava)
                    joborder = Createjoborder();

                int count = 1;
                foreach (var item in model.Joborder)
                {
                    if (isdava)
                    {
                        joborder = count.ToString();
                        count++;
                    }
                    item.Üstid = newid + 1;
                    item.Joborder = joborder;
                    objcontext.tbl_joborder.Add(item);
                    if(!isdava)
                        joborder = (Convert.ToInt32(joborder) + 1).ToString();
                }
                var NoOFRowsAffected = objcontext.SaveChanges();
                IsAdded = NoOFRowsAffected > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsAdded;
        }

        public bool UpdateMain(OrderModel model)
        {
            bool isUpdated = false;
            bool isdava = false;
            if (model.Costumerorder.Tür != "ÖZEL MÜŞTERİLER" && model.Costumerorder.Tür != "ŞİRKETLER")
                isdava = true;
            try
            {               
                 CostumerOrderModel update = objcontext.tbl_customerorder.First(i => i.Id == model.Costumerorder.Id);
                

                string joborder = "";
                 if (!isdava)
                    joborder = Createjoborder();
                 int count = Convert.ToInt32(model.Joborder.Max(u=>u.Joborder));
                 foreach (var item in model.Joborder)
                 {
                     
                      JobOrderModel updatejoborder = objcontext.tbl_joborder.FirstOrDefault(i => i.Üstid == model.Costumerorder.Id && i.Id==item.Id);
                      if (updatejoborder==null)
                      {
                         if (isdava)
                         {
                            count++;
                            joborder = count.ToString();                             
                         }
                        
                        item.Üstid = model.Costumerorder.Id;
                        item.Joborder = joborder;
                          objcontext.tbl_joborder.Add(item);
                          joborder = (Convert.ToInt32(joborder) + 1).ToString();
                     }
                     else
                     {
                        updatejoborder = item;
                     }
                                                   
                 }          
                 objcontext.SaveChanges();
                 isUpdated = true;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isUpdated;
        }

        public List<string> GetSource(string method)
        {
            List<string> source = new List<string>();
            try
            {
                switch (method)
                {
                    case "ödemeyöntem":
                        foreach (var entitiycontext in objcontext.tbl_paymenttype)
                        {
                            source.Add(entitiycontext.Parameter.ToString());
                        }
                        break;
                    case "method":
                        foreach (var entitiycontext in objcontext.tbl_processtype)
                        {
                            source.Add(entitiycontext.Parameter.ToString());
                        }
                        break;
                    case "durum":
                        foreach (var entitiycontext in objcontext.tbl_case)
                        {
                            source.Add(entitiycontext.Parameter.ToString());
                        }
                        break;
                    case "birim":
                        foreach (var entitiycontext in objcontext.tbl_unit)
                        {
                            source.Add(entitiycontext.Parameter.ToString());
                        }
                        break;
                    case "kdv":
                        foreach (var entitiycontext in objcontext.tbl_kdvsource)
                        {
                            source.Add(entitiycontext.Parameter.ToString());
                        }
                        break;
                    case "ürün":
                        foreach (var entitiycontext in objcontext.tbl_stok)
                        {
                            source.Add(entitiycontext.Stokadı.ToString());
                        }
                        break;
                    case "salesman":
                        foreach (var entitiycontext in objcontext.tbl_salesman)
                        {
                            source.Add(entitiycontext.Parameter.ToString());
                        }
                        break;
                    case "tür":
                        foreach (var entitiycontext in objcontext.tbl_type)
                        {
                            source.Add(entitiycontext.Parameter.ToString());
                        }
                        break;
                    case "mainürün":
                        foreach (var entitiycontext in objcontext.tbl_product)
                        {
                            source.Add(entitiycontext.Parameter.ToString());
                        }
                        break;
                    case "tür detay":
                        foreach (var entitiycontext in objcontext.tbl_typedetail)
                        {
                            source.Add(entitiycontext.Parameter.ToString());
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return source;
        }
        
        public OrderModel Getselectedrecord(int id)
        {
            OrderModel model = new OrderModel();           
            
            model.Costumerorder = objcontext.tbl_customerorder.First(u => u.Id == id);            
            model.Joborder = objcontext.tbl_joborder.Where(u => u.Üstid == id).ToList();
          
            return model;
        }

       

        //joborder 21-09-0004

        public string Createjoborder()
        {
            string joborder = "";
            try
            {
                int count = 0;
                string orderID = string.Empty;
                string month = DateTime.Now.Month.ToString("D2"), year = DateTime.Now.Year.ToString();              
                var list = objcontext.tbl_joborder.OrderByDescending(p => p.Id).Take(50);               
                foreach (var item in list)
                {
                    if (item != null && item.Joborder!=null)
                    {
                       if (item.Joborder.Length == 8)
                       {
                          if (int.TryParse(item.Joborder, out int output3))
                          {
                              count++;
                              bool itsyear = false, itsmonth = false, itsorderid = false;
                              string itemyear = "20" + item.Joborder.Substring(0, 2), itemmonth = item.Joborder.Substring(2, 2), itemid = item.Joborder.Substring(4, 4);
                              if (int.TryParse(itemyear, out int output))
                              {
                                  if (Convert.ToInt64(itemyear) <= 2099 && Convert.ToInt64(itemyear) >= 2020)
                                  {
                                      itsyear = true;
                                  }
                              }
                              if (int.TryParse(itemmonth, out int output1))
                              {
                                  if (Convert.ToInt64(itemmonth) >= 01 && Convert.ToInt64(itemmonth) <= 12)
                                  {
                                      itsmonth = true;
                                  }
                              }
                              if (int.TryParse(itemid, out int output2))
                              {
                                  itsorderid = true;
                              }
                              if (itsmonth && itsyear && itsorderid)
                              {
                                  if (itemmonth == month && itemyear == year)
                                  {
                                      int orderid = Convert.ToInt32(itemid) + 1;
                                      joborder = itemyear.Substring(2, 2) + itemmonth + orderid.ToString("D4");
                                        break;
                                  }
                                  else
                                  {
                                      joborder = year.Substring(2, 2) + month + "0001";
                                        break;
                                  }
                              }
                          }
                       }                           
                    }                                       
                }
                if (count == 0)
                {
                    joborder = year.Substring(2, 2) + month + "0001";
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return joborder.ToString();
        }

        //joborderwith 20210902

        public string Createjoborderalternatif()
        {
            int joborder = 0;
            //try
            //{
            //    int count = 0;
            //    string orderID = string.Empty;
            //    string month, year;
            //    month = DateTime.Now.Month.ToString("D2");
            //    year = DateTime.Now.Year.ToString();
            //    var list = objcontext.tbl_customerorder.OrderByDescending(p => p.Id).Take(50);
            //    foreach (var item in list)
            //    {
            //        count++;
            //        if (item != null)
            //        {
            //            //orderID = item.Orderno;
            //            if (orderID.Length == 8 || orderID.Length == 9)
            //            {
            //                if (orderID.Substring(0, 3) == "202" && Convert.ToInt32(orderID.Substring(4, 2)) < 13)
            //                {
            //                    if (orderID.Length >= 8)
            //                    {
            //                        if (orderID.Substring(0, 4) == year && orderID.Substring(4, 2) == month)
            //                        {
            //                            //if (orderID.Length < 9)
            //                            //{
            //                            //    //if (orderID.Substring(6, 2) != "99")
            //                            //        //joborder = (Convert.ToInt32(item.Orderno) + 1);
            //                            //    else
            //                            //        joborder = Convert.ToInt32(year + month + "100");
            //                            //}
            //                            else if (orderID.Length == 9)
            //                            {
            //                                //joborder = Convert.ToInt32(item.Orderno) + 1;
            //                            }
            //                        }
            //                        else
            //                            joborder = Convert.ToInt32(year + month + "01");
            //                    }
            //                    else
            //                        joborder = Convert.ToInt32(year + month + "01");
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //    if (count == 0)
            //    {
            //        joborder = Convert.ToInt32(year + month + "01");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return joborder.ToString();
        }
    }
}