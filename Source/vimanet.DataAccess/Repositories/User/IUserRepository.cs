using System;
using System.Collections.Generic;
using System.Text;
using vimanet.DataAccess.Entities;
using vimanet.DataAccess.Repositories.Contexts;

namespace vimanet.DataAccess.Repositories
{
    /// <summary>
    /// Provides data access for <see cref="User"/>
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        void Update(User user);
        UserInfoContext GetInfo(int id);
        IEnumerable<UserInfoContext> GetInfoAll();
    }
}
