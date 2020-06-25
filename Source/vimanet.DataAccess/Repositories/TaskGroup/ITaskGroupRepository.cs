using System;
using System.Collections.Generic;
using System.Text;
using vimanet.DataAccess.Entities;

namespace vimanet.DataAccess.Repositories
{
    /// <summary>
    /// Provides data access for <see cref="TaskGroup"/>
    /// </summary>
    public interface ITaskGroupRepository : IRepository<TaskGroup>
    {
        /// <summary>
        /// Gets overview information
        /// </summary>
        /// <returns>Overview context</returns>
        List<TaskGroupOverviewContext> GetOverview();

        TaskGroupWithTasksContent GetTaskGroupContext(int id);

        void Update(TaskGroup group);
    }
}
