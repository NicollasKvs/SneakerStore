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
        public static List<Produto> produtos = new();

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
