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

    public class DailyAccountingController : ControllerBase
    {
        IDAO dao;
        DailyAccountingController()
        {
            dao = DAOBase.GetDAO();
        }
        [HttpGet]
        public List<DailyAccountingModel> GetDailySales(string date)
        {
            List<DailyAccountingModel> DailySales = new List<DailyAccountingModel>();
            DailySales = dao.dailysalesfill(date);
            return DailySales;
        }
        [HttpGet]
        public List<DailyAccountingModel> GetPurchaseSales(string date)
        {
            List<DailyAccountingModel> DailyPurchase = new List<DailyAccountingModel>();
            DailyPurchase = dao.dailypurchasefill(date);
            return DailyPurchase;
        }

        [HttpGet]
        public List<GaugeModel> GetDailygaugevalues(string date)
        {
            List<GaugeModel> gaugelist = new List<GaugeModel>();
            gaugelist = dao.dailysalesgaugefill(date);
            return gaugelist;
        }

        [HttpGet]
        public List<GaugeModel> GetDailysalesgaugevalues(string date)
        {
            List<GaugeModel> gaugelist = new List<GaugeModel>();
            gaugelist = dao.dailypurchasegaugefill(date);
            return gaugelist;
        }
    }
}
