﻿using System;
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
    public partial class MenuPartidas : Form
    {
        public MenuPartidas()
        {
            InitializeComponent();

            cboTipoPartida.Items.Add("Abertas");
            cboTipoPartida.Items.Add("Finalizadas");
            cboTipoPartida.Items.Add("Jogando");
            cboTipoPartida.Items.Add("Todas");
            cboTipoPartida.SelectedIndex = 0;
            lstPartidas.SelectedIndex = 0;
      
           
            this.Controls.Add(cboTipoPartida);




        }

       

        private void cboTipoPartida_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoPartida = cboTipoPartida.SelectedItem.ToString();
            string retorno;
            string[] partidas;


            switch (tipoPartida)

            {
                case "Todas":
                    lstPartidas.Items.Clear();
                    retorno = Jogo.ListarPartidas("T");
                    retorno = retorno.Replace("\r", "");
                    retorno = retorno.Substring(0, retorno.Length-1);
                    partidas = retorno.Split('\n');




                    foreach (var partida in partidas)
                    {
                        lstPartidas.Items.Add(partida);

                    }
                    break;

                case "Abertas":
                    lstPartidas.Items.Clear();
                    retorno = Jogo.ListarPartidas("A");

                    retorno = retorno.Replace("\r", "");
                    retorno = retorno.Substring(0, retorno.Length-1);
                    partidas = retorno.Split('\n');
                    foreach (var partida in partidas)
                    {
                        lstPartidas.Items.Add(partida);
                    }
                    break;


                case "Jogando":
                    lstPartidas.Items.Clear();
                    retorno = Jogo.ListarPartidas("J");

                    retorno = retorno.Replace("\r", "");
                    retorno = retorno.Substring(0, retorno.Length-1);
                    partidas = retorno.Split('\n');
                    foreach (var partida in partidas)
                    {
                        lstPartidas.Items.Add(partida);
                    }
                    break;

                case "Finalizadas":
                    lstPartidas.Items.Clear();
                    retorno = Jogo.ListarPartidas("F");
                    retorno += Jogo.ListarPartidas("E");

                    retorno = retorno.Replace("\r", "");
                    retorno = retorno.Substring(0, retorno.Length-1);
                    partidas = retorno.Split('\n');
                    foreach (var partida in partidas)
                    {
                        lstPartidas.Items.Add(partida);
                    }
                    break;

            }
            lstPartidas.SelectedIndex = 0;
        }

        private void lstPartidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string partidaSelecionada;
            partidaSelecionada = lstPartidas.SelectedItem.ToString();
            string[] dadosPartida = partidaSelecionada.Split(',');

            int idPartida = Convert.ToInt32(dadosPartida[0]);
            string nomePartida = dadosPartida[1];
            string data = dadosPartida[2];
            string status = dadosPartida[3];
            status = status.Replace("A", "Aberta");
            status = status.Replace("J", "Jogando");
            status = status.Replace("F", "Finalizada");
            status = status.Replace("E", "Empate");

            txtIdpartida.Text = idPartida.ToString();
            txtStatus.Text = status.ToString();


            string retorno = Jogo.ListarJogadores(idPartida);
            retorno = retorno.Replace("\r", "");
            string[] jogadores = retorno.Split('\n');
            lstJogadores.Items.Clear();
            for (int i = 0; i < jogadores.Length; i++) {
                lstJogadores.Items.Add(jogadores[i]);
            }

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.StartPosition = FormStartPosition.CenterParent;
            menu.Show();
            this.Hide();
        }
    }


}

