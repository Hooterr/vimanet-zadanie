using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [MinLength(1)]
        public string Name { get; set; }
        
        /// <summary>
        /// Deadline of the task
        /// </summary>
        [Required]
        public DateTime Deadline { get; set; }

        /// <summary>
        /// The status of the task described by <see cref="TaskStatus"/>
        /// </summary>
        [Required]
        public TaskStatus Status { get; set; }

        #endregion

        #region Relational 

        /// <summary>
        /// Id of the user assigned to this task
        /// </summary>
        public virtual int? AssignedUserId { get; set; }

        /// <summary>
        /// User that is assigned to this task
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Owner's group ID
        /// </summary>
        public virtual int TaskGroupId { get; set; }

        /// <summary>
        /// The group that owns this task
        /// </summary>
        public virtual TaskGroup Group { get; set; }

        #endregion

    }
}
