using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BOTVaticano
{
    public partial class MesaDePartida : Form
    {
        public string idPartida { set; get; }
        public int idJogador { set; get; }

        public string senhaJogador {set; get;}
        public MesaDePartida()
        {

            InitializeComponent();



        }

        private void MesaDePartida_Load(object sender, EventArgs e)
        {

            int id = Int32.Parse(idPartida);
            string listaJogadores = Jogo.ListarJogadores(id);
            listaJogadores = listaJogadores.Replace("\r", "");
            string[] jogadores = listaJogadores.Split('\n');
            lslJogadores.Items.Clear();
            for (int i = 0; i < jogadores.Length-1; i++)
            {
                lslJogadores.Items.Add(jogadores[i]);
            }
            string[] jogador = jogadores[0].Split(',');

            Console.WriteLine(idJogador);
            Console.WriteLine(senhaJogador);





        }

        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(idPartida);
            string listaJogadores = Jogo.ListarJogadores(id);
            listaJogadores = listaJogadores.Replace("\r", "");
            string[] jogadores = listaJogadores.Split('\n');

            lslJogadores.Items.Clear();
            for (int i = 0; i < jogadores.Length; i++)
            {
                lslJogadores.Items.Add(jogadores[i]);
            }


            string inicarPartida = Jogo.IniciarPartida(idJogador, senhaJogador);

            string[] retorno = inicarPartida.Split(':');
            string erro = retorno[0];

            if (inicarPartida.Substring(0, erro.Length) == "ERRO")
            {
                MessageBox.Show(inicarPartida, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                MessageBox.Show("Partida iniciada com sucesso", "Partida Inicada", MessageBoxButtons.OK);

            }

            string vez = Jogo.VerificarVez(Int32.Parse(idPartida));
            string[] informacaoJogador =  vez.Split(',');
            int enderecoJogador =Int32.Parse( informacaoJogador[1]);



            foreach ( var i  in lslJogadores.Items) {

                string [] jogador =   i.ToString().Split(',');
                Console.WriteLine(i);
                Console.WriteLine("desgraça");
                 
                
                if (Int32.Parse( jogador[0]) == enderecoJogador) { 
                   lblVez.Text = jogador[1];
                    lblIdDaVez.Text = jogador[0];
                    break;
                }





            }





           


            


           


        }

       
    }
}
