using System.Linq;
using vimanet.DataAccess.Entities;

namespace vimanet.DataAccess.Repositories
{
    /// <summary>
    /// Provides data access for <see cref="UserTask"/>
    /// </summary>
    public interface IUserTaskRepository : IRepository<UserTask>
    {
        void Update(UserTask task);
    }
}
