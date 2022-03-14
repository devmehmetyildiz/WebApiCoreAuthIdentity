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
    public class AnalysisYearlyController : ControllerBase
    {

        private readonly string genelyıllık = "12";        
        private readonly string harcamayıllık = "204";      
        private readonly string ekgeliryıllık = "205";       
        public readonly string Satınalma = "GIDER";
        public readonly string Satış = "GELIR";
        private readonly ILogger<AnalysisYearlyController> _logger;
        private readonly StarNoteEntity _context;
        UnitOfWork unitOfWork;
        public AnalysisYearlyController(ILogger<AnalysisYearlyController> logger, StarNoteEntity context)
        {
            _logger = logger;
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }
        [Route("GetYearlyAnalysis")]
        [HttpGet]
        public List<AnalysisYearlyModel> GetYearlyAnalysis(string date, string type)
        {
            List<AnalysisYearlyModel> analysis = new List<AnalysisYearlyModel>();
            List<string> stoknamesall = new();
            List<string> stoknames = new();
            DateTime filterdate = Convert.ToDateTime(date);
            string month = filterdate.Month.ToString("D2");
            string year = filterdate.Year.ToString();
            AnalysisYearlyModel analysisYearlyModel;
            stoknamesall = unitOfWork.JoborderRepository.Usedstoks();
            foreach (var item in stoknamesall)
            {
                if (type == harcamayıllık || type == ekgeliryıllık)
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
            //stoknames = objcontext.tbl_stok.Select(u => u.Name).Distinct().ToList();               
            int IDcounter = 1;
            if (type == genelyıllık)
            {
                var enttiyresult1 = unitOfWork.CostumerorderRepository.GetAnalysisYearlyAll(Satış, Satınalma, month, year);
                analysisYearlyModel = new AnalysisYearlyModel
                {
                    Id = IDcounter,
                    Urun = "GENEL HARCAMALAR"
                };
                foreach (var item in enttiyresult1)
                {
                    string datefilter = item.RAN_DATE.Substring(3, 2);
                    switch (datefilter)
                    {
                        case "01":
                            analysisYearlyModel.Ay1 = Convert.ToDouble(item.PRICE);
                            break;
                        case "02":
                            analysisYearlyModel.Ay2 = Convert.ToDouble(item.PRICE);
                            break;
                        case "03":
                            analysisYearlyModel.Ay3 = Convert.ToDouble(item.PRICE);
                            break;
                        case "04":
                            analysisYearlyModel.Ay4 = Convert.ToDouble(item.PRICE);
                            break;
                        case "05":
                            analysisYearlyModel.Ay5 = Convert.ToDouble(item.PRICE);
                            break;
                        case "06":
                            analysisYearlyModel.Ay6 = Convert.ToDouble(item.PRICE);
                            break;
                        case "07":
                            analysisYearlyModel.Ay7 = Convert.ToDouble(item.PRICE);
                            break;
                        case "08":
                            analysisYearlyModel.Ay8 = Convert.ToDouble(item.PRICE);
                            break;
                        case "09":
                            analysisYearlyModel.Ay9 = Convert.ToDouble(item.PRICE);
                            break;
                        case "10":
                            analysisYearlyModel.Ay10 = Convert.ToDouble(item.PRICE);
                            break;
                        case "11":
                            analysisYearlyModel.Ay11 = Convert.ToDouble(item.PRICE);
                            break;
                        case "12":
                            analysisYearlyModel.Ay12 = Convert.ToDouble(item.PRICE);
                            break;
                    }
                }
                analysis.Add(analysisYearlyModel);
                IDcounter++;
            }

            foreach (var stokname in stoknames)
            {

                var enttiyresult = unitOfWork.CostumerorderRepository.GetAnalysisYearly(Satış, Satınalma, month, year, type, stokname);
                analysisYearlyModel = new AnalysisYearlyModel();
                analysisYearlyModel.Id = IDcounter;
                analysisYearlyModel.Urun = stokname;
                foreach (var item in enttiyresult)
                {
                    string datefilter = item.RAN_DATE.Substring(3, 2);
                    switch (datefilter)
                    {
                        case "01":
                            analysisYearlyModel.Ay1 += Convert.ToDouble(item.PRICE);
                            break;
                        case "02":
                            analysisYearlyModel.Ay2 += Convert.ToDouble(item.PRICE);
                            break;
                        case "03":
                            analysisYearlyModel.Ay3 += Convert.ToDouble(item.PRICE);
                            break;
                        case "04":
                            analysisYearlyModel.Ay4 += Convert.ToDouble(item.PRICE);
                            break;
                        case "05":
                            analysisYearlyModel.Ay5 += Convert.ToDouble(item.PRICE);
                            break;
                        case "06":
                            analysisYearlyModel.Ay6 += Convert.ToDouble(item.PRICE);
                            break;
                        case "07":
                            analysisYearlyModel.Ay7 += Convert.ToDouble(item.PRICE);
                            break;
                        case "08":
                            analysisYearlyModel.Ay8 += Convert.ToDouble(item.PRICE);
                            break;
                        case "09":
                            analysisYearlyModel.Ay9 += Convert.ToDouble(item.PRICE);
                            break;
                        case "10":
                            analysisYearlyModel.Ay10 += Convert.ToDouble(item.PRICE);
                            break;
                        case "11":
                            analysisYearlyModel.Ay11 += Convert.ToDouble(item.PRICE);
                            break;
                        case "12":
                            analysisYearlyModel.Ay12 += Convert.ToDouble(item.PRICE);
                            break;
                    }
                }
                analysis.Add(analysisYearlyModel);
                IDcounter++;
            }
            return analysis;
        }

        [Route("Getyearlysalesgauge")]
        [HttpGet]
        public List<string> Getyearlysalesgauge(string date, string type)
        {
            List<string> output = new()
            {
                unitOfWork.CostumerorderRepository.GetYearlysalesgauge(type, date)
            };
            return output;
        }
        [Route("Getyearlypurchasegauge")]
        [HttpGet]
        public List<string> Getyearlypurchasegauge(string date, string type)
        {
            List<string> output = new List<string>();
            output.Add(unitOfWork.CostumerorderRepository.GetYearlypurchasegauge(type, date));
            return output;
        }
        [Route("Getyearlynetgauge")]
        [HttpGet]
        public List<string> Getyearlynetgauge(string date, string type)
        {
            List<string> output = new()
            {
                unitOfWork.CostumerorderRepository.GetYearlynetgauge(type, date)
            };
            return output;
        }
        [Route("Getyearlypotansialgauge")]
        [HttpGet]
        public List<string> Getyearlypotansialgauge(string date, string type)
        {
            List<string> output = new()
            {
                unitOfWork.CostumerorderRepository.GetYearlypotasialgauege(type, date)
            };
            return output;
        }
    }
}
