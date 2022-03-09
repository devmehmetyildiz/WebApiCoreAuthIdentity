using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarNoteWebAPICore.DataAccess.Repositories.Abstract;
using StarNoteWebAPICore.EntityDB;
using StarNoteWebAPICore.Models;

namespace StarNoteWebAPICore.DataAccess.Repositories.Concrete
{
    public class UserRepository : Repository<CaseModel>, ICaseRepository
    {
        public StarNoteEntity starnoteapicontext { get { return _context as StarNoteEntity; } }

        private DbSet<CaseModel> _dbSet;
        public CaseRepository(StarNoteEntity context) : base(context)
        {
            _dbSet = starnoteapicontext.Set<CaseModel>();
        }
    }
}
