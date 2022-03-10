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

        [HttpGet]
        [Route("GetMainAll")]
        public List<OrderModel> GetMainAll()
        {           
            List<OrderModel> response = new List<OrderModel>();
            List<CostumerOrderModel> costumerorderlist = unitOfWork.CostumerorderRepository.GetAll();
            List<JobOrderModel> joborderlist = unitOfWork.JoborderRepository.GetAll();
            foreach (var item in costumerorderlist)
            {
                OrderModel model = new OrderModel
                {
                    Costumerorder = item,
                    Joborder = unitOfWork.JoborderRepository.GetByIDJobOrders(item.Id)
                };
                response.Add(model);
            }
            return response;
        }

        [HttpGet]
        public List<JobOrderModel> Getselectedjoborders(int Id)
        {
            List<JobOrderModel> list = new List<JobOrderModel>();
            list = unitOfWork.JoborderRepository.GetByIDJobOrders(Id);
            return list;
        }

        [HttpGet]
        public string GetJobOrder()
        {
            string response = "" ;
            response = dao.Createjoborder();
            return response;
        }

        [HttpPost]
        public bool AddMain(OrderModel objmain)
        {
            bool IsAdded = false;
            bool isdava = false;
            if (objmain.Costumerorder.Tür != "ÖZEL MÜŞTERİLER" && objmain.Costumerorder.Tür != "ŞİRKETLER")
                isdava = true;
            try
            {

                unitOfWork.CostumerorderRepository.Add(objmain.Costumerorder);
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
                    if (!isdava)
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

        [HttpPost]
        public bool UpdateMain(OrderModel objmain)
        {
            bool Isupdated = false;
           
                Isupdated = dao.GenericUpdate(objmain);
           
            return Isupdated;
        }

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


        [HttpGet]
        public List<string> GetödemeyöntemSource()
        {
            List<string> source = new List<string>();
            source = unitOfWork.PaymenttypeRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList();
            return source.OrderBy(x => x).ToList();
        }

        [HttpGet]
        public List<string> GetmethodSource()
        {
            List<string> source = new List<string>();
            source = unitOfWork.ProcesstypeRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList();
            return source.OrderBy(x => x).ToList();
        }

        [HttpGet]
        public List<string> GetdurumSource()
        {
            List<string> source = new List<string>();
            source = unitOfWork.CaseRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList();
            return source;
        }

        [HttpGet]
        public List<string> GetbirimSource()
        {
            List<string> source = new List<string>();
            source = unitOfWork.UnitRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList();
            return source.OrderBy(x => x).ToList();
        }

        [HttpGet]
        public List<string> GetkdvSource()
        {
            List<string> source = new List<string>();
            source = unitOfWork.KdvRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList();
            return source;
        }

        [HttpGet]
        public List<string> GetürünSource()
        {
            List<string> source = new List<string>();
            source = unitOfWork.StokRepository.GetAll().Select(x => x.Stokadı).OrderBy(x => x).ToList();
            return source.OrderBy(x => x).ToList();
        }

        [HttpGet]
        public List<string> GetsalesmanSource()
        {
            List<string> source = new List<string>();
            source = unitOfWork.SalesmanRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList();
            return source.OrderBy(x => x).ToList();
        }

        [HttpGet]
        public List<string> GettürSource()
        {
            List<string> source = new List<string>();
            source = unitOfWork.TypeRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList();
            return source.OrderBy(x => x).ToList();
        }

        [HttpGet]
        public List<string> Gettypedetailsource()
        {
            List<string> source = new List<string>();
            source = unitOfWork.TypedetailRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList();
            return source.OrderBy(x => x).ToList();
        }

        [HttpGet]
        public List<string> GetproductSource()
        {
            List<string> source = new List<string>();
            source = unitOfWork.ProductRepository.GetAll().Select(x => x.Parameter).OrderBy(x => x).ToList();
            return source.OrderBy(x => x).ToList();
        }

        [HttpGet]
        public List<CompanyModel> GetCompanySource()
        {
            List<CompanyModel> source = new List<CompanyModel>();
            source = unitOfWork.CompanyRepository.GetAll();
            return source;
        }

        [HttpGet]
        public List<CostumerModel> GetCostumerSource()
        {
            List<CostumerModel> source = new List<CostumerModel>();
            source = unitOfWork.CostumerRepository.GetAll();
            return source;
        }

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

        public List<string> Getjoborderlist()
        {
            List<string> list = new List<string>();
            list = dao.joborderlist();
            return list;
        }

        [HttpGet]
        public StokModel Getselectedstok(string name)
        {
            StokModel response = new StokModel();
            response = unitOfWork.StokRepository.get
            return response;
        }

      

        [HttpGet]
        public int Getnewid()
        {
            int id = 0;
            id = dao.lastmainid();
            return id;            
        }

        [HttpGet]
        public List<FilemanagementModel> Getselectedfilelist(int id)
        {
            List<FilemanagementModel> list = new List<FilemanagementModel>();
            list = unitOfWork.FilemanagementRepository.Getbyid(id);
            return list;
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
