
using StarNoteWebApi.DataAccess;
using StarNoteWebApi.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
namespace StarNoteWebApi.Controllers
{
    [Authorize]
    public class MainScreenController : ApiController
    {
        IDAO dao;        
        MainScreenController()
        {
            dao = DAOBase.GetDAO();
        }
        
        [HttpGet]
        public List<OrderModel> GetMainAll()
        {
            OrderModel model = new OrderModel();
            List<OrderModel> response = new List<OrderModel>();
            response = dao.GetAll();
            return response;
        }

        [HttpGet]
        public List<JobOrderModel> Getselectedjoborders(int Id)
        {
            List<JobOrderModel> list = new List<JobOrderModel>();
            list = dao.getselectedjoborderlist(Id);
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
            IsAdded = dao.GenericAdd(objmain, objmain.Costumerorder.Savetype);          
            return IsAdded;
        }

        [HttpPost]
        public bool AddMainSoft(OrderModel objmain)
        {
            bool IsAdded = false;
            IsAdded = dao.GenericAdd(objmain, 1);
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
                Ödemeyöntem = dao.GetSource("ödemeyöntem"),
                Method = dao.GetSource("method"),
                Durum = dao.GetSource("durum"),
                Birim = dao.GetSource("birim"),
                Kdv = dao.GetSource("kdv"),
                Ürün = dao.GetSource("ürün").OrderBy(x => x).ToList(),
                Salesman = dao.GetSource("salesman"),
                tür = dao.GetSource("tür").OrderBy(x => x).ToList(),
                türdetay = dao.GetSource("tür detay").OrderBy(x => x).ToList(),
                mainürün = dao.GetSource("mainürün").OrderBy(x => x).ToList(),
                company = dao.GetAllCompany(),
                costumer= dao.GetAllCostumer()
            };        
            return record;
        }


        [HttpGet]
        public List<string> GetödemeyöntemSource()
        {
            List<string> source = new List<string>();
            source = dao.GetSource("ödemeyöntem").OrderBy(x => x).ToList();
            return source.OrderBy(x => x).ToList();
        }

        [HttpGet]
        public List<string> GetmethodSource()
        {
            List<string> source = new List<string>();
            source = dao.GetSource("method");
            return source.OrderBy(x => x).ToList();
        }

        [HttpGet]
        public List<string> GetdurumSource()
        {
            List<string> source = new List<string>();
            source = dao.GetSource("durum");
            return source;
        }

        [HttpGet]
        public List<string> GetbirimSource()
        {
            List<string> source = new List<string>();
            source = dao.GetSource("birim");
            return source.OrderBy(x => x).ToList();
        }

        [HttpGet]
        public List<string> GetkdvSource()
        {
            List<string> source = new List<string>();
            source = dao.GetSource("kdv");
            return source;
        }

        [HttpGet]
        public List<string> GetürünSource()
        {
            List<string> source = new List<string>();
            source = dao.GetSource("ürün");
            return source.OrderBy(x => x).ToList();
        }

        [HttpGet]
        public List<string> GetsalesmanSource()
        {
            List<string> source = new List<string>();
            source = dao.GetSource("salesman");
            return source.OrderBy(x => x).ToList();
        }

        [HttpGet]
        public List<string> GettürSource()
        {
            List<string> source = new List<string>();
            source = dao.GetSource("tür");           
            return source.OrderBy(x => x).ToList();
        }

        [HttpGet]
        public List<string> Gettypedetailsource()
        {
            List<string> source = new List<string>();
            source = dao.GetSource("tür detay");
            return source.OrderBy(x => x).ToList();
        }

        [HttpGet]
        public List<string> GetproductSource()
        {
            List<string> source = new List<string>();
            source = dao.GetSource("mainürün");
            return source.OrderBy(x => x).ToList();
        }

        [HttpGet]
        public List<CompanyModel> GetCompanySource()
        {
            List<CompanyModel> source = new List<CompanyModel>();
            source = dao.GetAllCompany();
            return source;
        }

        [HttpGet]
        public List<CostumerModel> GetCostumerSource()
        {
            List<CostumerModel> source = new List<CostumerModel>();
            source = dao.GetAllCostumer();
            return source;
        }

        [HttpGet]
        public OrderModel Getselectedmodel(int ID)
        {
            OrderModel model = new OrderModel();
            model = dao.Getselectedrecord(ID);
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
            response = dao.Getselectedstok(name);
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
            list = dao.Getselectedfilelist(id);
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
