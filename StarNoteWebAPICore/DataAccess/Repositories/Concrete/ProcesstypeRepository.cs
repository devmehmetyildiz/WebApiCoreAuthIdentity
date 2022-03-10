using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarNoteWebAPICore.DataAccess.Repositories.Abstract;
using StarNoteWebAPICore.Models;

namespace StarNoteWebAPICore.DataAccess.Repositories.Concrete
{
    public class ProcesstypeRepository : Repository<ProcesstypeModel>, IProcesstypeRepository
    {
        public StarNoteEntity starnoteapicontext { get { return _context as StarNoteEntity; } }

        private DbSet<ProcesstypeModel> _dbSet;
        public ProcesstypeRepository(StarNoteEntity context) : base(context)
        {
            _dbSet = starnoteapicontext.Set<ProcesstypeModel>();
        }
    }
}
