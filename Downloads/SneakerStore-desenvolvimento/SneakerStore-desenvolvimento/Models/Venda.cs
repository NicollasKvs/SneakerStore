namespace SneakerStore.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public List<ItemVenda> Itens { get; set; } = new();
        public decimal Total => Itens.Sum(i => i.PrecoUnitario * i.Quantidade) ?? 0;
        public string Status { get; set; } = "Pendente";
        public DateTime Data { get; set; } = DateTime.Now;
    }

    public class ItemVenda
    {
        public int ProdutoId { get; set; }
        public string? NomeProduto { get; set; } = string.Empty;
        public decimal? PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
