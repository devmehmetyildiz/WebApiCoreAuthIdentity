using Microsoft.EntityFrameworkCore;
using StarNoteWebAPICore.DataAccess.Repositories.Abstract;
using StarNoteWebAPICore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarNoteWebAPICore.DataAccess.Repositories.Concrete
{
    public class CaseRepository : Repository<CaseModel>, ICaseRepository
    {
        public StarNoteEntity starnoteapicontext { get { return _context as StarNoteEntity; } }

        private DbSet<CaseModel> _dbSet;
        public CaseRepository(StarNoteEntity context) : base(context)
        {
            _dbSet = starnoteapicontext.Set<CaseModel>();
        }
    }
}
