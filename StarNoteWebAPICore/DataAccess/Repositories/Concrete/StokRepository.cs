using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarNoteWebAPICore.DataAccess.Repositories.Abstract;
using StarNoteWebAPICore.Models;

namespace StarNoteWebAPICore.DataAccess.Repositories.Concrete
{
    public class StokRepository : Repository<StokModel>, IStokRepository
    {
        public StarNoteEntity starnoteapicontext { get { return _context as StarNoteEntity; } }
        private DbSet<StokModel> _dbSet;
        public StokRepository(StarNoteEntity context) : base(context)
        {
            _dbSet = starnoteapicontext.Set<StokModel>();
        }

        public StokModel GetByStockNamme(string name)
        {
            return starnoteapicontext.tbl_stok.SingleOrDefault(u => u.Stokadı == name);
        }
    }
}
