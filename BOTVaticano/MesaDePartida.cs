using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BOTVaticano
{
    public partial class MesaDePartida : Form
    {
        private int tempo;
        private int tempoSecreto;

        private int qtdJogadores = 0;

        private Control controleMarcado;
        private bool isCliqueProgramado = false;

        private string naipeDaRodada = "";
        private bool ehPrimeiroJogador = false;  
        private bool temNaipe = false;
        private int cartaJogada = -1;

        private IDictionary<int, Button> btnsJogador1 = new Dictionary<int, Button>();
        private IDictionary<int, Button> btnsJogador2 = new Dictionary<int, Button>();
        private IDictionary<int, Button> btnsJogador3 = new Dictionary<int, Button>();
        private IDictionary<int, Button> btnsJogador4 = new Dictionary<int, Button>();

        public bool[] cartasJogadas1 = { true, true, true, true, true, true, true, true, true, true, true, true, true, true };
        public bool[] cartasJogadas2 = { true, true, true, true, true, true, true, true, true, true, true, true, true, true };
        public bool[] cartasJogadas3 = { true, true, true, true, true, true, true, true, true, true, true, true, true, true };
        public bool[] cartasJogadas4 = { true, true, true, true, true, true, true, true, true, true, true, true, true, true };

        //NOVO CÓDIGO AQUI
        private string idPartida;
        private int idJogador1;
        private string senhaJogador;

        private bool ehVezJogador1;

        List<Jogador> listaJogadores;
        Partida partida;
        public string IdPartida { set; get; }
        public int IdJogador1 { set; get; }
        public string SenhaJogador { set; get; }

        public MesaDePartida(string idPartida, int idJogador1, string senhaJogador)
        {
            IdPartida = idPartida;
            IdJogador1 = idJogador1;
            SenhaJogador = senhaJogador;

            ehVezJogador1 = false;

            listaJogadores = new List<Jogador>();
            partida = new Partida(Int32.Parse(IdPartida));

            InitializeComponent();
        }

        private string[] SepararJogadores() //OK
        {
            string listaJogadores = Jogo.ListarJogadores(Int32.Parse(IdPartida));
            listaJogadores = listaJogadores.Replace("\r", "");
            listaJogadores = listaJogadores.Substring(0, listaJogadores.Length - 1);
            string[] jogadores = listaJogadores.Split('\n');
            partida.QtdJogadores = jogadores.Length;
            return jogadores;
        }

        private bool checaJogadorExiste (List<Jogador> jogadores, Jogador jogador)
        {
            bool existe = false;
            foreach (Jogador j in listaJogadores)
            {
                if (j.IdJogador == jogador.IdJogador)
                {
                    existe = true;
                }
            }
            return existe;
        }//OK

        private void DefinirJogadores() //OK
        {
            Console.WriteLine($"IdJogador1: {IdJogador1} SenhaJogador: {SenhaJogador}");
            int indexJogador1 = -1;
            string[] jogadores = SepararJogadores();

            for (int i = 0; i < partida.QtdJogadores; i++)
            {
                int id = Int32.Parse(jogadores[i].Split(',')[0]);
                string nome = jogadores[i].Split(',')[1];
                Jogador jogador = new Jogador(id, nome, SenhaJogador);
                if (!checaJogadorExiste(listaJogadores, jogador))
                {
                    listaJogadores.Add(jogador);
                    break;
                }
            }

            foreach (Jogador jogador in listaJogadores)
            {
                if (jogador.IdJogador == IdJogador1)
                {
                    indexJogador1 = listaJogadores.IndexOf(jogador);
                    jogador.PosicaoJogadorNaMesa = 0;

                    if (indexJogador1 != 0)
                    {
                        Jogador aux = listaJogadores[0];
                        listaJogadores[0] = jogador;
                        listaJogadores[indexJogador1] = aux;
                    }
                    break;
                }
            }

            for (int i = 0; i < listaJogadores.Count; i++)
            {
                listaJogadores[i].PosicaoJogadorNaMesa = i;
            }

        }

        private void AtualizarJogadores() //OK
        {
            foreach (Jogador jogador in listaJogadores)
            {
                Console.WriteLine($"{jogador.IdJogador} {jogador.NomeJogador} {jogador.PosicaoJogadorNaMesa} {jogador.PontosJogador}");
            }
            List<Label> labelsJogadores = new List<Label> { lblJogador1, lblJogador2, lblJogador3, lblJogador4 };
            List<Label> labelsIDJogadores = new List<Label> { lblIDJogador1, lblIDJogador2, lblIDJogador3, lblIDJogador4 };

            lvwJogadores.Items.Clear();

            for (int i = 0; i < labelsJogadores.Count(); i++)
            {
                if (i < listaJogadores.Count())
                {
                    labelsIDJogadores[listaJogadores[i].PosicaoJogadorNaMesa].Text = (listaJogadores[i].IdJogador).ToString();
                    labelsIDJogadores[listaJogadores[i].PosicaoJogadorNaMesa].Visible = true;

                    labelsJogadores[listaJogadores[i].PosicaoJogadorNaMesa].Text = listaJogadores[i].NomeJogador;
                    labelsJogadores[listaJogadores[i].PosicaoJogadorNaMesa].Visible = true;

                    ListViewItem itemJogador = new ListViewItem(listaJogadores[i].NomeJogador);
                    itemJogador.SubItems.Add(listaJogadores[i].PontosJogador);

                    lvwJogadores.Items.Add(itemJogador);
                }
            }

        }

        private void AtualizarDadosDaMesa() //OK
        {
            ehVezJogador1 = false;

            partida.AtualizarVez();

            lblStatus.Text = partida.Acao;

            foreach (Jogador jogador in listaJogadores)
            {
                if (partida.IdJogadorDaVez == jogador.IdJogador)
                {
                    lblVezJogador.Text = jogador.NomeJogador;
                    
                    if (jogador.PosicaoJogadorNaMesa == 0)
                    {
                        ehVezJogador1 = true;
                    }
                }
            }

            lstJogadas.Items.Clear();
            foreach (string info in partida.Vez)
            {
                lstJogadas.Items.Add(info);
            }

            const int PRIMEIRAJOGADA = 3;

            if ((partida.Vez).Length <= PRIMEIRAJOGADA)
            {
                partida.AtualizarPrimeiraJogada();
            }
        }

        private void SepararCartas()
        {

            int qtdCartas = partida.QtdCartas;

            string listaCartas = Jogo.ConsultarMao(Int32.Parse(idPartida));
            listaCartas = listaCartas.Replace("\r", "");
            string[] cartas = listaCartas.Split('\n');

            for (int i = 0; i < qtdCartas * qtdJogadores; i++)
            {
                string[] carta = cartas[i].Split(',');

                foreach (Jogador jogador in listaJogadores)
                {
                    if (carta[0] == jogador.IdJogador.ToString())
                    {
                        Carta cartaJogador = new Carta(
                            idJogador: Int32.Parse(carta[0]), 
                            naipe: Char.Parse(carta[1]), 
                            idCarta: Int32.Parse(carta[2]));

                        jogador.Cartas[i % qtdCartas] = cartaJogador;
                    }
                }

            }

        }

        private void CriarBotoes(Jogador jogador, int startX, int startY, int sizeX, int sizeY)
        {
            //Essa função existe pq provavelmente vai ser substituída por outra depois que começarmos a usar imagens
            int switchPosX = 0, switchPosY = 0;

            List<Panel> paineis = new List<Panel> { pnlJogador1, pnlJogador2, pnlJogador3, pnlJogador4 };
            paineis[0].Visible = true;
            Panel painelJogador = null;

            int aux;
            int numJogador = jogador.PosicaoJogadorNaMesa + 1;
            int qtdCartas = partida.QtdCartas;

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

                ImgCarta newImgCarta = new ImgCarta(jogador.Cartas[i]);
                Image imgCarta = newImgCarta.GraphCarta();

                if (numJogador == 1)
                {
                    
                    btn.BackgroundImage = imgCarta;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;

                    //btn.Click += new EventHandler(BotaoSelecionado);
                    //btn.Enter += new EventHandler(MarcarImagem);
                    //btn.Leave += new EventHandler(DesmarcarImagem);

                }
                if (numJogador == 2)
                {
                    imgCarta.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    btn.BackgroundImage = imgCarta;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (numJogador == 3)
                {
                    imgCarta.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    btn.BackgroundImage = imgCarta;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (numJogador == 4)
                {
                    imgCarta.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    btn.BackgroundImage = imgCarta;
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

                ImgCarta newImgCarta = new ImgCarta(jogador.Cartas[i]);
                Image imgCarta = newImgCarta.GraphCarta();

                if (numJogador == 1)
                {

                    btn.BackgroundImage = imgCarta;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;

                    //btn.Click += new EventHandler(BotaoSelecionado);
                    //btn.Enter += new EventHandler(MarcarImagem);
                    //btn.Leave += new EventHandler(DesmarcarImagem);

                }
                if (numJogador == 2)
                {
                    imgCarta.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    btn.BackgroundImage = imgCarta;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (numJogador == 3)
                {
                    imgCarta.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    btn.BackgroundImage = imgCarta;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (numJogador == 4)
                {
                    imgCarta.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    btn.BackgroundImage = imgCarta;
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

        }//OK

        //private void DesenharCartas(int idJogador)
        //{

        //    int startX, startY;
        //    int sizeX = 60, sizeY = 80;
        //    int numJogador = -1;

        //    if (idJogador == idJogador1)
        //    {
        //        numJogador = 1;
        //    }
        //    if (idJogador == idJogador2)
        //    {
        //        numJogador = 2;
        //    }
        //    if (idJogador == idJogador3)
        //    {
        //        numJogador = 3;
        //    }
        //    if (idJogador == idJogador4)
        //    {
        //        numJogador = 4;
        //    }

        //    switch (numJogador)
        //    {
        //        case 1:
        //            pnlJogador1.Controls.Clear();
        //            startX = 2;
        //            startY = 0;
        //            CriarBotoes(1, startX, startY, sizeX, sizeY, cartasJogador1);
        //            break;
        //        case 2:
        //            pnlJogador2.Controls.Clear();
        //            startX = 368;
        //            startY = 80;
        //            CriarBotoes(2, startX, startY, sizeX, sizeY, cartasJogador2);
        //            break;
        //        case 3:
        //            pnlJogador3.Controls.Clear();
        //            startX = 80;
        //            startY = 2;
        //            CriarBotoes(3, startX, startY, sizeX, sizeY, cartasJogador3);
        //            break;
        //        case 4:
        //            pnlJogador4.Controls.Clear();
        //            startX = 0;
        //            startY = 368;
        //            CriarBotoes(4, startX, startY, sizeX, sizeY, cartasJogador4);
        //            break;
        //    }

        //}

        //private void BotaoSelecionado(object sender, EventArgs e)
        //{
        //    if (isCliqueProgramado)
        //    {
        //        controleMarcado = (Control)sender;
        //    }
        //}

        //private void SimularClique(Button btn)
        //{
        //    isCliqueProgramado = true;
        //    btn.PerformClick();
        //    btn.Focus();
        //}

        //private void MarcarImagem(object sender, EventArgs e)
        //{
        //    if (isCliqueProgramado)
        //    {
        //        Button btn = sender as Button;
        //        Panel parentPanel = btn.Parent as Panel;
        //        int cartaEscolhida = parentPanel.Controls.IndexOf(btn);

        //        string caminho = null;

        //        if (cartasJogador1[cartaEscolhida, 2] == "C")
        //        {
        //            caminho = "Cartas/Copas2.png";
        //        }
        //        if (cartasJogador1[cartaEscolhida, 2] == "O")
        //        {
        //            caminho = "Cartas/Ouros2.png";
        //        }
        //        if (cartasJogador1[cartaEscolhida, 2] == "S")
        //        {
        //            caminho = "Cartas/Estrela2.png";
        //        }
        //        if (cartasJogador1[cartaEscolhida, 2] == "E")
        //        {
        //            caminho = "Cartas/Espadas2.png";
        //        }
        //        if (cartasJogador1[cartaEscolhida, 2] == "L")
        //        {
        //            caminho = "Cartas/Lua2.png";
        //        }
        //        if (cartasJogador1[cartaEscolhida, 2] == "P")
        //        {
        //            caminho = "Cartas/Paus2.png";
        //        }
        //        if (cartasJogador1[cartaEscolhida, 2] == "T")
        //        {
        //            caminho = "Cartas/Triangulo2.png";
        //        }

        //        btn.BackgroundImage = Image.FromFile(caminho);
        //        btn.BackgroundImageLayout = ImageLayout.Stretch;
        //    }
        //}

        //private void DesmarcarImagem(object sender, EventArgs e)
        //{
        //    if (isCliqueProgramado)
        //    {
        //        Button btn = sender as Button;
        //        Panel parentPanel = btn.Parent as Panel;
        //        int cartaEscolhida = parentPanel.Controls.IndexOf(btn);

        //        string caminho = null;

        //        if (cartasJogador1[cartaEscolhida, 2] == "C")
        //        {
        //            caminho = "Cartas/Copas1.png";
        //        }
        //        if (cartasJogador1[cartaEscolhida, 2] == "O")
        //        {
        //            caminho = "Cartas/Ouros1.png";
        //        }
        //        if (cartasJogador1[cartaEscolhida, 2] == "S")
        //        {
        //            caminho = "Cartas/Estrela1.png";
        //        }
        //        if (cartasJogador1[cartaEscolhida, 2] == "E")
        //        {
        //            caminho = "Cartas/Espadas1.png";
        //        }
        //        if (cartasJogador1[cartaEscolhida, 2] == "L")
        //        {
        //            caminho = "Cartas/Lua1.png";
        //        }
        //        if (cartasJogador1[cartaEscolhida, 2] == "P")
        //        {
        //            caminho = "Cartas/Paus1.png";
        //        }
        //        if (cartasJogador1[cartaEscolhida, 2] == "T")
        //        {
        //            caminho = "Cartas/Triangulo1.png";
        //        }

        //        btn.BackgroundImage = Image.FromFile(caminho);
        //        btn.BackgroundImageLayout = ImageLayout.Stretch;
        //    }
        //}

        //private void AtualizarCartaDaMao(int idJogador)
        //{

        //    string retornoConsultarmao = Jogo.ConsultarMao(Int32.Parse(idPartida));
        //    retornoConsultarmao = retornoConsultarmao.Replace("\r", "");

        //    string[] cartas = retornoConsultarmao.Split('\n');

        //    List<bool[]> listaJogadas = new List<bool[]>{ cartasJogadas1, cartasJogadas2, cartasJogadas3, cartasJogadas4 };
        //    Panel painel = null;
        //    int numJogador = -1;

        //    if (idJogador == idJogador1)
        //    {
        //        painel = pnlJogador1;
        //        numJogador = 1;
        //    }
        //    if (idJogador == idJogador2)
        //    {
        //        painel = pnlJogador2;
        //        numJogador = 2;
        //    }
        //    if (idJogador == idJogador3)
        //    {
        //        painel = pnlJogador3;
        //        numJogador = 3;
        //    }
        //    if (idJogador == idJogador4)
        //    {
        //        painel = pnlJogador4;
        //        numJogador = 4;
        //    }

        //    for (int i = 0; i < 14; i++)
        //    {
        //        listaJogadas[numJogador - 1][i] = true;
        //    }

        //    for (int i = 0; i < cartas.Length; i++)
        //    {
        //        if (cartas[i].Split(',')[0] == idJogador.ToString())
        //        {
        //            listaJogadas[numJogador - 1][Int32.Parse(cartas[i].Split(',')[1]) - 1] = false;
        //        }
        //    }

        //    for (int i = 0; i < painel.Controls.Count; i++)
        //    {
        //        if (listaJogadas[numJogador - 1][i] == true)
        //        {
        //            painel.Controls[i].Visible = false;
        //        }
        //    }
        //}

        private void MesaDePartida_Load(object sender, EventArgs e)
        {
            DefinirJogadores();
            AtualizarJogadores();
            lblIDPartida.Text = IdPartida;
            lblDll.Text = "DLL: " + Jogo.Versao;
            lblStatus.Text = partida.Acao;
            tempo = 10;
            tempoSecreto = 3600;
            timer1.Start();

        }//OK

        //private void btnIniciarPartida_Click(object sender, EventArgs e)//COM ERRO
        //{
        //    DefinirJogadores(idJogador1);
        //    AtualizarJogadores();

        //    string retorno = Jogo.IniciarPartida(idJogador1, senhaJogador);

        //    if (retorno.Substring(0, 1) == "E")
        //    {
        //        MessageBox.Show(retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Partida iniciada com sucesso", "Partida Inicada", MessageBoxButtons.OK);
        //    }

        //    AtualizarVez();

        //    if (qtdJogadores == 2)
        //    {
        //        SepararCartas(idJogador1);
        //        SepararCartas(idJogador2);

        //        DesenharCartas(idJogador1);
        //        DesenharCartas(idJogador2);
        //    }
        //    if (qtdJogadores == 4)
        //    {
        //        SepararCartas(idJogador1);
        //        SepararCartas(idJogador2);
        //        SepararCartas(idJogador3);
        //        SepararCartas(idJogador4);

        //        DesenharCartas(idJogador1);
        //        DesenharCartas(idJogador2);
        //        DesenharCartas(idJogador3);
        //        DesenharCartas(idJogador4);
        //    }

        //    btnIniciarPartida.Visible = false;

        //    lblJogadas.Visible = true;
        //    lstJogadas.Visible = true;

        //    timer1.Start();
        //}

        //private void btnJogar_Click(object sender, EventArgs e)
        //{
        //    AtualizarVez();
        //    if (controleMarcado == null)
        //    {
        //        MessageBox.Show("Nenhum botão selecionado");
        //        return;

        //    }

        //    Panel parentPanel = controleMarcado.Parent as Panel;
        //    if (parentPanel.Name != "pnlJogador1")
        //    {
        //        MessageBox.Show("Controle selecionado não pertence ao jogador 1", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    int cartaEscolhida = parentPanel.Controls.IndexOf(controleMarcado) + 1;
        //    string retornoJogar = Jogo.Jogar(idJogador1, senhaJogador, cartaEscolhida);
        //    if (retornoJogar.Substring(0, 1) == "E")
        //    {
        //        MessageBox.Show(retornoJogar, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    else
        //    {
        //        AtualizarCartaDaMao(idJogador1);

        //    }

        //    AtualizarVez();
        //}

        //private void btnApostar_Click(object sender, EventArgs e)
        //{
        //    AtualizarVez();
        //    if (controleMarcado == null)
        //    {
        //        MessageBox.Show("Nenhum botão selecionado");
        //        return;

        //    }

        //    Panel parentPanel = controleMarcado.Parent as Panel;
        //    if (parentPanel.Name != "pnlJogador1")
        //    {
        //        MessageBox.Show("Controle selecionado não pertence ao jogador 1", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    int cartaEscolhida = parentPanel.Controls.IndexOf(controleMarcado) + 1;
        //    string retornoApostar = Jogo.Apostar(idJogador1, senhaJogador, cartaEscolhida);
        //    if (retornoApostar.Substring(0, 1) == "E")
        //    {
        //        MessageBox.Show(retornoApostar, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    else
        //    {
        //        AtualizarCartaDaMao(idJogador1);

        //    }

        //    AtualizarVez();
        //}

        //private void btnPular_Click(object sender, EventArgs e)
        //{
        //    string retornoApostar = Jogo.Apostar(idJogador1, senhaJogador, 0);
        //    if (retornoApostar.Substring(0, 1) == "E")
        //    {
        //        MessageBox.Show(retornoApostar, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    Jogo.Apostar(idJogador1, senhaJogador, 0);
        //    //MessageBox.Show("Pulou a aposta", "Aposta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    AtualizarVez();
        //}

        private async void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = tempoSecreto.ToString();
            tempoSecreto--;


            if (ehDivisivelPor3())
            {
                DefinirJogadores();
                AtualizarJogadores();
            }
            
            if (ehIgualAZero())
            {
                tempoSecreto = 3600;
            }
        }

        private bool ehDivisivelPor3()
        {
            return (tempoSecreto % 3) == 0;
        }//OK

        private bool ehIgualAZero()
        {
            return tempoSecreto == 0;
        }//OK
    }
}
