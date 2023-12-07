using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBit.Domain.Entities
{
    public class Produto
    {
        public Produto()
        {
            ProdutoID = Guid.NewGuid().ToString();
        }
        public string ProdutoID { get; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int EstoqueMinimo { get; set; }
        public int EstoqueMaximo { get; set; }
        public int SaldoEstoque { get; set; }
        public string Fornecedor { get; set; }
        public bool PossuiGarantia { get; set; }
    }
}
