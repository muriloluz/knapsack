﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knapsack.GA.Modelos
{
    public class InfoCompartimento
    {
        public InfoCompartimento(int pesoMaximo)
        {
            PesoMaximo = pesoMaximo;
        }

        public int PesoMaximo { get; set; }
    }
}
