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
    public partial class MesaDePartida : Form
    {
        public string idPartida { set; get; }
        public MesaDePartida()
        {

            InitializeComponent();


            
        }

        private void MesaDePartida_Load(object sender, EventArgs e)
        {    

            int id = Int32.Parse(idPartida);
            string listaJogadores = Jogo.ListarJogadores(id);
            Console.WriteLine(listaJogadores);
        }
    }
}
