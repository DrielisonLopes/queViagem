using System.ComponentModel.DataAnnotations;

namespace Viagem.Models
{
    public class Passageiro
    {
        [Key]
        [Required]
        public int Id {get; set;}
        [Required]
        public string Nome {get; set;}
        [Required]
        public string Email { get; set; }
    }
}