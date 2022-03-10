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
        private readonly ILogger<AnalysisMontlyController> _logger;
        private readonly StarNoteEntity _context;
        UnitOfWork unitOfWork;
        public AnalysisMontlyController(ILogger<AnalysisMontlyController> logger, StarNoteEntity context)
        {
            _logger = logger;
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        public List<AnalysisMontlyModel> GetMontlyAnalysis(string date,string type)
        {
            List<AnalysisMontlyModel> analysis = new List<AnalysisMontlyModel>();
            List<string> stoknamesall = new List<string>();
            List<string> stoknames = new List<string>();
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
            try
            {
                int IDcounter = 1;
                AnalysisMontlyModel analysisMontlyModel;
                if (type == genelaylık)
                {

                    string sql = "";
                    sql += " Select tbl_customerorder.ID";
                    sql += " ,tbl_customerorder.Daliverydate AS RAN_DATE";
                    sql += " ,(SUM(Case When tbl_customerorder.Salesmethod = '" + Satış + "' Then tbl_joborder.Price ELSE 0 END)";
                    sql += " - SUM(Case When tbl_customerorder.Salesmethod = '" + Satınalma + "' Then tbl_joborder.Price ELSE 0 END)) AS PRICE";
                    sql += "  from tbl_customerorder LEFT JOIN tbl_joborder ON tbl_customerorder.ID=tbl_joborder.Upperid";
                    sql += " WHERE MID(tbl_customerorder.Daliverydate, 4, 2) = '" + month + "'AND MID(tbl_customerorder.Daliverydate, 7, 4) = '" + year + "' AND";
                    sql += " tbl_customerorder.savetype = '1' GROUP BY tbl_customerorder.Daliverydate";
                    var enttiyresult1 = objcontext.partial_analysis.FromSqlRaw(sql).ToList();
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

                    string sqlcmd = "";
                    sqlcmd += "Select tbl_customerorder.ID,tbl_customerorder.Daliverydate AS RAN_DATE,";
                    sqlcmd += " (SUM(Case When tbl_customerorder.Salesmethod = '" + Satış + "' Then tbl_joborder.Price ELSE 0 END)";
                    sqlcmd += " - SUM(Case When tbl_customerorder.Salesmethod = '" + Satınalma + "' Then tbl_joborder.Price ELSE 0 END)) AS";
                    sqlcmd += " PRICE from tbl_customerorder LEFT JOIN tbl_joborder ON tbl_customerorder.ID=tbl_joborder.Upperid";
                    sqlcmd += " WHERE MID(tbl_customerorder.Daliverydate, 4, 2) = '" + month + "'AND MID(tbl_customerorder.Daliverydate, 7, 4) = '" + year + "' AND";
                    sqlcmd += " tbl_joborder.Product2='" + stokname + "' ";
                    if (type == adliyeaylık)
                    {
                        sqlcmd += " AND tbl_customerorder.savetype='0'";
                        sqlcmd += " AND tbl_customerorder.Type <>'ÖZEL MÜŞTERİLER'";
                        sqlcmd += " AND tbl_customerorder.Type <>'ŞİRKETLER'";
                    }
                    if (type == özelaylık)
                    {
                        sqlcmd += "AND tbl_customerorder.savetype='0'";
                        sqlcmd += " AND tbl_customerorder.Type ='ÖZEL MÜŞTERİLER'";
                    }
                    if (type == digerkurumaylık)
                    {
                        sqlcmd += " AND tbl_customerorder.savetype='0'";
                        sqlcmd += " AND tbl_customerorder.Type ='ŞİRKETLER'";
                    }
                    if (type == harcamaaylık)
                    {
                        sqlcmd += " AND tbl_customerorder.savetype='1'";
                        sqlcmd += " AND tbl_customerorder.Salesmethod = 'GIDER'";
                    }
                    if (type == ekgeliraylık)
                    {
                        sqlcmd += " AND tbl_customerorder.savetype='1'";
                        sqlcmd += " AND tbl_customerorder.Salesmethod = 'GELIR'";
                    }
                    sqlcmd += " GROUP BY tbl_customerorder.Daliverydate";
                    var enttiyresult = objcontext.partial_analysis.FromSqlRaw(sqlcmd).ToList();
                    analysisMontlyModel = new AnalysisMontlyModel();
                    analysisMontlyModel.Id = IDcounter;
                    analysisMontlyModel.Urun = stokname;
                    foreach (var item in enttiyresult)
                    {
                        string date = item.RAN_DATE.Substring(0, 2);
                        switch (date)
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


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return analysis;
        }

        [HttpGet]
        public List<string> Getmontlysalesgauge(string date, string type)
        {
            List<string> output = new List<string>();
            output = new List<string>(dao.monthanalysissalesgaugefill(date, type));
            return output;
        }

        [HttpGet]
        public List<string> Getmontlypurchasegauge(string date, string type)
        {
            List<string> output = new List<string>();
            output = new List<string>(dao.monthanalysispurchasegaugefill(date, type));
            return output;
        }

        [HttpGet]
        public List<string> Getmontlynetgauge(string date, string type)
        {
            List<string> output = new List<string>();
            output = new List<string>(dao.monthanalysisnetgaugefill(date, type));
            return output;
        }

        [HttpGet]
        public List<string> Getmontlypotansialgauge(string date, string type)
        {
            List<string> output = new List<string>();
            output = new List<string>(dao.monthanalysispotansialgaugefill(date, type));
            return output;
        }
    }
}
