﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarNoteWebAPICore.DataAccess.Repositories.Abstract;
using StarNoteWebAPICore.Models;

namespace StarNoteWebAPICore.DataAccess.Repositories.Concrete
{
    public class TypedetailRepository : Repository<TypedetailModel>, ITypedetailRepository
    {
        public StarNoteEntity starnoteapicontext { get { return _context as StarNoteEntity; } }

        private DbSet<TypedetailModel> _dbSet;
        public TypedetailRepository(StarNoteEntity context) : base(context)
        {
            _dbSet = starnoteapicontext.Set<TypedetailModel>();
        }
    }
}
