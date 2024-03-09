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

namespace BOTVaticano
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            lblVersao.Text = "Versão DLL: " + Jogo.Versao;
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            MenuPopupCriar menuPopupCriar = new MenuPopupCriar();
            menuPopupCriar.StartPosition = FormStartPosition.CenterParent;
            menuPopupCriar.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            MenuPartidas menuPartidas = new MenuPartidas();
            menuPartidas.StartPosition = FormStartPosition.CenterParent;
            menuPartidas.Show();
            this.Hide();
        }
    }
}
