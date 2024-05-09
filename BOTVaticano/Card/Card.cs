using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOTVaticano
{
    internal class Card
    {
        protected int donoID;
        protected int valor;
        protected char naipe;
        protected int posicaoCard;

        public int DonoID { get { return donoID; } set { donoID = value; } }
        public char Naipe { get { return naipe; } set { naipe = value; } }
        public int Valor { get { return valor; } set { valor = value; } }
        public int PosicaoCard { get { return posicaoCard; } set { posicaoCard = value; } }
        public Card(int idJogador, char naipe)
        {
            DonoID = idJogador;
            Naipe = naipe;
        }

        public void atribuiValor(int valorDaCarta)
        {
            Valor = valorDaCarta;
        }
    }
}
