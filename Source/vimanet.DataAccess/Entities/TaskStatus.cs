using System;
using System.Collections.Generic;
using System.Text;

namespace vimanet.DataAccess.Entities
{
    /// <summary>
    /// Represents status of a task
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// Task was just created
        /// </summary>
        New = 0,

        /// <summary>
        /// Task is in progress
        /// </summary>
        InProgress,

        /// <summary>
        /// Task is completed
        /// </summary>
        Completed,
    }
}
