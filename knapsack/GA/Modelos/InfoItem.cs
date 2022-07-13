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

        public double Prioridade { get; set; }

        public void CalculaPrioridade()
        {
            var total = 0.0;
            for (int i = 0; i < PesoItem.Length; i++)
            {
               total += (Valor / PesoItem[i]);
            }

            this.Prioridade = total;
        }
    }
}
