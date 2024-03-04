namespace BOTVaticano
{
    partial class Form1
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
            this.btnOi = new System.Windows.Forms.Button();
            this.lblOi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOi
            // 
            this.btnOi.Location = new System.Drawing.Point(309, 110);
            this.btnOi.Name = "btnOi";
            this.btnOi.Size = new System.Drawing.Size(186, 45);
            this.btnOi.TabIndex = 0;
            this.btnOi.Text = "Saudações";
            this.btnOi.UseVisualStyleBackColor = true;
            this.btnOi.Click += new System.EventHandler(this.btnOi_Click);
            // 
            // lblOi
            // 
            this.lblOi.AutoSize = true;
            this.lblOi.Location = new System.Drawing.Point(396, 215);
            this.lblOi.Name = "lblOi";
            this.lblOi.Size = new System.Drawing.Size(0, 16);
            this.lblOi.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblOi);
            this.Controls.Add(this.btnOi);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOi;
        private System.Windows.Forms.Label lblOi;
    }
}

