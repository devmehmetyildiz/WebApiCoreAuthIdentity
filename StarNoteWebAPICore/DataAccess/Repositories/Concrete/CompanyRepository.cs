using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarNoteWebAPICore.DataAccess.Repositories.Abstract;
using StarNoteWebAPICore.Models;

namespace StarNoteWebAPICore.DataAccess.Repositories.Concrete
{
    public class CompanyRepository : Repository<CompanyModel>, ICompanyRepository
    {
        public StarNoteEntity starnoteapicontext { get { return _context as StarNoteEntity; } }

        private DbSet<CompanyModel> _dbSet;
        public CompanyRepository(StarNoteEntity context) : base(context)
        {
            _dbSet = starnoteapicontext.Set<CompanyModel>();
        }
    }
}

