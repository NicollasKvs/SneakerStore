using Microsoft.AspNetCore.Mvc;
using SneakerStore.Data;
using SneakerStore.Models;
using System;
using System.Linq;

namespace SneakerStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContasPagarController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContasPagarController(AppDbContext context)
        {
            _context = context;
        }

        // GET /ContasPagar
        [HttpGet]
        public IActionResult GetContasPagar()
        {
            try
            {
                var contas = _context.ContasPagar.ToList();
                return Ok(contas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar contas: {ex.Message}");
            }
        }

        // POST /ContasPagar
        [HttpPost]
        public IActionResult Post([FromBody] ContaPagar conta)
        {
            try
            {
                if (conta == null)
                    return BadRequest("A conta não pode ser nula.");

                _context.ContasPagar.Add(conta);
                _context.SaveChanges();


                return CreatedAtAction(nameof(GetContasPagar), new { id = conta.Id }, conta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao salvar conta: {ex.Message}");
            }
        }
    }
}
