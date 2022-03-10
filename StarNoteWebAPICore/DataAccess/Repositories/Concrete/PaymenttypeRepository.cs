using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarNoteWebAPICore.DataAccess.Repositories.Abstract;
using StarNoteWebAPICore.Models;

namespace StarNoteWebAPICore.DataAccess.Repositories.Concrete
{
    public class PaymenttypeRepository : Repository<PaymenttypeModel>, IPaymenttypeRepository
    {
        public StarNoteEntity starnoteapicontext { get { return _context as StarNoteEntity; } }

        private DbSet<PaymenttypeModel> _dbSet;
        public PaymenttypeRepository(StarNoteEntity context) : base(context)
        {
            _dbSet = starnoteapicontext.Set<PaymenttypeModel>();
        }
    }
}
