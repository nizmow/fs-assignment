using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class FsAssignmentContext : DbContext
    {
        /// <summary>
        /// Stores history of all processed numbers to English of our application.
        /// </summary>
        public DbSet<NumberToEnglishProcessed> NumbersToEnglishProcessed { get; set; }


        public FsAssignmentContext(DbContextOptions<FsAssignmentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new NumberToEnglishProcessedConfiguration());
        }
    }
}