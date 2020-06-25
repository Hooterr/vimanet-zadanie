using Microsoft.EntityFrameworkCore;
using System.Linq;
using vimanet.DataAccess.Entities;

namespace vimanet.DataAccess.Repositories
{
    public class UserTaskRepository : BaseRepository<UserTask>, IUserTaskRepository
    {
        protected override DbSet<UserTask> DbSet => Db.Tasks;

        public UserTaskRepository(AppDataContext db) : base(db)
        {   }

        public void Update(UserTask task)
        {
            Db.Entry(task).State = EntityState.Modified;       
        }
    }
}
