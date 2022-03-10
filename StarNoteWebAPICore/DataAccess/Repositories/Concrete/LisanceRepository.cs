﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarNoteWebAPICore.DataAccess.Repositories.Abstract;
using StarNoteWebAPICore.EntityDB;
using StarNoteWebAPICore.Models;

namespace StarNoteWebAPICore.DataAccess.Repositories.Concrete
{
    public class LisanceRepository : Repository<LisanceModel>, ILisanceRepository
    {
        public StarNoteEntity starnoteapicontext { get { return _context as StarNoteEntity; } }

        private DbSet<LisanceModel> _dbSet;
        public LisanceRepository(StarNoteEntity context) : base(context)
        {
            _dbSet = starnoteapicontext.Set<LisanceModel>();
        }
    }
}
