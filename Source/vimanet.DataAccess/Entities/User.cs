using System;
using System.Collections.Generic;
using System.Text;

namespace vimanet.DataAccess.Entities
{
    /// <summary>
    /// Represents a user
    /// </summary>
    public class User : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// User's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User's last name
        /// </summary>
        public string LastName { get; set; }

        #endregion

        #region Relational 

        /// <summary>
        /// Tasks assigned to this user
        /// </summary>
        public virtual ICollection<UserTask> Tasks { get; set; }

        #endregion
    }
}
