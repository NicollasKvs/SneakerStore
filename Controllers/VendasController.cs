using Microsoft.AspNetCore.Mvc;
using SneakerStore.Models;

namespace SneakerStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        [HttpPost]
        public IActionResult RealizarVenda([FromBody] int produtoId)
        {
            var produto = ProdutoController.produtos.FirstOrDefault(p => p.Id == produtoId);
            if (produto == null || produto.QuantidadeEstoque <= 0)
                return BadRequest("Produto não encontrado ou fora de estoque.");

            produto.QuantidadeEstoque--;
            return Ok(produto);
        }
    }
}
