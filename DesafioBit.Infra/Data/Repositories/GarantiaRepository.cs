using DesafioBit.Application.Interfaces.Repositories;
using DesafioBit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBit.Infra.Data.Repositories
{
    public class GarantiaRepository : IGarantiaRepository
    {
        public static List<Garantia> Garantias = new List<Garantia>();
        public Garantia Alterar(Garantia ent)
        {
            var i = Garantias.FindIndex(f => f.GarantiaID == ent.GarantiaID);
            if (i == -1)
                return new Garantia();
            else
            {
                Garantias[i] = ent;

                return ent;
            }
        }

        public Garantia Cadastrar(Garantia ent)
        {
            if (ent == null || Garantias.Any(f => f.GarantiaID == ent.GarantiaID))
            {
                return new Garantia();
            }
            else
            {
                Garantias.Add(ent);
                return ent;
            }
        }

        public Garantia? ConsultarPorId(string id)
        {
            var result = Garantias.FirstOrDefault(f => f.GarantiaID == id);
            return result;
        }

        public List<Garantia>? ConsultarPorNome(string nome)
        {
            var result = Garantias.Where(f => f.Nome == nome).ToList();
            return result;
        }

        public List<Garantia>? ConsultarTodos()
        {
            return Garantias;
        }

        public Garantia Excluir (string id)
        {
            var result = new Garantia();
            result = Garantias.FirstOrDefault(f => f.GarantiaID == id);
            if (result != null)
                Garantias.Remove(result);

            return result ?? new Garantia();
        }
    }
}
