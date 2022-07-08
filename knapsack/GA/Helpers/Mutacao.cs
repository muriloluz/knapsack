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

        public static void MutaComMascara(Mochila mochila, int taxaMutacao)
        {
            var random = Constantes.Randomico.ProximoInt(101);
            if (random <= taxaMutacao)
            {
                var mascara = new int[mochila.Items.Length];
   
                for(int i = 0; i < mascara.Length; i++)
                {
                    mascara[i] = Constantes.Randomico.RandomZeroOuUm();
                }

                for(int j = 0; j < mochila.Items.Length; j++)
                {
                    if (mascara[j] == 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (mochila.Items[j] == 1)
                        {
                            mochila.Items[j] = 0;
                        }
                        else
                        {
                            mochila.Items[j] = 1;
                        }
                    }
                }
            }
        }
    }
}
