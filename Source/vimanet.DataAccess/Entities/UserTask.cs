using System;
using System.Collections.Generic;
using System.Text;

namespace vimanet.DataAccess.Entities
{
    /// <summary>
    /// Represents a single task
    /// </summary>
    public class UserTask : BaseEntity
    {

        #region Public Properties

        /// <summary>
        /// Name of the task
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Deadline of the task
        /// </summary>
        public DateTime Deadline { get; set; }

        public Status Status { get; set; }

        #endregion

        #region Relational 

        /// <summary>
        /// Id of the user assigned to this task
        /// </summary>
        public virtual int? UserId { get; set; }

        /// <summary>
        /// User that is assigned to this task
        /// </summary>
        public virtual User User { get; set; }

        #endregion

    }
}
