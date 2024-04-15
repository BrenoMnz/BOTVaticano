using MagicTrickServer;
using System;
using System.Windows.Forms;
using MagicTrickServer;

namespace BOTVaticano
{
    public partial class MenuPopupCriar : Form
    {
        public MenuPopupCriar()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string nome = (txtNome.Text).Trim();
            string senha = (txtSenha.Text).Trim();
            string resposta = "E";

            //REMOVER IF INTEIRO E O CONTEÚDO INTEIRO DO ELSE AO FAZER MERGE PRA UMA BRANCH NÃO TESTE
            if (nome == "whatsapp")
            {
                Random r = new Random();

                while (resposta.Substring(0, 1) == "E")
                {
                    int numeroPartida;
                    numeroPartida = r.Next(0, 1000);

                    resposta = Jogo.CriarPartida(nome + numeroPartida, senha, "Vaticano");

                }

                int partida = Int32.Parse(resposta);
                string[] jogador1 = null;

                for (int i = 1; i <= 4; i++)
                {
                    if (i == 1)
                    {
                        jogador1 = Jogo.EntrarPartida(partida, "Whats" + i, senha).Split(',');
                    }
                    else
                    {
                        string[] jogador = null;
                        jogador = Jogo.EntrarPartida(partida, "Whats" + i, senha).Split(',');
                        Console.WriteLine($"Whats{i} {jogador[0]} {jogador[1]}");
                    }
                }

                MesaDePartida mesaPartida = new MesaDePartida();
                mesaPartida.idJogador1 = Int32.Parse(jogador1[0]);
                mesaPartida.senhaJogador = jogador1[1];
                mesaPartida.idPartida = partida.ToString();
                mesaPartida.Show();

                DialogResult = DialogResult.No;
                Close();
                return;

            } else
            {
                resposta = Jogo.CriarPartida(nome, senha, "Vaticano");

            }

            if (resposta.Substring(0, 1) == "E")
            {
                MessageBox.Show(resposta, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Partida criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.Yes;
            Close();

            Menu menu = new Menu();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
