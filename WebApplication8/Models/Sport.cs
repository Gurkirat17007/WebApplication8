using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class Sport
    {
        [Key]
        public int Boys { get; set; }

        [Required]
        [StringLength(10)]
        public string Soccer { get; set; }

        [Required]
        [StringLength(10)]
        public string Baseball { get; set; }

        [Required]
        [StringLength(10)]
        public string Rugby { get; set; }
    }
}
