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

        private string idPartida;
        private int idJogador1;
        private string senhaJogador;

        private bool ehPrimeiroJogador;

        private bool partidaComecou;
        private int roundAtual;

        private int contAposta;
        Carta cartaSelecionada;

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

            ehPrimeiroJogador = false;

            partidaComecou = false;
            roundAtual = 1;

            contAposta = 0;

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

            if (partida.QtdJogadores == 2)
            {
                partida.QtdCartas = 12;
            }

            if (partida.QtdJogadores == 4)
            {
                partida.QtdCartas = 14;
            }

            return jogadores;
        }

        private bool checaJogadorExiste (List<Jogador> jogadores, Jogador jogador) //OK
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
        }

        private void DefinirJogadores() //OK
        {
            Console.WriteLine($"IdJogador1: {IdJogador1} SenhaJogador: {SenhaJogador}");
            int indexJogador1 = -1;
            string[] jogadores = SepararJogadores();

            for (int i = 0; i < partida.QtdJogadores; i++)
            {
                int id = Int32.Parse(jogadores[i].Split(',')[0]);
                string nome = jogadores[i].Split(',')[1];

                Jogador jogador;
                if (id == IdJogador1)
                {
                    jogador = new Bot(id, nome, SenhaJogador);
                }
                else
                {
                    jogador = new Jogador(id, nome, SenhaJogador);
                }

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
            string jogadores = Jogo.ListarJogadores2(Int32.Parse(IdPartida));
            jogadores = jogadores.Replace("\r", "");
            jogadores = jogadores.Substring(0, jogadores.Length - 1);
            string[] pontosJogadores = jogadores.Split('\n');

            foreach (Jogador jogador in listaJogadores)
            {
                Console.WriteLine($"{jogador.IdJogador} {jogador.NomeJogador} {jogador.PosicaoJogadorNaMesa} {jogador.PontosJogador}");
                Console.WriteLine($"Round: " + partida.Round);

                foreach (string info in pontosJogadores)
                {
                    string[] infoSeparada = info.Split(',');
                    if (jogador.IdJogador == Int32.Parse(infoSeparada[0]))
                    {
                        jogador.PontosJogador = infoSeparada[2];
                    }
                }
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

            partida.AtualizarVez();

            lblStatus.Text = partida.Acao;

            foreach (Jogador jogador in listaJogadores)
            {
                if (partida.IdJogadorDaVez == jogador.IdJogador)
                {
                    lblVezJogador.Text = jogador.NomeJogador;
                    
                }
            }

            lstJogadas.Items.Clear();
            foreach (string info in partida.Vez)
            {
                lstJogadas.Items.Add(info);
            }

            const int PRIMEIRAJOGADA = 6;

            if ((partida.Vez).Length <= PRIMEIRAJOGADA)
            {
                partida.AtualizarPrimeiraJogada();
            }
        }

        private void SepararCartas()//OK
        {

            int qtdCartas = partida.QtdCartas;

            string listaCartas = Jogo.ConsultarMao(Int32.Parse(IdPartida));
            listaCartas = listaCartas.Replace("\r", "");
            string[] cartas = listaCartas.Split('\n').Where(c => !string.IsNullOrEmpty(c)).ToArray();

            for (int i = 0; i < qtdCartas * partida.QtdJogadores; i++)
            {
                string[] carta = cartas[i].Split(',');

                foreach (Jogador jogador in listaJogadores)
                {
                    if (carta[0] == jogador.IdJogador.ToString())
                    {
                        Carta cartaJogador = new Carta(
                            idJogador: Int32.Parse(carta[0]), 
                            idCarta: Int32.Parse(carta[1]),
                            naipe: Char.Parse(carta[2]));

                        jogador.Cartas.Add(cartaJogador);
                    }
                }

            }

        }

        private void CriarBotoes(Jogador jogador, int startX, int startY, int sizeX, int sizeY)//OK SEM EVENTOS NOS BOTOES
        {

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

        }

        private void DesenharBotoes(Jogador jogador) //OK
        {

            int startX, startY;
            int sizeX = 60, sizeY = 80;

            switch (jogador.PosicaoJogadorNaMesa + 1)
            {
                case 1:
                    pnlJogador1.Controls.Clear();
                    startX = 2;
                    startY = 0;
                    CriarBotoes(listaJogadores[0], startX, startY, sizeX, sizeY);
                    break;
                case 2:
                    pnlJogador2.Controls.Clear();
                    startX = 368;
                    startY = 80;
                    CriarBotoes(listaJogadores[1], startX, startY, sizeX, sizeY);
                    break;
                case 3:
                    pnlJogador3.Controls.Clear();
                    startX = 80;
                    startY = 2;
                    CriarBotoes(listaJogadores[2], startX, startY, sizeX, sizeY);
                    break;
                case 4:
                    pnlJogador4.Controls.Clear();
                    startX = 0;
                    startY = 368;
                    CriarBotoes(listaJogadores[3], startX, startY, sizeX, sizeY);
                    break;
            }

        }

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

        private void AtualizarCartaDaMao()//OK
        {
            List<Panel> paineis = new List<Panel> { pnlJogador1, pnlJogador2, pnlJogador3, pnlJogador4 };

            string listaRodadas = Jogo.ExibirJogadas2(Int32.Parse(IdPartida), partida.Round);
            listaRodadas = listaRodadas.Replace("\r", "");
            string[] informacaoRodadas = listaRodadas.Split('\n').Where(c => !string.IsNullOrEmpty(c)).ToArray();

            if (informacaoRodadas.Length != 0)
            {
                foreach (Jogador jogador in listaJogadores)
                {
                    foreach (string info in informacaoRodadas)
                    {
                        string[] infoSeparada = info.Split(',');
                        if (Int32.Parse(infoSeparada[0]) == partida.Rodada)
                        {
                            if (Int32.Parse(infoSeparada[1]) == jogador.IdJogador)
                            {
                                jogador.Cartas[Int32.Parse(infoSeparada[4]) - 1].IdCarta = -1;
                                jogador.Cartas[Int32.Parse(infoSeparada[4]) - 1].Valor = Int32.Parse(infoSeparada[3]);

                                Panel painel = paineis[jogador.PosicaoJogadorNaMesa];
                                painel.Controls[Int32.Parse(infoSeparada[4]) - 1].Visible = false;
                            }
                        }
                    }

                    foreach (string info in partida.Vez)
                    {
                        if (contAposta != partida.QtdJogadores)
                        {
                            if (info[0] == 'A')
                            {
                                string aux = info;
                                aux = aux.Remove(0, 2);
                                string[] infoSeparadas = aux.Split(',');

                                if (Int32.Parse(infoSeparadas[0]) == jogador.IdJogador)
                                {
                                    jogador.Cartas[Int32.Parse(infoSeparadas[4]) - 1].IdCarta = -2;

                                    Panel painel = paineis[jogador.PosicaoJogadorNaMesa];
                                    painel.Controls[Int32.Parse(infoSeparadas[4]) - 1].Visible = false;
                                }

                                contAposta++;
                            }
                        }
                    }
                    if (contAposta < partida.QtdJogadores)
                    {
                        contAposta = 0; 
                    }
                }
            }


            //string retornoConsultarmao = Jogo.ConsultarMao(Int32.Parse(idPartida));
            //retornoConsultarmao = retornoConsultarmao.Replace("\r", "");

            //string[] cartas = retornoConsultarmao.Split('\n');

            //List<bool[]> listaJogadas = new List<bool[]> { cartasJogadas1, cartasJogadas2, cartasJogadas3, cartasJogadas4 };
            //Panel painel = null;
            //int numJogador = -1;

            //if (idJogador == idJogador1)
            //{
            //    painel = pnlJogador1;
            //    numJogador = 1;
            //}
            //if (idJogador == idJogador2)
            //{
            //    painel = pnlJogador2;
            //    numJogador = 2;
            //}
            //if (idJogador == idJogador3)
            //{
            //    painel = pnlJogador3;
            //    numJogador = 3;
            //}
            //if (idJogador == idJogador4)
            //{
            //    painel = pnlJogador4;
            //    numJogador = 4;
            //}

            //for (int i = 0; i < 14; i++)
            //{
            //    listaJogadas[numJogador - 1][i] = true;
            //}

            //for (int i = 0; i < cartas.Length; i++)
            //{
            //    if (cartas[i].Split(',')[0] == idJogador.ToString())
            //    {
            //        listaJogadas[numJogador - 1][Int32.Parse(cartas[i].Split(',')[1]) - 1] = false;
            //    }
            //}

            //for (int i = 0; i < painel.Controls.Count; i++)
            //{
            //    if (listaJogadas[numJogador - 1][i] == true)
            //    {
            //        painel.Controls[i].Visible = false;
            //    }
            //}
        }

        private void AtualizarCartaDaMesa() //MOSTRAR NA MESA
        {

        }

        private void MesaDePartida_Load(object sender, EventArgs e)//OK
        {
            DefinirJogadores();
            AtualizarJogadores();
            lblIDPartida.Text = IdPartida;
            lblDll.Text = "DLL: " + Jogo.Versao;
            lblStatus.Text = partida.Acao;
            tempo = 3;
            tempoSecreto = 3600;
            timer1.Start();

        }

        private void btnIniciarPartida_Click(object sender, EventArgs e)//OK
        {
            partidaComecou = true;

            DefinirJogadores();
            AtualizarJogadores();

            if (partida.Status.Length > 1)
            {
                string retorno = Jogo.IniciarPartida(IdJogador1, SenhaJogador);

                if (retorno.Substring(0, 1) == "E")
                {
                    MessageBox.Show(retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Partida iniciada com sucesso", "Partida Inicada", MessageBoxButtons.OK);
                }
            }

            AtualizarDadosDaMesa();

            SepararCartas();
            
            foreach (Jogador jogador in listaJogadores)
            {
               DesenharBotoes(jogador);
            }

            btnIniciarPartida.Visible = false;

            lblJogadas.Visible = true;
            lstJogadas.Visible = true;
        }

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
            Bot bot = null;

            tempoSecreto--;

            lblTimer.Text = tempo.ToString();

            if (ehDivisivelPor3())
            {
                if (!partidaComecou)
                {
                    DefinirJogadores();
                    AtualizarDadosDaMesa();
                }

                if (partida.Status.Length == 1)
                {
                    btnIniciarPartida.PerformClick();
                }

                AtualizarJogadores();

                if (partidaComecou)
                {
                    AtualizarDadosDaMesa();
                    partida.AtualizarRound();
                    AtualizarCartaDaMao();

                    bot = ((Bot)listaJogadores[0]);

                    if (bot.EhVezJogador1(partida))
                    {
                        tempo--;
                        lblTimer.Text = tempo.ToString();

                        if (cartaSelecionada == null)
                        {
                            if (partida.Acao == "Jogar")
                            {
                                cartaSelecionada = (bot.SelecionarCartaAleatoria(partida));
                            }

                            if (partida.Acao == "Apostar")
                            {
                                cartaSelecionada = (bot.DecidirAposta(partida));
                                if (cartaSelecionada == null)
                                {
                                    cartaSelecionada = new Carta(IdJogador1, ' ', 0);
                                }
                            }
                        }

                    }

                    if (roundAtual < partida.Round)
                    {
                        cartaSelecionada = null;
                        contAposta = 0;
                        roundAtual = partida.Round;

                        SepararCartas();

                        foreach (Jogador jogador in listaJogadores)
                        {
                            DesenharBotoes(jogador);
                        }
                    }
                }
            }
            
            if (ehIgualAZeroSecreto())
            {
                tempoSecreto = 3600;
            }

            if (ehIgualAZero())
            {

                if (roundAtual < partida.Round)
                {
                    cartaSelecionada = null;
                    contAposta = 0;
                    roundAtual = partida.Round;

                    SepararCartas();

                    foreach (Jogador jogador in listaJogadores)
                    {
                        DesenharBotoes(jogador);
                    }
                }

                if (((Bot)listaJogadores[0]).EhVezJogador1(partida))
                {
                    if (partida.Acao == "Jogar")
                    {
                        bot.JogarCarta(cartaSelecionada.IdCarta);
                        cartaSelecionada = null;
                    }

                    if (partida.Acao == "Apostar")
                    {
                        if (cartaSelecionada.IdCarta == 0)
                        {
                            Jogo.Apostar(IdJogador1, SenhaJogador, 0);
                            cartaSelecionada = null;
                        }
                        else
                        {
                            bot.Apostar(cartaSelecionada.IdCarta);
                            cartaSelecionada = null;
                        }
                    }
                }
                AtualizarDadosDaMesa();
                AtualizarCartaDaMao();
                tempo = 3;
            }
        }

        private bool ehDivisivelPor3()//OK
        {
            return (tempoSecreto % 3) == 0;
        }

        private bool ehIgualAZeroSecreto()//OK
        {
            return tempoSecreto == 0;
        }

        private bool ehIgualAZero()//OK
        {
            return tempo == 0;
        }

    }
}
