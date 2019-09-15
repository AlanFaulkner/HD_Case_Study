using CaseStudy.DataTransferObjects.DatabaseDTOs;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Repositories
{
    /// <summary>
    /// Configures database context to work with EF core
    /// </summary>
    public sealed class ApplicationDatabaseContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDatabaseContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<ApplicationDatabaseEntity> Applicants { get; set; }
    }
}