using knapsack.GA.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knapsack.GA.Helpers
{
    public static class Mutacao
    {
        public static void Muta(Mochila individuo, int taxaMutacao)
        {
            for (int i = 0; i < individuo.Items.Length; i++)
            {
                var random = Constantes.Randomico.ProximoInt(101);
                if (random <= taxaMutacao)
                {

                    if (individuo.Items[i] == 1)
                    {
                        individuo.Items[i] = 0;
                    }
                    else
                    {
                        individuo.Items[i] = 1;
                    }
                }
            }
        }
    }
}
