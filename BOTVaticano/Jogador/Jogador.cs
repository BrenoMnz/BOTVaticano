using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOTVaticano
{
    internal class Jogador
    {
        protected int idJogador;
        protected string nomeJogador;
        protected int posicaoJogadorNaMesa;
        protected string senhaJogadorNaPartida;
        protected string pontosJogador;
        // pontos - final round
        // vitoria - final da rodada
        protected List<Carta> cartas = new List<Carta>();

        public int IdJogador { get { return idJogador; } set { idJogador = value; } }
        public string NomeJogador { get { return nomeJogador; } set { nomeJogador = value; } }
        public int PosicaoJogadorNaMesa { get { return posicaoJogadorNaMesa; } set { posicaoJogadorNaMesa = value; } }
        public string SenhaJogadorNaPartida { get { return senhaJogadorNaPartida; } set { senhaJogadorNaPartida = value; } }
        public string PontosJogador { get { return pontosJogador; } set { pontosJogador = value; } }
        public List<Carta> Cartas { get { return cartas; } set { cartas = value; } }

        public Jogador(int idJogador, string nomeJogador, string senhaNaPartida)
        {
            this.idJogador = idJogador;
            this.nomeJogador = nomeJogador;
            this.senhaJogadorNaPartida = senhaNaPartida;
        }

        public void AtribuiCartas(List<Carta> cartas)
        {
            Cartas = cartas;
        }

        // TODO: Metodo com a logica de jogar Cartas
        public void JogarCarta(int posCard)
        {
            /*
             * Toda informação necessaria para se jogar uma carta 
             * deve ser contida dentro dessa classe ou 
             * recebida como parametro
             * */

            string resp;
            try
            {
                resp = Jogo.Jogar(IdJogador, SenhaJogadorNaPartida, posCard);
                if (resp.Substring(0, 1) == "E")
                {
                    MessageBox.Show(resp, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // TODO: Metodo com a logica de apostar cartas
        public void Apostar(int posCard)
        {
            /*
             * Toda informação necessaria para apostar uma carta 
             * deve ser contida dentro dessa classe ou 
             * recebida como parametro
             * */
            string resp;
            try
            {
                resp = Jogo.Apostar(IdJogador, SenhaJogadorNaPartida, posCard);
                if (resp.Substring(0, 1) == "E")
                {
                    MessageBox.Show(resp, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
