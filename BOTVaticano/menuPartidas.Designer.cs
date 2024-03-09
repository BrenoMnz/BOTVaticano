namespace BOTVaticano
{
    partial class MenuPartidas
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
            this.lstPartidas = new System.Windows.Forms.ListBox();
            this.cboTipoPartida = new System.Windows.Forms.ComboBox();
            this.lblIdpartida = new System.Windows.Forms.Label();
            this.lblJogadores = new System.Windows.Forms.Label();
            this.lstJogadores = new System.Windows.Forms.ListBox();
            this.txtIdpartida = new System.Windows.Forms.TextBox();
            this.lblPartidas = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstPartidas
            // 
            this.lstPartidas.FormattingEnabled = true;
            this.lstPartidas.Location = new System.Drawing.Point(9, 100);
            this.lstPartidas.Margin = new System.Windows.Forms.Padding(2);
            this.lstPartidas.Name = "lstPartidas";
            this.lstPartidas.Size = new System.Drawing.Size(438, 186);
            this.lstPartidas.TabIndex = 2;
            this.lstPartidas.SelectedIndexChanged += new System.EventHandler(this.lstPartidas_SelectedIndexChanged);
            // 
            // cboTipoPartida
            // 
            this.cboTipoPartida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPartida.FormattingEnabled = true;
            this.cboTipoPartida.Location = new System.Drawing.Point(9, 10);
            this.cboTipoPartida.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoPartida.Name = "cboTipoPartida";
            this.cboTipoPartida.Size = new System.Drawing.Size(92, 21);
            this.cboTipoPartida.TabIndex = 6;
            this.cboTipoPartida.SelectedIndexChanged += new System.EventHandler(this.cboTipoPartida_SelectedIndexChanged);
            // 
            // lblIdpartida
            // 
            this.lblIdpartida.AutoSize = true;
            this.lblIdpartida.Location = new System.Drawing.Point(9, 49);
            this.lblIdpartida.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdpartida.Name = "lblIdpartida";
            this.lblIdpartida.Size = new System.Drawing.Size(67, 13);
            this.lblIdpartida.TabIndex = 7;
            this.lblIdpartida.Text = "Id da Partida";
            // 
            // lblJogadores
            // 
            this.lblJogadores.AutoSize = true;
            this.lblJogadores.Location = new System.Drawing.Point(448, 85);
            this.lblJogadores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblJogadores.Name = "lblJogadores";
            this.lblJogadores.Size = new System.Drawing.Size(56, 13);
            this.lblJogadores.TabIndex = 8;
            this.lblJogadores.Text = "Jogadores";
            // 
            // lstJogadores
            // 
            this.lstJogadores.FormattingEnabled = true;
            this.lstJogadores.Location = new System.Drawing.Point(451, 100);
            this.lstJogadores.Margin = new System.Windows.Forms.Padding(2);
            this.lstJogadores.Name = "lstJogadores";
            this.lstJogadores.Size = new System.Drawing.Size(122, 186);
            this.lstJogadores.TabIndex = 9;
            // 
            // txtIdpartida
            // 
            this.txtIdpartida.Location = new System.Drawing.Point(9, 64);
            this.txtIdpartida.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdpartida.Name = "txtIdpartida";
            this.txtIdpartida.Size = new System.Drawing.Size(76, 20);
            this.txtIdpartida.TabIndex = 10;
            // 
            // lblPartidas
            // 
            this.lblPartidas.AutoSize = true;
            this.lblPartidas.Location = new System.Drawing.Point(9, 84);
            this.lblPartidas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPartidas.Name = "lblPartidas";
            this.lblPartidas.Size = new System.Drawing.Size(45, 13);
            this.lblPartidas.TabIndex = 11;
            this.lblPartidas.Text = "Partidas";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(98, 49);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Status";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(100, 64);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(2);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(76, 20);
            this.txtStatus.TabIndex = 13;
            // 
            // btnEntrar
            // 
            this.btnEntrar.Location = new System.Drawing.Point(464, 294);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(94, 41);
            this.btnEntrar.TabIndex = 15;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(479, 346);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(63, 23);
            this.btnVoltar.TabIndex = 16;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // MenuPartidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 381);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPartidas);
            this.Controls.Add(this.txtIdpartida);
            this.Controls.Add(this.lstJogadores);
            this.Controls.Add(this.lblJogadores);
            this.Controls.Add(this.lblIdpartida);
            this.Controls.Add(this.cboTipoPartida);
            this.Controls.Add(this.lstPartidas);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MenuPartidas";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstPartidas;
        private System.Windows.Forms.ComboBox cboTipoPartida;
        private System.Windows.Forms.Label lblIdpartida;
        private System.Windows.Forms.Label lblJogadores;
        private System.Windows.Forms.ListBox lstJogadores;
        private System.Windows.Forms.TextBox txtIdpartida;
        private System.Windows.Forms.Label lblPartidas;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Button btnVoltar;
    }
}