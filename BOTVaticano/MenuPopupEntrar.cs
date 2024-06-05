using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BOTVaticano
{
    public partial class MenuPopupEntrar : Form
    {
        public string idPartida {set; get;}
        public string tipoPartida { get; set;}

        public MenuPopupEntrar()
        {
            InitializeComponent();
        }
        
        private void btnEntrarPartida_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(lblIdpartida.Text);
                       
            string nome = (txtNomeJogador.Text).Trim();
            nome = txtNomeJogador.Text;
            txtNomeJogador.Clear();

            string senha = (txtSenhaPartida.Text).Trim();
            senha = txtSenhaPartida.Text;
            txtSenhaPartida.Clear();

            string retorno = Jogo.EntrarPartida(id, nome, senha);
            



            if (retorno.Substring(0, 4)=="ERRO"){
                MessageBox.Show(retorno, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] jogador = retorno.Split(',');
            int idJogador = Int32.Parse(jogador[0]);
            string senhaJogador = jogador[1];


            MesaDePartida mesaPartida = new MesaDePartida(idPartida, idJogador, senhaJogador);
            mesaPartida.StartPosition = FormStartPosition.CenterParent;
            mesaPartida.Show();
            Close();
            

        }

        private void MenuPopupEntrar_Load(object sender, EventArgs e)
        {
           
            lblIdpartida.Text = idPartida;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPartidas menupartidas = new MenuPartidas();
            menupartidas.Show();
            Close();
        }
    }
}
