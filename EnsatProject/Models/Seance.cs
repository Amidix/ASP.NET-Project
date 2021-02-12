using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnsatProject.Models
{
    public class Seance
    {
        public int SeanceId { get; set; }
        public int? EnseignantId { get; set; }
        public Enseignant? Enseignant { get; set; }
        public int? MatiereId { get; set; }
        public Matiere? Matiere { get; set; }
        [Display(Name = "Debut de Seance")]
        public DateTime DebutSeance{ get; set; }
        [Display(Name = "Fin de Seance")]
        public DateTime FinSeance { get; set; }
        public int Salle { get; set; }
    }
}
