using DesafioBit.Application.Interfaces.Repositories;
using DesafioBit.Application.Interfaces.Services;
using DesafioBit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBit.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public string Cadastrar(Produto ent)
        {
            return _produtoRepository.Cadastrar(ent);
        }

        public Produto Alterar(Produto ent)
        {
            return _produtoRepository.Alterar(ent);
        }
        public Produto? ConsultarPorId(string id)
        {
            return _produtoRepository.ConsultarPorId(id);
        }

        public List<Produto>? ConsultarPorNome(string nome)
        {
            return _produtoRepository.ConsultarPorNome(nome);
        }

        public List<Produto>? ConsultarPorFornecedor(string fornecedor)
        {
            return _produtoRepository.ConsultarPorFornecedor(fornecedor);
        }

        public List<Produto>? ConsultarTodos()
        {
            return _produtoRepository.ConsultarTodos();
        }

        public Produto Excluir(string id)
        {
            return _produtoRepository.Excluir(id);
        }
    }
}
