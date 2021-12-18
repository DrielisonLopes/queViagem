using Viagem.Models;
using Microsoft.EntityFrameworkCore;

namespace Viagem.Data
{
    public class ViagemContext : DbContext
    {
        public ViagemContext(DbContextOptions<ViagemContext> opt) : base(opt)
        {
        }
        public DbSet<Viajar> Viagens {get; set;}
        public DbSet<Passageiro> Passageiros {get; set;}
        public DbSet<Pagamento> Pagamentos {get; set;}
    }
}