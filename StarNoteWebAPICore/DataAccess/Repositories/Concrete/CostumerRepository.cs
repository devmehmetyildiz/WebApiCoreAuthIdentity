using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarNoteWebAPICore.DataAccess.Repositories.Abstract;
using StarNoteWebAPICore.Models;

namespace StarNoteWebAPICore.DataAccess.Repositories.Concrete
{
    public class CostumerRepository : Repository<CostumerModel>, ICostumerRepository
    {
        public StarNoteEntity starnoteapicontext { get { return _context as StarNoteEntity; } }

        private DbSet<CostumerModel> _dbSet;
        public CostumerRepository(StarNoteEntity context) : base(context)
        {
            _dbSet = starnoteapicontext.Set<CostumerModel>();
        }
    }
}
