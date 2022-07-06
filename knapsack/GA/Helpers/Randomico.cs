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
        public char RandomZeroOuUm()
        {
            var rand = ProximoInt(2);

            if (rand == 0)
            {
                return '0';
            }
            else
            {
                return '1';
            }
        }

        public int ProximoInt(int limiteNaoInclusivo)
        {
            return RandomNumberGenerator.GetInt32(limiteNaoInclusivo);
        }
    }
}