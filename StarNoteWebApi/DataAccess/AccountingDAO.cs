using StarNoteWebApi.EntitiyDB;
using StarNoteWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.DataAccess
{
    public class AccountingDAO : BaseDAO
    {    

        #region montlyaccounting

        public List<DataPoint> Loadsaleschart(string datefilter)
        {
            List<DataPoint> chartsetsales = new List<DataPoint>();
            try
            {
                using (objcontext)
                {
                    DateTime filterdate = Convert.ToDateTime(datefilter);
                    string lastDayOfMonth = (new DateTime(filterdate.Year, filterdate.Month, DateTime.DaysInMonth(filterdate.Year, filterdate.Month))).ToString("dd");
                    string month = filterdate.Month.ToString("D2");
                    string year = filterdate.Year.ToString();
                    objcontext = new StarNoteEntity();
                    var enttiyresult = objcontext.partial_saleschart.SqlQuery("Select ID,Daliverydate AS RAN_DATE,SUM(PRICE) AS PRICE from tbl_customerorder WHERE Salesmethod='" + Satış + "' AND MID(Daliverydate, 4, 2) = '" + month + "'AND MID(Daliverydate, 7, 4) = '" + year + "' Group By Daliverydate").ToList();

                    for (int i = 1; i <= Convert.ToInt16(lastDayOfMonth); i++)
                    {
                        bool isadded = false;
                        foreach (var item in enttiyresult)
                        {
                            if (item.RAN_DATE.Substring(0, 2).ToString() == i.ToString("D2"))
                            {
                                chartsetsales.Add(new DataPoint(i.ToString("D2"), item.PRICE));
                                isadded = true;
                                break;
                            }
                        }
                        if (!isadded)
                        {
                            chartsetsales.Add(new DataPoint(i.ToString("D2"), 0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return chartsetsales;
        }

        public List<DataPoint> loadpurchasecharts(string datefilter)
        {
            List<DataPoint> chartsetpurchase = new List<DataPoint>();
            try
            {
                using (objcontext)
                {
                    DateTime filterdate = Convert.ToDateTime(datefilter);
                    string lastDayOfMonth = (new DateTime(filterdate.Year, filterdate.Month, DateTime.DaysInMonth(filterdate.Year, filterdate.Month))).ToString("dd");
                    string month = filterdate.Month.ToString("D2");
                    string year = filterdate.Year.ToString();
                    objcontext = new StarNoteEntity();
                    var enttiyresult = objcontext.partial_saleschart.SqlQuery("Select ID,Daliverydate AS RAN_DATE,SUM(PRICE) AS PRICE from tbl_customerorder WHERE Salesmethod='" + Satınalma + "' AND MID(Daliverydate, 4, 2) = '" + month + "'AND MID(Daliverydate, 7, 4) = '" + year + "' Group By Daliverydate").ToList();
                    for (int i = 1; i <= Convert.ToInt16(lastDayOfMonth); i++)
                    {
                        bool isadded = false;
                        foreach (var item in enttiyresult)
                        {
                            if (item.RAN_DATE.Substring(0, 2).ToString() == i.ToString("D2"))
                            {
                                chartsetpurchase.Add(new DataPoint(i.ToString("D2"), item.PRICE));
                                isadded = true;
                                break;
                            }
                        }
                        if (!isadded)
                        {
                            chartsetpurchase.Add(new DataPoint(i.ToString("D2"), 0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return chartsetpurchase;
        }

        public List<DataPoint> Loadsalespies(string datefilter)
        {
            List<DataPoint> chartsetsales = new List<DataPoint>();
            try
            {
                using (objcontext)
                {
                    DateTime filterdate = Convert.ToDateTime(datefilter);
                    string month = filterdate.Month.ToString("D2");
                    string year = filterdate.Year.ToString();
                    objcontext = new StarNoteEntity();
                    var enttiyresult = objcontext.partial_salespie.SqlQuery("SELECT ID,Paymentmethod AS PAYMENT,COUNT(Paymentmethod)AS COUNT FROM tbl_customerorder WHERE Salesmethod='" + Satış + "' AND MID(Daliverydate, 4, 2) = '" + month + "'AND MID(Daliverydate, 7, 4) = '" + year + "' GROUP BY Paymentmethod").ToList();
                    foreach (var item in enttiyresult)
                    {
                        chartsetsales.Add(new DataPoint(item.PAYMENT, item.COUNT));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return chartsetsales;
        }

        public List<DataPoint> loadpurchasepies(string datefilter)
        {
            List<DataPoint> chartsetpurchase = new List<DataPoint>();
            try
            {
                using (objcontext)
                {
                    DateTime filterdate = Convert.ToDateTime(datefilter);
                    string month = filterdate.Month.ToString("D2");
                    string year = filterdate.Year.ToString();
                    objcontext = new StarNoteEntity();
                    var enttiyresult = objcontext.partial_salespie.SqlQuery("SELECT ID,Paymentmethod AS PAYMENT,COUNT(Paymentmethod)AS COUNT FROM tbl_customerorder WHERE Salesmethod='" + Satınalma + "' AND MID(Daliverydate, 4, 2) = '" + month + "'AND MID(Daliverydate, 7, 4) = '" + year + "' GROUP BY Paymentmethod").ToList();
                    foreach (var item in enttiyresult)
                    {
                        chartsetpurchase.Add(new DataPoint(item.PAYMENT, item.COUNT));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return chartsetpurchase;
        }

        public List<MontlyAccountingModel> Montlysalesfill(string datefilter)
        {
            List<MontlyAccountingModel> montlysalesmodelsales = new List<MontlyAccountingModel>();
            List<tbl_customerorder> costumerlist = new List<tbl_customerorder>();
            try
            {
                costumerlist = objcontext.tbl_customerorder.ToList();
                int IDSales = 1;
                DateTime filterdate = Convert.ToDateTime(datefilter);
                string month = filterdate.Month.ToString("D2");
                string year = filterdate.Year.ToString();
                foreach (var entity in costumerlist)
                {
                    if (entity.Salesmethod == Satış && entity.Daliverydate.Substring(3, 2).ToString() == month && entity.Daliverydate.Substring(6, 4).ToString() == year)
                    {

                        string ürün = "";
                        foreach (var subistem in objcontext.tbl_joborder.Where(u => u.Upperid == entity.ID))
                        {
                            if (ürün.Length == 0)
                            {
                                ürün += subistem.Amount + " " + subistem.Amounttype + " " + subistem.Producttype + "(" + subistem.Product + ")";
                            }
                            else
                            {
                                ürün += "," + subistem.Amount + " " + subistem.Amounttype + " " + subistem.Producttype + "(" + subistem.Product + ")";
                            }
                        }

                        montlysalesmodelsales.Add(new MontlyAccountingModel
                        {
                            Id = IDSales,
                            Satisgorevli = entity.Salesman,
                            Fiyat = Convert.ToDouble(entity.Price),
                            Randevutarihi = entity.Daliverydate,
                            Urun = ürün,
                            Ödemeyöntemi = entity.Paymentmethod
                        });
                        IDSales++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return montlysalesmodelsales;
        }

        public List<MontlyAccountingModel> Montlypurchasefill(string datefilter)
        {
            List<MontlyAccountingModel> montlysalesmodelpurchase = new List<MontlyAccountingModel>();
            List<tbl_customerorder> costumerlist = new List<tbl_customerorder>();
            try
            {
                costumerlist = objcontext.tbl_customerorder.ToList();
                int IDpurchase = 1;
                DateTime filterdate = Convert.ToDateTime(datefilter);
                string month = filterdate.Month.ToString("D2");
                string year = filterdate.Year.ToString();
                foreach (var entity in costumerlist)
                {
                    if (entity.Salesmethod == Satınalma && entity.Daliverydate.Substring(3, 2).ToString() == month && entity.Daliverydate.Substring(6, 4).ToString() == year)
                    {

                        string ürün = "";
                        foreach (var subistem in objcontext.tbl_joborder.Where(u => u.Upperid == entity.ID))
                        {
                            if (ürün.Length == 0)
                            {
                                ürün += subistem.Amount + " " + subistem.Amounttype + " " + subistem.Producttype + "(" + subistem.Product + ")";
                            }
                            else
                            {
                                ürün += "," + subistem.Amount + " " + subistem.Amounttype + " " + subistem.Producttype + "(" + subistem.Product + ")";
                            }
                        }
                        montlysalesmodelpurchase.Add(new MontlyAccountingModel
                        {
                            Id = IDpurchase,
                            Satisgorevli = entity.Salesman,
                            Fiyat = Convert.ToDouble(entity.Price),
                            Randevutarihi = entity.Daliverydate,
                            Urun = ürün,
                            Ödemeyöntemi = entity.Paymentmethod
                        });
                        IDpurchase++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return montlysalesmodelpurchase;
        }

        #endregion

        #region dailyaccounting
        public List<DailyAccountingModel> dailysalesfill(string date)
        {
            List<DailyAccountingModel> dailysalesmodelsales = new List<DailyAccountingModel>();
            List<tbl_customerorder> costumerlist = new List<tbl_customerorder>();
            
            try
            {
                costumerlist = objcontext.tbl_customerorder.ToList();
                int IDSales = 1;
                foreach (var entity in costumerlist)
                {
                    if (entity.Salesmethod == Satış && Convert.ToDateTime(entity.Daliverydate).ToString("dd.MM.yyyy") == date)
                    {
                        string ürün = "";
                        foreach (var subistem in objcontext.tbl_joborder.Where(u => u.Upperid == entity.ID))
                        {
                            if (ürün.Length == 0)
                            {
                                ürün += subistem.Amount + " " + subistem.Amounttype + " " + subistem.Producttype + "(" + subistem.Product + ")";
                            }
                            else
                            {
                                ürün += "," + subistem.Amount + " " + subistem.Amounttype + " " + subistem.Producttype + "(" + subistem.Product + ")";
                            }

                        }
                        dailysalesmodelsales.Add(new DailyAccountingModel
                        {
                            Id = IDSales,
                            Satisgorevli = entity.Salesman,
                            Fiyat = Convert.ToDouble(entity.Price),
                            Randevutarihi = entity.Daliverydate,
                            Urun = ürün,
                            Ödemeyöntemi = entity.Paymentmethod
                        });
                        IDSales++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dailysalesmodelsales;
        }

        public List<DailyAccountingModel> dailypurchasefill(string date)
        {
            List<DailyAccountingModel> dailysalesmodelpurchase = new List<DailyAccountingModel>();
            List<tbl_customerorder> costumerlist = new List<tbl_customerorder>();
            try
            {
                costumerlist = objcontext.tbl_customerorder.ToList();
                int IDpurchase = 1;
                foreach (var entity in costumerlist)
                {

                    if (entity.Salesmethod == Satınalma && Convert.ToDateTime(entity.Daliverydate).ToString("dd.MM.yyyy") == date)
                    {
                        string ürün = "";
                        foreach (var subistem in objcontext.tbl_joborder.Where(u => u.Upperid == entity.ID))
                        {
                            if (ürün.Length == 0)
                            {
                                ürün += subistem.Amount + " " + subistem.Amounttype + " " + subistem.Producttype + "(" + subistem.Product + ")";
                            }
                            else
                            {
                                ürün += "," + subistem.Amount + " " + subistem.Amounttype + " " + subistem.Producttype + "(" + subistem.Product + ")";
                            }
                        }
                        dailysalesmodelpurchase.Add(new DailyAccountingModel
                        {
                            Id = IDpurchase,
                            Satisgorevli = entity.Salesman,
                            Fiyat = Convert.ToDouble(entity.Price),
                            Randevutarihi = entity.Daliverydate,
                            Urun = ürün,
                            Ödemeyöntemi = entity.Paymentmethod
                        });
                        IDpurchase++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dailysalesmodelpurchase;
        }

        public List<GaugeModel> dailysalesgaugefill(string date)
        {
            List<GaugeModel> gaugelist = new List<GaugeModel>();
            List<string> ödemesource = new List<string>();
            try
            {
                //List<GaugeModel> gaugegoal = new List<GaugeModel>();
                //foreach (var item in objcontext.tbl_hedef)
                //{
                //    gaugegoal.Add(new GaugeModel() { Gaugename = item.Goal, Gaugevalue = item.GoalValue.ToString() });
                //}
                foreach (var ödemeyöntemi in objcontext.tbl_paymenttype)
                {
                    ödemesource.Add(ödemeyöntemi.Value);
                }
                foreach (var yöntem in ödemesource)
                {
                    try
                    {
                        //string sorgu = "DailyPurchase" + yöntem;
                        var toplamtutar = (from c in objcontext.tbl_customerorder where (c.Paymentmethod == yöntem && c.Salesmethod == Satınalma && c.Daliverydate.Substring(0, 10) == date) select c.Price).Sum();
                        //GaugeModel Item = gaugegoal.Find(c => c.Gaugename == sorgu);
                        //double yüzdedeger = (100 * Convert.ToDouble(toplamtutar)) /Convert.ToDouble(Item.Gaugevalue);
                        //GaugeModel gaugeModel = new GaugeModel { Gaugename = yöntem, Gaugevalue = yüzdedeger.ToString() };
                        gaugelist.Add(new GaugeModel { Gaugename = yöntem, Gaugevalue = toplamtutar.ToString() });
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gaugelist;
        }

        public List<GaugeModel> dailypurchasegaugefill(string date)
        {
            List<GaugeModel> gaugelist = new List<GaugeModel>();
            List<string> ödemesource = new List<string>();
            try
            {
                //List<GaugeModel> gaugegoal = new List<GaugeModel>();
                //foreach (var item in objcontext.tbl_hedef)
                //{
                //    gaugegoal.Add(new GaugeModel() { Gaugename = item.Goal, Gaugevalue = item.GoalValue.ToString() });
                //}
                foreach (var ödemeyöntemi in objcontext.tbl_paymenttype)
                {
                    ödemesource.Add(ödemeyöntemi.Value);
                }
                foreach (var yöntem in ödemesource)
                {
                    try
                    {
                        //string sorgu = "DailyPurchase" + yöntem;
                        var toplamtutar = (from c in objcontext.tbl_customerorder where (c.Paymentmethod == yöntem && c.Salesmethod == Satış && c.Daliverydate.Substring(0, 10) == date) select c.Price).Sum();
                        //GaugeModel Item = gaugegoal.Find(c => c.Gaugename == sorgu);
                        //double yüzdedeger = (100 * Convert.ToDouble(toplamtutar)) /Convert.ToDouble(Item.Gaugevalue);
                        //GaugeModel gaugeModel = new GaugeModel { Gaugename = yöntem, Gaugevalue = yüzdedeger.ToString() };
                        gaugelist.Add(new GaugeModel { Gaugename = yöntem, Gaugevalue = toplamtutar.ToString() });
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gaugelist;
        }
        #endregion
    }
}