using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBit.Domain.Entities
{
    public class Venda
    {
        public Venda()
        {
            ItensVenda = new List<Itens>();
            VendaID = Guid.NewGuid().ToString();
        }

        public string VendaID { get; }
        public List<Itens> ItensVenda { get; set; }
        public decimal ValorTotal => ItensVenda.Select(f => f.ValorTotal).Sum();

    }
}
