using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace knapsack.GA.Helpers
{
    public class Randomico
    {
        public int RandomZeroOuUm()
        {
            return ProximoInt(2);
        }

        public int ProximoInt(int limiteNaoInclusivo)
        {
            return RandomNumberGenerator.GetInt32(limiteNaoInclusivo);
        }
    }
}