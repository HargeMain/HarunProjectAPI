using HarunProjectAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HarunProjectAPI.ModelCreation
{
    public static class ModelRelationHelperBuilder
    {
        public static void BuildModelRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Depertment)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DepertmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectWorkLog>()
                .HasOne(p => p.User)
                .WithMany(u => u.ProjectWorkLogs)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectWorkLog>()
                .HasOne(p => p.ApprovedByUser)
                .WithMany(u => u.ApprovedWorkLogs)
                .HasForeignKey(p => p.ApprovedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectWorkLog>()
                .HasOne(p => p.Project)
                .WithMany(p => p.WorkLogs)
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Company)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Depertment)
                .WithMany(d => d.Projects)
                .HasForeignKey(p => p.DepertmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
