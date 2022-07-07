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
        public EstrategiaAG(int instancia, InfoItem[] infoItens, InfoCompartimento[] infoCompartimentos)
        {
            this.Instancia = instancia;
            InfoItens = infoItens;
            InfoCompartimentos = infoCompartimentos;
            this.Individuos = new List<Mochila>();

            this.TotalCompartimentos = infoCompartimentos.Length;
            this.TotalItens = infoItens.Length;
        }

        public int Instancia { get; private set; }

        public int TotalCompartimentos { get; private set; }

        public int TotalItens { get; private set; }

        public InfoItem[] InfoItens { get; private set; }

        public InfoCompartimento[] InfoCompartimentos { get; private set; }

        public List<Mochila> Individuos { get; private set; }

        public void IniciaPopulacao()
        {         
            for(int i = 0; i < 30; i++)
            {
                var individuo = HelperMochila.IniciarMochilaAleatoriaValida(this.TotalCompartimentos, this.TotalItens, this.InfoItens, this.InfoCompartimentos);
                this.Individuos.Add(individuo);
            }

            foreach(var item in this.Individuos)
            {
                Console.WriteLine(item.Aptidao(this.InfoItens));
            }

        }
    }
}
