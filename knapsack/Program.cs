// See https://aka.ms/new-console-template for more information


using knapsack.GA.Helpers;

Console.WriteLine("Taxa de Mutação: {0}" , Constantes.TaxaMutacao);

var estrategiaAG = new Parser().LerProblema();

estrategiaAG[0].IniciaPopulacao();