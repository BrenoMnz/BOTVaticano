using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string resposta = Jogo.CriarPartida(nome, senha, "Vaticano");

            if (resposta.Substring(0, 1) == "E")
            {
                MessageBox.Show(resposta, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Partida criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();

            Menu menu = new Menu();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
