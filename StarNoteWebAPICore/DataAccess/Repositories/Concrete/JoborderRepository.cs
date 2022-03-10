﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarNoteWebAPICore.DataAccess.Repositories.Abstract;
using StarNoteWebAPICore.Models;

namespace StarNoteWebAPICore.DataAccess.Repositories.Concrete
{
    public class JoborderRepository : Repository<JobOrderModel>, IJoborderRepository
    {
        public StarNoteEntity starnoteapicontext { get { return _context as StarNoteEntity; } }

        private DbSet<JobOrderModel> _dbSet;
        public JoborderRepository(StarNoteEntity context) : base(context)
        {
            _dbSet = starnoteapicontext.Set<JobOrderModel>();
        }

        public List<JobOrderModel> GetByIDJobOrders(int id)
        {
            return starnoteapicontext.tbl_joborder.Where(u => u.Üstid == id).ToList();
        }
    }
}
