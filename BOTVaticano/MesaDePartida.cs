using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BOTVaticano
{
    public partial class MesaDePartida : Form
    {
        private int tempo;
        public string idPartida { set; get; }
        public int idJogador1 { set; get; }
        public string senhaJogador { set; get; }

        private int idJogador2, idJogador3, idJogador4;

        private Control controleMarcado;

        private IDictionary<int, Button> btnsJogador1 = new Dictionary<int, Button>();
        private IDictionary<int, Button> btnsJogador2 = new Dictionary<int, Button>();
        private IDictionary<int, Button> btnsJogador3 = new Dictionary<int, Button>();
        private IDictionary<int, Button> btnsJogador4 = new Dictionary<int, Button>();

        /* Matriz bidimensional 14x3.
         * Cada linha representa uma carta do baralho
         * Cada coluna representa, respectivamente:
         * id do jogador, id da carta (sua posição), naipe
        */
        public string[,] cartasJogador1 = new string[14, 3];
        public string[,] cartasJogador2 = new string[14, 3];
        public string[,] cartasJogador3 = new string[14, 3];
        public string[,] cartasJogador4 = new string[14, 3];

        public bool[] cartasJogadas1 = { true, true, true, true, true, true, true, true, true, true, true, true, true, true };
        public bool[] cartasJogadas2 = { true, true, true, true, true, true, true, true, true, true, true, true, true, true };
        public bool[] cartasJogadas3 = { true, true, true, true, true, true, true, true, true, true, true, true, true, true };
        public bool[] cartasJogadas4 = { true, true, true, true, true, true, true, true, true, true, true, true, true, true };
        private string[] SepararJogadores()
        {
            int id = Int32.Parse(idPartida);
            string listaJogadores = Jogo.ListarJogadores(id);
            listaJogadores = listaJogadores.Replace("\r", "");
            listaJogadores = listaJogadores.Substring(0, listaJogadores.Length - 1);
            string[] jogadores = listaJogadores.Split('\n');
            return jogadores;
        }

        private void DefinirJogadores(int jogador1Id)
        {
            string[] jogadores = SepararJogadores();
            List<int> ordemJogadores = new List<int>();

            List<int> ids = new List<int>();
            for (int i = 0; i < jogadores.Length; i++)
            {
                ids.Add(Int32.Parse(jogadores[i].Split(',')[0]));
            }

            int indexJogador1 = ids.IndexOf(jogador1Id);

            for (int i = 1; i < ids.Count; i++)
            {
                int index = (indexJogador1 + i) % ids.Count;

                switch (i)
                {
                    case 1:
                        idJogador2 = ids[index];
                        break;
                    case 2:
                        idJogador3 = ids[index];
                        break;
                    case 3:
                        idJogador4 = ids[index];
                        break;
                }
            }

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
                    int idJogador = Int32.Parse(jogadores[i].Split(',')[0]);
                    int numJogador = -1;
                    string[] jogador;

                    if (idJogador == idJogador1)
                    {
                        numJogador = 1;
                    }
                    if (idJogador == idJogador2)
                    {
                        numJogador = 2;
                    }
                    if (idJogador == idJogador3)
                    {
                        numJogador = 3;
                    }
                    if (idJogador == idJogador4)
                    {
                        numJogador = 4;
                    }

                    jogador = jogadores[i].Split(',');

                    labelsIDJogadores[numJogador-1].Text = jogador[0];
                    labelsIDJogadores[numJogador - 1].Visible = true;
                    labelsJogadores[numJogador - 1].Text = jogador[1];
                    labelsJogadores[numJogador - 1].Visible = true;

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
            checarVez = checarVez.Replace("\r", "");
            string[] informacaoVez = checarVez.Split('\n');

            for (int i = 0; i < jogadores.Length; i++)
            {
                string[] jogador = jogadores[i].Split(',');
                if (jogador[0] == informacaoVez[0].Split(',')[1])
                {
                    lblVezJogador.Text = jogador[1];
                }
            }

            lstJogadas.Items.Clear();

            foreach (string info in informacaoVez)
            {
                lstJogadas.Items.Add(info);
            }
        }

        private void AtualizarJogadas()
        {
            string listaJogadas = Jogo.ExibirJogadas(Int32.Parse(idPartida));
            listaJogadas = listaJogadas.Replace("\r", "");
            string[] jogadas = listaJogadas.Split('\n');

            lstJogadas.Items.Clear();

            foreach (string jogada in jogadas)
            {
                lstJogadas.Items.Add(jogada);
            }
        }

        private void SepararCartas(int idJogador)
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

            string listaCartas = Jogo.ConsultarMao(Int32.Parse(idPartida));
            listaCartas = listaCartas.Replace("\r", "");
            string[] cartas = listaCartas.Split('\n');

            int numJogador = 0;
            if (idJogador == idJogador1)
            {
                numJogador = 1;
            }
            if (idJogador == idJogador2)
            {
                numJogador = 2;
            }
            if (idJogador == idJogador3)
            {
                numJogador = 3;
            }
            if (idJogador == idJogador4)
            {
                numJogador = 4;
            }

            for (int i = 0; i < qtdCartas * qtdJogadores; i++)
            {
                string[] carta = cartas[i].Split(',');

                if (carta[0] == idJogador.ToString())
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

        private void CriarBotoes(int numJogador, int startX, int startY, int sizeX, int sizeY, string[,] cartasJogador)
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
                btn.Text = "";
                btn.Size = new Size(sizeX, sizeY);
                btn.Location = new Point(startX, startY);
                if (numJogador != 1)
                {
                    btn.Enabled = false;
                }

                Image imagem = null;
                string caminho = null;
                if (cartasJogador[i, 2] == "C")
                {
                    caminho = "Cartas/Copas1.png";
                }
                if (cartasJogador[i, 2] == "O")
                {
                    caminho = "Cartas/Ouros1.png";
                }
                if (cartasJogador[i, 2] == "S")
                {
                    caminho = "Cartas/Estrela1.png";
                }
                if (cartasJogador[i, 2] == "E")
                {
                    caminho = "Cartas/Espadas1.png";
                }
                if (cartasJogador[i, 2] == "L")
                {
                    caminho = "Cartas/Lua1.png";
                }
                if (cartasJogador[i, 2] == "P")
                {
                    caminho = "Cartas/Paus1.png";
                }
                if (cartasJogador[i, 2] == "T")
                {
                    caminho = "Cartas/Triangulo1.png";
                }

                if (numJogador == 1)
                {
                    imagem = Image.FromFile(caminho);
                    btn.BackgroundImage = imagem;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;

                    btn.Click += new EventHandler(BotaoSelecionado);
                    btn.Enter += new EventHandler(MarcarImagem);
                    btn.Leave += new EventHandler(DesmarcarImagem);

                }
                if (numJogador == 2)
                {
                    imagem = Image.FromFile(caminho);
                    imagem.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    btn.BackgroundImage = imagem;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (numJogador == 3)
                {
                    imagem = Image.FromFile(caminho);
                    imagem.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    btn.BackgroundImage = imagem;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (numJogador == 4)
                {
                    imagem = Image.FromFile(caminho);
                    imagem.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    btn.BackgroundImage = imagem;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                }

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
                btn.Text = "";
                btn.Size = new Size(sizeX, sizeY);
                btn.Location = new Point(startX, startY);
                if (numJogador != 1)
                {
                    btn.Enabled = false;
                }

                Image imagem = null;
                string caminho = null;

                if (cartasJogador[i, 2] == "C")
                {
                    caminho = "Cartas/Copas1.png";
                }
                if (cartasJogador[i, 2] == "O")
                {
                    caminho = "Cartas/Ouros1.png";
                }
                if (cartasJogador[i, 2] == "S")
                {
                    caminho = "Cartas/Estrela1.png";
                }
                if (cartasJogador[i, 2] == "E")
                {
                    caminho = "Cartas/Espadas1.png";
                }
                if (cartasJogador[i, 2] == "L")
                {
                    caminho = "Cartas/Lua1.png";
                }
                if (cartasJogador[i, 2] == "P")
                {
                    caminho = "Cartas/Paus1.png";
                }
                if (cartasJogador[i, 2] == "T")
                {
                    caminho = "Cartas/Triangulo1.png";
                }

                if (numJogador == 1)
                {
                    imagem = Image.FromFile(caminho);
                    btn.BackgroundImage = imagem;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;

                    btn.Click += new EventHandler(BotaoSelecionado);
                    btn.Enter += new EventHandler(MarcarImagem);
                    btn.Leave += new EventHandler(DesmarcarImagem);

                }
                if (numJogador == 2)
                {
                    imagem = Image.FromFile(caminho);
                    imagem.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    btn.BackgroundImage = imagem;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (numJogador == 3)
                {
                    imagem = Image.FromFile(caminho);
                    imagem.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    btn.BackgroundImage = imagem;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (numJogador == 4)
                {
                    imagem = Image.FromFile(caminho);
                    imagem.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    btn.BackgroundImage = imagem;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                }

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

        private void DesenharCartas(int idJogador)
        {

            int startX, startY;
            int sizeX = 60, sizeY = 80;
            int numJogador = -1;

            if (idJogador == idJogador1)
            {
                numJogador = 1;
            }
            if (idJogador == idJogador2)
            {
                numJogador = 2;
            }
            if (idJogador == idJogador3)
            {
                numJogador = 3;
            }
            if (idJogador == idJogador4)
            {
                numJogador = 4;
            }

            switch (numJogador)
            {
                case 1:
                    pnlJogador1.Controls.Clear();
                    startX = 2;
                    startY = 0;
                    CriarBotoes(1, startX, startY, sizeX, sizeY, cartasJogador1);
                    break;
                case 2:
                    pnlJogador2.Controls.Clear();
                    startX = 368;
                    startY = 80;
                    CriarBotoes(2, startX, startY, sizeX, sizeY, cartasJogador2);
                    break;
                case 3:
                    pnlJogador3.Controls.Clear();
                    startX = 80;
                    startY = 2;
                    CriarBotoes(3, startX, startY, sizeX, sizeY, cartasJogador3);
                    break;
                case 4:
                    pnlJogador4.Controls.Clear();
                    startX = 0;
                    startY = 368;
                    CriarBotoes(4, startX, startY, sizeX, sizeY, cartasJogador4);
                    break;
            }

        }

        private void BotaoSelecionado(object sender, EventArgs e)
        {
            controleMarcado = (Control)sender;
        }

        private void MarcarImagem(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Panel parentPanel = btn.Parent as Panel;
            int cartaEscolhida = parentPanel.Controls.IndexOf(btn);

            string caminho = null;

            if (cartasJogador1[cartaEscolhida, 2] == "C")
            {
                caminho = "Cartas/Copas2.png";
            }
            if (cartasJogador1[cartaEscolhida, 2] == "O")
            {
                caminho = "Cartas/Ouros2.png";
            }
            if (cartasJogador1[cartaEscolhida, 2] == "S")
            {
                caminho = "Cartas/Estrela2.png";
            }
            if (cartasJogador1[cartaEscolhida, 2] == "E")
            {
                caminho = "Cartas/Espadas2.png";
            }
            if (cartasJogador1[cartaEscolhida, 2] == "L")
            {
                caminho = "Cartas/Lua2.png";
            }
            if (cartasJogador1[cartaEscolhida, 2] == "P")
            {
                caminho = "Cartas/Paus2.png";
            }
            if (cartasJogador1[cartaEscolhida, 2] == "T")
            {
                caminho = "Cartas/Triangulo2.png";
            }

            btn.BackgroundImage = Image.FromFile(caminho);
            btn.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void DesmarcarImagem(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Panel parentPanel = btn.Parent as Panel;
            int cartaEscolhida = parentPanel.Controls.IndexOf(btn);

            string caminho = null;

            if (cartasJogador1[cartaEscolhida, 2] == "C")
            {
                caminho = "Cartas/Copas1.png";
            }
            if (cartasJogador1[cartaEscolhida, 2] == "O")
            {
                caminho = "Cartas/Ouros1.png";
            }
            if (cartasJogador1[cartaEscolhida, 2] == "S")
            {
                caminho = "Cartas/Estrela1.png";
            }
            if (cartasJogador1[cartaEscolhida, 2] == "E")
            {
                caminho = "Cartas/Espadas1.png";
            }
            if (cartasJogador1[cartaEscolhida, 2] == "L")
            {
                caminho = "Cartas/Lua1.png";
            }
            if (cartasJogador1[cartaEscolhida, 2] == "P")
            {
                caminho = "Cartas/Paus1.png";
            }
            if (cartasJogador1[cartaEscolhida, 2] == "T")
            {
                caminho = "Cartas/Triangulo1.png";
            }

            btn.BackgroundImage = Image.FromFile(caminho);
            btn.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void AtualizarCartaDaMao(int idJogador)
        {

            string retornoConsultarmao = Jogo.ConsultarMao(Int32.Parse(idPartida));
            retornoConsultarmao = retornoConsultarmao.Replace("\r", "");

            string[] cartas = retornoConsultarmao.Split('\n');

            List<bool[]> listaJogadas = new List<bool[]>{ cartasJogadas1, cartasJogadas2, cartasJogadas3, cartasJogadas4 };
            Panel painel = null;
            int numJogador = -1;

            if (idJogador == idJogador1)
            {
                painel = pnlJogador1;
                numJogador = 1;
            }
            if (idJogador == idJogador2)
            {
                painel = pnlJogador2;
                numJogador = 2;
            }
            if (idJogador == idJogador3)
            {
                painel = pnlJogador3;
                numJogador = 3;
            }
            if (idJogador == idJogador4)
            {
                painel = pnlJogador4;
                numJogador = 4;
            }

            for (int i = 0; i < 14; i++)
            {
                listaJogadas[numJogador - 1][i] = true;
            }

            for (int i = 0; i < cartas.Length; i++)
            {
                if (cartas[i].Split(',')[0] == idJogador.ToString())
                {
                    listaJogadas[numJogador - 1][Int32.Parse(cartas[i].Split(',')[1]) - 1] = false;
                }
            }

            for (int i = 0; i < painel.Controls.Count; i++)
            {
                if (listaJogadas[numJogador - 1][i] == true)
                {
                    painel.Controls[i].Visible = false;
                }
            }
        }

        public MesaDePartida()
        {

            InitializeComponent();


        }

        private void MesaDePartida_Load(object sender, EventArgs e)
        {
            DefinirJogadores(idJogador1);
            AtualizarJogadores();
            lblIDPartida.Text = idPartida;
            tempo = 30;

        }

        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {
            DefinirJogadores(idJogador1);
            AtualizarJogadores();

            string retorno = Jogo.IniciarPartida(idJogador1, senhaJogador);

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
                SepararCartas(idJogador1);
                SepararCartas(idJogador2);

                DesenharCartas(idJogador1);
                DesenharCartas(idJogador2);
            }
            if (qtdJogadores == 4)
            {
                SepararCartas(idJogador1);
                SepararCartas(idJogador2);
                SepararCartas(idJogador3);
                SepararCartas(idJogador4);

                DesenharCartas(idJogador1);
                DesenharCartas(idJogador2);
                DesenharCartas(idJogador3);
                DesenharCartas(idJogador4);
            }

            btnIniciarPartida.Visible = false;

            lblJogadas.Visible = true;
            lstJogadas.Visible = true;

            timer1.Start();
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            //AtualizarJogadas();
            AtualizarVez();
            if (controleMarcado == null)
            {
                MessageBox.Show("Nenhum botão selecionado");
                return;

            }

            Panel parentPanel = controleMarcado.Parent as Panel;
            if (parentPanel.Name != "pnlJogador1")
            {
                MessageBox.Show("Controle selecionado não pertence ao jogador 1", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cartaEscolhida = parentPanel.Controls.IndexOf(controleMarcado) + 1;
            string retornoJogar = Jogo.Jogar(idJogador1, senhaJogador, cartaEscolhida);
            if (retornoJogar.Substring(0, 1) == "E")
            {
                MessageBox.Show(retornoJogar, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                AtualizarCartaDaMao(idJogador1);

            }

            //AtualizarJogadas();
            AtualizarVez();
        }

        private void btnApostar_Click(object sender, EventArgs e)
        {
            //AtualizarJogadas();
            AtualizarVez();
            if (controleMarcado == null)
            {
                MessageBox.Show("Nenhum botão selecionado");
                return;

            }

            Panel parentPanel = controleMarcado.Parent as Panel;
            if (parentPanel.Name != "pnlJogador1")
            {
                MessageBox.Show("Controle selecionado não pertence ao jogador 1", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cartaEscolhida = parentPanel.Controls.IndexOf(controleMarcado) + 1;
            string retornoApostar = Jogo.Apostar(idJogador1, senhaJogador, cartaEscolhida);
            if (retornoApostar.Substring(0, 1) == "E")
            {
                MessageBox.Show(retornoApostar, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                AtualizarCartaDaMao(idJogador1);

            }

            //AtualizarJogadas();
            AtualizarVez();
        }

        private void btnPular_Click(object sender, EventArgs e)
        {
            string retornoApostar = Jogo.Apostar(idJogador1, senhaJogador, 0);
            if (retornoApostar.Substring(0, 1) == "E")
            {
                MessageBox.Show(retornoApostar, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Jogo.Apostar(idJogador1, senhaJogador, 0);
            MessageBox.Show("Pulou a aposta", "Aposta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //AtualizarJogadas();
            AtualizarVez();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            lblTimer.Text = tempo.ToString();
            tempo--;

            if (Int32.Parse(lblTimer.Text) % 3 == 0)
            {
                AtualizarCartaDaMao(idJogador1);
                AtualizarCartaDaMao(idJogador2);
                AtualizarCartaDaMao(idJogador3);
                AtualizarCartaDaMao(idJogador4);
                AtualizarVez();
                //AtualizarJogadas();

            }
            if (Int32.Parse(lblTimer.Text) == 20)
            {
                tempo = 30;
            }

        }

    }
}
