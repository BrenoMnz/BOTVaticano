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
            string nome = (txtNomeJogador.Text).Trim();
            string senha = (txtSenhaPartida.Text).Trim();
            
        }

        private void MenuPopupEntrar_Load(object sender, EventArgs e)
        {
            txtIdPartida.Text = idPartida;
        }
    }
}
