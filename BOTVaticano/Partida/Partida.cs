
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
    private string status;
    private int idJogadorDaVez;
    private int rodada;
    private string acao;
    private int idPrimeiraJogada;
    private char naipePrimeiraJogada;
    private string[] vez;

    public int QtdJogadores { get { return qtdJogadores; } set { qtdJogadores = value; } }
    public int QtdCartas { get { return qtdCartas; } set { qtdCartas = value; } }
    public string Status { get { return status; } set { status = value; } }
    public int IdJogadorDaVez { get { return idJogadorDaVez; } set { idJogadorDaVez = Int32.Parse((vez[0].Split(','))[1]); } }
    public int Rodada { get { return rodada; } set { rodada = Int32.Parse((vez[0].Split(','))[2]); } }
    public string Acao { get { return acao; } set { acao = value; } }
    public int IdPrimeiraJogada { get { return idPrimeiraJogada; } set { idPrimeiraJogada = value; } }
    public char NaipePrimeiraJogada { get { return naipePrimeiraJogada; } set { naipePrimeiraJogada = value; } }
    public string[] Vez { get { return vez; } set { vez = value; } }

    public Partida(int idPartida) 
    {
        this.idPartida = idPartida;

        QtdJogadores = 0;
        if (QtdJogadores == 2)
        {
            QtdCartas = 12;
        }
        if(QtdJogadores == 4) 
        { 
            QtdCartas = 14;
        }

        Status = "Aberta";
        IdJogadorDaVez = -1;

        IdPrimeiraJogada = -1;
        NaipePrimeiraJogada = ' ';
    }

    public void AtualizarVez() 
    {
        string checarVez = Jogo.VerificarVez2(idPartida);
        checarVez = checarVez.Replace("\r", "");
        string[] informacaoVez = checarVez.Split('\n');
        informacaoVez = informacaoVez.Where(s => !string.IsNullOrEmpty(s)).ToArray();
        vez = informacaoVez;
        AtualizarInfoRodada();
    }

    private void AtualizarInfoRodada()
    {
        string[] infos = vez[0].Split(',');
        Status = infos[0];
        IdJogadorDaVez = Int32.Parse(infos[1]);
        Rodada = Int32.Parse(infos[2]);
        if (infos[3] == "C")
        {
            Acao = "Jogar";
        }
        if (infos[3] == "A")
        {
            Acao = "Apostar";
        }
        if (infos[3] == "E")
        {
            Acao = "Encerrada";
        }
    }

    public void AtualizarPrimeiraJogada()
    {

        foreach (string info in Vez)
        {
            string[] infoSeparada = info.Split(',');
            if (info[0] == 'J')
            {
                infoSeparada[0].Remove(0, 2);
                IdPrimeiraJogada = Int32.Parse(infoSeparada[0]);
            }
            if (info[0] == 'C')
            {
                NaipePrimeiraJogada = Char.Parse(infoSeparada[1]);
            }
        }
    }

    public Carta[] CartasJogadasRodada(List<Jogador> jogadores)
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
                    cartasJogadas[jogadores[i].PosicaoJogadorNaMesa] = carta;
                }
            }
        }
        return cartasJogadas;
    }

    public Carta[] CartasApostadasRodada(List<Jogador> jogadores)
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
                    cartasApostadas[jogadores[i].PosicaoJogadorNaMesa] = carta;
                }
            }
        }
        return cartasApostadas;
    }
    
}