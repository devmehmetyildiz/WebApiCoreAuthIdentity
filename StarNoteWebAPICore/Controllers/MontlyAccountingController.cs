using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class MontlyAccountingController : ControllerBase
    {
        public readonly string Satınalma = "GIDER";
        public readonly string Satış = "GELIR";
        private readonly ILogger<MontlyAccountingController> _logger;
        private readonly StarNoteEntity _context;
        UnitOfWork unitOfWork;
        public MontlyAccountingController(ILogger<MontlyAccountingController> logger, StarNoteEntity context)
        {
            _logger = logger;
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }
        [Route("GetMontlySales")]
        [HttpGet]
        public List<MontlyAccountingModel> GetMontlySales(string date)
        {
            List<MontlyAccountingModel> montlysalesmodelsales = new List<MontlyAccountingModel>();
            List<CostumerOrderModel> costumerlist = new List<CostumerOrderModel>();
            List<JobOrderModel> orderlist = new List<JobOrderModel>();
            costumerlist = unitOfWork.CostumerorderRepository.GetAll();
            orderlist = unitOfWork.JoborderRepository.GetAll();
            int IDSales = 1;
            DateTime filterdate = Convert.ToDateTime(date);
            string month = filterdate.Month.ToString("D2");
            string year = filterdate.Year.ToString();
            foreach (var entity in costumerlist)
            {
                if (entity.Satışyöntemi == Satış && entity.Randevutarihi.Substring(3, 2).ToString() == month && entity.Randevutarihi.Substring(6, 4).ToString() == year)
                {

                    string ürün = "";
                    foreach (var subistem in orderlist.Where(u => u.Üstid == entity.Id))
                    {
                        if (ürün.Length == 0)
                        {
                            ürün += subistem.Miktar + " " + subistem.Birim + " " + subistem.Ürün2detay + "(" + subistem.Ürün2 + ")";
                        }
                        else
                        {
                            ürün += "," + subistem.Miktar + " " + subistem.Birim + " " + subistem.Ürün2detay + "(" + subistem.Ürün2 + ")";
                        }
                    }

                    montlysalesmodelsales.Add(new MontlyAccountingModel
                    {
                        Id = IDSales,
                        Satisgorevli = entity.Satıselemanı,
                        Fiyat = Convert.ToDouble(entity.Ücret),
                        Randevutarihi = entity.Randevutarihi,
                        Urun = ürün,
                        Ödemeyöntemi = entity.Ödemeyöntemi
                    });
                    IDSales++;
                }
            }
            return montlysalesmodelsales;
        }
        [Route("GetMontlyPurchase")]
        [HttpGet]
        public List<MontlyAccountingModel> GetMontlyPurchase(string date)
        {
            List<MontlyAccountingModel> montlysalesmodelsales = new List<MontlyAccountingModel>();
            List<CostumerOrderModel> costumerlist = new List<CostumerOrderModel>();
            List<JobOrderModel> orderlist = new List<JobOrderModel>();
            costumerlist = unitOfWork.CostumerorderRepository.GetAll();
            orderlist = unitOfWork.JoborderRepository.GetAll();
            int IDSales = 1;
            DateTime filterdate = Convert.ToDateTime(date);
            string month = filterdate.Month.ToString("D2");
            string year = filterdate.Year.ToString();
            foreach (var entity in costumerlist)
            {
                if (entity.Satışyöntemi == Satınalma && entity.Randevutarihi.Substring(3, 2).ToString() == month && entity.Randevutarihi.Substring(6, 4).ToString() == year)
                {

                    string ürün = "";
                    foreach (var subistem in orderlist.Where(u => u.Üstid == entity.Id))
                    {
                        if (ürün.Length == 0)
                        {
                            ürün += subistem.Miktar + " " + subistem.Birim + " " + subistem.Ürün2detay + "(" + subistem.Ürün2 + ")";
                        }
                        else
                        {
                            ürün += "," + subistem.Miktar + " " + subistem.Birim + " " + subistem.Ürün2detay + "(" + subistem.Ürün2 + ")";
                        }
                    }

                    montlysalesmodelsales.Add(new MontlyAccountingModel
                    {
                        Id = IDSales,
                        Satisgorevli = entity.Satıselemanı,
                        Fiyat = Convert.ToDouble(entity.Ücret),
                        Randevutarihi = entity.Randevutarihi,
                        Urun = ürün,
                        Ödemeyöntemi = entity.Ödemeyöntemi
                    });
                    IDSales++;
                }
            }
            return montlysalesmodelsales;
        }
        [Route("GetSalesChart")]
        [HttpGet]
        public List<DataPoint> GetSalesChart(string date)
        {
            List<DataPoint> chartsetsales = new List<DataPoint>();
            DateTime filterdate = Convert.ToDateTime(date);
            string lastDayOfMonth = (new DateTime(filterdate.Year, filterdate.Month, DateTime.DaysInMonth(filterdate.Year, filterdate.Month))).ToString("dd");
            string month = filterdate.Month.ToString("D2");
            string year = filterdate.Year.ToString();
            var enttiyresult = unitOfWork.CostumerorderRepository.Getaccountingsales(Satış, month, year);
            for (int i = 1; i <= Convert.ToInt16(lastDayOfMonth); i++)
            {
                bool isadded = false;
                foreach (var item in enttiyresult)
                {
                    if (item.RAN_DATE.Substring(0, 2).ToString() == i.ToString("D2"))
                    {
                        chartsetsales.Add(new DataPoint(i.ToString("D2"), item.PRICE));
                        isadded = true;
                        break;
                    }
                }
                if (!isadded)
                {
                    chartsetsales.Add(new DataPoint(i.ToString("D2"), 0));
                }
            }
            return chartsetsales;
        }
        [Route("GetPurchaseChart")]
        [HttpGet]
        public List<DataPoint> GetPurchaseChart(string date)
        {
            List<DataPoint> chartsetpurchase = new List<DataPoint>();
            DateTime filterdate = Convert.ToDateTime(date);
            string lastDayOfMonth = (new DateTime(filterdate.Year, filterdate.Month, DateTime.DaysInMonth(filterdate.Year, filterdate.Month))).ToString("dd");
            string month = filterdate.Month.ToString("D2");
            string year = filterdate.Year.ToString();
            var enttiyresult = unitOfWork.CostumerorderRepository.Getaccountingsales(Satınalma, month, year);
            for (int i = 1; i <= Convert.ToInt16(lastDayOfMonth); i++)
            {
                bool isadded = false;
                foreach (var item in enttiyresult)
                {
                    if (item.RAN_DATE.Substring(0, 2).ToString() == i.ToString("D2"))
                    {
                        chartsetpurchase.Add(new DataPoint(i.ToString("D2"), item.PRICE));
                        isadded = true;
                        break;
                    }
                }
                if (!isadded)
                {
                    chartsetpurchase.Add(new DataPoint(i.ToString("D2"), 0));
                }
            }
            return chartsetpurchase;
        }
        [Route("GetPurchasePie")]
        [HttpGet]
        public List<DataPoint> GetPurchasePie(string date)
        {
            List<DataPoint> chartsetpurchase = new List<DataPoint>();
            DateTime filterdate = Convert.ToDateTime(date);
            string month = filterdate.Month.ToString("D2");
            string year = filterdate.Year.ToString();
            var enttiyresult = unitOfWork.CostumerorderRepository.Getaccountingpie(Satınalma,month,year);
            foreach (var item in enttiyresult)
            {
                chartsetpurchase.Add(new DataPoint(item.PAYMENT, item.COUNT));
            }
            return chartsetpurchase;
        }
        [Route("GetSalesPie")]
        [HttpGet]
        public List<DataPoint> GetSalesPie(string date)
        {
            List<DataPoint> chartsetsales = new List<DataPoint>();
            DateTime filterdate = Convert.ToDateTime(date);
            string month = filterdate.Month.ToString("D2");
            string year = filterdate.Year.ToString();
            var enttiyresult = unitOfWork.CostumerorderRepository.Getaccountingpie(Satış, month, year);
            foreach (var item in enttiyresult)
            {
                chartsetsales.Add(new DataPoint(item.PAYMENT, item.COUNT));
            }
            return chartsetsales;
        }

    }
}
