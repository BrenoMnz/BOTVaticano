
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
    private int round;
    private string acao;
    private int idPrimeiraJogada;
    private char naipePrimeiraJogada;
    private string[] vez;

    public int QtdJogadores { get { return qtdJogadores; } set { qtdJogadores = value; } }
    public int QtdCartas { get { return qtdCartas; } set { qtdCartas = value; } }
    public string Status { get { return status; } set { status = value; } }
    public int IdJogadorDaVez { get { return idJogadorDaVez; } set { idJogadorDaVez = value; } }
    public int Rodada { get { return rodada; } set { rodada = value; } }
    public int Round { get { return round; } set { round = value; } }
    public string Acao { get { return acao; } set { acao = value; } }
    public int IdPrimeiraJogada { get { return idPrimeiraJogada; } set { idPrimeiraJogada = value; } }
    public char NaipePrimeiraJogada { get { return naipePrimeiraJogada; } set { naipePrimeiraJogada = value; } }
    public string[] Vez { get { return vez; } set { vez = value; } }

    public Partida(int idPartida) 
    {
        this.idPartida = idPartida;

        Status = "Aberta";
        IdJogadorDaVez = -1;

        IdPrimeiraJogada = -1;
        NaipePrimeiraJogada = ' ';

        Rodada = 1;
        Round = 1;
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
    
    public void AtualizarInfoJogadores()
    {
        string listaJogadores = Jogo.ListarJogadores2(idPartida);
        listaJogadores = listaJogadores.Replace("\r", "");
        listaJogadores = listaJogadores.Substring(0, listaJogadores.Length - 1);
        string[] informacaoJogadores = listaJogadores.Split('\n');

        QtdJogadores = informacaoJogadores.Length;

        if (QtdJogadores == 2)
        {
            QtdCartas = 12;
        }

        if (QtdJogadores == 4)
        {
            QtdCartas = 14;
        }
    }

    private void AtualizarInfoRodada()
    {
        string[] infos = vez[0].Split(',');
        Status = infos[0];

        if (Status.Length == 1)
        {
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
    }

    public void AtualizarRound()
    {
        string listaRodadas = Jogo.ExibirJogadas2(idPartida, Round);
        listaRodadas = listaRodadas.Replace("\r", "");
        string[] informacaoRodadas = listaRodadas.Split('\n').Where(c => !string.IsNullOrEmpty(c)).ToArray();

        if (informacaoRodadas.Length != 0)
        {
            Rodada = Int32.Parse(informacaoRodadas[informacaoRodadas.Length - 1].Split(',')[0]);

            bool terminouORound = informacaoRodadas.Length == (QtdCartas - 1) * QtdJogadores;

            if (terminouORound)
            {
                Round += 1;
            }
        }
    }

    public void AtualizarPrimeiraJogada()
    {
        if (Vez.Length == 1)
        {
            NaipePrimeiraJogada = ' ';
        }

        bool ehPrimeiroC = false;

        foreach (string info in Vez)
        {
            string[] infoSeparada = info.Split(',');
            if (info[0] == 'J')
            {
                IdPrimeiraJogada = Int32.Parse(infoSeparada[1]);
            }
            if (info[0] == 'C' && ehPrimeiroC == false)
            {
                ehPrimeiroC = true;
                infoSeparada[0].Remove(0, 2);
                NaipePrimeiraJogada = Char.Parse(infoSeparada[1]);
            }
        }
    }

    public bool EhPrimeiraJogada()
    {
        if (Vez.Length == 1)
        {
            return true;
        }

        return false;
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