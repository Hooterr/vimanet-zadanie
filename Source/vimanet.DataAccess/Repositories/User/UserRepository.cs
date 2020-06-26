using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using vimanet.DataAccess.Entities;
using vimanet.DataAccess.Repositories.Contexts;

namespace vimanet.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        protected override DbSet<User> DbSet => Db.Users;
        
        public UserRepository(AppDataContext db) : base(db)
        { }

        public void Update(User user)
        {
            Db.Entry(user).State = EntityState.Modified;
        }

        public UserInfoContext GetInfo(int id)
        {
            var user = DbSet.Find(id);
            UserInfoContext result = null;
            if (user != null)
            {
                result = new UserInfoContext()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                };
            }
            return result;
        }

        public IEnumerable<UserInfoContext> GetInfoAll()
        {
            return DbSet.Select(user => new UserInfoContext()
            {
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
            }).ToList();
        }
    }
}
