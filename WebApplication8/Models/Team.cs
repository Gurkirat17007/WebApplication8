using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class Team
    {
        [Key]
        public int Boys { get; set; }

        [Required]
        [StringLength(10)]
        public string Girls { get; set; }

        [Required]
        [StringLength(10)]
        public string Kids { get; set; }

        [Required]
        [StringLength(10)]
        public string Old { get; set; }
    }
}
