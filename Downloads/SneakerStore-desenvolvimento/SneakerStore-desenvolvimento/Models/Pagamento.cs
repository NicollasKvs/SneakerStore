using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerStore
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public string MetodoPagamento { get; set; } = "Pix";
        public string Status { get; set; } = "Pendente"; 
    }

}