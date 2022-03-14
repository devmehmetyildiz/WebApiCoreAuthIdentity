using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarNoteWebAPICore.DataAccess.Repositories.Abstract;

using StarNoteWebAPICore.Models;

namespace StarNoteWebAPICore.DataAccess.Repositories.Concrete
{
    public class CostumerorderRepository : Repository<CostumerOrderModel>, ICostumerorderRepository
    {
        private readonly string genelaylık = "11";
        private readonly string genelyıllık = "12";
        private readonly string adliyeaylık = "101";
        private readonly string adliyeyıllık = "201";
        private readonly string özelaylık = "102";
        private readonly string özelyıllık = "202";
        private readonly string digerkurumaylık = "103";
        private readonly string digerkurumyıllık = "203";
        private readonly string harcamaaylık = "104";
        private readonly string harcamayıllık = "204";
        private readonly string ekgeliraylık = "105";
        private readonly string ekgeliryıllık = "205";
        public readonly string Satınalma = "GIDER";
        public readonly string Satış = "GELIR";
        public StarNoteEntity starnoteapicontext { get { return _context as StarNoteEntity; } }

        private DbSet<CostumerOrderModel> _dbSet;
        public CostumerorderRepository(StarNoteEntity context) : base(context)
        {
            _dbSet = starnoteapicontext.Set<CostumerOrderModel>();
        }

        public string Getmontlygauge(string month, string year, string type)
        {
            //return (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == type && c.Deliverydate.Month.ToString() == month && c.Deliverydate.Year.ToString() == year) select c.Price).Sum().ToString();
            return null;
        }

        public int GetMaxId()
        {
            return starnoteapicontext.tbl_customerorder.Max(u => u.Id);
        }

        public List<CostumerOrderModel> GetAllwithRegisterdatefilter(DateTime startdate, DateTime enddate)
        {
            //return starnoteapicontext.tbl_customerorder.Where(u => u.Kayıttarihi >= startdate && u.Kayıttarihi <= enddate).ToList();
            return null;
        }

        public List<CostumerOrderModel> GetAllwithDeliverydatefilter(DateTime startdate, DateTime enddate)
        {
            //return starnoteapicontext.tbl_customerorder.Where(u => u.Kayıttarihi >= startdate && u.Kayıttarihi <= enddate).ToList();
            return null;
        }

        public List<partial_analysis> GetAnalysisMontlyAll(string satıs, string satınalma, string month, string year)
        {
            string sql = "";
            sql += " Select tbl_customerorder.ID";
            sql += " ,tbl_customerorder.Randevutarihi AS RAN_DATE";
            sql += " ,(SUM(Case When tbl_customerorder.Satışyöntemi = '" + satıs + "' Then tbl_joborder.Ücret ELSE 0 END)";
            sql += " - SUM(Case When tbl_customerorder.Satışyöntemi = '" + satınalma + "' Then tbl_joborder.Ücret ELSE 0 END)) AS PRICE";
            sql += "  from tbl_customerorder LEFT JOIN tbl_joborder ON tbl_customerorder.ID=tbl_joborder.Üstid";
            sql += " WHERE MID(tbl_customerorder.Randevutarihi, 4, 2) = '" + month + "'AND MID(tbl_customerorder.Randevutarihi, 7, 4) = '" + year + "' AND";
            sql += " tbl_customerorder.Savetype = '1' GROUP BY tbl_customerorder.Randevutarihi";
            var enttiyresult1 = starnoteapicontext.partial_analysis.FromSqlRaw(sql).ToList();

            return enttiyresult1;
        }

