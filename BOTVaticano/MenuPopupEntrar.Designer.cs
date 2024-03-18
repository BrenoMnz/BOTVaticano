namespace BOTVaticano
{
    partial class MenuPopupEntrar
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
            this.lblNomeJogador = new System.Windows.Forms.Label();
            this.lblSenhaPartida = new System.Windows.Forms.Label();
            this.txtNomeJogador = new System.Windows.Forms.TextBox();
            this.txtSenhaPartida = new System.Windows.Forms.TextBox();
            this.lblIdpartida = new System.Windows.Forms.Label();
            this.lblTagIdPartida = new System.Windows.Forms.Label();
            this.btbVoltarMenuPartidas = new System.Windows.Forms.Button();
            this.btnEntrarPartida = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNomeJogador
            // 
            this.lblNomeJogador.AutoSize = true;
            this.lblNomeJogador.Location = new System.Drawing.Point(13, 54);
            this.lblNomeJogador.Name = "lblNomeJogador";
            this.lblNomeJogador.Size = new System.Drawing.Size(104, 16);
            this.lblNomeJogador.TabIndex = 0;
            this.lblNomeJogador.Text = "Digite seu nome";
            // 
            // lblSenhaPartida
            // 
            this.lblSenhaPartida.AutoSize = true;
            this.lblSenhaPartida.Location = new System.Drawing.Point(13, 107);
            this.lblSenhaPartida.Name = "lblSenhaPartida";
            this.lblSenhaPartida.Size = new System.Drawing.Size(93, 16);
            this.lblSenhaPartida.TabIndex = 1;
            this.lblSenhaPartida.Text = "Digite a senha";
            // 
            // txtNomeJogador
            // 
            this.txtNomeJogador.Location = new System.Drawing.Point(12, 72);
            this.txtNomeJogador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNomeJogador.Name = "txtNomeJogador";
            this.txtNomeJogador.Size = new System.Drawing.Size(207, 22);
            this.txtNomeJogador.TabIndex = 3;
            // 
            // txtSenhaPartida
            // 
            this.txtSenhaPartida.Location = new System.Drawing.Point(15, 125);
            this.txtSenhaPartida.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSenhaPartida.Name = "txtSenhaPartida";
            this.txtSenhaPartida.PasswordChar = '*';
            this.txtSenhaPartida.Size = new System.Drawing.Size(208, 22);
            this.txtSenhaPartida.TabIndex = 4;
            // 
            // lblIdpartida
            // 
            this.lblIdpartida.AutoSize = true;
            this.lblIdpartida.Location = new System.Drawing.Point(104, 21);
            this.lblIdpartida.Name = "lblIdpartida";
            this.lblIdpartida.Size = new System.Drawing.Size(61, 16);
            this.lblIdpartida.TabIndex = 6;
            this.lblIdpartida.Text = "IdPartida";
            // 
            // lblTagIdPartida
            // 
            this.lblTagIdPartida.AutoSize = true;
            this.lblTagIdPartida.Location = new System.Drawing.Point(13, 21);
            this.lblTagIdPartida.Name = "lblTagIdPartida";
            this.lblTagIdPartida.Size = new System.Drawing.Size(85, 16);
            this.lblTagIdPartida.TabIndex = 7;
            this.lblTagIdPartida.Text = "Id da partida:";
            // 
            // btbVoltarMenuPartidas
            // 
            this.btbVoltarMenuPartidas.Location = new System.Drawing.Point(157, 18);
            this.btbVoltarMenuPartidas.Name = "btbVoltarMenuPartidas";
            this.btbVoltarMenuPartidas.Size = new System.Drawing.Size(100, 28);
            this.btbVoltarMenuPartidas.TabIndex = 8;
            this.btbVoltarMenuPartidas.Text = "Voltar";
            this.btbVoltarMenuPartidas.UseVisualStyleBackColor = true;
            this.btbVoltarMenuPartidas.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEntrarPartida
            // 
            this.btnEntrarPartida.Location = new System.Drawing.Point(37, 18);
            this.btnEntrarPartida.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEntrarPartida.Name = "btnEntrarPartida";
            this.btnEntrarPartida.Size = new System.Drawing.Size(100, 28);
            this.btnEntrarPartida.TabIndex = 2;
            this.btnEntrarPartida.Text = "Entrar";
            this.btnEntrarPartida.UseVisualStyleBackColor = true;
            this.btnEntrarPartida.Click += new System.EventHandler(this.btnEntrarPartida_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.btbVoltarMenuPartidas);
            this.panel1.Controls.Add(this.btnEntrarPartida);
            this.panel1.Location = new System.Drawing.Point(-4, 169);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 63);
            this.panel1.TabIndex = 9;
            // 
            // MenuPopupEntrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 230);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTagIdPartida);
            this.Controls.Add(this.lblIdpartida);
            this.Controls.Add(this.txtSenhaPartida);
            this.Controls.Add(this.txtNomeJogador);
            this.Controls.Add(this.lblSenhaPartida);
            this.Controls.Add(this.lblNomeJogador);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MenuPopupEntrar";
            this.Text = "MenuPopupEntrar";
            this.Load += new System.EventHandler(this.MenuPopupEntrar_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomeJogador;
        private System.Windows.Forms.Label lblSenhaPartida;
        private System.Windows.Forms.TextBox txtNomeJogador;
        private System.Windows.Forms.TextBox txtSenhaPartida;
        private System.Windows.Forms.Label lblIdpartida;
        private System.Windows.Forms.Label lblTagIdPartida;
        private System.Windows.Forms.Button btbVoltarMenuPartidas;
        private System.Windows.Forms.Button btnEntrarPartida;
        private System.Windows.Forms.Panel panel1;
    }
}