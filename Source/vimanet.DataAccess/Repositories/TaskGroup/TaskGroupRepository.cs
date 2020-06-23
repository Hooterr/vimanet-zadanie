using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vimanet.DataAccess.Entities;

namespace vimanet.DataAccess.Repositories
{
    /// <summary>
    /// Repository to manage <see cref="TaskGroup"/>
    /// </summary>
    public class TaskGroupRepository : BaseRepository<TaskGroup>, ITaskGroupRepository
    {
        protected override DbSet<TaskGroup> DbSet => Db.Groups;

        public TaskGroupRepository(AppDataContext db) : base(db)
        { }

        public List<TaskGroupOverviewContext> GetOverview()
        {
            var query = DbSet.Select(item => new TaskGroupOverviewContext()
            {
                Name = item.Name,
                TotalNumberOfTasks = item.UserTasks.Count(),
            });

            return query.ToList();
        }
    }
}
