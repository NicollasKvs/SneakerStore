using Microsoft.AspNetCore.Mvc;
using SneakerStore.Models;
using SneakerStore.Data;

namespace SneakerStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FuncionariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetFuncionarios()
        {
            var funcionarios = _context.Funcionarios.ToList();
            return Ok(funcionarios);
        }

        [HttpPost]
        public IActionResult CreateFuncionario(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFuncionarioById), new { id = funcionario.Id }, funcionario);
        }

        [HttpGet("{id}")]
        public IActionResult GetFuncionarioById(int id)
        {
            var funcionario = _context.Funcionarios.Find(id);
            if (funcionario == null)
                return NotFound();

            return Ok(funcionario);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFuncionario(int id, Funcionario funcionario)
        {
            var funcionarioDb = _context.Funcionarios.Find(id);
            if (funcionarioDb == null)
                return NotFound();

            funcionarioDb.Nome = funcionario.Nome;
            funcionarioDb.Cargo = funcionario.Cargo;
            funcionarioDb.Email = funcionario.Email;
            funcionarioDb.DataAdmissao = funcionario.DataAdmissao;
            funcionarioDb.Ativo = funcionario.Ativo;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFuncionario(int id)
        {
            var funcionario = _context.Funcionarios.Find(id);
            if (funcionario == null)
                return NotFound();

            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
