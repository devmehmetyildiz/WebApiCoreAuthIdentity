using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarNoteWebAPICore.Models;
namespace StarNoteWebAPICore.DataAccess.Repositories.Abstract
{
    public interface IFilemanagementRepository : IRepository<FilemanagementModel>
    {
        List<FilemanagementModel> GetSelectedFiles(int Id);
    }
}
