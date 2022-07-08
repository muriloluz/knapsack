﻿using knapsack.GA.Helpers;
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

        public int Instancia { get; private set; }

        public int TotalRestricoes { get; private set; }

        public int TotalItens { get; private set; }

        public InfoItem[] InfoItens { get; private set; }

        public InfoRestricao[] InfoRestricoes { get; private set; }

        public List<Mochila> Pais { get; private set; }

        public List<Mochila> Filhos { get; private set; }


        public void Iniciar()
        {
            for (int g = 0; g < Constantes.Geracoes; g++)
            {
                this.IniciaPopulacao();

                for (int i = 0; i < Constantes.TamanhoPopulacao / 2; i++)
                {
                    var pai = this.SelecionaPaisAleatoriamente();
                    var mae = this.SelecionaPaisAleatoriamente();

                    /// Crossover
                    var filhos = Recombinacao.DoisPontos(pai, mae, Constantes.TaxaRecombinacao, this.InfoItens);

                    /// Mutacao
                    foreach (var f in filhos)
                    {
                        Mutacao.Muta(f, Constantes.TaxaMutacao);
                    }

                    filhos.ForEach(x => HelperMochila.CorrigePesoItemPorRestricaoAleatorio(x, this.TotalItens, this.InfoItens, this.InfoRestricoes));

                    this.Filhos.AddRange(filhos);
                }

                this.SelecionaSobreviventesElitismo(Constantes.SobreviventesElitismo);

                if(g % 200 == 0)
                {
                    Console.WriteLine("Geração: " + g);
                    ImprimeMelhorIndividuo();
                }
            }

            ImprimeMelhorIndividuo();
        }

        private Mochila SelecionaPaisAleatoriamente()
        {
            var randomico = Constantes.Randomico.ProximoInt(Constantes.TamanhoPopulacao);

            return this.Pais.ElementAt(randomico);
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
