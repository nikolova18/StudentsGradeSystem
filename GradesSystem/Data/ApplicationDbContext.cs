namespace GradesSystem.Data
{
    using GradesSystem.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Student> Students { get; init; }
        public DbSet<Subject> Subjects { get; init; }
        public DbSet<SubjectGrades> SubjectGrades { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<SubjectGrades>()
                .HasKey(ssg => new { ssg.StudentId, ssg.SubjectId });
                



            base.OnModelCreating(builder);
        }
    }
}
