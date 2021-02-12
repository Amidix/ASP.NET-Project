using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnsatProject.Areas.Identity.Data;
using EnsatProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EnsatProject.Data
{
    public class EnsatProjectContext : IdentityDbContext<EnsatProjectUser>
    {
        public EnsatProjectContext(DbContextOptions<EnsatProjectContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
             // builder.Entity<Matiere>().ToTable("Matiere");
          //builder.Entity<Enrollment>().ToTable("Enrollment");
            //  builder.Entity<Eleve>().ToTable("Eleve");
            //   builder.Entity<Filiere>().ToTable("Filiere");
            //   builder.Entity<Enseignant>().ToTable("Enseignant");
            //  builder.Entity<CourseAssignment>().ToTable("CourseAssignment");
            //     builder.Entity<CourseAssignment>()
             // .HasKey(c => new { c.MatiereID, c.EnseignantID });
        }
    // public DbSet<Enseignant> Enseignants { get; set; }
    //    public DbSet<Matiere> Matieres { get; set; }
      //  public DbSet<Module> Modules { get; set; }
     //   public DbSet<CourseAssignment> CourseAssignements { get; set; }
    //    public DbSet<Enrollment> Enrollments { get; set; }
     //   public DbSet<Filiere> Filieres { get; set; }

    }
}
