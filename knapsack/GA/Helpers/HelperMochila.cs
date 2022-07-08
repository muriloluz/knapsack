using knapsack.GA.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knapsack.GA.Helpers
{
    public static class HelperMochila
    {
        public static Mochila IniciarMochilaAleatoriaValida(
            int quantidadeItens,
            InfoItem[] infoItens,
            InfoRestricao[] infoRestricao)
        {
            var mochila = IniciarMochilaAleatoria(quantidadeItens, infoRestricao);

            CorrigePesoItemPorRestricaoAleatorio(mochila, quantidadeItens, infoItens, infoRestricao);

            return mochila;
        }

        private static Mochila IniciarMochilaAleatoria(int quantidadeItens, InfoRestricao[] infoRestricao)
        {
            var mochila = new Mochila(quantidadeItens, infoRestricao.Length);

            var itemAtual = 0;

            while (itemAtual < quantidadeItens)
            {
                mochila.Items[itemAtual] = Constantes.Randomico.RandomZeroOuUm();
                itemAtual++;
            }

            return mochila;
        }

        public static void CorrigePesoItemPorRestricaoAleatorio(
            Mochila mochila,
            int quantidadeItens,
            InfoItem[] infoItem,
            InfoRestricao[] infoRestricao)
        {
            var valido = false;

            while (!valido)
            {
                //// Calcula Restricoes
                var itensPresentes = mochila.CalcularRestricoesAtuais(infoItem);

                //// Checa se são validas as dimensões
                
                for(int i = 0; i < infoRestricao.Length; i++)
                {
                    if( mochila.PesoRestricoesAtuais[i] <= infoRestricao[i].PesoMaximo )
                    {
                        valido = true;
                    }
                    else
                    {
                        /// Basta uma dimensão inválida
                        valido = false;
                        break;
                    }
                }

                if (valido)
                {
                    break;
                }
                else
                {
                    var indiceItemRemocao = Constantes.Randomico.ProximoInt(itensPresentes.Count);
                    var indiceParaAlteracao = itensPresentes.ElementAt(indiceItemRemocao);

                    mochila.Items[indiceParaAlteracao] = 0;
                }
            }

            /// Tenta adicionar o máximo de itens disponíveis
            mochila.CalcularRestricoesAtuais(infoItem);

            for(int i = 0; i < infoItem.Length; i++)
            {
                /// Se o item for ausente, verificar se ele cabe nas restrições
                if (mochila.Items[i] == 0)
                {
                    var podeSerInserido = true;
                    for(int j = 0; j < infoRestricao.Length; j++)
                    {
                        if(infoItem[i].PesoItem[j] + mochila.PesoRestricoesAtuais[j] > infoRestricao[j].PesoMaximo)
                        {
                            podeSerInserido = false;
                        }
                    }

                    if (podeSerInserido)
                    {
                        mochila.Items[i] = 1;
                        mochila.CalcularRestricoesAtuais(infoItem);
                    }
                    
                }
            }

        }
    }
}