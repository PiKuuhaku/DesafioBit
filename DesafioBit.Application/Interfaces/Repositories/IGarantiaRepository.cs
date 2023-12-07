using DesafioBit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBit.Application.Interfaces.Repositories
{
    public interface IGarantiaRepository
    {
        Garantia Cadastrar(Garantia ent);
        Garantia Alterar(Garantia ent);
        Garantia? ConsultarPorId(string id);
        List<Garantia>? ConsultarPorNome(string nome);
        List<Garantia>? ConsultarTodos();
        Garantia Excluir(string id);
    }
}
