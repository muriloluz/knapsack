using knapsack.GA.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knapsack.GA.Helpers
{
    public static class Recombinacao
    {
        public static List<Mochila> UmPonto(Mochila pai, Mochila mae, int taxaRecombinacao, InfoItem[] infoItem)
        {
            var random = Constantes.Randomico.ProximoInt(101);

            Mochila filho1;
            Mochila filho2;

            if (random <= taxaRecombinacao)
            {
                filho1 = new Mochila(pai.Items.Length, pai.PesoRestricoesAtuais.Length);
                filho2 = new Mochila(pai.Items.Length, pai.PesoRestricoesAtuais.Length);

                var ponto = Constantes.Randomico.ProximoInt(pai.Items.Length);

                for (int i = 0; i <= ponto; i++)
                {
                    filho1.Items[i] = pai.Items[i];

                    filho2.Items[i] = mae.Items[i];
                }

                for (int j = ponto + 1; j < pai.Items.Length; j++)
                {
                    filho1.Items[j] = mae.Items[j];

                    filho2.Items[j] = pai.Items[j];
                }
            }
            else
            {
                filho1 = Clona(pai, infoItem);
                filho2 = Clona(mae, infoItem);
            }

            var retorno = new List<Mochila>();

            retorno.Add(filho1);
            retorno.Add(filho2);

            return retorno;
        }

        public static List<Mochila> DoisPontos(Mochila pai, Mochila mae, int taxaRecombinacao, InfoItem[] infoItem)
        {
            var random = Constantes.Randomico.ProximoInt(101);

            Mochila filho1;
            Mochila filho2;


            if (random <= taxaRecombinacao)
            {
                var pontoUm = Constantes.Randomico.ProximoInt(pai.Items.Length);
                var pontoDois = Constantes.Randomico.ProximoInt(pai.Items.Length);

                var pontoMenor = (pontoUm < pontoDois) ? pontoUm : pontoDois;
                var pontoMaior = (pontoUm >= pontoDois) ? pontoUm : pontoDois;

                filho1 = new Mochila(pai.Items.Length, pai.PesoRestricoesAtuais.Length);
                filho2 = new Mochila(pai.Items.Length, pai.PesoRestricoesAtuais.Length);

                for (int i = 0; i <= pontoMenor; i++)
                {
                    filho1.Items[i] = pai.Items[i];
                    filho2.Items[i] = mae.Items[i];
                }

                for (int j = pontoMenor + 1; j <= pontoMaior; j++)
                {
                    filho1.Items[j] = mae.Items[j];
                    filho2.Items[j] = pai.Items[j];
                }

                for (int w = pontoMaior + 1; w < pai.Items.Length; w++)
                {
                    filho1.Items[w] = pai.Items[w];
                    filho2.Items[w] = mae.Items[w];
                }
            }
            else
            {
                filho1 = Clona(pai, infoItem);
                filho2 = Clona(mae, infoItem);
            }

            var retorno = new List<Mochila>();

            retorno.Add(filho1);
            retorno.Add(filho2);

            return retorno;
        }

        private static Mochila Clona(Mochila pai, InfoItem[] infoItem)
        {
            var filho = new Mochila(pai.Items.Length, pai.PesoRestricoesAtuais.Length);

            for (int i = 0; i < pai.Items.Length; i++)
            {
                filho.Items[i] = pai.Items[i];
            }

            filho.CalcularRestricoesAtuais(infoItem);

            return filho;
        }
    }
}