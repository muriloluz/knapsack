// See https://aka.ms/new-console-template for more information


using knapsack.GA.Helpers;
using knapsack.GA.Modelos;
using System.Threading.Tasks;


var listaResultado = new List<int>();

Console.WriteLine("INICIO");
Console.WriteLine();

for (int j = 0; j < Constantes.QuantidadeExecucoes; j++) {

    Parallel.For(0, Constantes.Paralelismo, (i) =>
    {
    //Console.WriteLine("Taxa de Mutação: {0}", Constantes.TaxaMutacao);
    //Console.WriteLine("Taxa de Recombinação: {0}", Constantes.TaxaRecombinacao);
        var estrategiaAG = new Parser().LerProblema();
        estrategiaAG[0].Iniciar();
        listaResultado.Add(estrategiaAG[0].MelhorIndividuo.Aptidao(estrategiaAG[0].InfoItens));
    });


    foreach (var resultado in listaResultado)
    {
        Console.WriteLine("Melhor aptidão: " + resultado + "  ");
    }

    listaResultado.Clear();
}

Console.WriteLine();
Console.WriteLine("FIM");
Console.WriteLine();
Console.WriteLine();
