using EnsatProject.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnsatProject.Models
{
    public class Enrollment
    {
     
        public int EnrollmentId { get; set; }
        public int? EleveId { get; set; }
        public int? MatiereId { get; set; }
        public int? NoteId { get; set; }
        public Note Note { get; set; }
        public Eleve Eleve { get; set; }
        public Matiere Matiere { get; set; }
    }
}
