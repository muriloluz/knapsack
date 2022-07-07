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
        public List<EstrategiaAG> LerProblema()
        {
            var arquivo = File.ReadAllLines(@"C:\Projetos\ce\knapsack\knapsack\GA\Data\mknapcb1.txt");

            var retorno = new List<EstrategiaAG>();

            var quantidadeInstancias = arquivo[0].Trim();
            var instanciaAtual = 1;

            Console.WriteLine("Quantidade instâncias do arquivo: {1}", instanciaAtual, quantidadeInstancias);

            var linhaCorrente = 1;

            var informacoes = arquivo[linhaCorrente].Trim().Split();

            int quantidadeCompartimentos = int.Parse(informacoes[linhaCorrente]);
            int quantidadeTotalItens =  int.Parse(informacoes[0]);

            Console.WriteLine("Instância: {0} - Quantidade itens: {1}", instanciaAtual, quantidadeTotalItens);
            Console.WriteLine("Instância: {0} - Compartimentos: {1}", instanciaAtual, quantidadeCompartimentos);

            linhaCorrente++;

            var infoItens = new InfoItem[quantidadeTotalItens];
            var itemAtualColetado = 0;

            while (itemAtualColetado < quantidadeTotalItens)
            {
                var itensLinha = arquivo[linhaCorrente].Trim().Split().ToList();

                foreach(var valor in itensLinha)
                {
                    infoItens[itemAtualColetado] = new InfoItem(int.Parse(valor), quantidadeCompartimentos);
                    itemAtualColetado++;
                }     
                linhaCorrente++;
            }

            //// Inicia leitura dos pesos em cada compartimento
            var compartimentoAtual = 0;

            while(compartimentoAtual < quantidadeCompartimentos)
            {
                var itemAtual = 0;
                while (itemAtual < quantidadeTotalItens)
                {
                    var itensLinha = arquivo[linhaCorrente].Trim().Split().ToList();

                    foreach (var valor in itensLinha)
                    {
                        infoItens.ElementAt(itemAtual).PesoItem[compartimentoAtual] = int.Parse(valor);
                        itemAtual++;

                    }
                    linhaCorrente++;
                }

                compartimentoAtual++;
            }

            //// Iniciar leitura da capacidade dos slots
            var infoCompartimentos = new InfoCompartimento[quantidadeCompartimentos];

            var pesoCompartimentos = arquivo[linhaCorrente].Trim().Split().ToList();

            if(pesoCompartimentos.Count() != quantidadeCompartimentos)
            {
                throw new Exception("O arquivo está no formato incorreto.");
            }

            compartimentoAtual = 0;

            while(compartimentoAtual < quantidadeCompartimentos)
            {
                infoCompartimentos[compartimentoAtual] = new InfoCompartimento(int.Parse(pesoCompartimentos.ElementAt(compartimentoAtual)));
                compartimentoAtual++;
            }

            retorno.Add(new EstrategiaAG(instanciaAtual, infoItens, infoCompartimentos));

            return retorno;
        }
    }
}
