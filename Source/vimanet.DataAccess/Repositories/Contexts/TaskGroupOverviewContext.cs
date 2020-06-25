using System;
using System.Collections.Generic;
using System.Text;

namespace vimanet.DataAccess.Repositories
{
    /// <summary>
    /// Overview context for <see cref="TaskGroup"/>
    /// </summary>
    public class TaskGroupOverviewContext
    {
        /// <summary>
        /// Id of the group
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the group
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Total number of tasks that this group consists of
        /// </summary>
        public int TotalNumberOfTasks { get; set; }

    }
}
