using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnsatProject.Models
{
    public class Filiere
    {
      
        public int? FiliereId { get; set; }
        public string NomFiliere { get; set; }
        public int? ChefFiliereId { get; set; }
        public Enseignant ChefFiliere { get; set; }
        public ICollection<Matiere> Matieres { get; set; }

    }
}
