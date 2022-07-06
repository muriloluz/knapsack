using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knapsack.GA.Modelos
{
    public class InfoCompartimento
    {
        public int Id { get; set; }
        public int PesoMaximo { get; set; }

        public int[] PesoItem { get; set; }
    }
}
