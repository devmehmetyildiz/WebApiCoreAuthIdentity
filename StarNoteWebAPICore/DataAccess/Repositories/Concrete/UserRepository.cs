using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarNoteWebAPICore.DataAccess.Repositories.Abstract;
using StarNoteWebAPICore.Models;

namespace StarNoteWebAPICore.DataAccess.Repositories.Concrete
{
    public class UserRepository : Repository<UsersModel>, IUserRepository
    {
        public StarNoteEntity starnoteapicontext { get { return _context as StarNoteEntity; } }

        private DbSet<UsersModel> _dbSet;
        public UserRepository(StarNoteEntity context) : base(context)
        {
            _dbSet = starnoteapicontext.Set<UsersModel>();
        }

        public UsersModel Finduser(string username, string password)
        {
            return starnoteapicontext.tbl_users.FirstOrDefault(u => u.Kullanıcıadi == username && u.Şifre == password);
        }
    }
}
