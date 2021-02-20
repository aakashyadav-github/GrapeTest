using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrapeTest.Models
{
    public class Blog
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

       
    }
}