        public List<partial_analysis> GetAnalysisMontly(string satıs, string satınalma, string month, string year, string type, string stokname)
        {
            string sqlcmd = "";
            sqlcmd += "Select tbl_customerorder.ID,tbl_customerorder.Randevutarihi AS RAN_DATE,";
            sqlcmd += " (SUM(Case When tbl_customerorder.Satışyöntemi = '" + satıs + "' Then tbl_joborder.Ücret ELSE 0 END)";
            sqlcmd += " - SUM(Case When tbl_customerorder.Satışyöntemi = '" + satınalma + "' Then tbl_joborder.Ücret ELSE 0 END)) AS";
            sqlcmd += " PRICE from tbl_customerorder LEFT JOIN tbl_joborder ON tbl_customerorder.ID=tbl_joborder.Üstid";
            sqlcmd += " WHERE MID(tbl_customerorder.Randevutarihi, 4, 2) = '" + month + "'AND MID(tbl_customerorder.Randevutarihi, 7, 4) = '" + year + "' AND";
            sqlcmd += " tbl_joborder.Ürün2='" + stokname + "' ";
            if (type == adliyeaylık)
            {
                sqlcmd += " AND tbl_customerorder.Savetype='0'";
                sqlcmd += " AND tbl_customerorder.Tür <>'ÖZEL MÜŞTERİLER'";
                sqlcmd += " AND tbl_customerorder.Tür <>'ŞİRKETLER'";
            }
            if (type == özelaylık)
            {
                sqlcmd += "AND tbl_customerorder.Savetype='0'";
                sqlcmd += " AND tbl_customerorder.Tür ='ÖZEL MÜŞTERİLER'";
            }
            if (type == digerkurumaylık)
            {
                sqlcmd += " AND tbl_customerorder.savetype='0'";
                sqlcmd += " AND tbl_customerorder.Tür ='ŞİRKETLER'";
            }
            if (type == harcamaaylık)
            {
                sqlcmd += " AND tbl_customerorder.savetype='1'";
                sqlcmd += " AND tbl_customerorder.Satışyöntemi = 'GIDER'";
            }
            if (type == ekgeliraylık)
            {
                sqlcmd += " AND tbl_customerorder.savetype='1'";
                sqlcmd += " AND tbl_customerorder.Satışyöntemi = 'GELIR'";
            }
            sqlcmd += " GROUP BY tbl_customerorder.Randevutarihi";
            var enttiyresult = starnoteapicontext.partial_analysis.FromSqlRaw(sqlcmd).ToList();

            return enttiyresult;
        }

