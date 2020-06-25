using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using vimanet.DataAccess.Entities;

namespace vimanet.DataAccess
{
    /// <summary>
    /// Db context for the application
    /// </summary>
    public class AppDataContext : DbContext
    {

        #region Db Sets

        public DbSet<User> Users { get; set; }
        public DbSet<TaskGroup> Groups { get; set; }
        public DbSet<UserTask> Tasks { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="options">Options to configure</param>
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {   }

        #endregion

    }
}
