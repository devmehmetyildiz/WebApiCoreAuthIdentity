using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarNoteWebAPICore.DataAccess.Repositories.Abstract;
using StarNoteWebAPICore.Models;

namespace StarNoteWebAPICore.DataAccess.Repositories.Concrete
{
    public class TypeRepository : Repository<TypeModel>, ITypeRepository
    {
        public StarNoteEntity starnoteapicontext { get { return _context as StarNoteEntity; } }

        private DbSet<TypeModel> _dbSet;
        public TypeRepository(StarNoteEntity context) : base(context)
        {
            _dbSet = starnoteapicontext.Set<TypeModel>();
        }
    }
}
