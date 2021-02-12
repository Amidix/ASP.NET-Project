using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnsatProject.Models
{
    public class CourseAssignment
    {
        
        public int EnseignantId  { get; set; }
       
        public int MatiereId { get; set; }
        public Enseignant Enseignant { get; set; }
        public Matiere Matiere { get; set; }
    }
}
