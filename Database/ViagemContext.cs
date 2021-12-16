using Viagem.Models;
using Microsoft.EntityFrameworkCore;

namespace Viagem.Database
{
    public class ViajarContext : DbContext
    {
        public ViajarContext(DbContextOptions<ViajarContext> opt) : base(opt)
        {
        }
        public DbSet<Viajar> Viagens {get; set;}
        // public DbSet<Nome> Nomes {get; set;}
        // public DbSet<Pagamento> Pagamentos {get; set;}
    }
}