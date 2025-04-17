using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Assignment18_EFcore
{
    public class AppDbContext : DbContext
    {
        public DbSet<School> school;
        public DbSet<Department> departments;
        public DbSet<Teacher> teachers;
        public DbSet<TeacherTransfer> teachersTransfer;
        protected override void OnConfiguring(DbContextOptionsBuilder opt) 
            => opt.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=initialDB;Integrated Security=True;");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>()
                .HasOne(s => s.dept)
                .WithMany(d => d.Schools)
                .HasForeignKey(s => s.deptId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.School)
                .WithMany(s => s.Teachers)
                .HasForeignKey(t => t.SchoolId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TeacherTransfer>()
                .HasOne(tt => tt.Teacher)
                .WithMany(t => t.TeacherTransfers)
                .HasForeignKey(tt => tt.TeacherID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TeacherTransfer>()
                .HasOne(tt => tt.FromSchool)
                .WithMany(s => s.FromTransfers)
                .HasForeignKey(tt => tt.FromSchoolID)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<TeacherTransfer>()
                .HasOne(tt => tt.ToSchool)
                .WithMany(s => s.ToTransfers)
                .HasForeignKey(tt => tt.ToSchoolID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
