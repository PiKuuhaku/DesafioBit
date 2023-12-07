using DesafioBit.Application.Interfaces.Services;
using DesafioBit.Application.Services;
using DesafioBit.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GarantiaController : ControllerBase
    {
        private readonly IGarantiaService _garantiaService;

        public GarantiaController(IGarantiaService garantiaService)
        {
            _garantiaService = garantiaService;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public string Cadastrar(Garantia ent)
        {
            var result = _garantiaService.Cadastrar(ent);
            if (result == null)
                return "ID inválido ou garantia já cadastrada.";
            else
                return $"Garantia \"{result.Nome}\" (ID: \"{result.GarantiaID}\") cadastrada com sucesso!";
        }

        [HttpGet]
        [Route("BuscaPorNome")]
        public List<Garantia>? BuscaPorNome(string nome)
        {
            return _garantiaService.ConsultarPorNome(nome);
        }

        [HttpGet]
        [Route("BuscaPorId")]
        public Garantia? BuscaPorId(string id)
        {
            return _garantiaService.ConsultarPorId(id);
        }

        [HttpPost]
        [Route("Alterar")]
        public string Alterar(Garantia ent, string id)
        {
            var edit = _garantiaService.ConsultarPorId(id);
            if (edit == null)
                return "Garantia não encontrada.";
            else
            {
                edit.Nome = ent.Nome;
                edit.Valor = ent.Valor;
                edit.Prazo = ent.Prazo;

                var result = _garantiaService.Alterar(edit);
                return $"Garantia \"{result.Nome}\" (ID: \"{result.GarantiaID}\") alterada com sucesso!";
            }
        }

        [HttpPost]
        [Route("Excluir")]
        public string Excluir(string id)
        {
            var result = _garantiaService.Excluir(id);
            if (result == null)
                return "Garantia não encontrada.";
            else
                return $"Garantia \"{result.Nome}\" (ID: \"{result.GarantiaID}\") excluida com sucesso!";
        }
    }
}
