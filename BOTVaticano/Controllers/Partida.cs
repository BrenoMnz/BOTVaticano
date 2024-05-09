
using BOTVaticano;
using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.VisualStyles;

class Partida
{ 
    private int idPartida;
    private int qtdJogadores;
    private int qtdCartas;
    private int jogadorDaVez;
    private int rodada;
    private string[] vez;
    
    List<Carta> cartasRodada;

    public int QtdJogadores { get { return qtdJogadores; } set { qtdJogadores = value; } }
    public int QtdCartas { get { return qtdCartas; } set { qtdCartas = value; } }
    public int Rodada { get { return rodada; } set { rodada = Int32.Parse((vez[0].Split(','))[2]); } }
    public int JogadorDaVez { get { return jogadorDaVez; } set { jogadorDaVez = Int32.Parse((vez[0].Split(','))[1]); } }

    public Partida(int idPartida, List<Jogador> jogadores) 
    {
        this.idPartida = idPartida;
        qtdJogadores = jogadores.Count;

        if (qtdJogadores == 2)
        {
            qtdCartas = 12;
        }
        if(qtdJogadores == 4) 
        { 
            qtdCartas = 14;
        }

        jogadorDaVez = -1;

        cartasRodada = new List<Carta>();

    }

    void AtualizarVez() 
    {
        string checarVez = Jogo.VerificarVez2(idPartida);
        checarVez = checarVez.Replace("\r", "");
        string[] informacaoVez = checarVez.Split('\n');
        informacaoVez = informacaoVez.Where(s => !string.IsNullOrEmpty(s)).ToArray();
        vez = informacaoVez;
    }

    Carta[] CartasJogadas(List<Jogador> jogadores)
    {
        Carta[] cartasJogadas = new Carta[4];
        Carta carta = null;
        foreach (string jogada in vez)
        {
            if (jogada[0] == 'C')
            {
                jogada.Remove(0, 2);
                string[] infoCarta = jogada.Split(',');
                carta = new Carta(Int32.Parse(infoCarta[0]), Char.Parse(infoCarta[1]), Int32.Parse(infoCarta[3]));
                carta.Valor = Int32.Parse(infoCarta[2]);
            }

            for (int i = 0; i < jogadores.Count; i++)
            {
                if (jogadores[i].IdJogador == carta.IdJogador)
                {
                    cartasJogadas[i] = carta;
                }
            }
        }
        return cartasJogadas;
    }

    Carta[] CartasApostadas(List<Jogador> jogadores)
    {
        Carta[] cartasApostadas = new Carta[4];
        Carta carta = null;
        foreach (string jogada in vez)
        {
            if (jogada[0] == 'A')
            {
                jogada.Remove(0, 2);
                string[] infoCarta = jogada.Split(',');
                carta = new Carta(Int32.Parse(infoCarta[0]), Char.Parse(infoCarta[1]), Int32.Parse(infoCarta[3]));
                carta.Valor = Int32.Parse(infoCarta[2]);
            }

            for (int i = 0; i < jogadores.Count; i++)
            {
                if (jogadores[i].IdJogador == carta.IdJogador)
                {
                    cartasApostadas[i] = carta;
                }
            }
        }
        return cartasApostadas;
    }



    
}