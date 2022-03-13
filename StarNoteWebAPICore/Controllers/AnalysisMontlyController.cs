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
    public class AnalysisMontlyController : ControllerBase
    {
        private readonly string genelaylık = "11";       
        private readonly string harcamaaylık = "104";   
        private readonly string ekgeliraylık = "105";    
        public readonly string Satınalma = "GIDER";
        public readonly string Satış = "GELIR";
        private readonly ILogger<AnalysisMontlyController> _logger;
        private readonly StarNoteEntity _context;
        UnitOfWork unitOfWork;
        public AnalysisMontlyController(ILogger<AnalysisMontlyController> logger, StarNoteEntity context)
        {
            _logger = logger;
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }
        [Route("GetMontlyAnalysis")]
        [HttpGet]
        public List<AnalysisMontlyModel> GetMontlyAnalysis(string date,string type)
        {
            List<AnalysisMontlyModel> analysis = new();
            List<string> stoknamesall = new();
            List<string> stoknames = new();
            DateTime filterdate = Convert.ToDateTime(date);
            string month = filterdate.Month.ToString("D2");
            string year = filterdate.Year.ToString();
            stoknamesall = unitOfWork.JoborderRepository.Usedstoks();
            foreach (var item in stoknamesall)
            {
                if (type == harcamaaylık || type == ekgeliraylık)
                {
                    if (unitOfWork.StokRepository.GetByStockNamme(item) == null)
                        stoknames.Add(item);
                }
                else
                {
                    if (unitOfWork.StokRepository.GetByStockNamme(item) != null)
                        stoknames.Add(item);
                }
            }
            int IDcounter = 1;
            AnalysisMontlyModel analysisMontlyModel;
            if (type == genelaylık)
            {

                var enttiyresult1 = unitOfWork.CostumerorderRepository.GetAnalysisMontlyAll(Satış, Satınalma, month, year);
                analysisMontlyModel = new AnalysisMontlyModel();
                analysisMontlyModel.Id = IDcounter;
                analysisMontlyModel.Urun = "GENEL HARCAMALAR";
                foreach (var item in enttiyresult1)
                {
                    string datefilter = item.RAN_DATE.Substring(0, 2);
                    switch (datefilter)
                    {
                        case "01":
                            analysisMontlyModel.Gun1 = Convert.ToDouble(item.PRICE);
                            break;
                        case "02":
                            analysisMontlyModel.Gun2 = Convert.ToDouble(item.PRICE);
                            break;
                        case "03":
                            analysisMontlyModel.Gun3 = Convert.ToDouble(item.PRICE);
                            break;
                        case "04":
                            analysisMontlyModel.Gun4 = Convert.ToDouble(item.PRICE);
                            break;
                        case "05":
                            analysisMontlyModel.Gun5 = Convert.ToDouble(item.PRICE);
                            break;
                        case "06":
                            analysisMontlyModel.Gun6 = Convert.ToDouble(item.PRICE);
                            break;
                        case "07":
                            analysisMontlyModel.Gun7 = Convert.ToDouble(item.PRICE);
                            break;
                        case "08":
                            analysisMontlyModel.Gun8 = Convert.ToDouble(item.PRICE);
                            break;
                        case "09":
                            analysisMontlyModel.Gun9 = Convert.ToDouble(item.PRICE);
                            break;
                        case "10":
                            analysisMontlyModel.Gun10 = Convert.ToDouble(item.PRICE);
                            break;
                        case "11":
                            analysisMontlyModel.Gun11 = Convert.ToDouble(item.PRICE);
                            break;
                        case "12":
                            analysisMontlyModel.Gun12 = Convert.ToDouble(item.PRICE);
                            break;
                        case "13":
                            analysisMontlyModel.Gun13 = Convert.ToDouble(item.PRICE);
                            break;
                        case "14":
                            analysisMontlyModel.Gun14 = Convert.ToDouble(item.PRICE);
                            break;
                        case "15":
                            analysisMontlyModel.Gun15 = Convert.ToDouble(item.PRICE);
                            break;
                        case "16":
                            analysisMontlyModel.Gun16 = Convert.ToDouble(item.PRICE);
                            break;
                        case "17":
                            analysisMontlyModel.Gun17 = Convert.ToDouble(item.PRICE);
                            break;
                        case "18":
                            analysisMontlyModel.Gun18 = Convert.ToDouble(item.PRICE);
                            break;
                        case "19":
                            analysisMontlyModel.Gun19 = Convert.ToDouble(item.PRICE);
                            break;
                        case "20":
                            analysisMontlyModel.Gun20 = Convert.ToDouble(item.PRICE);
                            break;
                        case "21":
                            analysisMontlyModel.Gun21 = Convert.ToDouble(item.PRICE);
                            break;
                        case "22":
                            analysisMontlyModel.Gun22 = Convert.ToDouble(item.PRICE);
                            break;
                        case "23":
                            analysisMontlyModel.Gun23 = Convert.ToDouble(item.PRICE);
                            break;
                        case "24":
                            analysisMontlyModel.Gun24 = Convert.ToDouble(item.PRICE);
                            break;
                        case "25":
                            analysisMontlyModel.Gun25 = Convert.ToDouble(item.PRICE);
                            break;
                        case "26":
                            analysisMontlyModel.Gun26 = Convert.ToDouble(item.PRICE);
                            break;
                        case "27":
                            analysisMontlyModel.Gun27 = Convert.ToDouble(item.PRICE);
                            break;
                        case "28":
                            analysisMontlyModel.Gun28 = Convert.ToDouble(item.PRICE);
                            break;
                        case "29":
                            analysisMontlyModel.Gun29 = Convert.ToDouble(item.PRICE);
                            break;
                        case "30":
                            analysisMontlyModel.Gun30 = Convert.ToDouble(item.PRICE);
                            break;
                        case "31":
                            analysisMontlyModel.Gun31 = Convert.ToDouble(item.PRICE);
                            break;

                    }
                }
                analysis.Add(analysisMontlyModel);
                IDcounter++;
            }
            foreach (var stokname in stoknames)
            {

                var enttiyresult = unitOfWork.CostumerorderRepository.GetAnalysisMontly(Satış, Satınalma, month, year, type, stokname);
                analysisMontlyModel = new AnalysisMontlyModel
                {
                    Id = IDcounter,
                    Urun = stokname
                };
                foreach (var item in enttiyresult)
                {
                    string datefilter = item.RAN_DATE.Substring(0, 2);
                    switch (datefilter)
                    {
                        case "01":
                            analysisMontlyModel.Gun1 += Convert.ToDouble(item.PRICE);
                            break;
                        case "02":
                            analysisMontlyModel.Gun2 += Convert.ToDouble(item.PRICE);
                            break;
                        case "03":
                            analysisMontlyModel.Gun3 += Convert.ToDouble(item.PRICE);
                            break;
                        case "04":
                            analysisMontlyModel.Gun4 += Convert.ToDouble(item.PRICE);
                            break;
                        case "05":
                            analysisMontlyModel.Gun5 += Convert.ToDouble(item.PRICE);
                            break;
                        case "06":
                            analysisMontlyModel.Gun6 += Convert.ToDouble(item.PRICE);
                            break;
                        case "07":
                            analysisMontlyModel.Gun7 += Convert.ToDouble(item.PRICE);
                            break;
                        case "08":
                            analysisMontlyModel.Gun8 += Convert.ToDouble(item.PRICE);
                            break;
                        case "09":
                            analysisMontlyModel.Gun9 += Convert.ToDouble(item.PRICE);
                            break;
                        case "10":
                            analysisMontlyModel.Gun10 += Convert.ToDouble(item.PRICE);
                            break;
                        case "11":
                            analysisMontlyModel.Gun11 += Convert.ToDouble(item.PRICE);
                            break;
                        case "12":
                            analysisMontlyModel.Gun12 += Convert.ToDouble(item.PRICE);
                            break;
                        case "13":
                            analysisMontlyModel.Gun13 += Convert.ToDouble(item.PRICE);
                            break;
                        case "14":
                            analysisMontlyModel.Gun14 += Convert.ToDouble(item.PRICE);
                            break;
                        case "15":
                            analysisMontlyModel.Gun15 += Convert.ToDouble(item.PRICE);
                            break;
                        case "16":
                            analysisMontlyModel.Gun16 += Convert.ToDouble(item.PRICE);
                            break;
                        case "17":
                            analysisMontlyModel.Gun17 += Convert.ToDouble(item.PRICE);
                            break;
                        case "18":
                            analysisMontlyModel.Gun18 += Convert.ToDouble(item.PRICE);
                            break;
                        case "19":
                            analysisMontlyModel.Gun19 += Convert.ToDouble(item.PRICE);
                            break;
                        case "20":
                            analysisMontlyModel.Gun20 += Convert.ToDouble(item.PRICE);
                            break;
                        case "21":
                            analysisMontlyModel.Gun21 += Convert.ToDouble(item.PRICE);
                            break;
                        case "22":
                            analysisMontlyModel.Gun22 += Convert.ToDouble(item.PRICE);
                            break;
                        case "23":
                            analysisMontlyModel.Gun23 += Convert.ToDouble(item.PRICE);
                            break;
                        case "24":
                            analysisMontlyModel.Gun24 += Convert.ToDouble(item.PRICE);
                            break;
                        case "25":
                            analysisMontlyModel.Gun25 += Convert.ToDouble(item.PRICE);
                            break;
                        case "26":
                            analysisMontlyModel.Gun26 += Convert.ToDouble(item.PRICE);
                            break;
                        case "27":
                            analysisMontlyModel.Gun27 += Convert.ToDouble(item.PRICE);
                            break;
                        case "28":
                            analysisMontlyModel.Gun28 += Convert.ToDouble(item.PRICE);
                            break;
                        case "29":
                            analysisMontlyModel.Gun29 += Convert.ToDouble(item.PRICE);
                            break;
                        case "30":
                            analysisMontlyModel.Gun30 += Convert.ToDouble(item.PRICE);
                            break;
                        case "31":
                            analysisMontlyModel.Gun31 += Convert.ToDouble(item.PRICE);
                            break;

                    }
                }
                analysis.Add(analysisMontlyModel);
                IDcounter++;
            }
            return analysis;
        }
        [Route("Getmontlysalesgauge")]
        [HttpGet]
        public List<string> Getmontlysalesgauge(string date, string type)
        {
            List<string> output = new()
            {
                unitOfWork.CostumerorderRepository.Getmontlysalesgauge(type, date)
            };
            return output;
        }
        [Route("Getmontlypurchasegauge")]
        [HttpGet]
        public List<string> Getmontlypurchasegauge(string date, string type)
        {
            List<string> output = new()
            {
                unitOfWork.CostumerorderRepository.Getmontlypurchasegauge(type, date)
            };
            return output;
        }
        [Route("Getmontlynetgauge")]
        [HttpGet]
        public List<string> Getmontlynetgauge(string date, string type)
        {
            List<string> output = new()
            {
                unitOfWork.CostumerorderRepository.Getmontlynetgauge(type, date)
            };
            return output;
        }
        [Route("Getmontlypotansialgauge")]
        [HttpGet]
        public List<string> Getmontlypotansialgauge(string date, string type)
        {
            List<string> output = new()
            {
                unitOfWork.CostumerorderRepository.Getmontlypotasialgauege(type, date)
            };
            return output;
        }
    }
}
