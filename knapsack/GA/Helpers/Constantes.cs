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

        public static int SobreviventesElitismo = 10;

        public static int QuantidadeMelhoresFilhosPorGeracao = 10;

        public static int QuantidadeFilhosPorGeracao = 50;

        public static int TamanhoPopulacao = 50;

        /// <summary>
        ///  Primeiro otimo foi com 10 000
        /// </summary>
        public static int Geracoes = 100;

        public static int QuantidadeExecucoes = 10;

        public static bool ImprimirIndividuo = false;

        public static int ImprimirACada = 1000;

        public static int ParticipantesTorneio = 2;
    }
}