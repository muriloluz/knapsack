using knapsack.GA.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knapsack.GA.Helpers
{
    public class Parser
    {        
        public Mochila LerProblema()
        {
            var arquivo = File.ReadAllLines(@"C:\Projetos\ce\knapsack\knapsack\GA\Data\mknapcb1.txt");

            var quantidadeInstancias = arquivo[0].Trim();

            Console.WriteLine("Quantidade instancias: {0}", quantidadeInstancias);

            var linhaCorrente = 1;

            var informacoes = arquivo[linhaCorrente].Trim().Split();

            int slots = int.Parse(informacoes[linhaCorrente]);
            int quantidadeTotalItens =  int.Parse(informacoes[0]);

            Console.WriteLine("Quantidade itens: {0}", quantidadeTotalItens);
            Console.WriteLine("Slots: {0}", slots);
            var item = 0;
            linhaCorrente++;

            var pesos = new List<string>();

            while (pesos.Count() < quantidadeTotalItens)
            {
                pesos.AddRange(arquivo[linhaCorrente].Trim().Split().ToList());               
                linhaCorrente++;
            }

            Console.WriteLine("Pesos calculados: {0}", pesos.Count());


            return new Mochila(slots);
        }
    }
}
