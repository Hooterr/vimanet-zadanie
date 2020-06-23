using System;
using System.Collections.Generic;
using System.Text;

namespace vimanet.DataAccess.Entities
{
    /// <summary>
    ///  Base class for every entity
    /// </summary>
    public abstract class BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// Id of the entity
        /// </summary>
        public int Id { get; set; }

        #endregion
    }
}
