using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SneakerStore.Models
{
    public class ContaPagar
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Descricao { get; set; } 

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }

        public DateTime? DataPagamento { get; set; }

        [Required]
        public string? Categoria { get; set; } 
        [NotMapped]
        [JsonPropertyName("pago")] 
        public bool Pago { get; set; }
    }
}
