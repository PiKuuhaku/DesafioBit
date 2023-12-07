using DesafioBit.Application.Interfaces.Services;
using DesafioBit.Application.Services;
using DesafioBit.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public string Cadastrar(Venda ent)
        {
            var result = _vendaService.Cadastrar(ent);
            return result;
        }

        [HttpGet]
        [Route("BuscaPorId")]
        public Venda? BuscaPorId(string id)
        {
            return _vendaService.ConsultarPorId(id);
        }

        [HttpGet]
        [Route("BuscaTodos")]
        public List<Venda>? BuscaTodos()
        {
            return _vendaService.ConsultarTodos();
        }

        [HttpPost]
        [Route("Excluir")]
        public string Excluir(string id)
        {
            var result = _vendaService.Excluir(id);
            if (result == null)
                return "Venda não encontrada.";
            else
                return $"Venda \"{result.VendaID}\" excluida com sucesso!";
        }
    }
}
