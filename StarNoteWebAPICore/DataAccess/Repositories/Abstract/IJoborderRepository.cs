using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarNoteWebAPICore.Models;
namespace StarNoteWebAPICore.DataAccess.Repositories.Abstract
{
    public interface IJoborderRepository : IRepository<JobOrderModel>
    {
        List<JobOrderModel> GetByIDJobOrders(int id);

        List<JobOrderModel> Getlastordersbycount(int count);

        List<string> Usedstoks();
        
    }
}
