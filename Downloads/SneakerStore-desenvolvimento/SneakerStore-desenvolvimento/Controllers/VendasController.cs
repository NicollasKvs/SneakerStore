using Microsoft.AspNetCore.Mvc;
using SneakerStore.Models;

namespace SneakerStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        public static List<Venda> vendas = new List<Venda>();

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var venda = vendas.FirstOrDefault(v => v.Id == id);
            if (venda == null)
                return NotFound(new { mensagem = "Venda não encontrada." });

            return Ok(venda);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Venda venda) 
        {
            // Validar se há itens na venda
            if (venda.Itens == null || !venda.Itens.Any())
                return BadRequest("Itens da venda não podem ser nulos ou vazios.");

            var produtoId = venda.Itens.FirstOrDefault()?.ProdutoId;
            if (produtoId == null)
                return BadRequest("ProdutoId inválido.");

            // Validar se a lista de produtos está inicializada
            if (ProdutoController.produtos == null)
                return StatusCode(500, "Lista de produtos não inicializada.");

            var produto = ProdutoController.produtos.FirstOrDefault(p => p.Id == produtoId);

            // Validar se o produto existe e está disponível no estoque
            if (produto == null || produto.QuantidadeEstoque <= 0)
                return BadRequest("Produto não encontrado ou fora de estoque.");

            // Reduzir estoque apenas se houver disponibilidade
            produto.QuantidadeEstoque--;

            var item = new ItemVenda
            {
                ProdutoId = produto.Id,
                NomeProduto = produto.Nome,
                PrecoUnitario = produto.Preco,
                Quantidade = 1
            };

            var novaVenda = new Venda
            {
                Id = vendas.Count + 1,
                Itens = new List<ItemVenda> { item },
                Status = "Pendente",
                Data = DateTime.Now
            };

            vendas.Add(novaVenda);

            return Ok(new { mensagem = "Venda realizada com sucesso.", venda = novaVenda });


        }
    }
}
