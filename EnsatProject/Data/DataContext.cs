using EnsatProject.Areas.Identity.Data;
using EnsatProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnsatProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
         //   builder.Entity<Matiere>().ToTable("Matiere");
           // builder.Entity<Enrollment>().ToTable("Enrollment");
            //  builder.Entity<Eleve>().ToTable("Eleve");
            //   builder.Entity<Filiere>().ToTable("Filiere");
            //   builder.Entity<Enseignant>().ToTable("Enseignant");
            //  builder.Entity<CourseAssignment>().ToTable("CourseAssignment");
                 builder.Entity<CourseAssignment>()
                 .HasKey(c => new { c.MatiereId, c.EnseignantId });
        }
        public DbSet<Enseignant> Enseignant { get; set; }
        public DbSet<EnsatProjectUser> EnsatProjectUser { get; set; }
        public DbSet<Matiere> Matiere { get; set; }
          public DbSet<Module> Module { get; set; }
         public DbSet<CourseAssignment> CourseAssignment { get; set; }
            public DbSet<Enrollment> Enrollment { get; set; }
           public DbSet<Filiere> Filiere { get; set; }
        public DbSet<Eleve> Eleve { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<Seance> Seance { get; set; }
        public DbSet<Absence> Absence { get; set; }
    }
}
