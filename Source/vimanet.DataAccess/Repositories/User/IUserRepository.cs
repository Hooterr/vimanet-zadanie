using System;
using System.Collections.Generic;
using System.Text;
using vimanet.DataAccess.Entities;

namespace vimanet.DataAccess.Repositories
{
    /// <summary>
    /// Provides data access for <see cref="User"/>
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
    }
}
