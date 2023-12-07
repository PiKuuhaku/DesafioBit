using DesafioBit.Application.Interfaces.Services;
using DesafioBit.Application.Services;
using DesafioBit.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public string Cadastrar(Produto ent)
        {
            var result = _produtoService.Cadastrar(ent);
            return result;
        }

        [HttpGet]
        [Route("BuscaPorNome")]
        public List<Produto>? BuscaPorNome(string nome)
        {
            return _produtoService.ConsultarPorNome(nome);
        }

        [HttpGet]
        [Route("BuscaPorId")]
        public Produto? BuscaPorId(string id)
        {
            return _produtoService.ConsultarPorId(id);
        }

        [HttpGet]
        [Route("BuscaPorFornecedor")]
        public List<Produto>? BuscaPorFornecedor(string fornecedor)
        {
            return _produtoService.ConsultarPorFornecedor(fornecedor);
        }

        [HttpPost]
        [Route("Alterar")]
        public string Alterar(Produto ent, string id)
        {
            var edit = _produtoService.ConsultarPorId(id);
            if (edit == null)
                return "Produto não encontrado.";
            else
            {
                edit.Nome = ent.Nome;
                edit.Valor = ent.Valor;
                edit.EstoqueMinimo = ent.EstoqueMinimo;
                edit.EstoqueMaximo = ent.EstoqueMaximo;
                edit.SaldoEstoque = ent.SaldoEstoque;
                edit.Fornecedor = ent.Fornecedor;
                edit.PossuiGarantia = ent.PossuiGarantia;

                var result = _produtoService.Alterar(edit);
                return $"Produto \"{result.Nome}\" (ID: \"{result.ProdutoID}\") alterado com sucesso!";
            }
        }

        [HttpPost]
        [Route("Excluir")]
        public string Excluir(string id)
        {
            var result = _produtoService.Excluir(id);
            if (result == null)
                return "Produto não encontrado.";
            else
                return $"Produto \"{result.Nome}\" (ID: \"{result.ProdutoID}\") excluido com sucesso!";
        }
    }
}
