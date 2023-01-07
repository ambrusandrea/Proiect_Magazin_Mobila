using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin_Mobila.Models;

namespace Proiect_Magazin_Mobila.Data
{
    public class Proiect_Magazin_MobilaContext : DbContext
    {
        public Proiect_Magazin_MobilaContext (DbContextOptions<Proiect_Magazin_MobilaContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Magazin_Mobila.Models.Furniture> Furniture { get; set; } = default!;

        public DbSet<Proiect_Magazin_Mobila.Models.Designer> Designer { get; set; }

        public DbSet<Proiect_Magazin_Mobila.Models.Material> Material { get; set; }

        public DbSet<Proiect_Magazin_Mobila.Models.Category> Category { get; set; }

        public DbSet<Proiect_Magazin_Mobila.Models.Member> Member { get; set; }

        public DbSet<Proiect_Magazin_Mobila.Models.Registration> Registration { get; set; }
    }
}
