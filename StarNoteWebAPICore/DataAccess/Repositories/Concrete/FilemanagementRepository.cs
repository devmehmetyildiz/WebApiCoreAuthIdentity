using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarNoteWebAPICore.DataAccess.Repositories.Abstract;
using StarNoteWebAPICore.Models;

namespace StarNoteWebAPICore.DataAccess.Repositories.Concrete
{
    public class FilemanagementRepository : Repository<FilemanagementModel>, IFilemanagementRepository
    {
        public StarNoteEntity starnoteapicontext { get { return _context as StarNoteEntity; } }

        private DbSet<FilemanagementModel> _dbSet;
        public FilemanagementRepository(StarNoteEntity context) : base(context)
        {
            _dbSet = starnoteapicontext.Set<FilemanagementModel>();
        }

        public List<FilemanagementModel> GetSelectedFiles(int Id)
        {
            return starnoteapicontext.tbl_filemanagement.Where(u => u.Mainid == Id).ToList();
        }
    }
}
