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

        [Required]
        public int PassageiroId_passageiro {get; set;}
        public Passageiro Passageiro {get; set;}
        [Required]
        public int PagamentoId_pagamento {get; set;}
        public Pagamento Pagamento {get; set;}
    }
}