        string ICostumerorderRepository.Getmontlysalesgauge(string type, string date)
        {
            DateTime filterdate = Convert.ToDateTime(date);
            string month = filterdate.Month.ToString("D2");
            string year = filterdate.Year.ToString();
            string item = string.Empty;
            if (type == genelaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year) select c.Ücret).Sum().ToString();
            if (type == adliyeaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Tür != "ÖZEL MÜŞTERİLER" && c.Tür != "ŞİRKETLER") select c.Ücret).Sum().ToString();
            if (type == özelaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ÖZEL MÜŞTERİLER") select c.Ücret).Sum().ToString();
            if (type == digerkurumaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ŞİRKETLER") select c.Ücret).Sum().ToString();
            if (type == harcamaaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GIDER") select c.Ücret).Sum().ToString();
            if (type == ekgeliraylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GELIR") select c.Ücret).Sum().ToString();
            if (item == string.Empty)
                item = "0";
            return item;
        }

        public string Getmontlypurchasegauge(string type, string date)
        {
            DateTime filterdate = Convert.ToDateTime(date);
            string month = filterdate.Month.ToString("D2");
            string year = filterdate.Year.ToString();
            string item = string.Empty;
            if (type == genelaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year) select c.Ücret).Sum().ToString();
            if (type == adliyeaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Tür != "ÖZEL MÜŞTERİLER" && c.Tür != "ŞİRKETLER") select c.Ücret).Sum().ToString();
            if (type == özelaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ÖZEL MÜŞTERİLER") select c.Ücret).Sum().ToString();
            if (type == digerkurumaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ŞİRKETLER") select c.Ücret).Sum().ToString();
            if (type == harcamaaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GIDER") select c.Ücret).Sum().ToString();
            if (type == ekgeliraylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GELIR") select c.Ücret).Sum().ToString();
            return item;
        }

        public string Getmontlynetgauge(string type, string date)
        {
            DateTime filterdate = Convert.ToDateTime(date);
            string month = filterdate.Month.ToString("D2");
            string year = filterdate.Year.ToString();
            string outcome = string.Empty;
            string income = string.Empty;
            if (type == genelaylık)
            {
                outcome = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year) select c.Ücret).Sum().ToString();
                income = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year) select c.Ücret).Sum().ToString();
            }
            if (type == adliyeaylık)
            {
                outcome = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Tür != "ÖZEL MÜŞTERİLER" && c.Tür != "ŞİRKETLER") select c.Ücret).Sum().ToString();
                income = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Tür != "ÖZEL MÜŞTERİLER" && c.Tür != "ŞİRKETLER") select c.Ücret).Sum().ToString();
            }
            if (type == özelaylık)
            {
                outcome = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ÖZEL MÜŞTERİLER") select c.Ücret).Sum().ToString();
                income = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ÖZEL MÜŞTERİLER") select c.Ücret).Sum().ToString();
            }
            if (type == digerkurumaylık)
            {
                outcome = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ŞİRKETLER") select c.Ücret).Sum().ToString();
                income = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ŞİRKETLER") select c.Ücret).Sum().ToString();
            }
            if (type == harcamaaylık)
            {
                outcome = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GIDER") select c.Ücret).Sum().ToString();
                income = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GIDER") select c.Ücret).Sum().ToString();
            }
            if (type == ekgeliraylık)
            {
                outcome = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GELIR") select c.Ücret).Sum().ToString();
                income = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GELIR") select c.Ücret).Sum().ToString();
            }
            if (outcome.Trim() == string.Empty)
                outcome = "0";
            if (income.Trim() == string.Empty)
                income = "0";
            double netdeger = Convert.ToDouble(income) - Convert.ToDouble(outcome);
            return netdeger.ToString();
        }

        public string Getmontlypotasialgauege(string type, string date)
        {
            DateTime filterdate = Convert.ToDateTime(date);
            string month = filterdate.Month.ToString("D2");
            string year = filterdate.Year.ToString();
            string item = string.Empty;
            if (type == genelaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year) select c.Beklenentutar).Sum().ToString();
            if (type == adliyeaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Tür != "ÖZEL MÜŞTERİLER" && c.Tür != "ŞİRKETLER") select c.Beklenentutar).Sum().ToString();
            if (type == özelaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ÖZEL MÜŞTERİLER") select c.Beklenentutar).Sum().ToString();
            if (type == digerkurumaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ŞİRKETLER") select c.Beklenentutar).Sum().ToString();
            if (type == harcamaaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GIDER") select c.Beklenentutar).Sum().ToString();
            if (type == ekgeliraylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(3, 2) == month && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GELIR") select c.Beklenentutar).Sum().ToString();
            if (item == string.Empty)
                item = "0";
            if (item == string.Empty)
                item = "0";

            return item;
        }

        public List<partial_analysis> GetAnalysisYearlyAll(string satıs, string satınalma, string month, string year)
        {
            string sql = "Select tbl_customerorder.ID AS ID, tbl_customerorder.Randevutarihi AS RAN_DATE, (SUM(Case When tbl_customerorder.Satışyöntemi = '" + Satış + "' Then";
            sql += " tbl_joborder.Ücret ELSE 0 END) - SUM(Case When tbl_customerorder.Satışyöntemi = '" + Satınalma + "' Then tbl_joborder.Ücret ELSE 0 END))";
            sql += " AS PRICE from tbl_customerorder LEFT JOIN tbl_joborder ON tbl_customerorder.ID = tbl_joborder.Üstid";
            sql += " WHERE MID(tbl_customerorder.Randevutarihi, 7, 4) = '" + year + "' AND tbl_customerorder.savetype = '1' GROUP BY MID(tbl_customerorder.Randevutarihi, 4, 2)";
            var enttiyresult1 = starnoteapicontext.partial_analysis.FromSqlRaw(sql).ToList();
            return enttiyresult1;
        }

        public List<partial_analysis> GetAnalysisYearly(string satıs, string satınalma, string month, string year, string type, string stokname)
        {
            string sqlcmd = "Select tbl_customerorder.ID AS ID, tbl_customerorder.Randevutarihi AS RAN_DATE, (SUM(Case";
            sqlcmd += " When tbl_customerorder.Satışyöntemi = '" + Satış + "' Then tbl_joborder.Ücret ELSE 0 END)";
            sqlcmd += " - SUM(Case When tbl_customerorder.Satışyöntemi = '" + Satınalma + "' Then tbl_joborder.Ücret ELSE 0 END))";
            sqlcmd += " AS PRICE from tbl_customerorder LEFT JOIN tbl_joborder ON tbl_customerorder.ID = tbl_joborder.Üstid WHERE";
            sqlcmd += " MID(tbl_customerorder.Randevutarihi, 7, 4) = '" + year + "' AND tbl_joborder.Ürün2 = '" + stokname + "' ";
            if (type == adliyeyıllık)
            {
                sqlcmd += " AND tbl_customerorder.Savetype='0'";
                sqlcmd += " AND tbl_customerorder.Tür <>'ÖZEL MÜŞTERİLER'";
                sqlcmd += " AND tbl_customerorder.Tür <>'ŞİRKETLER'";
            }
            if (type == özelyıllık)
            {
                sqlcmd += "AND tbl_customerorder.Savetype='0'";
                sqlcmd += " AND tbl_customerorder.Tür ='ÖZEL MÜŞTERİLER'";
            }
            if (type == digerkurumyıllık)
            {
                sqlcmd += " AND tbl_customerorder.Savetype='0'";
                sqlcmd += " AND tbl_customerorder.Tür ='ŞİRKETLER'";
            }
            if (type == harcamayıllık)
            {
                sqlcmd += " AND tbl_customerorder.Savetype='1'";
                sqlcmd += " AND tbl_customerorder.Satışyöntemi = 'GIDER'";
            }
            if (type == ekgeliryıllık)
            {
                sqlcmd += " AND tbl_customerorder.Savetype='1'";
                sqlcmd += " AND tbl_customerorder.Satışyöntemi = 'GELIR'";
            }
            sqlcmd += " GROUP BY MID(tbl_customerorder.Randevutarihi, 4, 2)";
            var enttiyresult = starnoteapicontext.partial_analysis.FromSqlRaw(sqlcmd).ToList();
            return enttiyresult;
        }

        public string GetYearlysalesgauge(string Tür, string date)
        {
            DateTime filterdate = Convert.ToDateTime(date);
            string month = filterdate.Month.ToString("D2");
            string year = filterdate.Year.ToString();
            string item = string.Empty;
            if (Tür == genelyıllık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(6, 4) == year) select c.Ücret).Sum().ToString();
            if (Tür == adliyeyıllık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(6, 4) == year && c.Tür != "ÖZEL MÜŞTERİLER" && c.Tür != "ŞİRKETLER") select c.Ücret).Sum().ToString();
            if (Tür == özelyıllık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ÖZEL MÜŞTERİLER") select c.Ücret).Sum().ToString();
            if (Tür == digerkurumyıllık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ŞİRKETLER") select c.Ücret).Sum().ToString();
            if (Tür == harcamayıllık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GIDER") select c.Ücret).Sum().ToString();
            if (Tür == ekgeliryıllık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GELIR") select c.Ücret).Sum().ToString();
            if (item == string.Empty)
                item = "0";
            return item;
        }

        public string GetYearlypurchasegauge(string Tür, string date)
        {
            DateTime filterdate = Convert.ToDateTime(date);
            string month = filterdate.Month.ToString("D2");
            string year = filterdate.Year.ToString();
            string item = string.Empty;
            if (Tür == genelaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(6, 4) == year) select c.Ücret).Sum().ToString();
            if (Tür == adliyeaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(6, 4) == year && c.Tür != "ÖZEL MÜŞTERİLER" && c.Tür != "ŞİRKETLER") select c.Ücret).Sum().ToString();
            if (Tür == özelaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ÖZEL MÜŞTERİLER") select c.Ücret).Sum().ToString();
            if (Tür == digerkurumaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ŞİRKETLER") select c.Ücret).Sum().ToString();
            if (Tür == harcamaaylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GIDER") select c.Ücret).Sum().ToString();
            if (Tür == ekgeliraylık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GELIR") select c.Ücret).Sum().ToString();
            if (item == string.Empty)
                item = "0";
            return item;
        }

        public string GetYearlynetgauge(string Tür, string date)
        {
            DateTime filterdate = Convert.ToDateTime(date);
            string month = filterdate.Month.ToString("D2");
            string year = filterdate.Year.ToString();
            string outcome = string.Empty;
            string income = string.Empty;
            if (Tür == genelaylık)
            {
                outcome = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(6, 4) == year) select c.Ücret).Sum().ToString();
                income = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(6, 4) == year) select c.Ücret).Sum().ToString();
            }
            if (Tür == adliyeaylık)
            {
                outcome = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(6, 4) == year && c.Tür != "ÖZEL MÜŞTERİLER" && c.Tür != "ŞİRKETLER") select c.Ücret).Sum().ToString();
                income = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(6, 4) == year && c.Tür != "ÖZEL MÜŞTERİLER" && c.Tür != "ŞİRKETLER") select c.Ücret).Sum().ToString();
            }
            if (Tür == özelaylık)
            {
                outcome = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ÖZEL MÜŞTERİLER") select c.Ücret).Sum().ToString();
                income = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ÖZEL MÜŞTERİLER") select c.Ücret).Sum().ToString();
            }
            if (Tür == digerkurumaylık)
            {
                outcome = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ŞİRKETLER") select c.Ücret).Sum().ToString();
                income = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ŞİRKETLER") select c.Ücret).Sum().ToString();
            }
            if (Tür == harcamaaylık)
            {
                outcome = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GIDER") select c.Ücret).Sum().ToString();
                income = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GIDER") select c.Ücret).Sum().ToString();
            }
            if (Tür == ekgeliraylık)
            {
                outcome = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satınalma && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GELIR") select c.Ücret).Sum().ToString();
                income = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GELIR") select c.Ücret).Sum().ToString();
            }
            if (outcome.Trim() == string.Empty)
                outcome = "0";
            if (income.Trim() == string.Empty)
                income = "0";
            double netdeger = Convert.ToDouble(income) - Convert.ToDouble(outcome);
            return netdeger.ToString();
        }

        public string GetYearlypotasialgauege(string Tür, string date)
        {
            DateTime filterdate = Convert.ToDateTime(date);
            string month = filterdate.Month.ToString("D2");
            string year = filterdate.Year.ToString();
            string item = string.Empty;
            if (Tür == genelyıllık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(6, 4) == year) select c.Beklenentutar).Sum().ToString();
            if (Tür == adliyeyıllık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(6, 4) == year && c.Tür != "ÖZEL MÜŞTERİLER" && c.Tür != "ŞİRKETLER") select c.Beklenentutar).Sum().ToString();
            if (Tür == özelyıllık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ÖZEL MÜŞTERİLER") select c.Beklenentutar).Sum().ToString();
            if (Tür == digerkurumyıllık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(6, 4) == year && c.Tür == "ŞİRKETLER") select c.Beklenentutar).Sum().ToString();
            if (Tür == harcamayıllık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GIDER") select c.Beklenentutar).Sum().ToString();
            if (Tür == ekgeliryıllık)
                item = (from c in starnoteapicontext.tbl_customerorder where (c.Satışyöntemi == Satış && c.Randevutarihi.Substring(6, 4) == year && c.Savetype == 1 && c.Satışyöntemi == "GELIR") select c.Beklenentutar).Sum().ToString();
            if (item == string.Empty)
                item = "0";
            return item;
        }

        public string calcsumpayment(string payment, string date, string method)
        {
            return (from c in starnoteapicontext.tbl_customerorder where (c.Ödemeyöntemi == payment && c.Satışyöntemi == method && c.Randevutarihi.Substring(0, 10) == date) select c.Ücret).Sum().ToString();
        }

        public List<partial_saleschart> Getaccountingsales(string method, string month, string year)
        {
            return starnoteapicontext.partial_saleschart.FromSqlRaw("Select Id,Randevutarihi AS RAN_DATE,SUM(Ücret) AS PRICE from tbl_customerorder WHERE Satışyöntemi='" + method + "' AND MID(Randevutarihi, 4, 2) = '" + month + "'AND MID(Randevutarihi, 7, 4) = '" + year + "' Group By Randevutarihi").ToList();
        }

        public List<partial_salespie> Getaccountingpie(string method, string month, string year)
        {
           return starnoteapicontext.partial_salespie.FromSqlRaw("SELECT Id,Ödemeyöntemi AS PAYMENT,COUNT(Ödemeyöntemi)AS COUNT FROM tbl_customerorder WHERE Satışyöntemi='" + method + "' AND MID(Randevutarihi, 4, 2) = '" + month + "'AND MID(Randevutarihi, 7, 4) = '" + year + "' GROUP BY Ödemeyöntemi").ToList();
        }
    }
}
