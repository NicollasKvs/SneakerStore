using Microsoft.AspNetCore.Mvc;
using SneakerStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace SneakerStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        // Simulação de banco em memória
        public static Carrinho CarrinhoAtual { get; set; } = new Carrinho();
        public static List<Venda> Vendas { get; set; } = new List<Venda>();
        public static int ProximoIdVenda = 1;

        // GET: api/vendas/carrinho
        [HttpGet("carrinho")]
        public IActionResult VerCarrinho()
        {
            return Ok(CarrinhoAtual.Itens);
        }

        // POST: api/vendas/carrinho
        [HttpPost("carrinho")]
        public IActionResult AdicionarAoCarrinho([FromBody] ItemCarrinho item)
        {
            var produto = ProdutoController.produtos.FirstOrDefault(p => p.Id == item.ProdutoId);
            if (produto == null || produto.QuantidadeEstoque < item.Quantidade)
                return BadRequest("Produto não encontrado ou estoque insuficiente.");

            CarrinhoAtual.AdicionarItem(item);
            return Ok(CarrinhoAtual.Itens);
        }

        // DELETE: api/vendas/carrinho/{produtoId}
        [HttpDelete("carrinho/{produtoId}")]
        public IActionResult RemoverDoCarrinho(int produtoId)
        {
            CarrinhoAtual.RemoverItem(produtoId);
            return Ok(CarrinhoAtual.Itens);
        }

        // POST: api/vendas/finalizar
        [HttpPost("finalizar")]
        public IActionResult FinalizarVenda()
        {
            if (!CarrinhoAtual.Itens.Any())
                return BadRequest("Carrinho está vazio.");

            // Atualizar estoque
            foreach (var item in CarrinhoAtual.Itens)
            {
                var produto = ProdutoController.produtos.FirstOrDefault(p => p.Id == item.ProdutoId);
                if (produto == null || produto.QuantidadeEstoque < item.Quantidade)
                    return BadRequest($"Estoque insuficiente para o produto {item.ProdutoId}");

                produto.QuantidadeEstoque -= item.Quantidade;
            }

            // Criar venda
            var novaVenda = new Venda
            {
                Id = ProximoIdVenda++,
                Itens = CarrinhoAtual.Itens.ToList(),
                Status = StatusVenda.Pendente
            };

            Vendas.Add(novaVenda);
            CarrinhoAtual.Limpar();
            return Ok(novaVenda);
        }

        // PATCH: api/vendas/atualizar-status/{id}
        [HttpPatch("atualizar-status/{id}")]
        public IActionResult AtualizarStatus(int id, [FromQuery] StatusVenda novoStatus)
        {
            var venda = Vendas.FirstOrDefault(v => v.Id == id);
            if (venda == null)
                return NotFound("Venda não encontrada.");

            venda.Status = novoStatus;
            return Ok(venda);
        }

        // GET: api/vendas
        [HttpGet]
        public IActionResult ListarVendas()
        {
            return Ok(Vendas);
        }
    }
}
