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
            cboGrupo.Items.Add("Andorra");
            cboGrupo.Items.Add("Amsterdã");
            cboGrupo.Items.Add("Atenas");
            cboGrupo.Items.Add("Berlim");
            cboGrupo.Items.Add("Berna");
            cboGrupo.Items.Add("Bratislava");
            cboGrupo.Items.Add("Bruxelas");
            cboGrupo.Items.Add("Budapeste");
            cboGrupo.Items.Add("Copenhage");
            cboGrupo.Items.Add("Helsinque");
            cboGrupo.Items.Add("Lisboa");
            cboGrupo.Items.Add("Luxemburgo");
            cboGrupo.Items.Add("Madri");
            cboGrupo.Items.Add("Praga");
            cboGrupo.Items.Add("Riga");
            cboGrupo.Items.Add("Tirana");
            cboGrupo.Items.Add("Varsóvia");
            cboGrupo.Items.Add("Vaticano");
            cboGrupo.Items.Add("Yerevan");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string nome = (txtNome.Text).Trim();
            string senha = (txtSenha.Text).Trim();
            string grupo = cboGrupo.SelectedItem.ToString();
            string resposta = Jogo.CriarPartida(nome, senha, grupo);

            if (resposta == "ERRO:Nome da partida está vazio")
            {
                MessageBox.Show("Insira um nome!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resposta == "ERRO:Nome da partida com mais que 20 caracteres")
            {
                MessageBox.Show("Insira um nome com 20 caracteres ou menos!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resposta == "ERRO:Senha com mais de 10 caracteres")
            {
                MessageBox.Show("Insira uma senha com 10 caracteres ou menos!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resposta == "ERRO:Grupo com mais de 50 caracteres")
            {
                MessageBox.Show("Insira um grupo com 50 caracteres ou menos!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Partida criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            //ENTRAR NA PARTIDA??

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }
    }
}
