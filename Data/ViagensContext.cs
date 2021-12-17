using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Viagem.Models;

namespace Viagem.Database
{
    public class ViagensContext : DbContext
    {
        public ViagensContext (DbContextOptions<ViagensContext> options)
            : base(options)
        {
        }

        public DbSet<Viagem.Models.Viajar> Viajar { get; set; }

        public DbSet<Viagem.Models.Passageiro> Passageiro { get; set; }

        public DbSet<Viagem.Models.Pagamento> Pagamento { get; set; }
    }
}
