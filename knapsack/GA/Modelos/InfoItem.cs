using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knapsack.GA.Modelos
{
    public class InfoItem
    {
        public InfoItem(int valor, int quantidadeRestricoes)
        {
            Valor = valor;
            PesoItem = new int[quantidadeRestricoes];
        }
        public int Valor { get; set; }

        public int[] PesoItem { get; set; }
    }
}
