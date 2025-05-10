using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerStore.Models
{
    public class Insumo
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Quantidade { get; set; }
        public int FornecedorId { get; set; }
    }
}