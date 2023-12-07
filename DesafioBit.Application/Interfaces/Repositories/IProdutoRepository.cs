using DesafioBit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBit.Application.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        string Cadastrar(Produto ent);
        Produto Alterar(Produto ent);
        Produto? ConsultarPorId(string id);
        List<Produto>? ConsultarPorNome(string nome);
        List<Produto>? ConsultarPorFornecedor(string fornecedor);
        List<Produto>? ConsultarTodos();
        Produto Excluir(string id);
    }
}
