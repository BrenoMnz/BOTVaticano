namespace BOTVaticano
{
    partial class menuPartidas
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstJogadores = new System.Windows.Forms.ListBox();
            this.txtIdpartida = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstPartidas
            // 
            this.lstPartidas.FormattingEnabled = true;
            this.lstPartidas.ItemHeight = 16;
            this.lstPartidas.Location = new System.Drawing.Point(12, 123);
            this.lstPartidas.Name = "lstPartidas";
            this.lstPartidas.Size = new System.Drawing.Size(431, 228);
            this.lstPartidas.TabIndex = 2;
            this.lstPartidas.SelectedIndexChanged += new System.EventHandler(this.lstPartidas_SelectedIndexChanged);
            // 
            // cboTipoPartida
            // 
            this.cboTipoPartida.FormattingEnabled = true;
            this.cboTipoPartida.Location = new System.Drawing.Point(12, 12);
            this.cboTipoPartida.Name = "cboTipoPartida";
            this.cboTipoPartida.Size = new System.Drawing.Size(121, 24);
            this.cboTipoPartida.TabIndex = 6;
            this.cboTipoPartida.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblIdpartida
            // 
            this.lblIdpartida.AutoSize = true;
            this.lblIdpartida.Location = new System.Drawing.Point(12, 72);
            this.lblIdpartida.Name = "lblIdpartida";
            this.lblIdpartida.Size = new System.Drawing.Size(83, 16);
            this.lblIdpartida.TabIndex = 7;
            this.lblIdpartida.Text = "Id da Partida";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(473, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Jogadores";
            // 
            // lstJogadores
            // 
            this.lstJogadores.FormattingEnabled = true;
            this.lstJogadores.ItemHeight = 16;
            this.lstJogadores.Location = new System.Drawing.Point(476, 123);
            this.lstJogadores.Name = "lstJogadores";
            this.lstJogadores.Size = new System.Drawing.Size(120, 228);
            this.lstJogadores.TabIndex = 9;
            // 
            // txtIdpartida
            // 
            this.txtIdpartida.Location = new System.Drawing.Point(12, 92);
            this.txtIdpartida.Name = "txtIdpartida";
            this.txtIdpartida.Size = new System.Drawing.Size(100, 22);
            this.txtIdpartida.TabIndex = 10;
            // 
            // menuPartidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 450);
            this.Controls.Add(this.txtIdpartida);
            this.Controls.Add(this.lstJogadores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblIdpartida);
            this.Controls.Add(this.cboTipoPartida);
            this.Controls.Add(this.lstPartidas);
            this.Name = "menuPartidas";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.menuPartidas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstPartidas;
        private System.Windows.Forms.ComboBox cboTipoPartida;
        private System.Windows.Forms.Label lblIdpartida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstJogadores;
        private System.Windows.Forms.TextBox txtIdpartida;
    }
}