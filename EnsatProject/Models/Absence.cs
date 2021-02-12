using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnsatProject.Models
{
    public class Absence
    {
        public int AbsenceId { get; set; }
        public int? EleveId { get; set; }
        public int? SeanceId { get; set; }

        public Boolean Absent { get; set; }

        // Navigation Properties
        public Eleve Eleve { get; set; }
        public Seance Seance { get; set; }
    }
}
