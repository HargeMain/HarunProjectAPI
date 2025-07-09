using HarunProjectAPI.ModelCreation;
using HarunProjectAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HarunProjectAPI.DBContext
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }

        protected DBContext()
        {
        }
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Depertment> Depertments { get; set; } = null!;
        public DbSet<ProjectWorkLog> ProjectWorkLogs { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);
            ModelRelationHelperBuilder.BuildModelRelations(modelBuilder);
        }
    }
}
