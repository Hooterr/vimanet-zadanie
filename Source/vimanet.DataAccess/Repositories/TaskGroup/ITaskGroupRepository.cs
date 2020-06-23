using System;
using System.Collections.Generic;
using System.Text;

namespace vimanet.DataAccess.Repositories
{
    /// <summary>
    /// Provides data access for <see cref="TaskGroup"/>
    /// </summary>
    public interface ITaskGroupRepository
    {
        /// <summary>
        /// Gets overview information
        /// </summary>
        /// <returns>Overview context</returns>
        List<TaskGroupOverviewContext> GetOverview();
    }
}
