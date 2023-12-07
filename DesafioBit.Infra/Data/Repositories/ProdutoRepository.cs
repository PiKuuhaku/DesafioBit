using DesafioBit.Application.Interfaces.Repositories;
using DesafioBit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBit.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public static List<Produto> Produtos = new List<Produto>();
        public string Cadastrar(Produto ent)
        {
            if(ent == null || Produtos.Any(f => f.ProdutoID == ent.ProdutoID))
            {
                return "Produto já cadastrado.";
            }
            else
            {
                if(ent.SaldoEstoque < ent.EstoqueMinimo)
                    return "Não é possível cadastrar um produto com estoque menor que o mínimo.";
                if (ent.SaldoEstoque > ent.EstoqueMaximo)
                    return "Não é possível cadastrar um produto com estoque maior que o máximo.";

                Produtos.Add(ent);
                return $"Produto \"{ent.Nome}\" (ID: \"{ent.ProdutoID}\") cadastrado com sucesso!";
            }
        }
        
        public Produto Alterar(Produto ent)
        {
            var i = Produtos.FindIndex(f => f.ProdutoID == ent.ProdutoID);
            if(i == -1)
                return new Produto();
            else
            {
                Produtos[i] = ent;

                return ent;
            }
        }

        public Produto? ConsultarPorId(string id)
        {
            var result = Produtos.FirstOrDefault(f => f.ProdutoID == id);
            return result;
        }

        public List<Produto>? ConsultarPorNome(string nome)
        {
            var result = Produtos.Where(f => f.Nome == nome).ToList();
            return result;
        }

        public List<Produto>? ConsultarPorFornecedor(string fornecedor)
        {
            var result = Produtos.Where(f => f.Fornecedor == fornecedor).ToList();
            return result;
        }

        public List<Produto>? ConsultarTodos()
        {
            return Produtos;
        }

        public Produto Excluir(string id)
        {
            var result = new Produto();
            result = Produtos.FirstOrDefault(f => f.ProdutoID == id);
            if(result != null)
                Produtos.Remove(result);

            return result ?? new Produto();
        }
    }
}
