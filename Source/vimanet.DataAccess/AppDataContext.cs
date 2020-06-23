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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Set in-memory database
            optionsBuilder.UseSqlite("Data Source=:memory:; Version=3; New=True;");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
