using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SneakerStore.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        
        [NotMapped]
        public List<ItemCarrinho> Itens { get; set; } = new();
        public decimal Total => Itens.Sum(i => i.Total);
        public StatusVenda Status { get; set; } = StatusVenda.Pendente;
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusVenda
    {
        Pendente,
        Pago,
        Enviado,
        Entregue,
        Devolvido
    }
}
