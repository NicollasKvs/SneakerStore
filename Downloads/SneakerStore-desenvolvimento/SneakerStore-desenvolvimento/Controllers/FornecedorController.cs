using Microsoft.AspNetCore.Mvc;
using SneakerStore.Models;

namespace SneakerStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private static List<Fornecedor> fornecedores = new();

        [HttpGet]
        public IActionResult Get() => Ok(fornecedores);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var fornecedor = fornecedores.FirstOrDefault(f => f.Id == id);
            if (fornecedor == null) return NotFound();
            return Ok(fornecedor);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Fornecedor fornecedor)
        {
            fornecedor.Id = fornecedores.Count + 1;
            fornecedores.Add(fornecedor);
            return CreatedAtAction(nameof(GetById), new { id = fornecedor.Id }, fornecedor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Fornecedor fornecedor)
        {
            var index = fornecedores.FindIndex(f => f.Id == id);
            if (index == -1) return NotFound();

            fornecedor.Id = id;
            fornecedores[index] = fornecedor;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var fornecedor = fornecedores.FirstOrDefault(f => f.Id == id);
            if (fornecedor == null) return NotFound();

            fornecedores.Remove(fornecedor);
            return NoContent();
        }
    }
}
