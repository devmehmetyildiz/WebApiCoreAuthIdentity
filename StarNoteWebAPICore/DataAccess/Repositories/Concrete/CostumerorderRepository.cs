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
    }
}
