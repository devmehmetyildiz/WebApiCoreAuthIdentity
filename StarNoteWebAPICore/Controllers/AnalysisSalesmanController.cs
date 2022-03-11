using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class AnalysisSalesmanController : ControllerBase
    {
        //IDAO dao;
        //AnalysisSalesmanController()
        //{
        //    dao = DAOBase.GetDAO();
        //}
        //AnalysisDAO dataaccess = new AnalysisDAO();
        //[HttpGet]
        //public List<SalesmanAnalysisModel> GetSalesmanlistsales(string ay)
        //{
        //    List<SalesmanAnalysisModel> Salesmansales = new List<SalesmanAnalysisModel>();
        //    Salesmansales = new List<SalesmanAnalysisModel>(dao.Fillsalesmantablesales(ay));
        //    return Salesmansales;
        //}

        //[HttpGet]
        //public List<SalesmanAnalysisModel> GetSalesmanlistpurchase(string ay)
        //{
        //    List<SalesmanAnalysisModel> Salesmanpurchase = new List<SalesmanAnalysisModel>();
        //    Salesmanpurchase = new List<SalesmanAnalysisModel>(dao.Fillsalesmantablepurchase(ay));
        //    return Salesmanpurchase;
        //}

        //[HttpGet]
        //public List<DataPoint> GetPurchasePie(string date)
        //{
        //    List<DataPoint> Purchasepie = new List<DataPoint>();
        //    Purchasepie = dao.loadpurchasepiessalesman(date);
        //    return Purchasepie;
        //}
        //[HttpGet]
        //public List<DataPoint> GetSalesPie(string date)
        //{
        //    List<DataPoint> Salespie = new List<DataPoint>();
        //    Salespie = dao.Loadsalespiessalesman(date);
        //    return Salespie;
        //}
    }
}
