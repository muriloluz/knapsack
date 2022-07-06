using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knapsack.GA.Modelos
{
    public class Mochila
    {
        public Mochila(int quantidadeItens)
        {
            this.InfoCompartimento = new List<InfoCompartimento>();
        }

        public List<InfoCompartimento> InfoCompartimento { get; set; }

        public int[][] Items { get; set; }
    }
}
