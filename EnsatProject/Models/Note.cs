using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnsatProject.Models
{
    public class Note
    {
        public int Id { get; set; }
        public float Valeur { get; set; }
        public int MatiereId { get; set; }
        public int? StudentId { get; set; }

        // Navigation Properties
        public  Matiere Matiere { get; set; }
        public  Eleve Eleve { get; set; }
    }
}
