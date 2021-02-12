using EnsatProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnsatProject.Models
{
    public enum MyRole
    {
        eleve,
        enseignant,
        admin
    }
    public class Eleve 
    { 

        public int Id { get; set; }
        public int? EnsatProjectUserId { get; set; }
        public EnsatProjectUser? EnsatProjectUser { get; set; }
        public string CIN { get; set; }
        public string CNE { get; set; }
        public MyRole MyRole { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public Filiere? Filiere { get; set; }
        public int? FiliereId {get; set;}
        
    }
}

