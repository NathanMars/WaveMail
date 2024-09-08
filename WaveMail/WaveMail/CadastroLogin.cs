using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WaveMail
{
    /// <summary>
    /// Formulario que permite o cadastro de novos usuarios. "Voltar" fecha este forms e abre o forms "Login"
    /// </summary>
    public partial class CadastroLogin : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=WaveMail;Integrated Security=True";
        public CadastroLogin()
        {
            InitializeComponent();
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            // Verifica se a senha e a confirmação de senha são iguais
            if (tbSenha.Text != tbConfirmarSenha.Text)
            {
                MessageBox.Show("As senha não coincidem. Por favor, verifique.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Não prossegue com o cadastro se as senhas não coincidirem
            }
            // Verifica se todos os campos foram preenchidos
            if ((tbUsuario.Text==string.Empty)||(tbSenha.Text == string.Empty))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Lógica para cadastrar o usuário no banco de dados
                string Usuario = tbUsuario.Text;
                string Senha = tbSenha.Text;

                string query = "INSERT INTO Usuarios (Usuario, Senha) VALUES (@Usuario, @Senha)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Usuario", Usuario);
                    command.Parameters.AddWithValue("@Senha", Senha);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Cadastro realizado com sucesso!");
                Login loginForm = new Login();
                loginForm.ShowDialog();
                this.Close();
            }
        }

        private void btVoltar_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.ShowDialog();
            this.Close();
        }

        // Mostra ou oculta a senha com base no estado da CheckBox
        private void cbSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSenha.Checked)
            {
                tbSenha.PasswordChar = '\0'; // '\0' representa nenhum caractere de senha
                tbConfirmarSenha.PasswordChar = '\0';
            }
            else
            {
                tbSenha.PasswordChar = '*'; // Restaura o caractere de senha para '*'
                tbConfirmarSenha.PasswordChar = '*';
            }
        }

        // Automatiza a inserção do dominio no email do usuario
        private void tbUsuario_TextChanged(object sender, EventArgs e)
        {
          string dominio = "@wavemail.com";

            if (!tbUsuario.Text.EndsWith(dominio))
            {
                // Salva a posição do cursor antes de adicionar o domínio
                int posicaoCursor = tbUsuario.SelectionStart;

                // Adiciona o domínio ao texto
                tbUsuario.Text += dominio;

                // Restaura a posição do cursor para antes do "@" (posição inicial + comprimento do texto adicionado)
                tbUsuario.SelectionStart = posicaoCursor + dominio.IndexOf('@');
            }
        }
    }
}
