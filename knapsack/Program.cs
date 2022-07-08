// See https://aka.ms/new-console-template for more information


using knapsack.GA.Helpers;

Console.WriteLine("Taxa de Mutação: {0}" , Constantes.TaxaMutacao);
Console.WriteLine("Taxa de Recombinação: {0}", Constantes.TaxaRecombinacao);

var estrategiaAG = new Parser().LerProblema();

estrategiaAG[0].Iniciar();