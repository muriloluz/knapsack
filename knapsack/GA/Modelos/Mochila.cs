using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knapsack.GA.Modelos
{
    public class Mochila
    {
        public Mochila(int quantidadeItens, int quantidadeRestricoes)
        {
            this.Items = new int[quantidadeItens];
            this.PesoRestricoesAtuais = new int[quantidadeRestricoes];
        }

        public int[] Items { get; private set; }

        public int[] PesoRestricoesAtuais { get; private set; }

        public void ImprimeMochila(InfoItem[] infoItem)
        {
            var qntRestricoes = this.Items.Length;

            var qntItens = this.Items.Length;

            Console.WriteLine();

            Console.WriteLine("Mochila: ");

            for (int i = 0; i < qntItens; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine();
                }

                Console.Write(this.Items[i] + "  ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Restrições Atuais: ");

            for(int i = 0; i < this.PesoRestricoesAtuais.Length; i++)
            {
                Console.Write(this.PesoRestricoesAtuais[i] + "   ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Quantidade de Itens: " + this.Items.Where(x=>x == 1).Count());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Valor da mochila: " + this.Aptidao(infoItem));
            Console.WriteLine();
            Console.WriteLine();
        }

        public List<int> CalcularRestricoesAtuais(InfoItem[] infoItem)
        {
            List<int> indiceDosItensPresentes = new List<int>();

            //// Zera calculo inicial
            for (int p = 0; p < PesoRestricoesAtuais.Length; p++)
            {
                this.PesoRestricoesAtuais[p] = 0;
            }

            //// Primeiro Calculo das restrições com os itens atuais.
            for (int i = 0; i < this.Items.Length; i++)
            {
                if (this.Items[i] == 1)
                {
                    indiceDosItensPresentes.Add(i);

                    for (int j = 0; j < this.PesoRestricoesAtuais.Length; j++)
                    {
                        PesoRestricoesAtuais[j] += infoItem[i].PesoItem[j];
                    }
                }

            }

            return indiceDosItensPresentes;
        }

        public int Aptidao(InfoItem[] infoItem)
        {
            var valorAcumulado = 0;

            for (int i = 0; i < this.Items.Length; i++)
            {
                if (this.Items[i] == 1)
                {
                    valorAcumulado += infoItem[i].Valor;
                }
            }

            return valorAcumulado;
        }
    }
}
