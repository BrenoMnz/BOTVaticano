using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOTVaticano
{
    public class Carta
    {
        private int donoID;
        private int valor;
        private char naipe;

        public int DonoID { get { return donoID; } set { donoID = value; } }
        public char Naipe { get { return naipe; } set { naipe = value; } }
        public int Valor { get { return valor; } set { valor = value; } }
        public Carta(int idJogador, char naipe)
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
