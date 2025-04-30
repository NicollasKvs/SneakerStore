using Microsoft.AspNetCore.Mvc;
using SneakerStore.Models;

namespace SneakerStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsumoController : ControllerBase
    {
        private static List<Insumo> insumos = new();

        [HttpGet]
        public IActionResult Get() => Ok(insumos);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var insumo = insumos.FirstOrDefault(i => i.Id == id);
            if (insumo == null) return NotFound();
            return Ok(insumo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Insumo insumo)
        {
            insumo.Id = insumos.Count + 1;
            insumos.Add(insumo);
            return CreatedAtAction(nameof(GetById), new { id = insumo.Id }, insumo);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Insumo insumo)
        {
            var index = insumos.FindIndex(i => i.Id == id);
            if (index == -1) return NotFound();

            insumo.Id = id;
            insumos[index] = insumo;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var insumo = insumos.FirstOrDefault(i => i.Id == id);
            if (insumo == null) return NotFound();

            insumos.Remove(insumo);
            return NoContent();
        }
    }
}
