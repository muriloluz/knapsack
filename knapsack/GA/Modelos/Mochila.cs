using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knapsack.GA.Modelos
{
    public class Mochila
    {
        public Mochila(int quantidadeCompartimentos, int quantidadeItens)
        {
            this.Items = new int[quantidadeCompartimentos][];

            for(int i = 0; i < quantidadeCompartimentos; i++)
            {
                this.Items[i] = new int[quantidadeItens];
            }
        }

        public int[][] Items { get; private set; }

        public int Aptidao(InfoItem[] infoItems)
        {
            var qntCompartimento = this.Items.Length;
            var qntItens = this.Items[0].Length;
            var valorAcumlado = 0;

            for(int i = 0; i < qntCompartimento; i++)
            {
                for(int j = 0; j < qntItens; j++)
                {
                    if(this.Items[i][j] == 1)
                    {
                        valorAcumlado += infoItems[j].Valor;
                    }
                }
            }

            return valorAcumlado;
        }

        public void ImprimeMochila(InfoItem[] infoItems)
        {
            var qntCompartimento = this.Items.Length;
            var qntItens = this.Items[0].Length;
            var valorAcumlado = 0;
            var pesoPorCompartimento = 0;

            for (int i = 0; i < qntCompartimento; i++)
            {
                for (int j = 0; j < qntItens; j++)
                {
                    if (this.Items[i][j] == 1)
                    {
                        valorAcumlado += infoItems[j].Valor;
                    }
                }
            }
        }
    }
}
