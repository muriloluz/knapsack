// See https://aka.ms/new-console-template for more information


using knapsack.GA.Helpers;
using knapsack.GA.Modelos;
using System.Threading.Tasks;


var listaResultado = new List<Mochila>();

Console.WriteLine("INICIO");
Console.WriteLine(DateTime.Now.ToString("G"));
Console.WriteLine();

var estrategiaAG = new Parser().LerProblema();

var w = 0;


listaResultado.Clear();

InfoItem[] infoItens = null ;

Console.WriteLine("INSTANCIA: " + w);


for (int j = 0; j < Constantes.QuantidadeExecucoes; j++)
{

    //Console.WriteLine("Taxa de Mutação: {0}", Constantes.TaxaMutacao);
    //Console.WriteLine("Taxa de Recombinação: {0}", Constantes.TaxaRecombinacao);

    estrategiaAG[w].Iniciar();
    infoItens = estrategiaAG[w].InfoItens;
    listaResultado.Add(estrategiaAG[w].MelhorIndividuo);
}

foreach (var resultado in listaResultado)
{
    Console.WriteLine(resultado.Aptidao(infoItens));
}

double media = listaResultado.Select(x=>x.Aptidao(infoItens)).Average();
double soma = listaResultado.Select(x => x.Aptidao(infoItens)).Sum(d => Math.Pow(d - media, 2));
double desvio = Math.Sqrt((soma) / listaResultado.Count());
double maior = listaResultado.Select(x => x.Aptidao(infoItens)).Max();

var melhorMochila = listaResultado.Where(x => x.Aptidao(infoItens) == maior).FirstOrDefault();

melhorMochila.ImprimeMochila(infoItens);

Console.WriteLine("MEDIA: " + media);
Console.WriteLine("DESVIO: " + desvio);
Console.WriteLine("MAX: " + maior);

Console.WriteLine();
Console.WriteLine();

Console.WriteLine();
Console.WriteLine("FIM");
Console.WriteLine(DateTime.Now.ToString("G"));
Console.WriteLine();
Console.WriteLine();