using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knapsack.GA.Helpers
{
    public class Constantes
    {
        public static int TaxaMutacao = 5;

        public static int TaxaRecombinacao = 65;

        public static Randomico Randomico = new Randomico();

        public static int SobreviventesElitismo = 4;
    }
}