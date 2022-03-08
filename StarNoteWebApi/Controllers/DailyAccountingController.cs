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

    public class DailyAccountingController : ApiController
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
