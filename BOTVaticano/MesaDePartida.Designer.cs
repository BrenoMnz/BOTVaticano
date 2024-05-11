namespace BOTVaticano
{
    partial class MesaDePartida
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "Jogador 1",
            "42"}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "Jogador 2",
            "42"}, -1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "Jogador 3",
            "42"}, -1);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "Jogador 4",
            "42"}, -1);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDll = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIniciarPartida = new System.Windows.Forms.Button();
            this.lvwJogadores = new System.Windows.Forms.ListView();
            this.clhJogador = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhPontos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstJogadas = new System.Windows.Forms.ListBox();
            this.lblJogadas = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblVezJogador = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblJogador3 = new System.Windows.Forms.Label();
            this.pnlJogador1 = new System.Windows.Forms.Panel();
            this.lblJogador4 = new System.Windows.Forms.Label();
            this.pnlJogador4 = new System.Windows.Forms.Panel();
            this.lblJogador1 = new System.Windows.Forms.Label();
            this.lblJogador2 = new System.Windows.Forms.Label();
            this.lblIDJogador1 = new System.Windows.Forms.Label();
            this.lblIDJogador2 = new System.Windows.Forms.Label();
            this.lblIDJogador3 = new System.Windows.Forms.Label();
            this.lblIDJogador4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblIDPartida = new System.Windows.Forms.Label();
            this.pnlJogador2 = new System.Windows.Forms.Panel();
            this.pnlJogador3 = new System.Windows.Forms.Panel();
            this.btnApostar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnJogar = new System.Windows.Forms.Button();
            this.btnPular = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.lblDll);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnIniciarPartida);
            this.panel1.Controls.Add(this.lvwJogadores);
            this.panel1.Controls.Add(this.lstJogadas);
            this.panel1.Controls.Add(this.lblJogadas);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.lblTimer);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.lblVezJogador);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(1001, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 686);
            this.panel1.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(141, 68);
            this.lblStatus.MaximumSize = new System.Drawing.Size(100, 20);
            this.lblStatus.MinimumSize = new System.Drawing.Size(100, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 20);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDll
            // 
            this.lblDll.AutoSize = true;
            this.lblDll.Location = new System.Drawing.Point(84, 663);
            this.lblDll.MaximumSize = new System.Drawing.Size(100, 13);
            this.lblDll.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblDll.Name = "lblDll";
            this.lblDll.Size = new System.Drawing.Size(100, 13);
            this.lblDll.TabIndex = 11;
            this.lblDll.Text = "DLL";
            this.lblDll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 642);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Cidade do Vaticano";
            // 
            // btnIniciarPartida
            // 
            this.btnIniciarPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarPartida.Location = new System.Drawing.Point(61, 415);
            this.btnIniciarPartida.Name = "btnIniciarPartida";
            this.btnIniciarPartida.Size = new System.Drawing.Size(146, 50);
            this.btnIniciarPartida.TabIndex = 9;
            this.btnIniciarPartida.Text = "Iniciar partida";
            this.btnIniciarPartida.UseVisualStyleBackColor = true;
            //this.btnIniciarPartida.Click += new System.EventHandler(this.btnIniciarPartida_Click);
            // 
            // lvwJogadores
            // 
            this.lvwJogadores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhJogador,
            this.clhPontos});
            this.lvwJogadores.HideSelection = false;
            this.lvwJogadores.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8});
            this.lvwJogadores.Location = new System.Drawing.Point(12, 128);
            this.lvwJogadores.Name = "lvwJogadores";
            this.lvwJogadores.Scrollable = false;
            this.lvwJogadores.Size = new System.Drawing.Size(241, 100);
            this.lvwJogadores.TabIndex = 8;
            this.lvwJogadores.UseCompatibleStateImageBehavior = false;
            this.lvwJogadores.View = System.Windows.Forms.View.Details;
            // 
            // clhJogador
            // 
            this.clhJogador.Tag = "";
            this.clhJogador.Text = "Jogador";
            this.clhJogador.Width = 160;
            // 
            // clhPontos
            // 
            this.clhPontos.Text = "Pontuação";
            this.clhPontos.Width = 81;
            // 
            // lstJogadas
            // 
            this.lstJogadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstJogadas.FormattingEnabled = true;
            this.lstJogadas.Location = new System.Drawing.Point(12, 271);
            this.lstJogadas.Name = "lstJogadas";
            this.lstJogadas.Size = new System.Drawing.Size(241, 368);
            this.lstJogadas.TabIndex = 7;
            this.lstJogadas.Visible = false;
            // 
            // lblJogadas
            // 
            this.lblJogadas.AutoSize = true;
            this.lblJogadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJogadas.Location = new System.Drawing.Point(8, 242);
            this.lblJogadas.Name = "lblJogadas";
            this.lblJogadas.Size = new System.Drawing.Size(70, 20);
            this.lblJogadas.TabIndex = 6;
            this.lblJogadas.Text = "Jogadas";
            this.lblJogadas.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 93);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 20);
            this.label15.TabIndex = 4;
            this.label15.Text = "Jogadores";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.Red;
            this.lblTimer.Location = new System.Drawing.Point(58, 54);
            this.lblTimer.MaximumSize = new System.Drawing.Size(0, 20);
            this.lblTimer.MinimumSize = new System.Drawing.Size(0, 20);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(21, 20);
            this.lblTimer.TabIndex = 3;
            this.lblTimer.Text = "10";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(44, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 20);
            this.label13.TabIndex = 2;
            this.label13.Text = "Timer";
            // 
            // lblVezJogador
            // 
            this.lblVezJogador.AutoSize = true;
            this.lblVezJogador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVezJogador.Location = new System.Drawing.Point(142, 41);
            this.lblVezJogador.MaximumSize = new System.Drawing.Size(100, 20);
            this.lblVezJogador.MinimumSize = new System.Drawing.Size(100, 20);
            this.lblVezJogador.Name = "lblVezJogador";
            this.lblVezJogador.Size = new System.Drawing.Size(100, 20);
            this.lblVezJogador.TabIndex = 1;
            this.lblVezJogador.Text = "Jogador";
            this.lblVezJogador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(135, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Vez do jogador";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(417, 259);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 162);
            this.panel2.TabIndex = 4;
            // 
            // lblJogador3
            // 
            this.lblJogador3.AutoSize = true;
            this.lblJogador3.Location = new System.Drawing.Point(6, 303);
            this.lblJogador3.MaximumSize = new System.Drawing.Size(100, 39);
            this.lblJogador3.MinimumSize = new System.Drawing.Size(100, 39);
            this.lblJogador3.Name = "lblJogador3";
            this.lblJogador3.Size = new System.Drawing.Size(100, 39);
            this.lblJogador3.TabIndex = 5;
            this.lblJogador3.Text = "Jogador 3";
            this.lblJogador3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblJogador3.Visible = false;
            // 
            // pnlJogador1
            // 
            this.pnlJogador1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlJogador1.Location = new System.Drawing.Point(283, 443);
            this.pnlJogador1.Name = "pnlJogador1";
            this.pnlJogador1.Size = new System.Drawing.Size(432, 162);
            this.pnlJogador1.TabIndex = 6;
            this.pnlJogador1.Visible = false;
            // 
            // lblJogador4
            // 
            this.lblJogador4.AutoSize = true;
            this.lblJogador4.Location = new System.Drawing.Point(893, 303);
            this.lblJogador4.MaximumSize = new System.Drawing.Size(100, 39);
            this.lblJogador4.MinimumSize = new System.Drawing.Size(100, 39);
            this.lblJogador4.Name = "lblJogador4";
            this.lblJogador4.Size = new System.Drawing.Size(100, 39);
            this.lblJogador4.TabIndex = 8;
            this.lblJogador4.Text = "Jogador 4";
            this.lblJogador4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblJogador4.Visible = false;
            // 
            // pnlJogador4
            // 
            this.pnlJogador4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlJogador4.Location = new System.Drawing.Point(725, 123);
            this.pnlJogador4.Name = "pnlJogador4";
            this.pnlJogador4.Size = new System.Drawing.Size(162, 432);
            this.pnlJogador4.TabIndex = 8;
            this.pnlJogador4.Visible = false;
            // 
            // lblJogador1
            // 
            this.lblJogador1.AutoSize = true;
            this.lblJogador1.Location = new System.Drawing.Point(450, 608);
            this.lblJogador1.MaximumSize = new System.Drawing.Size(100, 39);
            this.lblJogador1.MinimumSize = new System.Drawing.Size(100, 39);
            this.lblJogador1.Name = "lblJogador1";
            this.lblJogador1.Size = new System.Drawing.Size(100, 39);
            this.lblJogador1.TabIndex = 9;
            this.lblJogador1.Text = "Jogador 1";
            this.lblJogador1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblJogador1.Visible = false;
            // 
            // lblJogador2
            // 
            this.lblJogador2.AutoSize = true;
            this.lblJogador2.Location = new System.Drawing.Point(450, 32);
            this.lblJogador2.MaximumSize = new System.Drawing.Size(100, 39);
            this.lblJogador2.MinimumSize = new System.Drawing.Size(100, 39);
            this.lblJogador2.Name = "lblJogador2";
            this.lblJogador2.Size = new System.Drawing.Size(100, 39);
            this.lblJogador2.TabIndex = 10;
            this.lblJogador2.Text = "Jogador 2";
            this.lblJogador2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblJogador2.Visible = false;
            // 
            // lblIDJogador1
            // 
            this.lblIDJogador1.AutoSize = true;
            this.lblIDJogador1.Location = new System.Drawing.Point(449, 659);
            this.lblIDJogador1.MaximumSize = new System.Drawing.Size(100, 0);
            this.lblIDJogador1.MinimumSize = new System.Drawing.Size(100, 0);
            this.lblIDJogador1.Name = "lblIDJogador1";
            this.lblIDJogador1.Size = new System.Drawing.Size(100, 13);
            this.lblIDJogador1.TabIndex = 11;
            this.lblIDJogador1.Text = "42";
            this.lblIDJogador1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIDJogador1.Visible = false;
            // 
            // lblIDJogador2
            // 
            this.lblIDJogador2.AutoSize = true;
            this.lblIDJogador2.Location = new System.Drawing.Point(449, 8);
            this.lblIDJogador2.MaximumSize = new System.Drawing.Size(100, 0);
            this.lblIDJogador2.MinimumSize = new System.Drawing.Size(100, 0);
            this.lblIDJogador2.Name = "lblIDJogador2";
            this.lblIDJogador2.Size = new System.Drawing.Size(100, 13);
            this.lblIDJogador2.TabIndex = 12;
            this.lblIDJogador2.Text = "42";
            this.lblIDJogador2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIDJogador2.Visible = false;
            // 
            // lblIDJogador3
            // 
            this.lblIDJogador3.AutoSize = true;
            this.lblIDJogador3.Location = new System.Drawing.Point(6, 354);
            this.lblIDJogador3.MaximumSize = new System.Drawing.Size(100, 0);
            this.lblIDJogador3.MinimumSize = new System.Drawing.Size(100, 0);
            this.lblIDJogador3.Name = "lblIDJogador3";
            this.lblIDJogador3.Size = new System.Drawing.Size(100, 13);
            this.lblIDJogador3.TabIndex = 13;
            this.lblIDJogador3.Text = "42";
            this.lblIDJogador3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIDJogador3.Visible = false;
            // 
            // lblIDJogador4
            // 
            this.lblIDJogador4.AutoSize = true;
            this.lblIDJogador4.Location = new System.Drawing.Point(893, 354);
            this.lblIDJogador4.MaximumSize = new System.Drawing.Size(100, 0);
            this.lblIDJogador4.MinimumSize = new System.Drawing.Size(100, 0);
            this.lblIDJogador4.Name = "lblIDJogador4";
            this.lblIDJogador4.Size = new System.Drawing.Size(100, 13);
            this.lblIDJogador4.TabIndex = 14;
            this.lblIDJogador4.Text = "42";
            this.lblIDJogador4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIDJogador4.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "ID da partida";
            // 
            // lblIDPartida
            // 
            this.lblIDPartida.AutoSize = true;
            this.lblIDPartida.Location = new System.Drawing.Point(-10, 32);
            this.lblIDPartida.MaximumSize = new System.Drawing.Size(100, 0);
            this.lblIDPartida.MinimumSize = new System.Drawing.Size(100, 0);
            this.lblIDPartida.Name = "lblIDPartida";
            this.lblIDPartida.Size = new System.Drawing.Size(100, 13);
            this.lblIDPartida.TabIndex = 16;
            this.lblIDPartida.Text = "42";
            this.lblIDPartida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlJogador2
            // 
            this.pnlJogador2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlJogador2.Location = new System.Drawing.Point(284, 74);
            this.pnlJogador2.Name = "pnlJogador2";
            this.pnlJogador2.Size = new System.Drawing.Size(432, 162);
            this.pnlJogador2.TabIndex = 14;
            this.pnlJogador2.Visible = false;
            // 
            // pnlJogador3
            // 
            this.pnlJogador3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlJogador3.Location = new System.Drawing.Point(112, 123);
            this.pnlJogador3.Name = "pnlJogador3";
            this.pnlJogador3.Size = new System.Drawing.Size(162, 432);
            this.pnlJogador3.TabIndex = 25;
            this.pnlJogador3.Visible = false;
            // 
            // btnApostar
            // 
            this.btnApostar.Location = new System.Drawing.Point(827, 608);
            this.btnApostar.Margin = new System.Windows.Forms.Padding(2);
            this.btnApostar.Name = "btnApostar";
            this.btnApostar.Size = new System.Drawing.Size(97, 36);
            this.btnApostar.TabIndex = 26;
            this.btnApostar.Text = "Apostar";
            this.btnApostar.UseVisualStyleBackColor = true;
            //this.btnApostar.Click += new System.EventHandler(this.btnApostar_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnJogar
            // 
            this.btnJogar.Location = new System.Drawing.Point(725, 608);
            this.btnJogar.Name = "btnJogar";
            this.btnJogar.Size = new System.Drawing.Size(97, 36);
            this.btnJogar.TabIndex = 27;
            this.btnJogar.Text = "Jogar";
            this.btnJogar.UseVisualStyleBackColor = true;
            //this.btnJogar.Click += new System.EventHandler(this.btnJogar_Click);
            // 
            // btnPular
            // 
            this.btnPular.Location = new System.Drawing.Point(786, 650);
            this.btnPular.Name = "btnPular";
            this.btnPular.Size = new System.Drawing.Size(75, 23);
            this.btnPular.TabIndex = 28;
            this.btnPular.Text = "Pular";
            this.btnPular.UseVisualStyleBackColor = true;
            //this.btnPular.Click += new System.EventHandler(this.btnPular_Click);
            // 
            // MesaDePartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnPular);
            this.Controls.Add(this.btnJogar);
            this.Controls.Add(this.btnApostar);
            this.Controls.Add(this.pnlJogador3);
            this.Controls.Add(this.pnlJogador2);
            this.Controls.Add(this.lblIDPartida);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblIDJogador4);
            this.Controls.Add(this.lblIDJogador3);
            this.Controls.Add(this.lblIDJogador2);
            this.Controls.Add(this.lblIDJogador1);
            this.Controls.Add(this.lblJogador2);
            this.Controls.Add(this.lblJogador1);
            this.Controls.Add(this.pnlJogador4);
            this.Controls.Add(this.lblJogador4);
            this.Controls.Add(this.pnlJogador1);
            this.Controls.Add(this.lblJogador3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MesaDePartida";
            this.Text = "MesaDePartida";
            this.Load += new System.EventHandler(this.MesaDePartida_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblJogador3;
        private System.Windows.Forms.Panel pnlJogador1;
        private System.Windows.Forms.Label lblJogador4;
        private System.Windows.Forms.Panel pnlJogador4;
        private System.Windows.Forms.Label lblJogador1;
        private System.Windows.Forms.Label lblJogador2;
        private System.Windows.Forms.Label lblIDJogador1;
        private System.Windows.Forms.Label lblIDJogador2;
        private System.Windows.Forms.Label lblIDJogador3;
        private System.Windows.Forms.Label lblIDJogador4;
        private System.Windows.Forms.Label lblVezJogador;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblIDPartida;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListView lvwJogadores;
        private System.Windows.Forms.ColumnHeader clhJogador;
        private System.Windows.Forms.ColumnHeader clhPontos;
        private System.Windows.Forms.ListBox lstJogadas;
        private System.Windows.Forms.Label lblJogadas;
        private System.Windows.Forms.Button btnIniciarPartida;
        private System.Windows.Forms.Panel pnlJogador2;
        private System.Windows.Forms.Panel pnlJogador3;
        private System.Windows.Forms.Button btnApostar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnJogar;
        private System.Windows.Forms.Button btnPular;
        private System.Windows.Forms.Label lblDll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
    }
}