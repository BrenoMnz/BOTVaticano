using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BOTVaticano
{
    public partial class MesaDePartida : Form
    {
        private int tempoSecreto;

        private string idPartida;
        private int idJogador1;
        private string senhaJogador;

        private bool ehPrimeiroJogador;

        private bool partidaComecou;
        private int rodadaAtual;
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
            rodadaAtual = 1;
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
            
            partida.AtualizarPrimeiraJogada();
        }

        private void SepararCartas()//OK
        {

            int qtdCartas = partida.QtdCartas;

            string listaCartas = Jogo.ConsultarMao(Int32.Parse(IdPartida));
            listaCartas = listaCartas.Replace("\r", "");
            string[] cartas = listaCartas.Split('\n').Where(c => !string.IsNullOrEmpty(c)).ToArray();

            foreach (Jogador jogador in listaJogadores)
            {
                jogador.Cartas.Clear();
            }

            foreach (string carta in cartas)
            {
                string[] cartaAtual = carta.Split(',');

                foreach (Jogador jogador in listaJogadores)
                {
                    if (cartaAtual[0] == jogador.IdJogador.ToString())
                    {
                        Carta cartaJogador = new Carta(
                            idJogador: Int32.Parse(cartaAtual[0]),
                            idCarta: Int32.Parse(cartaAtual[1]),
                            naipe: Char.Parse(cartaAtual[2]));

                        jogador.Cartas.Add(cartaJogador);
                    }
                }
            }

            if (cartas.Length < partida.QtdCartas * partida.QtdJogadores)
            {
                string cartasJogadas = Jogo.ExibirJogadas2(Int32.Parse(IdPartida), partida.Round);
                cartasJogadas = cartasJogadas.Replace("\r", "");
                string[] cartasJogadasSeparadas = cartasJogadas.Split('\n').Where(c => !string.IsNullOrEmpty(c)).ToArray();

                foreach (string cartaJogada in cartasJogadasSeparadas)
                {
                    string[] cartaJogadaSeparada = cartaJogada.Split(',');

                    foreach (Jogador jogador in listaJogadores)
                    {
                        if (Int32.Parse(cartaJogadaSeparada[1]) == jogador.IdJogador)
                        {
                            Carta cartaJogador = new Carta(
                                idJogador: Int32.Parse(cartaJogadaSeparada[1]),
                                idCarta: Int32.Parse(cartaJogadaSeparada[4]),
                                naipe: Char.Parse(cartaJogadaSeparada[2]));
                            cartaJogador.Valor = Int32.Parse(cartaJogadaSeparada[3]);

                            Carta cartaApostada = null;

                            jogador.Cartas.Add(cartaJogador);

                            foreach (string info in partida.Vez) {

                                if (info[0] == 'A')
                                {
                                    string aux = info;
                                    aux = aux.Remove(0, 2);
                                    string[] infoSeparadas = aux.Split(',');

                                    if (Int32.Parse(infoSeparadas[0]) == jogador.IdJogador)
                                    {
                                        cartaApostada = new Carta(
                                            idJogador: Int32.Parse(infoSeparadas[0]),
                                            idCarta: Int32.Parse(infoSeparadas[4]),
                                            naipe: Char.Parse(infoSeparadas[1]));
                                        cartaApostada.Valor = Int32.Parse(infoSeparadas[2]);
                                    }

                                    jogador.Cartas.Add(cartaApostada);
                                }
                            }

                            if (cartaApostada != null)
                            {
                                if (cartaApostada.IdCarta != jogador.Cartas.IndexOf(cartaApostada) + 1)
                                {
                                    Carta aux = null;

                                    for (int i = cartaApostada.IdCarta - 1; i < jogador.Cartas.Count; i++)
                                    {
                                        aux = jogador.Cartas[i];
                                        jogador.Cartas[i] = jogador.Cartas[partida.QtdCartas - 1];
                                        jogador.Cartas[partida.QtdCartas - 1] = aux;
                                    }
                                }
                            }

                            if (cartaJogador.IdCarta != jogador.Cartas.IndexOf(cartaJogador) + 1)
                            {
                                Carta aux = null;

                                for (int i = cartaJogador.IdCarta - 1; i < jogador.Cartas.Count; i++)
                                {
                                    aux = jogador.Cartas[i];
                                    jogador.Cartas[i] = jogador.Cartas[partida.QtdCartas - 1];
                                    jogador.Cartas[partida.QtdCartas - 1] = aux;
                                }
                            }
                        }
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

        private void AtualizarCartasDaMesa(Carta carta, int contador)
        {

            Button btn = new Button();
            ImgCarta imgCarta = new ImgCarta(carta);
            Image img = imgCarta.GraphCarta();
            btn.Size = new Size(60, 80);
            btn.BackgroundImage = img;
            btn.BackgroundImageLayout = ImageLayout.Stretch;
            btn.Font = new Font("Arial", 12, FontStyle.Bold);
            btn.ForeColor = Color.Black;
            btn.Text = carta.Valor.ToString();
            btn.Location = new Point(60 * contador, 0);

            panelJogadas.Controls.Add(btn);
            //string[] info2 = informacaoRodadas[informacaoRodadas.Length - 1].Split(',');
            //int sizeX = 60, sizeY = 80;
            //Button btn = new Button();
            //Carta cartaaux = new Carta(Int32.Parse(info2[1]), Char.Parse(info2[2]), Int32.Parse(info2[4]));
            //ImgCarta img = new ImgCarta(cartaaux);
            //Image imgCarta = img.GraphCarta();
            //btn.Size = new Size(sizeX, sizeY);
            //btn.BackgroundImage = imgCarta;
            //btn.BackgroundImageLayout = ImageLayout.Stretch;
            //btn.Font = new Font("Arial", 12, FontStyle.Bold);
            //btn.ForeColor = Color.Black;
            //btn.Name = info2[1] + info2[4];
            //btn.Text = info2[3];

            //if (panelJogadas.Controls.Count == 0)
            //{
            //    panelJogadas.Controls.Add(btn);
            //}
            //if (panelJogadas.Controls.Count > 0 && panelJogadas.Controls[panelJogadas.Controls.Count - 1].Name != btn.Name && panelJogadas.Controls.Count < partida.QtdJogadores)
            //{
            //    int posicaoX = panelJogadas.Controls[panelJogadas.Controls.Count - 1].Location.X;
            //    int posicaoY = panelJogadas.Controls[panelJogadas.Controls.Count - 1].Location.Y;
            //    posicaoX += sizeX;
            //    //posicaoY +=2* sizeY;
            //    panelJogadas.Controls.Add(btn);
            //    btn.Location = new Point(posicaoX, posicaoY);
            //}
        }
        private void AtualizarCartaDaMao()//OK
        {
            List<Panel> paineis = new List<Panel> { pnlJogador1, pnlJogador2, pnlJogador3, pnlJogador4 };

            string listaRodadas = Jogo.ExibirJogadas2(Int32.Parse(IdPartida), partida.Round);
            listaRodadas = listaRodadas.Replace("\r", "");
            string[] informacaoRodadas = listaRodadas.Split('\n').Where(c => !string.IsNullOrEmpty(c)).ToArray();

            if (informacaoRodadas.Length == 0)
            {
                panelJogadas.Controls.Clear();
            }

            if (informacaoRodadas.Length != 0)
            {
                foreach (Jogador jogador in listaJogadores)
                {
                    foreach (string info in informacaoRodadas)
                    {
                        string[] infoSeparada = info.Split(',');
                        if (Int32.Parse(infoSeparada[1]) == jogador.IdJogador)
                        {
                            int idCartaDoJogador = jogador.Cartas[Int32.Parse(infoSeparada[4]) - 1].IdCarta;

                            if (idCartaDoJogador != -1 || idCartaDoJogador != -2)
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
                        int contJogadas = 0;
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
                            if (info[0] == 'C')
                            {
                                string aux = info;
                                aux = aux.Remove(0, 2);
                                string[] infoSeparadas = aux.Split(',');

                                if (panelJogadas.Controls.Count < contJogadas + 1)
                                {
                                    Carta cartaJogada = new Carta(
                                        idJogador: Int32.Parse(infoSeparadas[0]),
                                        idCarta: Int32.Parse(infoSeparadas[3]),
                                        naipe: Char.Parse(infoSeparadas[1]));
                                    cartaJogada.Valor = Int32.Parse(infoSeparadas[2]);

                                    AtualizarCartasDaMesa(cartaJogada, contAposta);
                                }

                                contJogadas++;
                            }

                        }
                    }
                    if (contAposta <= partida.QtdJogadores)
                    {
                        contAposta = 0;
                    }
                }
            }

        }

        private void MesaDePartida_Load(object sender, EventArgs e)//OK
        {
            DefinirJogadores();
            AtualizarJogadores();
            lblIDPartida.Text = IdPartida;
            lblDll.Text = "DLL: " + Jogo.Versao;
            lblStatus.Text = partida.Acao;
            tempoSecreto = 3600;
            timer1.Start();

        }

        private void btnIniciarPartida_Click(object sender, EventArgs e)//OK
        {
            tempoSecreto = 3603;

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
        private async void timer1_Tick(object sender, EventArgs e)
        {
            Bot bot = null;

            tempoSecreto--;

            if (ehDivisivelPor2())
            {
                if (!partidaComecou)
                {
                    DefinirJogadores();
                    AtualizarDadosDaMesa();
                }
            }

            if (ehDivisivelPor4())
            {

                if (partida.Status.Length == 1)
                {
                    btnIniciarPartida.PerformClick();
                }

                AtualizarJogadores();

                if (partidaComecou)
                {

                    AtualizarDadosDaMesa();

                    if (partida.Status == "F" || partida.Status == "E")
                    {
                        timer1.Stop();

                        lblIDJogador1.Visible = false;
                        lblIDJogador2.Visible = false;
                        lblIDJogador3.Visible = false;
                        lblIDJogador4.Visible = false;

                        lblJogador1.Visible = false;
                        lblJogador2.Visible = false;
                        lblJogador3.Visible = false;
                        lblJogador4.Visible = false;

                        panelJogadas.Visible = false;

                        pnlJogador1.Visible = false;
                        pnlJogador2.Visible = false;
                        pnlJogador3.Visible = false;
                        pnlJogador4.Visible = false;

                        panel1.Visible = false;

                        lblPartidaFim.Visible = true;
                        txtVencedores.Visible = true;

                        List<string> listaVencedores = new List<string>();
                        string palavra = "";
                        if (partida.Status == "F")
                        {
                            palavra = "é o vencedor!";
                            string idVencedor = partida.Vez[0].Split(',')[1]; 
                            foreach (Jogador jogador in listaJogadores)
                            {
                                if (idVencedor == jogador.IdJogador.ToString())
                                {
                                    listaVencedores.Add(jogador.NomeJogador);
                                }
                            }
                        }
                        if (partida.Status == "E")
                        {
                            palavra = "empataram!";
                            string listaPontuacao = Jogo.ListarJogadores2(Int32.Parse(IdPartida));
                            listaPontuacao = listaPontuacao.Replace("\r", "");
                            string[] jogadores = listaPontuacao.Split('\n').Where(c => !string.IsNullOrEmpty(c)).ToArray();

                            int maiorPontuacao = -100;

                            foreach (string jogador in jogadores)
                            {
                               string[] info = jogador.Split(',');
                                if (Int32.Parse(info[2]) > maiorPontuacao)
                                {
                                    maiorPontuacao = Int32.Parse(info[2]);
                                }
                            }

                            foreach (string jogador in jogadores)
                            {
                                string[] info = jogador.Split(',');
                                if (Int32.Parse(info[2]) == maiorPontuacao)
                                {
                                    listaVencedores.Add(info[1]);
                                }
                            }
                        }

                        foreach (string jogador in listaVencedores)
                        {
                            foreach (Jogador j in listaJogadores)
                            {
                                if (j.IdJogador.ToString() == jogador)
                                {
                                    listaVencedores[listaVencedores.IndexOf(jogador)] = j.IdJogador.ToString();
                                }
                            }
                        }

                        foreach (string jogador in listaVencedores)
                        {
                            txtVencedores.Text += jogador + "\r\n";
                        }

                        txtVencedores.Text += palavra;

                    } else
                    {
                        partida.AtualizarRound();
                        AtualizarCartaDaMao();

                        bot = ((Bot)listaJogadores[0]);

                        if (bot.EhVezJogador1(partida))
                        {

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
                        
                        if (rodadaAtual < partida.Rodada)
                        {
                            panelJogadas.Controls.Clear();
                            rodadaAtual = partida.Rodada;
                        }

                        if (roundAtual < partida.Round)
                        {
                            cartaSelecionada = null;
                            contAposta = 0;
                            rodadaAtual = 1;
                            roundAtual = partida.Round;

                            SepararCartas();

                            foreach (Jogador jogador in listaJogadores)
                            {
                                DesenharBotoes(jogador);
                            }
                        }

                        if (((Bot)listaJogadores[0]).EhVezJogador1(partida))
                        {
                            if (cartaSelecionada != null)
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
                        }
                    }

                    
                }
            }
            
            if (ehIgualAZeroSecreto())
            {
                tempoSecreto = 3600;
            }
        }

        private bool ehDivisivelPor4()//OK
        {
            return (tempoSecreto % 4) == 0;
        }

        private bool ehIgualAZeroSecreto()//OK
        {
            return tempoSecreto == 0;
        }

        private bool ehDivisivelPor2()
        {
            return (tempoSecreto % 2) == 0;
        }
    }
}
