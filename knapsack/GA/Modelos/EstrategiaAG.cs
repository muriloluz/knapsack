using knapsack.GA.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knapsack.GA.Modelos
{
    public class EstrategiaAG
    {
        public EstrategiaAG(int instancia, InfoItem[] infoItens, InfoRestricao[] infoRestricoes)
        {
            this.Instancia = instancia;
            InfoItens = infoItens;
            InfoRestricoes = infoRestricoes;
            this.Pais = new List<Mochila>();
            this.Filhos = new List<Mochila>();

            this.TotalRestricoes = infoRestricoes.Length;
            this.TotalItens = infoItens.Length;
        }

        public void Limpar()
        {
            this.Pais = new List<Mochila>();
            this.Filhos = new List<Mochila>();
            this.MelhorIndividuo = null;
        }

        public int Instancia { get; private set; }

        public int TotalRestricoes { get; private set; }

        public int TotalItens { get; private set; }

        public InfoItem[] InfoItens { get; private set; }

        public InfoRestricao[] InfoRestricoes { get; private set; }

        public List<Mochila> Pais { get; private set; }

        public List<Mochila> Filhos { get; private set; }

        public Mochila MelhorIndividuo { get; private set; }

        public void Iniciar()
        {
            this.Limpar();
            this.IniciaPopulacao();

            //// Calcula o custo-beneficio de cada item 

            //var lista = new List<InfoItem>();
            //for(int i = 0; i < TotalItens; i++)
            //{
            //    var item = this.InfoItens[i];
            //    item.CalculaPrioridade();
            //    lista.Add(item);
            //}

            //this.InfoItens = lista.OrderByDescending(x=>x.Prioridade).ToArray();

            //lista.Clear();
            

            for (int g = 0; g < Constantes.Geracoes; g++)
            {
                for (int i = 0; i < Constantes.QuantidadeFilhosPorGeracao / 2; i++)
                {
                    var pai = this.SelecionaIndividuoTorneio(Constantes.ParticipantesTorneio);
                    var mae = this.SelecionaIndividuoTorneio(Constantes.ParticipantesTorneio);

                    //var pai = this.SelecionaProporcionalAptidao();
                    //var mae = this.SelecionaProporcionalAptidao();

                    /// Crossover
                    var filhos = Recombinacao.Uniforme(pai, mae, Constantes.TaxaRecombinacao, this.InfoItens);

                    /// Mutacao
                    foreach (var f in filhos)
                    {
                        Mutacao.Muta(f, Constantes.TaxaMutacao);
                    }

                    filhos.ForEach(x => HelperMochila.ReparaPesoItemPorRestricaoAleatorio(x, this.TotalItens, this.InfoItens, this.InfoRestricoes));

                    this.Filhos.AddRange(filhos);
                }

                 this.SelecionaSobreviventesElitismo(Constantes.SobreviventesElitismo);

                ///// this.SelecionaMelhoresFilhos(Constantes.QuantidadeMelhoresFilhosPorGeracao);

                if (g % Constantes.ImprimirACada == 0 && Constantes.ImprimirIndividuo)
                {
                    Console.WriteLine("Geração: " + g);
                    ImprimeMelhorIndividuo();
                }
            }

            this.MelhorIndividuo = this.Pais.OrderByDescending(x => x.Aptidao(this.InfoItens)).First();
        }

        private Mochila SelecionaPaisAleatoriamente()
        {
            var randomico = Constantes.Randomico.ProximoInt(Constantes.TamanhoPopulacao);

            return this.Pais.ElementAt(randomico);
        }

        private Mochila SelecionaIndividuoTorneio(int numeroParticipantes)
        {
            var numeroSorteados = new List<int>();
            var listaCandidatos = new List<Mochila>();

            while (numeroSorteados.Count < numeroParticipantes)
            {
                var sorteado = Constantes.Randomico.ProximoInt(Constantes.TamanhoPopulacao);

                if (numeroSorteados.Contains(sorteado))
                {
                    continue;
                }
                else
                {
                    numeroSorteados.Add(sorteado);
                }
            }

            foreach (var s in numeroSorteados)
            {
                listaCandidatos.Add(this.Pais.ElementAt(s));
            }

            return listaCandidatos.OrderByDescending(x => x.Aptidao(this.InfoItens)).Take(1).First();
        }

        private void SelecionaSobreviventesElitismo(int n)
        {
            var listaMelhoresPais = this.Pais.OrderByDescending(x => x.Aptidao(this.InfoItens)).Take(n).ToList();

            var listaFilhosCandidatos = new List<int>();

            while (listaFilhosCandidatos.Count < n)
            {
                var candidato = Constantes.Randomico.ProximoInt(Constantes.TamanhoPopulacao);

                if (listaFilhosCandidatos.Contains(candidato))
                {
                    continue;
                }
                else
                {
                    listaFilhosCandidatos.Add(candidato);
                }
            }

            foreach (var indice in listaFilhosCandidatos.OrderByDescending(x => x))
            {
                this.Filhos.RemoveAt(indice);
            }

            this.Pais = this.Filhos.ToList();
            this.Pais.AddRange(listaMelhoresPais);
            this.Filhos.Clear();
        }

        private void SelecionaMelhoresFilhos(int n)
        {
            var listaMelhoresPais = this.Pais.OrderByDescending(x => x.Aptidao(this.InfoItens)).Take(Constantes.TamanhoPopulacao - n).ToList();
            var listaMelhoresFilhos = this.Filhos.OrderByDescending(x => x.Aptidao(this.InfoItens)).Take(n).ToList();

            listaMelhoresPais.AddRange(listaMelhoresFilhos);

            this.Pais = listaMelhoresPais.ToList();
            this.Filhos.Clear();
        }

        private Mochila SelecionaProporcionalAptidao()
        {
            var aptidaoTotal = this.SomaTotalAptidaoPais();
            var randomico = Constantes.Randomico.ProximoInt(aptidaoTotal);

            var selecionadoInicial = 0;
            var aptidaoAcumulada = 0;

            for (int i = 0; i < this.TotalItens; i++)
            {
                aptidaoAcumulada += this.Pais.ElementAt(i).Aptidao(this.InfoItens);
                if (aptidaoAcumulada < randomico)
                {
                    continue;
                }
                else
                {
                    selecionadoInicial = i;
                    break;
                }
            }

            return this.Pais.ElementAt(selecionadoInicial);
        }

        private void IniciaPopulacao()
        {
            for (int i = 0; i < Constantes.TamanhoPopulacao; i++)
            {
                var individuo = HelperMochila.IniciarMochilaAleatoriaValida(this.TotalItens, this.InfoItens, this.InfoRestricoes);
                this.Pais.Add(individuo);
            }
        }

        private void ImprimeMelhorIndividuo()
        {
            var melhorIndividuo = this.Pais.OrderByDescending(x => x.Aptidao(this.InfoItens)).First();

            melhorIndividuo.ImprimeMochila(this.InfoItens);
        }

        private int SomaTotalAptidaoPais()
        {
            int total = this.Pais.Select(x => x.Aptidao(this.InfoItens)).Sum();

            return total;
        }
    }
}
