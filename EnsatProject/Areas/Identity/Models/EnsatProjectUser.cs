using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EnsatProject.Models;
using Microsoft.AspNetCore.Identity;


namespace EnsatProject.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the EnsatProjectUser class
 
    public class EnsatProjectUser : IdentityUser
    {
        public int Id { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public String Nom { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public String Prenom { get; set; }
        [PersonalData]
        [Column(TypeName = "int")]
        public int Age { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public String Email { get; set; }
       //public ICollection<Enrollment> Enrollments { get; set; }
       //public Filiere Filiere { get; set; }
       //public int FiliereID {get; set;}
        public string fullName
        {
            get
            {
                return this.Nom + " " + this.Prenom;
            }
        }
    }
}
