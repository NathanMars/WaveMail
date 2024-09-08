namespace WaveMail
{
    partial class LerEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LerEmail));
            this.label1 = new System.Windows.Forms.Label();
            this.tbAssunto = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btVoltar = new System.Windows.Forms.Button();
            this.btResponder = new System.Windows.Forms.Button();
            this.tbMensagem = new System.Windows.Forms.TextBox();
            this.tbRemetente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(51, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Assunto";
            // 
            // tbAssunto
            // 
            this.tbAssunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAssunto.Location = new System.Drawing.Point(166, 102);
            this.tbAssunto.Name = "tbAssunto";
            this.tbAssunto.ReadOnly = true;
            this.tbAssunto.Size = new System.Drawing.Size(251, 27);
            this.tbAssunto.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(451, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // btVoltar
            // 
            this.btVoltar.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVoltar.Location = new System.Drawing.Point(619, 104);
            this.btVoltar.Name = "btVoltar";
            this.btVoltar.Size = new System.Drawing.Size(152, 47);
            this.btVoltar.TabIndex = 5;
            this.btVoltar.Text = "Voltar";
            this.btVoltar.UseVisualStyleBackColor = true;
            this.btVoltar.Click += new System.EventHandler(this.btVoltar_Click);
            // 
            // btResponder
            // 
            this.btResponder.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btResponder.Location = new System.Drawing.Point(619, 35);
            this.btResponder.Name = "btResponder";
            this.btResponder.Size = new System.Drawing.Size(152, 55);
            this.btResponder.TabIndex = 4;
            this.btResponder.Text = "Responder";
            this.btResponder.UseVisualStyleBackColor = true;
            this.btResponder.Click += new System.EventHandler(this.btResponder_Click);
            // 
            // tbMensagem
            // 
            this.tbMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMensagem.Location = new System.Drawing.Point(41, 172);
            this.tbMensagem.Multiline = true;
            this.tbMensagem.Name = "tbMensagem";
            this.tbMensagem.ReadOnly = true;
            this.tbMensagem.Size = new System.Drawing.Size(730, 243);
            this.tbMensagem.TabIndex = 3;
            // 
            // tbRemetente
            // 
            this.tbRemetente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRemetente.Location = new System.Drawing.Point(55, 46);
            this.tbRemetente.Name = "tbRemetente";
            this.tbRemetente.ReadOnly = true;
            this.tbRemetente.Size = new System.Drawing.Size(362, 27);
            this.tbRemetente.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "De";
            // 
            // LerEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbAssunto);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btVoltar);
            this.Controls.Add(this.btResponder);
            this.Controls.Add(this.tbMensagem);
            this.Controls.Add(this.tbRemetente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LerEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ler Email";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAssunto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btVoltar;
        private System.Windows.Forms.Button btResponder;
        private System.Windows.Forms.TextBox tbMensagem;
        private System.Windows.Forms.TextBox tbRemetente;
        private System.Windows.Forms.Label label2;
    }
}