using StarNoteWebApi.DataAccess;
using StarNoteWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StarNoteWebApi.Controllers
{
    [Authorize]
    public class AnalysisYearlyController : ApiController
    {
        //AnalysisDAO db1dataaccess = new AnalysisDAO();
        IDAO dao;
        AnalysisYearlyController()
        {
            dao = DAOBase.GetDAO();
        }
        [HttpGet]
        public List<AnalysisYearlyModel> GetYearlyAnalysis(string date, string type)
        {
            List<AnalysisYearlyModel> Yearlylist = new List<AnalysisYearlyModel>();
            Yearlylist = dao.Fillyearlyanalysis(date, type);
            return Yearlylist;
        }


        [HttpGet]
        public List<string> Getyearlysalesgauge(string date, string type)
        {
            List<string> output = new List<string>();
            output = new List<string>(dao.yearlyanalysissalesgaugefill(date, type));
            return output;
        }

        [HttpGet]
        public List<string> Getyearlypurchasegauge(string date, string type)
        {
            List<string> output = new List<string>();
            output = new List<string>(dao.yearlyanalysispurchasegaugefill(date, type));
            return output;
        }

        [HttpGet]
        public List<string> Getyearlynetgauge(string date, string type)
        {
            List<string> output = new List<string>();
            output = new List<string>(dao.yearlyanalysisnetgaugefill(date, type));
            return output;
        }

        [HttpGet]
        public List<string> Getyearlypotansialgauge(string date, string type)
        {
            List<string> output = new List<string>();
            output = new List<string>(dao.yearlyanalysispotansialgaugefill(date, type));
            return output;
        }
    }
}
