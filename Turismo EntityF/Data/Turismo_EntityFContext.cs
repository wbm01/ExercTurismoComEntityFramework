using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Turismo_EntityF.Models;

namespace Turismo_EntityF.Data
{
    public class Turismo_EntityFContext : DbContext
    {
        public Turismo_EntityFContext (DbContextOptions<Turismo_EntityFContext> options)
            : base(options)
        {
        }

        public DbSet<Turismo_EntityF.Models.City> City { get; set; } = default!;

        public DbSet<Turismo_EntityF.Models.Address>? Address { get; set; }

        public DbSet<Turismo_EntityF.Models.Client>? Client { get; set; }

        public DbSet<Turismo_EntityF.Models.Hotel>? Hotel { get; set; }

        public DbSet<Turismo_EntityF.Models.Ticket>? Ticket { get; set; }

        public DbSet<Turismo_EntityF.Models.Package>? Package { get; set; }
    }
}
