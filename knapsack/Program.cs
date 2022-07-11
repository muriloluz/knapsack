// See https://aka.ms/new-console-template for more information


using knapsack.GA.Helpers;
using knapsack.GA.Modelos;
using System.Threading.Tasks;


var listaResultado = new List<Mochila>();

Console.WriteLine("INICIO");
Console.WriteLine();

var estrategiaAG = new Parser().LerProblema();

for (int j = 0; j < Constantes.QuantidadeExecucoes; j++)
{

    //Console.WriteLine("Taxa de Mutação: {0}", Constantes.TaxaMutacao);
    //Console.WriteLine("Taxa de Recombinação: {0}", Constantes.TaxaRecombinacao);

    estrategiaAG[0].Iniciar();
    listaResultado.Add(estrategiaAG[0].MelhorIndividuo);


    foreach (var resultado in listaResultado)
    {
        resultado.ImprimeMochila(estrategiaAG[0].InfoItens);
    }

    listaResultado.Clear();
}

Console.WriteLine();
Console.WriteLine("FIM");
Console.WriteLine();
Console.WriteLine();
