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
    public class GarantiaService : IGarantiaService
    {
        private readonly IGarantiaRepository _garantiaRepository;

        public GarantiaService(IGarantiaRepository garantiaRepository)
        {
            _garantiaRepository = garantiaRepository;
        }
        public Garantia Alterar(Garantia ent)
        {
            return _garantiaRepository.Alterar(ent);
        }

        public Garantia Cadastrar(Garantia ent)
        {
            return _garantiaRepository.Cadastrar(ent);
        }

        public Garantia? ConsultarPorId(string id)
        {
            return _garantiaRepository.ConsultarPorId(id);
        }

        public List<Garantia>? ConsultarPorNome(string nome)
        {
            return _garantiaRepository.ConsultarPorNome(nome);
        }

        public List<Garantia>? ConsultarTodos()
        {
            return _garantiaRepository.ConsultarTodos();
        }

        public Garantia Excluir(string id)
        {
            return _garantiaRepository.Excluir(id);
        }
    }
}
