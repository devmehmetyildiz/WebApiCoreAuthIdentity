using StarNoteWebApi.EntitiyDB;
using StarNoteWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.DataAccess
{
    public class MainDAO : BaseDAO
    {      

        public List<OrderModel> GetAll()
        {
            List<OrderModel> list = new List<OrderModel>();
            CostumerOrderModel costumerorder = new CostumerOrderModel();
           
            try
            {
                var items = objcontext.tbl_customerorder.ToList();
                foreach (var entitiycontext in items)
                {
                    costumerorder = (new CostumerOrderModel
                    {
                        Id = entitiycontext.ID,
                        Siparişno = entitiycontext.Orderno,
                        Kayıtdetay =entitiycontext.Orderdetail,
                        Kayıtdetay1=entitiycontext.Orderdetail1,
                        Kayıtdetay2=entitiycontext.Orderdetail2,
                        Türdetay=entitiycontext.Typedetail,
                        Tür = entitiycontext.Type,
                        İsim = entitiycontext.Name,
                        Adres = entitiycontext.Address,
                        Acıklama = entitiycontext.Info,                        
                        Durum = entitiycontext.State,
                        Eposta = entitiycontext.Email,
                        Firmaadresi = entitiycontext.Companyaddress,
                        Firmaadı = entitiycontext.Companyname,                       
                        Kayıttarihi = entitiycontext.Registerdate,
                        Satışyöntemi = entitiycontext.Salesmethod,                                         
                        Randevutarihi = entitiycontext.Daliverydate,
                        Tckimlik = entitiycontext.Tc,
                        Satıselemanı = entitiycontext.Salesman,
                        Telefon = entitiycontext.Phone,
                        Vergidairesi = entitiycontext.Taxaddress,
                        Vergino = entitiycontext.Taxnumber,
                        Ödemeyöntemi = entitiycontext.Paymentmethod,
                        Ücret = (double)entitiycontext.Price,
                        Önödeme = (double)entitiycontext.Prepayment,
                        İlçe = entitiycontext.Town,
                        Şehir = entitiycontext.City,
                        Kullanıcı = entitiycontext.Usercreated,
                        Kdv = entitiycontext.Kdv,                       
                        Beklenentutar =(double)entitiycontext.Pricewaiting,
                        Savetype=(int)entitiycontext.Savetype,
                        Talimatadliye = entitiycontext.TalimatAdliye,
                        Talimatkararno=entitiycontext.TalimatKararno,
                        Talimatmahkeme = entitiycontext.TalimatMahkeme
                        
                    });
                    var joborders = objcontext.tbl_joborder.Where(u => u.Upperid == entitiycontext.ID).ToList();
                    List<JobOrderModel> joborderlist = new List<JobOrderModel>();
                    foreach (var item in joborders)
                    {
                        joborderlist.Add(new JobOrderModel
                        {
                            Id=item.Id,
                            Ürün=item.Product,
                            Joborder = item.JobOrderNo,
                            Ürün2=item.Product2,
                            Ürün2detay=item.Producttype,
                            Ücret=(double)item.Price,
                            Acıklama=item.Info,
                            Birim=item.Amounttype,
                            Durum=item.State,
                            Üstid=(int)item.Upperid,
                            Hesaplananadet=(int)item.Countedamount,
                            Hesaplanantutar=(double)item.Countedprice,
                            Karaktersayı=(int)item.Numberofchar,
                            Kelimesayı=(int)item.Numberofword,
                            Miktar=(int)item.Amount,
                            Satırsayı=(int)item.Numberofline,
                            Tavsiyeedilentutar=(double)item.Suggestedprice
                        });
                    }                 
                    list.Add(new OrderModel
                    {
                        Costumerorder = costumerorder,
                        Joborder = joborderlist
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public List<JobOrderModel> GetSelectedJoborders(int Id)
        {
            List<JobOrderModel> joborderlist = new List<JobOrderModel>();
            try
            {
                var joborders = objcontext.tbl_joborder.Where(u => u.Upperid == Id).ToList();

                foreach (var item in joborders)
                {
                    joborderlist.Add(new JobOrderModel
                    {
                        Id = item.Id,
                        Ürün = item.Product,
                        Joborder=item.JobOrderNo,
                        Ürün2 = item.Product2,
                        Ürün2detay = item.Producttype,
                        Ücret = (double)item.Price,
                        Acıklama = item.Info,
                        Birim = item.Amounttype,
                        Durum = item.State,
                        Üstid = (int)item.Upperid,
                        Hesaplananadet = (int)item.Countedamount,
                        Hesaplanantutar = (double)item.Countedprice,
                        Karaktersayı = (int)item.Numberofchar,
                        Kelimesayı = (int)item.Numberofword,
                        Miktar = (int)item.Amount,
                        Satırsayı = (int)item.Numberofline,
                        Tavsiyeedilentutar = (double)item.Suggestedprice
                    });
                }              
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
                var latestId = objcontext.tbl_customerorder.Max(p => p.ID);             
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
                tbl_customerorder modelcostumer = new tbl_customerorder()
                {
                    Type = model.Costumerorder.Tür,
                    Orderno = model.Costumerorder.Siparişno,
                    Typedetail = model.Costumerorder.Türdetay,
                    Orderdetail = model.Costumerorder.Kayıtdetay,
                    Orderdetail1 = model.Costumerorder.Kayıtdetay1,
                    Orderdetail2 = model.Costumerorder.Kayıtdetay2,
                    Name = model.Costumerorder.İsim,
                    Phone = model.Costumerorder.Telefon,
                    Address = model.Costumerorder.Adres,
                    City = model.Costumerorder.Şehir,
                    Companyaddress = model.Costumerorder.Firmaadresi,
                    Companyname = model.Costumerorder.Firmaadı,
                    Email = model.Costumerorder.Eposta,
                    Info = model.Costumerorder.Acıklama,
                    Kdv = model.Costumerorder.Kdv,
                    Paymentmethod = model.Costumerorder.Ödemeyöntemi,
                    Price = model.Costumerorder.Ücret,
                    Daliverydate = model.Costumerorder.Randevutarihi,
                    Registerdate = model.Costumerorder.Kayıttarihi,
                    Savetype = model.Costumerorder.Savetype,
                    Salesmethod = model.Costumerorder.Satışyöntemi,
                    Salesman = model.Costumerorder.Satıselemanı,
                    State = model.Costumerorder.Durum,
                    Taxaddress = model.Costumerorder.Vergidairesi,
                    Taxnumber = model.Costumerorder.Vergino,
                    Tc = model.Costumerorder.Tckimlik,
                    Town = model.Costumerorder.İlçe,
                    Usercreated = model.Costumerorder.Kullanıcı,
                    Pricewaiting = model.Costumerorder.Beklenentutar,
                    Prepayment = model.Costumerorder.Önödeme,
                    TalimatAdliye= model.Costumerorder.Talimatadliye,
                    TalimatKararno= model.Costumerorder.Talimatkararno,
                    TalimatMahkeme = model.Costumerorder.Talimatmahkeme

                };
                objcontext.tbl_customerorder.Add(modelcostumer);
                int newid = objcontext.tbl_customerorder.Max(u => (int?)u.ID) ?? 0;

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
                    tbl_joborder modeljoborder = new tbl_joborder()
                    {
                        Upperid = newid + 1,
                        JobOrderNo = joborder,
                        Product = item.Ürün,
                        Product2 = item.Ürün2,
                        Producttype = item.Ürün2detay,
                        Amounttype = item.Birim,
                        Info = item.Acıklama,
                        Amount = item.Miktar,
                        Price = item.Ücret,
                        State = item.Durum,
                        Countedamount = item.Hesaplananadet,
                        Countedprice = item.Hesaplanantutar,
                        Numberofchar = item.Karaktersayı,
                        Numberofline = item.Kelimesayı,
                        Numberofword = item.Satırsayı,
                        Suggestedprice = item.Tavsiyeedilentutar
                    };
                    objcontext.tbl_joborder.Add(modeljoborder);
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
                 tbl_customerorder update = objcontext.tbl_customerorder.First(i => i.ID == model.Costumerorder.Id);
                 update.Type = model.Costumerorder.Tür;
                 update.Orderno = model.Costumerorder.Siparişno;
                 update.Typedetail = model.Costumerorder.Türdetay;
                 update.Orderdetail = model.Costumerorder.Kayıtdetay;
                 update.Orderdetail1 = model.Costumerorder.Kayıtdetay1;
                 update.Orderdetail2 = model.Costumerorder.Kayıtdetay2;
                 update.Name = model.Costumerorder.İsim;
                 update.Phone = model.Costumerorder.Telefon;
                 update.Address = model.Costumerorder.Adres;
                 update.City = model.Costumerorder.Şehir;
                 update.Companyaddress = model.Costumerorder.Firmaadresi;
                 update.Companyname = model.Costumerorder.Firmaadı;
                 update.Email = model.Costumerorder.Eposta;
                 update.Info = model.Costumerorder.Acıklama;
                 update.Kdv = model.Costumerorder.Kdv;
                 update.Paymentmethod = model.Costumerorder.Ödemeyöntemi;
                 update.Price = model.Costumerorder.Ücret;
                 update.Daliverydate = model.Costumerorder.Randevutarihi;
                 update.Registerdate = model.Costumerorder.Kayıttarihi;
                 update.Savetype = model.Costumerorder.Savetype;
                 update.Salesmethod = model.Costumerorder.Satışyöntemi;
                 update.Salesman = model.Costumerorder.Satıselemanı;
                 update.State = model.Costumerorder.Durum;
                 update.Taxaddress = model.Costumerorder.Vergidairesi;
                 update.Taxnumber = model.Costumerorder.Vergino;
                 update.Tc = model.Costumerorder.Tckimlik;
                 update.Town = model.Costumerorder.İlçe;
                 update.Usercreated = model.Costumerorder.Kullanıcı;
                 update.Pricewaiting = model.Costumerorder.Beklenentutar;
                 update.Prepayment = model.Costumerorder.Önödeme;
                 update.TalimatMahkeme = model.Costumerorder.Talimatmahkeme;
                 update.TalimatKararno = model.Costumerorder.Talimatkararno;
                 update.TalimatAdliye = model.Costumerorder.Talimatadliye;

                string joborder = "";
                 if (!isdava)
                    joborder = Createjoborder();
                 int count = Convert.ToInt32(model.Joborder.Max(u=>u.Joborder));
                 foreach (var item in model.Joborder)
                 {
                     
                      tbl_joborder updatejoborder = objcontext.tbl_joborder.FirstOrDefault(i => i.Upperid == model.Costumerorder.Id && i.Id==item.Id);
                      if (updatejoborder==null)
                      {
                         if (isdava)
                         {
                            count++;
                            joborder = count.ToString();                             
                         }
                         tbl_joborder addjoborder = new tbl_joborder();
                          addjoborder.Upperid = model.Costumerorder.Id;
                          addjoborder.JobOrderNo = joborder;
                          addjoborder.Product = item.Ürün;
                          addjoborder.Product2 = item.Ürün2;
                          addjoborder.Producttype = item.Ürün2detay;
                          addjoborder.Amounttype = item.Birim;
                          addjoborder.Info = item.Acıklama;
                          addjoborder.Amount = item.Miktar;
                          addjoborder.Price = item.Ücret;
                          addjoborder.State = item.Durum;
                          addjoborder.Countedamount = item.Hesaplananadet;
                          addjoborder.Countedprice = item.Hesaplanantutar;
                          addjoborder.Numberofchar = item.Karaktersayı;
                          addjoborder.Numberofline = item.Kelimesayı;
                          addjoborder.Numberofword = item.Satırsayı;
                          addjoborder.Suggestedprice = item.Tavsiyeedilentutar;
                          objcontext.tbl_joborder.Add(addjoborder);
                          joborder = (Convert.ToInt32(joborder) + 1).ToString();
                     }
                     else
                     {
                         updatejoborder.Upperid = model.Costumerorder.Id;
                         updatejoborder.JobOrderNo = item.Joborder;
                         updatejoborder.Product = item.Ürün;
                         updatejoborder.Product2 = item.Ürün2;
                         updatejoborder.Producttype = item.Ürün2detay;
                         updatejoborder.Amounttype = item.Birim;
                         updatejoborder.Info = item.Acıklama;
                         updatejoborder.Amount = item.Miktar;
                         updatejoborder.Price = item.Ücret;
                         updatejoborder.State = item.Durum;
                         updatejoborder.Countedamount = item.Hesaplananadet;
                         updatejoborder.Countedprice = item.Hesaplanantutar;
                         updatejoborder.Numberofchar = item.Karaktersayı;
                         updatejoborder.Numberofline = item.Kelimesayı;
                         updatejoborder.Numberofword = item.Satırsayı;
                         updatejoborder.Suggestedprice = item.Tavsiyeedilentutar;
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
                            source.Add(entitiycontext.Value.ToString());
                        }
                        break;
                    case "method":
                        foreach (var entitiycontext in objcontext.tbl_processtype)
                        {
                            source.Add(entitiycontext.Value.ToString());
                        }
                        break;
                    case "durum":
                        foreach (var entitiycontext in objcontext.tbl_case)
                        {
                            source.Add(entitiycontext.Value.ToString());
                        }
                        break;
                    case "birim":
                        foreach (var entitiycontext in objcontext.tbl_unit)
                        {
                            source.Add(entitiycontext.Value.ToString());
                        }
                        break;
                    case "kdv":
                        foreach (var entitiycontext in objcontext.tbl_kdvsource)
                        {
                            source.Add(entitiycontext.Value.ToString());
                        }
                        break;
                    case "ürün":
                        foreach (var entitiycontext in objcontext.tbl_stok)
                        {
                            source.Add(entitiycontext.Name.ToString());
                        }
                        break;
                    case "salesman":
                        foreach (var entitiycontext in objcontext.tbl_salesman)
                        {
                            source.Add(entitiycontext.Value.ToString());
                        }
                        break;
                    case "tür":
                        foreach (var entitiycontext in objcontext.tbl_type)
                        {
                            source.Add(entitiycontext.Value.ToString());
                        }
                        break;
                    case "mainürün":
                        foreach (var entitiycontext in objcontext.tbl_product)
                        {
                            source.Add(entitiycontext.Value.ToString());
                        }
                        break;
                    case "tür detay":
                        foreach (var entitiycontext in objcontext.tbl_typedetail)
                        {
                            source.Add(entitiycontext.Value.ToString());
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
            CostumerOrderModel costumerorder = new CostumerOrderModel();
            var entitiycontext = objcontext.tbl_customerorder.First(u => u.ID == id);            
            costumerorder = (new CostumerOrderModel
            {
                Id = entitiycontext.ID,
                Siparişno = entitiycontext.Orderno,
                Kayıtdetay = entitiycontext.Orderdetail,
                Kayıtdetay1 = entitiycontext.Orderdetail1,
                Kayıtdetay2 = entitiycontext.Orderdetail2,
                Türdetay = entitiycontext.Typedetail,
                Tür = entitiycontext.Type,
                İsim = entitiycontext.Name,
                Adres = entitiycontext.Address,
                Acıklama = entitiycontext.Info,
                Durum = entitiycontext.State,
                Eposta = entitiycontext.Email,
                Firmaadresi = entitiycontext.Companyaddress,
                Firmaadı = entitiycontext.Companyname,
                Kayıttarihi = entitiycontext.Registerdate,
                Satışyöntemi = entitiycontext.Paymentmethod,
                Randevutarihi = entitiycontext.Daliverydate,
                Tckimlik = entitiycontext.Tc,
                Satıselemanı = entitiycontext.Salesman,
                Telefon = entitiycontext.Phone,
                Vergidairesi = entitiycontext.Taxaddress,
                Vergino = entitiycontext.Taxnumber,
                Ödemeyöntemi = entitiycontext.Paymentmethod,
                Ücret = (double)entitiycontext.Price,
                İlçe = entitiycontext.Town,
                Şehir = entitiycontext.City,
                Kullanıcı = entitiycontext.Usercreated,
                Kdv = entitiycontext.Kdv,
                Beklenentutar = (double)entitiycontext.Pricewaiting,
                Savetype=(int)entitiycontext.Savetype,
                Önödeme = (double)entitiycontext.Prepayment,
                Talimatadliye = entitiycontext.TalimatAdliye,
                Talimatkararno = entitiycontext.TalimatKararno,
                Talimatmahkeme= entitiycontext.TalimatMahkeme
            });
            var joborders = objcontext.tbl_joborder.Where(u => u.Upperid == id).ToList();
            List<JobOrderModel> joborderlist = new List<JobOrderModel>();
            foreach (var item in joborders)
            {
                joborderlist.Add(new JobOrderModel
                {
                    Id = item.Id,
                    Ürün = item.Product,
                    Ürün2 = item.Product2,
                    Ürün2detay = item.Producttype,
                    Ücret = (double)item.Price,
                    Acıklama = item.Info,
                    Birim = item.Amounttype,
                    Durum = item.State,
                    Üstid = (int)item.Upperid,
                    Hesaplananadet = (int)item.Countedamount,
                    Hesaplanantutar = (double)item.Countedprice,
                    Karaktersayı = (int)item.Numberofchar,
                    Kelimesayı = (int)item.Numberofword,
                    Miktar = (int)item.Amount,
                    Satırsayı = (int)item.Numberofline,
                    Tavsiyeedilentutar = (double)item.Suggestedprice
                });
            }
            OrderModel model = new OrderModel
            {
                Costumerorder = costumerorder,
                Joborder = joborderlist
            };   
            return model;
        }

        public List<string> joborderlist()
        {
            List<string> joborderlist = new List<string>();
            foreach (var entitiycontext in objcontext.tbl_customerorder)
            {
                if (entitiycontext.Orderno!=String.Empty && entitiycontext.Savetype==0 )
                {
                    if (entitiycontext.Orderno.ToString().Length == 8|| entitiycontext.Orderno.ToString().Length == 9)
                    {
                        joborderlist.Add(entitiycontext.Orderno);
                    }
                    
                }              
            }
            joborderlist.Sort();
            joborderlist.Reverse();
            return joborderlist;
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
                    if (item != null && item.JobOrderNo!=null)
                    {
                       if (item.JobOrderNo.Length == 8)
                       {
                          if (int.TryParse(item.JobOrderNo, out int output3))
                          {
                              count++;
                              bool itsyear = false, itsmonth = false, itsorderid = false;
                              string itemyear = "20" + item.JobOrderNo.Substring(0, 2), itemmonth = item.JobOrderNo.Substring(2, 2), itemid = item.JobOrderNo.Substring(4, 4);
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
            try
            {
                int count = 0;
                string orderID = string.Empty;
                string month, year;
                month = DateTime.Now.Month.ToString("D2");
                year = DateTime.Now.Year.ToString();
                var list = objcontext.tbl_customerorder.OrderByDescending(p => p.ID).Take(50);
                foreach (var item in list)
                {
                    count++;
                    if (item != null)
                    {
                        orderID = item.Orderno;
                        if (orderID.Length == 8 || orderID.Length == 9)
                        {
                            if (orderID.Substring(0, 3) == "202" && Convert.ToInt32(orderID.Substring(4, 2)) < 13)
                            {
                                if (orderID.Length >= 8)
                                {
                                    if (orderID.Substring(0, 4) == year && orderID.Substring(4, 2) == month)
                                    {
                                        if (orderID.Length < 9)
                                        {
                                            if (orderID.Substring(6, 2) != "99")
                                                joborder = (Convert.ToInt32(item.Orderno) + 1);
                                            else
                                                joborder = Convert.ToInt32(year + month + "100");
                                        }
                                        else if (orderID.Length == 9)
                                        {
                                            joborder = Convert.ToInt32(item.Orderno) + 1;
                                        }
                                    }
                                    else
                                        joborder = Convert.ToInt32(year + month + "01");
                                }
                                else
                                    joborder = Convert.ToInt32(year + month + "01");
                                break;
                            }
                        }
                    }
                }
                if (count == 0)
                {
                    joborder = Convert.ToInt32(year + month + "01");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return joborder.ToString();
        }
    }
}