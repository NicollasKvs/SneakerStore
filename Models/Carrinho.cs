using System.Collections.Generic;
using System.Linq;

namespace SneakerStore.Models
{
    public class Carrinho
    {
        public List<ItemCarrinho> Itens { get; set; } = new List<ItemCarrinho>();

        public void AdicionarItem(ItemCarrinho item)
        {
            var itemExistente = Itens.FirstOrDefault(i => i.ProdutoId == item.ProdutoId);

            if (itemExistente != null)
            {
                itemExistente.Quantidade += item.Quantidade;
            }
            else
            {
                Itens.Add(item);
            }
        }

        public void RemoverItem(int produtoId)
        {
            var item = Itens.FirstOrDefault(i => i.ProdutoId == produtoId);
            if (item != null)
            {
                Itens.Remove(item);
            }
        }

        public void Limpar()
        {
            Itens.Clear();
        }
    }

    public class ItemCarrinho
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        public decimal Total => Quantidade * PrecoUnitario;
    }
}
