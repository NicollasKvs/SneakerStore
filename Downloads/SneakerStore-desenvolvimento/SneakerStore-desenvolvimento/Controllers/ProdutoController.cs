using Microsoft.AspNetCore.Mvc;
using SneakerStore.Models;
using SneakerStore.Data;

namespace SneakerStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ProdutoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public static List<Produto> produtos = new List<Produto>();

        static ProdutoController()
        {
            produtos.Add(new Produto { Id = 1, Nome = "Tênis Nike Air Max", Preco = 499.99m, QuantidadeEstoque = 10 });
            produtos.Add(new Produto { Id = 2, Nome = "Adidas Ultraboost", Preco = 599.99m, QuantidadeEstoque = 5 });
            produtos.Add(new Produto { Id = 3, Nome = "Puma RS-X", Preco = 399.99m, QuantidadeEstoque = 8 });
        }

        [HttpGet]
        public IActionResult Get() => Ok(produtos);

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            produto.Id = produtos.Count + 1;
            produtos.Add(produto);
            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Produto produto)
        {
            var index = produtos.FindIndex(p => p.Id == id);
            if (index == -1) return NotFound();
            produto.Id = id;
            produtos[index] = produto;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null) return NotFound();
            produtos.Remove(produto);
            return NoContent();
        }
    }
}
