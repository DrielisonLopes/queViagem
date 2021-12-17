using System.ComponentModel.DataAnnotations;

namespace Viagem.Models
{
    public class Pagamento
    {
        [Key]
        [Required]
        public int Id {get; set;}
        [Required]
        public string Pagar {get; set;}
    }
}