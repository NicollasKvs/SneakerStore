using System;
using System.ComponentModel.DataAnnotations;

namespace SneakerStore.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Cargo { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required]
        public DateTime DataAdmissao { get; set; }

        public bool Ativo { get; set; } = true;
    }
}
