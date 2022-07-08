// See https://aka.ms/new-console-template for more information


using knapsack.GA.Helpers;
using knapsack.GA.Modelos;
using System.Threading.Tasks;


var listaResultado = new List<int>();


Parallel.For(0,5, (i) =>
{
    //Console.WriteLine("Taxa de Mutação: {0}", Constantes.TaxaMutacao);
    //Console.WriteLine("Taxa de Recombinação: {0}", Constantes.TaxaRecombinacao);
    var estrategiaAG = new Parser().LerProblema();
    estrategiaAG[0].Iniciar();
    listaResultado.Add(estrategiaAG[0].MelhorIndividuo.Aptidao(estrategiaAG[0].InfoItens));
});


foreach(var resultado in listaResultado)
{
    Console.WriteLine();
    Console.WriteLine();
    Console.Write(resultado + "  ");
}
