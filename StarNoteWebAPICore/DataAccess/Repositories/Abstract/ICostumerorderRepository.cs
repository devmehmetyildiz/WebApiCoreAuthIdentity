using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarNoteWebAPICore.Models;
namespace StarNoteWebAPICore.DataAccess.Repositories.Abstract
{
    public interface ICostumerorderRepository : IRepository<CostumerOrderModel>
    {
        int GetMaxId();

        string Getmontlygauge(string month, string year, string type);

        List<CostumerOrderModel> GetAllwithRegisterdatefilter(DateTime startdate, DateTime enddate);

        List<CostumerOrderModel> GetAllwithDeliverydatefilter(DateTime startdate, DateTime enddate);

        List<partial_analysis> GetAnalysisMontlyAll(string satıs, string satınalma, string month, string year);
        List<partial_analysis> GetAnalysisMontly(string satıs, string satınalma, string month, string year,string type,string stokname);
        string Getmontlysalesgauge(string type, string date);
        string Getmontlypurchasegauge(string type, string date);
        string Getmontlynetgauge(string type, string date);
        string Getmontlypotasialgauege(string type, string date);

        List<partial_analysis> GetAnalysisYearlyAll(string satıs, string satınalma, string month, string year);
        List<partial_analysis> GetAnalysisYearly(string satıs, string satınalma, string month, string year, string type, string stokname);
        string GetYearlysalesgauge(string type, string date);
        string GetYearlypurchasegauge(string type, string date);
        string GetYearlynetgauge(string type, string date);
        string GetYearlypotasialgauege(string type, string date);

        string calcsumpayment(string payment,string date,string method);

        List<partial_saleschart> Getaccountingsales(string method, string month, string year);

        List<partial_salespie> Getaccountingpie(string method, string month, string year);
    }
}
