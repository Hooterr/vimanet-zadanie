using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using vimanet.DataAccess.Entities;

namespace vimanet.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        protected override DbSet<User> DbSet => Db.Users;
        
        public UserRepository(AppDataContext db) : base(db)
        { }
    }
}
