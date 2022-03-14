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

    public class DailyAccountingController : ControllerBase
    {
        public readonly string Satınalma = "GIDER";
        public readonly string Satış = "GELIR";
        private readonly ILogger<DailyAccountingController> _logger;
        private readonly StarNoteEntity _context;
        UnitOfWork unitOfWork;
        public DailyAccountingController(ILogger<DailyAccountingController> logger, StarNoteEntity context)
        {
            _logger = logger;
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }
        [Route("GetDailySales")]
        [HttpGet]
        public List<DailyAccountingModel> GetDailySales(string date)
        {
            List<DailyAccountingModel> dailysalesmodelsales = new List<DailyAccountingModel>();
            List<CostumerOrderModel> costumerlist = new List<CostumerOrderModel>();
            List<JobOrderModel> orderlist = new List<JobOrderModel>();
            try
            {
                costumerlist = unitOfWork.CostumerorderRepository.GetAll();
                int IDSales = 1;
                foreach (var entity in costumerlist)
                {
                    if (entity.Satışyöntemi == Satış && Convert.ToDateTime(entity.Randevutarihi).ToString("dd.MM.yyyy") == date)
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
                        dailysalesmodelsales.Add(new DailyAccountingModel
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dailysalesmodelsales;
        }
        [Route("GetPurchaseSales")]
        [HttpGet]
        public List<DailyAccountingModel> GetPurchaseSales(string date)
        {
            List<DailyAccountingModel> dailysalesmodelpurchase = new List<DailyAccountingModel>();
            List<CostumerOrderModel> costumerlist = new List<CostumerOrderModel>();
            List<JobOrderModel> orderlist = new List<JobOrderModel>();
            costumerlist = unitOfWork.CostumerorderRepository.GetAll();
            int IDpurchase = 1;
            foreach (var entity in costumerlist)
            {
                if (entity.Satışyöntemi == Satınalma && Convert.ToDateTime(entity.Randevutarihi).ToString("dd.MM.yyyy") == date)
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
                    dailysalesmodelpurchase.Add(new DailyAccountingModel
                    {
                        Id = IDpurchase,
                        Satisgorevli = entity.Satıselemanı,
                        Fiyat = Convert.ToDouble(entity.Ücret),
                        Randevutarihi = entity.Randevutarihi,
                        Urun = ürün,
                        Ödemeyöntemi = entity.Ödemeyöntemi
                    });
                    IDpurchase++;
                }
            }
            return dailysalesmodelpurchase;
        }
        [Route("GetDailygaugevalues")]
        [HttpGet]
        public List<GaugeModel> GetDailygaugevalues(string date)
        {
            List<GaugeModel> gaugelist = new List<GaugeModel>();
            List<string> ödemesource = new List<string>();
            foreach (var ödemeyöntemi in unitOfWork.PaymenttypeRepository.GetAll())
            {
                ödemesource.Add(ödemeyöntemi.Parameter);
            }
            foreach (var yöntem in ödemesource)
            {
                var toplamtutar = unitOfWork.CostumerorderRepository.calcsumpayment(yöntem, date, Satınalma);
                gaugelist.Add(new GaugeModel { Gaugename = yöntem, Gaugevalue = toplamtutar.ToString() });
            }
            return gaugelist;
        }
        [Route("GetDailysalesgaugevalues")]
        [HttpGet]
        public List<GaugeModel> GetDailysalesgaugevalues(string date)
        {
            List<GaugeModel> gaugelist = new List<GaugeModel>();
            List<string> ödemesource = new List<string>();
            foreach (var ödemeyöntemi in unitOfWork.PaymenttypeRepository.GetAll())
            {
                ödemesource.Add(ödemeyöntemi.Parameter);
            }
            foreach (var yöntem in ödemesource)
            {
                var toplamtutar = unitOfWork.CostumerorderRepository.calcsumpayment(yöntem, date, Satış);
                gaugelist.Add(new GaugeModel { Gaugename = yöntem, Gaugevalue = toplamtutar.ToString() });
            }
            return gaugelist;
        }
    }
}
