using Microsoft.AspNetCore.Mvc;
using SneakerStore.Data;
using SneakerStore.Models;
using System;
using System.Linq;

namespace SneakerStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContasReceberController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContasReceberController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_context.ContasReceber.ToList());

        [HttpPost]
        public IActionResult Post([FromBody] ContaReceber conta)
        {
            _context.ContasReceber.Add(conta);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = conta.Id }, conta);
        }
    }
}
