﻿using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Runtime.InteropServices.WindowsRuntime;

namespace BOTVaticano
{
    public partial class MesaDePartida : Form
    {
        public string idPartida { set; get; }
        public int idJogador { set; get; }
        public string senhaJogador { set; get; }

        private IDictionary<int, Button> btnsJogador1 = new Dictionary<int, Button>();
        private IDictionary<int, Button> btnsJogador2 = new Dictionary<int, Button>();
        private IDictionary<int, Button> btnsJogador3 = new Dictionary<int, Button>();
        private IDictionary<int, Button> btnsJogador4 = new Dictionary<int, Button>();

        public string[,] cartasJogador1 = new string[14, 3];
        public string[,] cartasJogador2 = new string[14, 3];
        public string[,] cartasJogador3 = new string[14, 3];
        public string[,] cartasJogador4 = new string[14, 3];

        
        private string[] SepararJogadores()
        {
            int id = Int32.Parse(idPartida);
            string listaJogadores = Jogo.ListarJogadores(id);
            listaJogadores = listaJogadores.Replace("\r", "");
            listaJogadores = listaJogadores.Substring(0, listaJogadores.Length - 1);
            string[] jogadores = listaJogadores.Split('\n');
            return jogadores;
        }

        private void AtualizarJogadores()
        {
            string[] jogadores = SepararJogadores();
            List<Label> labelsJogadores = new List<Label> { lblJogador1, lblJogador2, lblJogador3, lblJogador4 };
            List<Label> labelsIDJogadores = new List<Label> { lblIDJogador1, lblIDJogador2, lblIDJogador3, lblIDJogador4 };

            lvwJogadores.Items.Clear();

            for (int i = 0; i < labelsJogadores.Count(); i++)
            {
                if (i < jogadores.Length)
                {
                    string[] jogador = jogadores[i].Split(',');

                    labelsIDJogadores[i].Text = jogador[0];
                    labelsIDJogadores[i].Visible = true;
                    labelsJogadores[i].Text = jogador[1];
                    labelsJogadores[i].Visible = true;

                    ListViewItem itemJogador = new ListViewItem(jogador[1]);
                    itemJogador.SubItems.Add(jogador[2]);
                    lvwJogadores.Items.Add(itemJogador);
                }
            }

        }

        private void AtualizarVez()
        {
            string[] jogadores = SepararJogadores();

            string checarVez = Jogo.VerificarVez(Int32.Parse(idPartida));
            string[] informacaoVez = checarVez.Split(',');

            for (int i = 0; i < jogadores.Length; i++)
            {
                string[] jogador = jogadores[i].Split(',');
                if (jogador[0] == informacaoVez[1])
                {
                    lblVezJogador.Text = jogador[1];
                }
            }
        }

        private void SepararCartas(int numJogador)
        {
            int qtdJogadores = SepararJogadores().Length;

            int qtdCartas = 0;

            if (qtdJogadores == 2)
            {
                qtdCartas = 12;
            }
            if (qtdJogadores == 4)
            {
                qtdCartas = 14;
            }

            string[] jogadores = SepararJogadores();
            string idJogador = jogadores[numJogador - 1].Split(',')[0];

            string listaCartas = Jogo.ConsultarMao(Int32.Parse(idPartida));
            listaCartas = listaCartas.Replace("\r", "");
            string[] cartas = listaCartas.Split('\n');


            for (int i = 0; i < qtdCartas * qtdJogadores; i++)
            {
                string[] carta = cartas[i].Split(',');

                if (carta[0] == idJogador)
                {
                    switch (numJogador)
                    {
                        case 1:
                            cartasJogador1[i % qtdCartas, 0] = carta[0];
                            cartasJogador1[i % qtdCartas, 1] = carta[1];
                            cartasJogador1[i % qtdCartas, 2] = carta[2];
                            break;
                        case 2:
                            cartasJogador2[i % qtdCartas, 0] = carta[0];
                            cartasJogador2[i % qtdCartas, 1] = carta[1];
                            cartasJogador2[i % qtdCartas, 2] = carta[2];
                            break;
                        case 3:
                            cartasJogador3[i % qtdCartas, 0] = carta[0];
                            cartasJogador3[i % qtdCartas, 1] = carta[1];
                            cartasJogador3[i % qtdCartas, 2] = carta[2];
                            break;
                        case 4:
                            cartasJogador4[i % qtdCartas, 0] = carta[0];
                            cartasJogador4[i % qtdCartas, 1] = carta[1];
                            cartasJogador4[i % qtdCartas, 2] = carta[2];
                            break;
                    }
                }

            }

        }

