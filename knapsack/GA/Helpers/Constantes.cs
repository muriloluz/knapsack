﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knapsack.GA.Helpers
{
    public class Constantes
    {
        public static int TaxaMutacao = 2;

        public static int TaxaRecombinacao = 85;

        public static Randomico Randomico = new Randomico();

        public static int SobreviventesElitismo = 5;

        public static int QuantidadeMelhoresFilhosPorGeracao = 20;

        public static int TamanhoPopulacao = 50;

        /// <summary>
        ///  Primeiro otimo foi com 10 000
        /// </summary>
        public static int Geracoes = 20000;

        public static int Paralelismo = 1;

        /// <summary>
        ///  Total é quantidade x paralelismo
        /// </summary>
        public static int QuantidadeExecucoes = 1;

        public static bool ImprimirIndividuo = true;

        public static int ImprimirACada = 500;

        public static int ParticipantesTorneio = 2;
    }
}