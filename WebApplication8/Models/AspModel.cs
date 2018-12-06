using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class AspModel : DbContext
    {
        public AspModel(DbContextOptions<AspModel>options) : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Sport> Sports { get; set; }

    }
}
