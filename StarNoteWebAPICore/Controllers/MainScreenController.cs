using StarNoteWebAPICore.DataAccess;
using StarNoteWebAPICore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace StarNoteWebAPICore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MainScreenController : ControllerBase
    {
        private readonly ILogger<MainScreenController> _logger;
        private readonly StarNoteEntity _context;
        UnitOfWork unitOfWork;

        public MainScreenController(ILogger<MainScreenController> logger, StarNoteEntity context)
        {
            _logger = logger;
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }
        [Route("GetMainAll")]
        [HttpGet]       
        public List<OrderModel> GetMainAll()
        {           
            List<OrderModel> response = new();
            List<CostumerOrderModel> costumerorderlist = unitOfWork.CostumerorderRepository.GetAll();
            List<JobOrderModel> joborderlist = unitOfWork.JoborderRepository.GetAll();
            foreach (var item in costumerorderlist)
            {
                OrderModel model = new OrderModel
                {
                    Costumerorder = item,
                    Joborder = joborderlist.Where(u=>u.Üstid==item.Id).ToList()
                };
                response.Add(model);
            }
            return response;
        }
        [Route("Getselectedjoborders")]
        [HttpGet]
        public List<JobOrderModel> Getselectedjoborders(int Id)
        {
            List<JobOrderModel> list = new List<JobOrderModel>();
            list = unitOfWork.JoborderRepository.GetByIDJobOrders(Id);
            return list;
        }

        private string Createjoborderr()
        {
            string joborder = "";
            int count = 0;
            string orderID = string.Empty;
            string month = DateTime.Now.Month.ToString("D2"), year = DateTime.Now.Year.ToString();
            var list = unitOfWork.JoborderRepository.Getlastordersbycount(100);
            foreach (var item in list)
            {
                if (item != null && item.Joborder != null)
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
            return joborder.ToString();
        }
        [Route("GetJobOrder")]
        [HttpGet]
        public string GetJobOrder()
        {
            return Createjoborderr();
        }
        [Route("AddMain")]
        [HttpPost]
        public bool AddMain(OrderModel objmain)
        {
            bool IsAdded = false;
            bool isdava = false;
            if (objmain.Costumerorder.Tür != "ÖZEL MÜŞTERİLER" && objmain.Costumerorder.Tür != "ŞİRKETLER")
                isdava = true;
            unitOfWork.CostumerorderRepository.Add(objmain.Costumerorder);
            int newid = unitOfWork.CostumerorderRepository.GetMaxId();

            string joborder = "";
            if (!isdava)
                joborder = Createjoborderr();

            int count = 1;
            foreach (var item in objmain.Joborder)
            {
                if (isdava)
                {
                    joborder = count.ToString();
                    count++;
                }
                item.Id = 0;
                item.Üstid = newid + 1;
                item.Joborder = joborder;
                unitOfWork.JoborderRepository.Add(item);
                if (!isdava)
                    joborder = (Convert.ToInt32(joborder) + 1).ToString();
            }
            if (unitOfWork.Complate() > 0)
                IsAdded = true;
            return IsAdded;
        }
        [Route("UpdateMain")]
        [HttpPost]
        public bool UpdateMain(OrderModel objmain)
        {
            bool isUpdated = false;
            bool isdava = false;
            if (objmain.Costumerorder.Tür != "ÖZEL MÜŞTERİLER" && objmain.Costumerorder.Tür != "ŞİRKETLER")
                isdava = true;
            unitOfWork.CostumerorderRepository.update(unitOfWork.CostumerorderRepository.Getbyid(objmain.Costumerorder.Id), objmain.Costumerorder);
            string joborder = "";
            if (!isdava)
                joborder = Createjoborderr();
            int count = Convert.ToInt32(objmain.Joborder.Max(u => u.Joborder));
            foreach (var item in objmain.Joborder)
            {
               
                if (item.Üstid==0)
                {
                    if (isdava)
                    {
                        count++;
                        joborder = count.ToString();
                    }
                    JobOrderModel addjoborder = item;
                    addjoborder.Joborder = joborder;
                    addjoborder.Üstid = objmain.Costumerorder.Id;
                    addjoborder.Id = 0;
                    unitOfWork.JoborderRepository.Add(addjoborder);
                    joborder = (Convert.ToInt32(joborder) + 1).ToString();
                   
                }
                else
                {
                    unitOfWork.JoborderRepository.update(unitOfWork.JoborderRepository.Getbyid(item.Id), item);
                }

            }
            if (unitOfWork.Complate() > 0)
                isUpdated = true;
            return isUpdated;
        }
        [Route("Getsources")]
        [HttpGet]
        public helperclass Getsources()
        {
            helperclass record = new helperclass
            {
                Ödemeyöntem = unitOfWork.PaymenttypeRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList(),
                Method = unitOfWork.ProcesstypeRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList(),
                Durum = unitOfWork.CaseRepository.GetAll().Select(x=>x.Parameter).OrderBy(x=>x).ToList(),
                Birim = unitOfWork.UnitRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList(),
                Kdv = unitOfWork.KdvRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList(),
                Ürün = unitOfWork.StokRepository.GetAll().Select(x => x.Stokadı).OrderBy(x => x).ToList(),
                Salesman = unitOfWork.SalesmanRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList(),
                tür = unitOfWork.TypeRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList(),
                türdetay = unitOfWork.TypedetailRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList(),
                mainürün = unitOfWork.ProductRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList(),
                company = unitOfWork.CompanyRepository.GetAll(),
                costumer= unitOfWork.CostumerRepository.GetAll()
            };        
            return record;
        }

        [Route("GetödemeyöntemSource")]
        [HttpGet]
        public List<string> GetödemeyöntemSource()
        {
            List<string> source = new List<string>();
            source = unitOfWork.PaymenttypeRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList();
            return source.OrderBy(x => x).ToList();
        }
        [Route("GetmethodSource")]
        [HttpGet]
        public List<string> GetmethodSource()
        {
            List<string> source = new List<string>();
            source = unitOfWork.ProcesstypeRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList();
            return source.OrderBy(x => x).ToList();
        }
        [Route("GetdurumSource")]
        [HttpGet]
        public List<string> GetdurumSource()
        {
            List<string> source = new List<string>();
            source = unitOfWork.CaseRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList();
            return source;
        }
        [Route("GetbirimSource")]
        [HttpGet]
        public List<string> GetbirimSource()
        {
            List<string> source = new List<string>();
            source = unitOfWork.UnitRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList();
            return source.OrderBy(x => x).ToList();
        }
        [Route("GetkdvSource")]
        [HttpGet]
        public List<string> GetkdvSource()
        {
            List<string> source = new List<string>();
            source = unitOfWork.KdvRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList();
            return source;
        }
        [Route("GetürünSource")]
        [HttpGet]
        public List<string> GetürünSource()
        {
            List<string> source = new();
            source = unitOfWork.StokRepository.GetAll().Select(x => x.Stokadı).OrderBy(x => x).ToList();
            return source.OrderBy(x => x).ToList();
        }
        [Route("GetsalesmanSource")]
        [HttpGet]
        public List<string> GetsalesmanSource()
        {
            List<string> source = new();
            source = unitOfWork.SalesmanRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList();
            return source.OrderBy(x => x).ToList();
        }
        [Route("GettürSource")]
        [HttpGet]
        public List<string> GettürSource()
        {
            List<string> source = new();
            source = unitOfWork.TypeRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList();
            return source.OrderBy(x => x).ToList();
        }
        [Route("Gettypedetailsource")]
        [HttpGet]
        public List<string> Gettypedetailsource()
        {
            List<string> source = new();
            source = unitOfWork.TypedetailRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList();
            return source.OrderBy(x => x).ToList();
        }
        [Route("GetproductSource")]
        [HttpGet]
        public List<string> GetproductSource()
        {
            List<string> source = new();
            source = unitOfWork.ProductRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList();
            return source.OrderBy(x => x).ToList();
        }
        [Route("GetCompanySource")]
        [HttpGet]
        public List<CompanyModel> GetCompanySource()
        {
            List<CompanyModel> source = new List<CompanyModel>();
            source = unitOfWork.CompanyRepository.GetAll();
            return source;
        }
        [Route("GetCostumerSource")]
        [HttpGet]
        public List<CostumerModel> GetCostumerSource()
        {
            List<CostumerModel> source = new List<CostumerModel>();
            source = unitOfWork.CostumerRepository.GetAll();
            return source;
        }
        [Route("Getselectedmodel")]
        [HttpGet]
        public OrderModel Getselectedmodel(int ID)
        {
            OrderModel model = new OrderModel
            {
                Costumerorder = unitOfWork.CostumerorderRepository.Getbyid(ID),
                Joborder = unitOfWork.JoborderRepository.GetByIDJobOrders(ID)
            };
            return model;
        }
        [Route("Getjoborderlist")]
        [HttpGet]
        public List<string> Getjoborderlist()
        {
            List<string> joborderlist = new List<string>();
            foreach (var entitiycontext in unitOfWork.CostumerorderRepository.GetAll())
            {
                if (entitiycontext.Siparişno != String.Empty && entitiycontext.Savetype == 0)
                {
                    if (entitiycontext.Siparişno.ToString().Length == 8 || entitiycontext.Siparişno.ToString().Length == 9)
                    {
                        joborderlist.Add(entitiycontext.Siparişno);
                    }

                }
            }
            joborderlist.Sort();
            joborderlist.Reverse();
            return joborderlist;
        }
        [Route("Getselectedstok")]
        [HttpGet]
        public StokModel Getselectedstok(string name)
        {
            return unitOfWork.StokRepository.GetByStockNamme(name);
        }


        [Route("Getnewid")]
        [HttpGet]
        public int Getnewid()
        {
           return unitOfWork.CostumerorderRepository.GetMaxId();
        }
        [Route("Getselectedfilelist")]
        [HttpGet]
        public List<FilemanagementModel> Getselectedfilelist(int id)
        {
            return unitOfWork.FilemanagementRepository.GetSelectedFiles(id);
        }

        
    }
    public class helperclass
    {
        public List<string> Ödemeyöntem{ get; set; }
        public List<string> Method{ get; set; }
        public List<string> Durum { get; set; }
        public List<string> Birim { get; set; }
        public List<string> Kdv { get; set; }
        public List<string> Ürün { get; set; }
        public List<string> Salesman { get; set; }
        public List<string> tür { get; set; }
        public List<string> türdetay { get; set; }
        public List<string> mainürün { get; set; }
        public List<CompanyModel> company { get; set; }
        public List<CostumerModel> costumer { get; set; }
    }
}
