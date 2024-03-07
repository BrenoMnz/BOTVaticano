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
            if (nome == "" || senha == "")
            {
                MessageBox.Show("Preencha todos os campos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                //TRATAR ERRO DE NOME IGUAL AO CRIAR PARTIDA
                Jogo.CriarPartida(nome, senha, "Vaticano");
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
