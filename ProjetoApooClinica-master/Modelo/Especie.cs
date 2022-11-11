using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class Especie
    {
        public long EspecieId { get; set; }
        public string Nome { get; set; }
        public Especie Especie { get; set; }
    }
}
