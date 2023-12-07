using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBit.Domain.Entities
{
    public class Garantia
    {
        public Garantia()
        {
            GarantiaID = Guid.NewGuid().ToString();
        }
        public string GarantiaID {get; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Prazo { get; set; }
    }
}
