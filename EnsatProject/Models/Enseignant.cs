using Castle.MicroKernel.SubSystems.Conversion;
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
    public class Enseignant 
    {
        
        public int Id { get; set; }
        public int? EnsatProjectUserId { get; set; }
        public EnsatProjectUser? EnsatProjectUser { get; set; }
        public MyRole MyRole { get; set; }

        public ICollection<CourseAssignment> CourseAssignments  { get; set; }
    }
}
