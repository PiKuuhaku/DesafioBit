using DesafioBit.Application.Interfaces.Repositories;
using DesafioBit.Application.Interfaces.Services;
using DesafioBit.Application.Services;
using DesafioBit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBit.Infra.Data.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        public static List<Venda> Vendas = new List<Venda>();
        private readonly IProdutoService _produtoService;
        private readonly IGarantiaService _garantiaService;

        public VendaRepository(IProdutoService produtoService, IGarantiaService garantiaService)
        {
            _produtoService = produtoService;
            _garantiaService = garantiaService;
        }
        public string Cadastrar(Venda ent)
        {
            if (ent == null || Vendas.Any(f => f.VendaID == ent.VendaID))
            {
                return "Venda já cadastrada.";
            }
            else
            {
                if(ent.ItensVenda == null || ent.ItensVenda.Count == 0) 
                {
                    return "produto(s) inexistente(s).";
                }
                else
                {
                    var produtos = _produtoService.ConsultarTodos();
                    var garantias = _garantiaService.ConsultarTodos();
                    foreach (var item in ent.ItensVenda) 
                    {
                        if(item.Garantia != null && ((garantias == null && item.Garantia != null) || (garantias != null && !garantias.Any(f => f.Nome == item.Garantia.Nome))))
                        {
                            return "Garantia inexistente.";
                        }
                        else
                        {
                            item.Garantia = _garantiaService.ConsultarPorNome(item.Garantia.Nome).FirstOrDefault();
                        }
                        if (produtos == null || !produtos.Any(f => f.ProdutoID == item.ProdutoID))
                        {
                            return "produto(s) inválido(s).";
                        }
                        else
                        {
                            var produto = produtos.FirstOrDefault(f => f.ProdutoID == item.ProdutoID);
                            if (produto != null) 
                            {
                                if (produto.SaldoEstoque < item.Quantidade || (produto.SaldoEstoque - item.Quantidade < produto.EstoqueMinimo))
                                    return $"Saldo insuficiente do produto \"{item.ProdutoID}\" no estoque.";
                                else
                                {
                                    produto.SaldoEstoque = produto.SaldoEstoque - item.Quantidade;
                                    _produtoService.Alterar(produto);
                                }
                            }
                        }
                    }
                    Vendas.Add(ent);
                    return $"Venda \"{ent.VendaID}\" realizada com sucesso.";
                }
            }
        }

        public Venda? ConsultarPorId(string id)
        {
            var result = Vendas.FirstOrDefault(f => f.VendaID == id);
            return result;
        }

        public List<Venda>? ConsultarTodos()
        {
            return Vendas;
        }

        public Venda Excluir(string id)
        {
            var result = new Venda();
            result = Vendas.FirstOrDefault(f => f.VendaID == id);
            if (result != null)
                Vendas.Remove(result);

            return result ?? new Venda();
        }
    }
}
