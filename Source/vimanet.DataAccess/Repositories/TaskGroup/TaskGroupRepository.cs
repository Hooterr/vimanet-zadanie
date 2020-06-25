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
                Id = item.Id,
                Name = item.Name,
                TotalNumberOfTasks = item.UserTasks.Count(),
            });

            return query.ToList();
        }

        public TaskGroupWithTasksContent GetTaskGroupContext(int id)
        {
            var group = DbSet
                .Where(group => group.Id == id)
                .Include(group => group.UserTasks)
                .FirstOrDefault();
            if (group == null)
                return null;

            return new TaskGroupWithTasksContent() {
                Id = group.Id,
                Name = group.Name,
                UserTasks = group.UserTasks.Select(task => new TaskContext()
                {
                    Id = task.Id,
                    Name = task.Name,
                    Deadline = task.Deadline,
                    Status = task.Status,
                    AssignedUserId = task.AssignedUserId ?? 0,
                })
            };
        }

        public void Update(TaskGroup group)
        {
            Db.Entry(group).State = EntityState.Modified;
        }
    }
}
