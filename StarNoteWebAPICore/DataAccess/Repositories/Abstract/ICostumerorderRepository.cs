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

        List<>
    }
}
