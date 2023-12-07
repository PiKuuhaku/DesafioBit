using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBit.Domain.Entities
{
    public class Itens
    {
        public Itens()
        {
            Garantia = new Garantia();
        }

        public string ProdutoID { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal => ValorUnitario * Quantidade;
        public Garantia? Garantia { get; set; }
    }
}
