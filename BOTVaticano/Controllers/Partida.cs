
using BOTVaticano;
using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Linq;

class Partida
{ 
    private int idPartida;
    private int qtdJogadores;
    private int qtdCartas;
    private int jogadorDaVez;
    private int rodada;
    private string[] vez;
    
    List<Carta> cartasRodada;


    public Partida(int idPartida) 
    {
        this.idPartida = idPartida;
        qtdJogadores = SepararJogadores().Length;

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

    public int QtdJogadores 
    {
        get 
        { 
            return qtdJogadores; 
        }
    }

    public int QtdCartas
    {
        get
        {
            return qtdCartas;
        }
       
    }
    public int Rodada
    {
        get
        {
            return rodada;
        }

        set 
        { 
            rodada = Int32.Parse((vez[0].Split(','))[2]);
        }

    }

    public int JogadorDaVez
    {
        get
        {
            return jogadorDaVez;
        }

        set
        {
            jogadorDaVez = Int32.Parse((vez[0].Split(','))[1]);
        }

    }
    private string[] SepararJogadores()
    {
        int id = idPartida;
        string listaJogadores = Jogo.ListarJogadores(id);
        listaJogadores = listaJogadores.Replace("\r", "");
        listaJogadores = listaJogadores.Substring(0, listaJogadores.Length - 1);
        string[] jogadores = listaJogadores.Split('\n');
        return jogadores;
    }

    void AtualizarVez() 
    {
        string checarVez = Jogo.VerificarVez2(idPartida);
        checarVez = checarVez.Replace("\r", "");
        string[] informacaoVez = checarVez.Split('\n');
        informacaoVez = informacaoVez.Where(s => !string.IsNullOrEmpty(s)).ToArray();
        vez = informacaoVez;
    }

    void cartaJogada() 
    {

        //eseprando a mesaPartida

    }



    
}