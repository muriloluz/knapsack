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
        public Problema LerProblema()
        {
            var arquivo = File.ReadAllLines(@"C:\Projetos\ce\knapsack\knapsack\GA\Data\mknapcb1.txt");

            //var arquivo = File.ReadAllLines(@"G:\Projetos\ufg\EV\knapsack\knapsack\GA\Data\mknapcb1.txt"); 

            var problema = new Problema();
            var retorno = new List<EstrategiaAG>();

            var quantidadeInstancias = int.Parse(arquivo[0].Trim());

            problema.QuantidadeInstancias = quantidadeInstancias;

            var instanciaAtual = 1;
            var linhaCorrente = 0;
            while (instanciaAtual <= quantidadeInstancias)
            {

                //Console.WriteLine("Quantidade instâncias do arquivo: {1}", instanciaAtual, quantidadeInstancias);
                linhaCorrente++;
                var informacoes = arquivo[linhaCorrente].Trim().Split();

                int quantidadeRestricoes = int.Parse(informacoes[1]);
                int quantidadeTotalItens = int.Parse(informacoes[0]);

                //Console.WriteLine("Instância: {0} - Quantidade itens: {1}", instanciaAtual, quantidadeTotalItens);
                //Console.WriteLine("Instância: {0} - Restrições: {1}", instanciaAtual, quantidadeRestricoes);

                linhaCorrente++;

                var infoItens = new InfoItem[quantidadeTotalItens];
                var itemAtualColetado = 0;

                while (itemAtualColetado < quantidadeTotalItens)
                {
                    var itensLinha = arquivo[linhaCorrente].Trim().Split().ToList();

                    foreach (var valor in itensLinha)
                    {
                        infoItens[itemAtualColetado] = new InfoItem(int.Parse(valor), quantidadeRestricoes);
                        itemAtualColetado++;
                    }
                    linhaCorrente++;
                }

                //// Inicia leitura dos pesos em cada restrição
                var restricaoAtual = 0;

                while (restricaoAtual < quantidadeRestricoes)
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

                while(pesoRestricoes.Count() != quantidadeRestricoes)
                {
                    linhaCorrente++;
                    pesoRestricoes.AddRange(arquivo[linhaCorrente].Trim().Split().ToList());
                }

                if (pesoRestricoes.Count() != quantidadeRestricoes)
                {
                    throw new Exception("O arquivo está no formato incorreto.");
                }

                restricaoAtual = 0;

                while (restricaoAtual < quantidadeRestricoes)
                {
                    infoRestricoes[restricaoAtual] = new InfoRestricao(int.Parse(pesoRestricoes.ElementAt(restricaoAtual)));
                    restricaoAtual++;
                }

                retorno.Add(new EstrategiaAG(instanciaAtual, infoItens, infoRestricoes));

                instanciaAtual++;
            }

            problema.estrategiaAGs = retorno;
            return problema;
        }
    }
}
