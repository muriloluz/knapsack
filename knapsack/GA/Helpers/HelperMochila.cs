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
            int quantidadeCompartimentos,
            int quantidadeItens,
            InfoItem[] infoItens,
            InfoCompartimento[] infoCompartimentos)
        {
            var mochila = IniciarMochilaAleatoria(quantidadeCompartimentos, quantidadeItens);

            CorrigeQuantidadeItens(mochila, quantidadeCompartimentos, quantidadeItens);
            CorrigePesoItemNoCompartimento(mochila, quantidadeCompartimentos, quantidadeItens, infoItens, infoCompartimentos);

            return mochila;
        }

        private static Mochila IniciarMochilaAleatoria(
            int quantidadeCompartimentos,
            int quantidadeItens)
        {
            var mochila = new Mochila(quantidadeCompartimentos, quantidadeItens);

            var compartimentoAtual = 0;
            var itemAtualNoCompartimento = 0;

            while (compartimentoAtual < quantidadeCompartimentos)
            {
                while(itemAtualNoCompartimento < quantidadeItens)
                {
                    mochila.Items[compartimentoAtual][itemAtualNoCompartimento] = Constantes.Randomico.RandomZeroOuUm();
                    itemAtualNoCompartimento++;
                }
                compartimentoAtual++;
                itemAtualNoCompartimento = 0;
            }

            return mochila;
        }

        private static void CorrigeQuantidadeItens(
            Mochila mochila,
            int quantidadeCompartimentos,
            int quantidadeItens)
        {
            var compartimentoAtual = 0;
            var itemAtualNoCompartimento = 0;

            while(itemAtualNoCompartimento < quantidadeItens)
            {
                var auxItensPresentes = new List<int>();

                while(compartimentoAtual < quantidadeCompartimentos)
                {
                    if(mochila.Items[compartimentoAtual][itemAtualNoCompartimento] == 1)
                    {
                        auxItensPresentes.Add(compartimentoAtual);
                    }

                    compartimentoAtual++;
                }

                //// O mesmo item não pode estar presente em mais de um compartimento, 
                //// sorteando o compartimento que será mantido  com 1 e os demais com 0.
                if(auxItensPresentes.Count > 1)
                {
                    var posicaoQueSeraMantida = Constantes.Randomico.ProximoInt(auxItensPresentes.Count);

                    auxItensPresentes.RemoveAt(posicaoQueSeraMantida);

                    foreach(var p in auxItensPresentes)
                    {
                        mochila.Items[p][itemAtualNoCompartimento] = 0;
                    }
                }

                compartimentoAtual = 0;
                itemAtualNoCompartimento++;
            }
        }

        private static void CorrigePesoItemNoCompartimento(
            Mochila mochila,
            int quantidadeCompartimentos,
            int quantidadeItens,
            InfoItem[] infoItem,
            InfoCompartimento[] infoCompartimento)
        {
            var compartimentoAtual = 0;
            var itemAtualNoCompartimento = 0;

            while (compartimentoAtual < quantidadeCompartimentos)
            {
                var auxItensPresentes = new List<int>();
                var totalPesoCompartimento = 0;

                while (itemAtualNoCompartimento < quantidadeItens)
                {
                    if (mochila.Items[compartimentoAtual][itemAtualNoCompartimento] == 1)
                    {
                        auxItensPresentes.Add(itemAtualNoCompartimento);
                        totalPesoCompartimento += infoItem[itemAtualNoCompartimento].PesoItem[compartimentoAtual];
                    }

                    itemAtualNoCompartimento++;
                }

                //// Caso o peso tenha sido ultrapassado
                //// Sortear, dentre os itens existentes alguma para ser removido.
                if (totalPesoCompartimento > infoCompartimento[compartimentoAtual].PesoMaximo)
                {
                    var posicaoItemRemovido = Constantes.Randomico.ProximoInt(auxItensPresentes.Count);
                    var itemRemovido = auxItensPresentes.ElementAt(posicaoItemRemovido);
                    mochila.Items[compartimentoAtual][itemRemovido] = 0;
                }
                else
                {
                    compartimentoAtual++;
                }

                itemAtualNoCompartimento = 0;
            }
        }
    }
}
