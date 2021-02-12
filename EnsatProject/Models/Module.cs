using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnsatProject.Models
{
    public class Module
    {

        public int ModuleId { get; set; }
        public string NomModule { get; set; }
        public ICollection<Matiere> Matieres { get; set; }
        public Enseignant Coordinateur { get; set; }
    }
}
