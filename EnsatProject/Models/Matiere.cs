using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnsatProject.Models
{
    public class Matiere
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MatiereId { get; set; }
        public string NomMatiere { get; set; }
        public float HeuresCours { get; set; }
        public float HeuresTD { get; set; }
        public float HeuresTP { get; set; }
       public int FiliereId { get; set; }
       public Filiere Filiere { get; set; }
        public Module Module { get; set; }
        public ICollection<Enrollment> Entrollments { get; set; }
        public ICollection<CourseAssignment> CourseAssignements { get; set; }
    }
}
