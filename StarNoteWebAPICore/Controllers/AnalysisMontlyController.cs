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
    public class AnalysisMontlyController : ControllerBase
    {
        IDAO dao;
        AnalysisMontlyController()
        {
            dao = DAOBase.GetDAO();
        }
        //AnalysisDAO dataaccess = new AnalysisDAO();
        [HttpGet]
        public List<AnalysisMontlyModel> GetMontlyAnalysis(string date,string type)
        {
            List<AnalysisMontlyModel> Montlylist = new List<AnalysisMontlyModel>();
            Montlylist = dao.Fillmontlyanalysis(date,type);
            return Montlylist;
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
