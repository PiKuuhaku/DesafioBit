using DesafioBit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBit.Application.Interfaces.Repositories
{
    public interface IVendaRepository
    {
        string Cadastrar(Venda ent);
        Venda? ConsultarPorId(string id);
        List<Venda>? ConsultarTodos();
        Venda Excluir(string id);
    }
}
