using Microsoft.AspNetCore.Mvc;
using SneakerStore.Models;
using SneakerStore.Data;

namespace SneakerStore.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RelatoriosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("fluxo-caixa")]
        public IActionResult FluxoCaixa()
        {
            var totalRecebido = _context.ContasReceber
                .Where(c => c.DataRecebimento.HasValue)
                .Sum(c => c.Valor);

            var totalPago = _context.ContasPagar
                .Where(c => c.DataPagamento.HasValue)
                .Sum(c => c.Valor);

            var saldo = totalRecebido - totalPago;

            return Ok(new
            {
                Receitas = totalRecebido,
                Despesas = totalPago,
                Saldo = saldo
            });
        }
    }
}