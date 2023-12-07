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
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }
        public string Cadastrar(Venda ent)
        {
            return _vendaRepository.Cadastrar(ent);
        }

        public Venda? ConsultarPorId(string id)
        {
            return _vendaRepository.ConsultarPorId(id);
        }

        public List<Venda>? ConsultarTodos()
        {
            return _vendaRepository.ConsultarTodos();
        }

        public Venda Excluir(string id)
        {
            return _vendaRepository.Excluir(id);
        }
    }
}
