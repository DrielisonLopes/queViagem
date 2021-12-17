using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Viagem.Models;

namespace Viagem.Database
{
    public class PassageiroContext : DbContext
    {
        public PassageiroContext (DbContextOptions<PassageiroContext> options)
            : base(options)
        {
        }

        public DbSet<Viagem.Models.Passageiro> Passageiro { get; set; }
    }
}
