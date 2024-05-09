
namespace BOTVaticano
{
    public class Carta
    {
        private int idJogador;
        private int valor;
        private char naipe;
        private int idCarta;

        public int IdJogador { get { return idJogador; } set { idJogador = value; } }
        public char Naipe { get { return naipe; } set { naipe = value; } }
        public int Valor { get { return valor; } set { valor = value; } }
        public Carta(int idJogador, char naipe, int idCarta)
        {
            this.idJogador = idJogador;
            this.naipe = naipe;
            this.idCarta = idCarta; 
        }

        public void atribuiValor(int valorDaCarta)
        {
            Valor = valorDaCarta;
        }
    }
}
