using Microsoft.AspNetCore.Mvc;
using SneakerStore.Models;

namespace SneakerStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckoutController : ControllerBase
    {
    [HttpPost]
    public IActionResult Checkout([FromBody] Pagamento pagamento)
    {
        var venda = VendasController.vendas.FirstOrDefault(v => v.Id == pagamento.VendaId);
        if (venda == null)
            return BadRequest("Venda não encontrada.");

        // Atualizar o status da venda após pagamento aprovado
        venda.Status = "Aprovado";

        pagamento.Status = "Aprovado"; // Simulação de aprovação automática
        return Ok(new { mensagem = "Pagamento aprovado!", venda });
    }
    }
}
