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
            var arquivo = File.ReadAllLines(@"G:\Projetos\ufg\EV\knapsack\knapsack\GA\Data\mknapcb1.txt");

            var retorno = new List<EstrategiaAG>();

            var quantidadeInstancias = arquivo[0].Trim();
            var instanciaAtual = 1;

            //Console.WriteLine("Quantidade instâncias do arquivo: {1}", instanciaAtual, quantidadeInstancias);

            var linhaCorrente = 1;

            var informacoes = arquivo[linhaCorrente].Trim().Split();

            int quantidadeRestricoes = int.Parse(informacoes[linhaCorrente]);
            int quantidadeTotalItens =  int.Parse(informacoes[0]);

            //Console.WriteLine("Instância: {0} - Quantidade itens: {1}", instanciaAtual, quantidadeTotalItens);
            //Console.WriteLine("Instância: {0} - Restrições: {1}", instanciaAtual, quantidadeRestricoes);

            linhaCorrente++;

            var infoItens = new InfoItem[quantidadeTotalItens];
            var itemAtualColetado = 0;

            while (itemAtualColetado < quantidadeTotalItens)
            {
                var itensLinha = arquivo[linhaCorrente].Trim().Split().ToList();

                foreach(var valor in itensLinha)
                {
                    infoItens[itemAtualColetado] = new InfoItem(int.Parse(valor), quantidadeRestricoes);
                    itemAtualColetado++;
                }     
                linhaCorrente++;
            }

            //// Inicia leitura dos pesos em cada restrição
            var restricaoAtual = 0;

            while(restricaoAtual < quantidadeRestricoes)
            {
                var itemAtual = 0;
                while (itemAtual < quantidadeTotalItens)
                {
                    var itensLinha = arquivo[linhaCorrente].Trim().Split().ToList();

                    foreach (var valor in itensLinha)
                    {
                        infoItens.ElementAt(itemAtual).PesoItem[restricaoAtual] = int.Parse(valor);
                        itemAtual++;

                    }
                    linhaCorrente++;
                }

                restricaoAtual++;
            }

            //// Iniciar leitura da capacidade dos slots
            var infoRestricoes = new InfoRestricao[quantidadeRestricoes];

            var pesoRestricoes = arquivo[linhaCorrente].Trim().Split().ToList();

            if(pesoRestricoes.Count() != quantidadeRestricoes)
            {
                throw new Exception("O arquivo está no formato incorreto.");
            }

            restricaoAtual = 0;

            while(restricaoAtual < quantidadeRestricoes)
            {
                infoRestricoes[restricaoAtual] = new InfoRestricao(int.Parse(pesoRestricoes.ElementAt(restricaoAtual)));
                restricaoAtual++;
            }

            retorno.Add(new EstrategiaAG(instanciaAtual, infoItens, infoRestricoes));

            return retorno;
        }
    }
}
