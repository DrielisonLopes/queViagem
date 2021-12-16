using System.ComponentModel.DataAnnotations;

namespace Viagem.Models
{
    public class Viajar
    {
        [Key]
        [Required]
        public int Id {get; set;}
        [Required]
        public string Partida {get; set;}
        [Required]
        public string Destino {get; set;}
        [Required]
        public int dataIda {get; set;}
        [Required]
        public int dataVolta {get; set;}

        // [Required]
        // public int NomeId_nome {get; set;}
        // public Nome Nome {get; set;}
        // [Required]
        // public string PagamentoId_pagamento {get; set;}
        // public Pagamento Pagamento {get; set;}
    }
}