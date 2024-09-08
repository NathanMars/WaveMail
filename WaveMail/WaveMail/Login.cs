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

namespace WaveMail
{
    /// <summary>
    /// Forms de login que faz a autenticação do usuario. Botão "Cadastrar" fecha este forms e abre o forms "CadastroLogin"
    /// </summary>
    public partial class Login : Form
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WaveMail;Integrated Security=True;";
        public bool LoginSuccessful { get; private set; }
        public Login()
        {
            InitializeComponent();
        }

        // As duas funções abaixo realizam autenticação do usuario para realizar o login
        private void btEntrar_Click(object sender, EventArgs e)
        {
            string usuario = tbUsuario.Text;
            string senha = tbSenha.Text;

            int UsuarioID = AutenticarUsuario(usuario, senha);

            if (UsuarioID != -1)
            {
                LoginSuccessful = true;
                Form1 formPrincipal = new Form1(UsuarioID);
                formPrincipal.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos. Tente novamente.");
                LoginSuccessful = false;
            }
        }
        private int AutenticarUsuario(string usuario, string senha)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ID FROM Usuarios WHERE Usuario = @Usuario AND Senha = @Senha";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Usuario", usuario);
                command.Parameters.AddWithValue("@Senha", senha);

                object result = command.ExecuteScalar();

                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            
            new CadastroLogin().ShowDialog();
            this.Close();
        }

        private void cbSenha_CheckedChanged(object sender, EventArgs e)
        {
            // Versão antiga, não usar
            
        }

        // Automatiza a inserção do dominio ao email do usuario
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

        // Mostra ou oculta a senha com base no estado da CheckBox
        private void cbSenha_CheckedChanged_1(object sender, EventArgs e)
        { 
            if (cbSenha.Checked)
            {
                tbSenha.PasswordChar = '\0'; // '\0' representa nenhum caractere de senha
            }
            else
            {
                tbSenha.PasswordChar = '*'; // Restaura o caractere de senha para '*'
            }
        }
    } 
}
