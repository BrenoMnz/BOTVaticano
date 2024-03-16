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
        public MenuPopupEntrar()
        {
            InitializeComponent();
        }
        
        private void btnEntrarPartida_Click(object sender, EventArgs e)
        {
            int id;
            id = Int32.Parse(lblIdpartida.Text);
            string nome = (txtNomeJogador.Text).Trim();
            nome = txtNomeJogador.Text;
            Console.WriteLine(nome);    
            string senha = (txtSenhaPartida.Text).Trim();
            senha = txtSenhaPartida.Text;
            Console.WriteLine(senha);
            id = Int32.Parse(lblIdpartida.Text);
            string retorno = Jogo.EntrarPartida(id, nome, senha);

            if (retorno.Substring(0, 4)=="ERRO"){
                MessageBox.Show(retorno, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Jogo.IniciarPartida(nome, senha);

            MesaDePartida mesaPartida = new MesaDePartida();
            mesaPartida.StartPosition = FormStartPosition.CenterParent;
            mesaPartida.idPartida = this.idPartida;
            mesaPartida.Show();
            
        }

        private void MenuPopupEntrar_Load(object sender, EventArgs e)
        {
    
            lblIdpartida.Text = idPartida;
        }
    }
}