        private void CriarBotoes(int numJogador, int startX, int startY, int sizeX, int sizeY, string[,] cartasJogador, IDictionary<int, Button> btns)
        {
            //Essa função existe pq provavelmente vai ser substituída por outra depois que começarmos a usar imagens
            int switchPosX = 0, switchPosY = 0;

            List<Panel> paineis = new List<Panel> { pnlJogador1, pnlJogador2, pnlJogador3, pnlJogador4 };
            paineis[0].Visible = true;
            Panel painelJogador = null;

            int aux;
            switch (numJogador)
            {

                case 1:
                    switchPosX = 61;
                    switchPosY = 80;
                    painelJogador = paineis[0];
                    break;
                case 2:
                    switchPosX = -61;
                    switchPosY = -80;
                    painelJogador = paineis[1];
                    break;
                case 3:
                    switchPosX = -80;
                    switchPosY = 61;
                    aux = sizeX;
                    sizeX = sizeY;
                    sizeY = aux;
                    painelJogador = paineis[2];
                    break;
                case 4:
                    switchPosX = 80;
                    switchPosY = -61;
                    aux = sizeX;
                    sizeX = sizeY;
                    sizeY = aux;
                    painelJogador = paineis[3];
                    break;
            }

            painelJogador.Visible = true;

            int qtdJogadores = SepararJogadores().Length;

            int qtdCartas = 0;

            if (qtdJogadores == 2)
            {
                qtdCartas = 12;
            }
            if (qtdJogadores == 4)
            {
                qtdCartas = 14;
            }

            for (int i = 0; i < (qtdCartas / 2); i++)
            {
                Button btn = new Button();
                btn.Text = cartasJogador[i, 2];
                btn.Size = new Size(sizeX, sizeY);
                btn.Location = new Point(startX, startY);
                btn.Click += new EventHandler(this.FazerUmaJogada);
                
                Console.WriteLine("Jogador: " + numJogador);
                Console.WriteLine("Carta: " + cartasJogador[i, 1]);
                Console.WriteLine("startX: " + startX);
                Console.WriteLine("startY: " + startY);

                btns.Add(Int32.Parse(cartasJogador[i, 1]), btn);

                painelJogador.Controls.Add(btn);

                if (numJogador == 1 || numJogador == 2)
                {
                    startX += switchPosX;
                }
                if (numJogador == 3 || numJogador == 4)
                {
                    startY += switchPosY;
                }
            }
            if (numJogador == 1 || numJogador == 2)
            {
                startX -= switchPosX * qtdCartas / 2;
                startY += switchPosY;
            }
            if (numJogador == 3 || numJogador == 4)
            {
                startY -= switchPosY * qtdCartas / 2;
                startX += switchPosX;
            }
            for (int i = (qtdCartas / 2); i < qtdCartas; i++)
            {
                Button btn = new Button();
                btn.Text = cartasJogador[i, 2];
                btn.Size = new Size(sizeX, sizeY);
                btn.Location = new Point(startX, startY);
                btn.Click += new EventHandler(this.FazerUmaJogada);

                Console.WriteLine("Jogador: " + numJogador);
                Console.WriteLine("Carta: " + cartasJogador[i, 1]);
                Console.WriteLine("startX: " + startX);
                Console.WriteLine("startY: " + startY);

                btns.Add(Int32.Parse(cartasJogador[i, 1]), btn);

                painelJogador.Controls.Add(btn);

                if (numJogador == 1 || numJogador == 2)
                {
                    startX += switchPosX;
                }
                if (numJogador == 3 || numJogador == 4)
                {
                    startY += switchPosY;
                }
            }

        }

        private void DesenharCartas(int numJogador)
        {
            int startX = 0, startY = 0;
            int sizeX = 60, sizeY = 80;

            switch (numJogador)
            {
                case 1:
                    pnlJogador1.Controls.Clear();
                    startX = 2;
                    startY = 0;
                    CriarBotoes(1, startX, startY, sizeX, sizeY, cartasJogador1, btnsJogador1);
                    break;
                case 2:
                    pnlJogador2.Controls.Clear();
                    startX = 368;
                    startY = 80;
                    CriarBotoes(2, startX, startY, sizeX, sizeY, cartasJogador2, btnsJogador2);
                    break;
                case 3:
                    pnlJogador3.Controls.Clear();
                    startX = 80;
                    startY = 2;
                    CriarBotoes(3, startX, startY, sizeX, sizeY, cartasJogador3, btnsJogador3);
                    break;
                case 4:
                    pnlJogador4.Controls.Clear();
                    startX = 0;
                    startY = 368;
                    CriarBotoes(4, startX, startY, sizeX, sizeY, cartasJogador4, btnsJogador4);
                    break;
            }

        }
        
        public MesaDePartida()
        {

            InitializeComponent();

        }

        private void MesaDePartida_Load(object sender, EventArgs e)
        {

            AtualizarJogadores();

        }

        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {

            AtualizarJogadores();

            string retorno = Jogo.IniciarPartida(idJogador, senhaJogador);

            if (retorno.Substring(0, 1) == "E")
            {
                MessageBox.Show(retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Partida iniciada com sucesso", "Partida Inicada", MessageBoxButtons.OK);
            }

            AtualizarVez();

            int qtdJogadores = SepararJogadores().Length;
            
            if (qtdJogadores == 2)
            {
                SepararCartas(1);
                SepararCartas(2);

                DesenharCartas(1);
                DesenharCartas(2);
            }
            if (qtdJogadores == 4)
            {
                SepararCartas(1);
                SepararCartas(2);
                SepararCartas(3);
                SepararCartas(4);

                DesenharCartas(1);
                DesenharCartas(2);
                DesenharCartas(3);
                DesenharCartas(4);
            }

            btnIniciarPartida.Visible = false;

            lblRodadas.Visible = true;
            lstRodadas.Visible = true;
        }


        private void FazerUmaJogada(object sender, EventArgs e) 
        {

            Button btn = sender as Button;
            Panel parentPanel = btn.Parent as Panel;
            string nomeLista = parentPanel.Name;

            switch (nomeLista) {

                case "pnlJogador1":
                    int cartaEscolhida = parentPanel.Controls.IndexOf(btn)+1;
                    Console.WriteLine(cartaEscolhida);
                   string retornoJogar =  Jogo.Jogar(idJogador, senhaJogador, cartaEscolhida);
                    if (retornoJogar.Substring(0, 1) == "E")
                    {
                        MessageBox.Show(retornoJogar, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(retornoJogar);
                        btn.Visible = false;
  
                    }

                    break;

                case "pnlJogador2":
                    break;

                case "pnlJogador3":
                    break;

                case "pnlJogador4":
                        break;


            }

        }

        private void btnApostar_Click(object sender, EventArgs e)
        {
            Jogo.Apostar(idJogador, senhaJogador, 0);
        }
    }

}
