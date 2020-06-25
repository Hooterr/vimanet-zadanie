using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace vimanet.DataAccess.Entities
{
    /// <summary>
    /// Represents a group of tasks
    /// </summary>
    public class TaskGroup : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// Name of the group
        /// </summary>
        [MinLength(1)]
        public string Name { get; set; }

        #endregion

        #region Relational 

        /// <summary>
        /// Tasks the group consists of
        /// </summary>
        public virtual ICollection<UserTask> UserTasks { get; set; }

        #endregion
    }
}
