using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace SneakerStore.Models
{
    public class ContaReceber
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; } 

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }

        public DateTime? DataRecebimento { get; set; }

        public bool Recebido => DataRecebimento.HasValue;

        public bool Inadimplente => !Recebido && DataVencimento < DateTime.Now;
    }
}
