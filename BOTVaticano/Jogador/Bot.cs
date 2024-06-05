using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOTVaticano
{
    internal class Bot : Jogador
    {
        bool apostou;
        Random random;
        public Bot(int idJogador, string nomeJogador, string senhaNaPartida) : base(idJogador, nomeJogador, senhaNaPartida)
        {
            apostou = false;
            random = new Random();
        }
        
        public Carta SelecionarCartaAleatoria(Partida partida)
        {
            List<Carta> cartasJogaveis = new List<Carta>();
            Carta cartaJogavel = null;

            if (partida.NaipePrimeiraJogada != ' ')
            {
                foreach (Carta carta in cartas)
                {
                    if (carta.Naipe == partida.NaipePrimeiraJogada && carta.IdCarta > 0)
                    {
                        cartasJogaveis.Add(carta);
                    }
                }
            }

            if (cartasJogaveis.Count == 0)
            {
                foreach (Carta carta in cartas)
                {
                    if (carta.IdCarta > 0)
                    {
                        cartasJogaveis.Add(carta);
                    }
                }
            }

            int cartaSelecionada = random.Next(0, cartasJogaveis.Count);
            if (cartasJogaveis.Count > 0)
            {
                cartaJogavel = cartasJogaveis[cartaSelecionada];
            }

            return cartaJogavel;
        }

        public Carta SelecionaCartaDeAposta(Partida partida)
        {
            List<Carta> cartasApostaveis= new List<Carta>();
            Carta cartaApostavel = null;

            foreach (Carta carta in cartas)
            {
                if (carta.IdCarta > 0)
                {
                    cartasApostaveis.Add(carta);
                }
            }

            int cartaSelecionada = random.Next(0, cartasApostaveis.Count);
            if (cartasApostaveis.Count > 0)
            {
                cartaApostavel = cartasApostaveis[cartaSelecionada];
            }

            return cartaApostavel;

        }

        public Carta DecidirAposta(Partida partida)
        {
            if (apostou)
            {
               return null;
            }

            Random random = new Random();

            int chanceDeAposta = random.Next(0, 100);

            if (chanceDeAposta > 50)
            {
                return null;
            }

            Carta cartaSelecionada = SelecionaCartaDeAposta(partida);

            return cartaSelecionada;
        }
        public bool EhVezJogador1(Partida partida)
        {
            if (partida.IdJogadorDaVez == IdJogador)
            {
                return true;
            }

            return false;
        }
    }
}
