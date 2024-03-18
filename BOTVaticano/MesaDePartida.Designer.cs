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
            this.lblidPartida = new System.Windows.Forms.Label();
            this.btnIniciarPartida = new System.Windows.Forms.Button();
            this.lslJogadores = new System.Windows.Forms.ListBox();
            this.lblVez = new System.Windows.Forms.Label();
            this.lbJogadordaVez = new System.Windows.Forms.Label();
            this.lblIdDaVez = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblidPartida
            // 
            this.lblidPartida.AutoSize = true;
            this.lblidPartida.Location = new System.Drawing.Point(12, 9);
            this.lblidPartida.Name = "lblidPartida";
            this.lblidPartida.Size = new System.Drawing.Size(44, 16);
            this.lblidPartida.TabIndex = 0;
            this.lblidPartida.Text = "label1";
            // 
            // btnIniciarPartida
            // 
            this.btnIniciarPartida.Location = new System.Drawing.Point(663, 378);
            this.btnIniciarPartida.Name = "btnIniciarPartida";
            this.btnIniciarPartida.Size = new System.Drawing.Size(125, 41);
            this.btnIniciarPartida.TabIndex = 1;
            this.btnIniciarPartida.Text = "Iniciar Jogo";
            this.btnIniciarPartida.UseVisualStyleBackColor = true;
            this.btnIniciarPartida.Click += new System.EventHandler(this.btnIniciarPartida_Click);
            // 
            // lslJogadores
            // 
            this.lslJogadores.FormattingEnabled = true;
            this.lslJogadores.ItemHeight = 16;
            this.lslJogadores.Location = new System.Drawing.Point(668, 26);
            this.lslJogadores.Name = "lslJogadores";
            this.lslJogadores.Size = new System.Drawing.Size(120, 132);
            this.lslJogadores.TabIndex = 2;
            // 
            // lblVez
            // 
            this.lblVez.AutoSize = true;
            this.lblVez.Location = new System.Drawing.Point(668, 181);
            this.lblVez.Name = "lblVez";
            this.lblVez.Size = new System.Drawing.Size(58, 16);
            this.lblVez.TabIndex = 3;
            this.lblVez.Text = "Jogador";
            // 
            // lbJogadordaVez
            // 
            this.lbJogadordaVez.AutoSize = true;
            this.lbJogadordaVez.Location = new System.Drawing.Point(668, 165);
            this.lbJogadordaVez.Name = "lbJogadordaVez";
            this.lbJogadordaVez.Size = new System.Drawing.Size(101, 16);
            this.lbJogadordaVez.TabIndex = 4;
            this.lbJogadordaVez.Text = "Jogador da vez";
            // 
            // lblIdDaVez
            // 
            this.lblIdDaVez.AutoSize = true;
            this.lblIdDaVez.Location = new System.Drawing.Point(668, 213);
            this.lblIdDaVez.Name = "lblIdDaVez";
            this.lblIdDaVez.Size = new System.Drawing.Size(69, 16);
            this.lblIdDaVez.TabIndex = 5;
            this.lblIdDaVez.Text = "IdJogador";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(668, 197);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(93, 16);
            this.lblId.TabIndex = 6;
            this.lblId.Text = "ID do Jogador";
            // 
            // MesaDePartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblIdDaVez);
            this.Controls.Add(this.lbJogadordaVez);
            this.Controls.Add(this.lblVez);
            this.Controls.Add(this.lslJogadores);
            this.Controls.Add(this.btnIniciarPartida);
            this.Controls.Add(this.lblidPartida);
            this.Name = "MesaDePartida";
            this.Text = "MesaDePartida";
            this.Load += new System.EventHandler(this.MesaDePartida_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblidPartida;
        private System.Windows.Forms.Button btnIniciarPartida;
        private System.Windows.Forms.ListBox lslJogadores;
        private System.Windows.Forms.Label lblVez;
        private System.Windows.Forms.Label lbJogadordaVez;
        private System.Windows.Forms.Label lblIdDaVez;
        private System.Windows.Forms.Label lblId;
    }
}