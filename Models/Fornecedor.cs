using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerStore.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CNPJ { get; set; }
        public string? Email { get; set; }
    }
}