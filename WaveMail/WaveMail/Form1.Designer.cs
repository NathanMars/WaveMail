namespace WaveMail
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.caixDeEntradaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caixaDeSaídaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lixeiraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewPadrao = new System.Windows.Forms.DataGridView();
            this.Conta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assunto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Corpo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btMover = new System.Windows.Forms.Button();
            this.btLer = new System.Windows.Forms.Button();
            this.lbInbox = new System.Windows.Forms.Label();
            this.lbSaida = new System.Windows.Forms.Label();
            this.lbLixeira = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPadrao)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Desktop;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caixDeEntradaToolStripMenuItem,
            this.caixaDeSaídaToolStripMenuItem,
            this.lixeiraToolStripMenuItem,
            this.enviarEmailToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // caixDeEntradaToolStripMenuItem
            // 
            this.caixDeEntradaToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caixDeEntradaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.caixDeEntradaToolStripMenuItem.Name = "caixDeEntradaToolStripMenuItem";
            this.caixDeEntradaToolStripMenuItem.Size = new System.Drawing.Size(170, 24);
            this.caixDeEntradaToolStripMenuItem.Text = "Caixa de &Entrada";
            this.caixDeEntradaToolStripMenuItem.Click += new System.EventHandler(this.caixDeEntradaToolStripMenuItem_Click);
            // 
            // caixaDeSaídaToolStripMenuItem
            // 
            this.caixaDeSaídaToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caixaDeSaídaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.caixaDeSaídaToolStripMenuItem.Name = "caixaDeSaídaToolStripMenuItem";
            this.caixaDeSaídaToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
            this.caixaDeSaídaToolStripMenuItem.Text = "Caixa de &Saída";
            this.caixaDeSaídaToolStripMenuItem.Click += new System.EventHandler(this.caixaDeSaídaToolStripMenuItem_Click);
            // 
            // lixeiraToolStripMenuItem
            // 
            this.lixeiraToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lixeiraToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.lixeiraToolStripMenuItem.Name = "lixeiraToolStripMenuItem";
            this.lixeiraToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.lixeiraToolStripMenuItem.Text = "&Lixeira";
            this.lixeiraToolStripMenuItem.Click += new System.EventHandler(this.lixeiraToolStripMenuItem_Click);
            // 
            // enviarEmailToolStripMenuItem
            // 
            this.enviarEmailToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviarEmailToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.enviarEmailToolStripMenuItem.Name = "enviarEmailToolStripMenuItem";
            this.enviarEmailToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.enviarEmailToolStripMenuItem.Text = "&Enviar E-mail";
            this.enviarEmailToolStripMenuItem.Click += new System.EventHandler(this.enviarEmailToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.logOutToolStripMenuItem.Text = "Log &Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // dataGridViewPadrao
            // 
            this.dataGridViewPadrao.AllowUserToAddRows = false;
            this.dataGridViewPadrao.AllowUserToOrderColumns = true;
            this.dataGridViewPadrao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPadrao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Conta,
            this.Assunto,
            this.Corpo,
            this.Lido});
            this.dataGridViewPadrao.Location = new System.Drawing.Point(12, 46);
            this.dataGridViewPadrao.Name = "dataGridViewPadrao";
            this.dataGridViewPadrao.RowHeadersWidth = 51;
            this.dataGridViewPadrao.RowTemplate.Height = 24;
            this.dataGridViewPadrao.Size = new System.Drawing.Size(776, 354);
            this.dataGridViewPadrao.TabIndex = 1;
            this.dataGridViewPadrao.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPadrao_CellContentClick);
            // 
            // Conta
            // 
            this.Conta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Conta.FillWeight = 25F;
            this.Conta.HeaderText = "Remetente";
            this.Conta.MinimumWidth = 6;
            this.Conta.Name = "Conta";
            this.Conta.ReadOnly = true;
            this.Conta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Assunto
            // 
            this.Assunto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Assunto.FillWeight = 25F;
            this.Assunto.HeaderText = "Assunto";
            this.Assunto.MinimumWidth = 6;
            this.Assunto.Name = "Assunto";
            this.Assunto.ReadOnly = true;
            // 
            // Corpo
            // 
            this.Corpo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Corpo.FillWeight = 50F;
            this.Corpo.HeaderText = "Corpo";
            this.Corpo.MinimumWidth = 6;
            this.Corpo.Name = "Corpo";
            this.Corpo.ReadOnly = true;
            // 
            // Lido
            // 
            this.Lido.HeaderText = "Lido";
            this.Lido.MinimumWidth = 6;
            this.Lido.Name = "Lido";
            this.Lido.ReadOnly = true;
            this.Lido.Width = 50;
            // 
            // btExcluir
            // 
            this.btExcluir.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExcluir.Location = new System.Drawing.Point(365, 406);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(142, 32);
            this.btExcluir.TabIndex = 3;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btMover
            // 
            this.btMover.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMover.Location = new System.Drawing.Point(12, 406);
            this.btMover.Name = "btMover";
            this.btMover.Size = new System.Drawing.Size(230, 32);
            this.btMover.TabIndex = 2;
            this.btMover.Text = "Mover para a Lixeira";
            this.btMover.UseVisualStyleBackColor = true;
            this.btMover.Click += new System.EventHandler(this.btMover_Click);
            // 
            // btLer
            // 
            this.btLer.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLer.Location = new System.Drawing.Point(646, 406);
            this.btLer.Name = "btLer";
            this.btLer.Size = new System.Drawing.Size(142, 32);
            this.btLer.TabIndex = 4;
            this.btLer.Text = "Ler Email";
            this.btLer.UseVisualStyleBackColor = true;
            this.btLer.Click += new System.EventHandler(this.btLer_Click);
            // 
            // lbInbox
            // 
            this.lbInbox.AutoSize = true;
            this.lbInbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInbox.Location = new System.Drawing.Point(71, 27);
            this.lbInbox.Name = "lbInbox";
            this.lbInbox.Size = new System.Drawing.Size(29, 25);
            this.lbInbox.TabIndex = 5;
            this.lbInbox.Text = "^";
            this.lbInbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSaida
            // 
            this.lbSaida.AutoSize = true;
            this.lbSaida.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSaida.Location = new System.Drawing.Point(260, 27);
            this.lbSaida.Name = "lbSaida";
            this.lbSaida.Size = new System.Drawing.Size(29, 25);
            this.lbSaida.TabIndex = 6;
            this.lbSaida.Text = "^";
            this.lbSaida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLixeira
            // 
            this.lbLixeira.AutoSize = true;
            this.lbLixeira.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLixeira.Location = new System.Drawing.Point(391, 27);
            this.lbLixeira.Name = "lbLixeira";
            this.lbLixeira.Size = new System.Drawing.Size(29, 25);
            this.lbLixeira.TabIndex = 7;
            this.lbLixeira.Text = "^";
            this.lbLixeira.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btLer);
            this.Controls.Add(this.btMover);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.dataGridViewPadrao);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lbInbox);
            this.Controls.Add(this.lbSaida);
            this.Controls.Add(this.lbLixeira);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WaveMail";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPadrao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem caixDeEntradaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caixaDeSaídaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lixeiraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewPadrao;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btMover;
        private System.Windows.Forms.Button btLer;
        private System.Windows.Forms.Label lbInbox;
        private System.Windows.Forms.Label lbSaida;
        private System.Windows.Forms.Label lbLixeira;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Corpo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Lido;
    }
}

