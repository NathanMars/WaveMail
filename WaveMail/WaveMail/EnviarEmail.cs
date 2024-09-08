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
    /// Formulario que envia Emails para outras contas
    /// </summary>
    public partial class EnviarEmail : Form
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WaveMail;Integrated Security=True;";

        private int remetenteId; // Recebe o ID do usuário logado
        public EnviarEmail(int remetenteId)
        {
            InitializeComponent();
            this.remetenteId = remetenteId;
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            string destinatario = tbDestinatario.Text;
            string assunto = tbAssunto.Text;
            string mensagem = tbMensagem.Text;

            if (!string.IsNullOrEmpty(destinatario) && !string.IsNullOrEmpty(mensagem))
            {
                int destinatarioId = ObterIdUsuario(destinatario);
                

                if (destinatarioId != -1)
                {
                    EnviarMensagem(remetenteId, destinatarioId, assunto, mensagem);
                    MessageBox.Show("Mensagem enviada com sucesso!");
                    LimparCampos();
                    this.Close(); // Fecha o formulário após enviar a mensagem
                }
                else
                {
                    MessageBox.Show("Destinatário não encontrado. Verifique o nome de usuário.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
            }
    } 
        private int ObterIdUsuario(string usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ID FROM Usuarios WHERE Usuario = @Usuario";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Usuario", usuario);

                object result = command.ExecuteScalar();

                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        private void EnviarMensagem(int remetenteId, int destinatarioId, string assunto, string mensagem)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Insere a mensagem na tabela Messages
                string queryMensagem = "INSERT INTO Mensagens (RemetenteID, DestinatarioID, Assunto, Corpo) VALUES (@Remetente, @Destinatario, @Assunto, @Mensagem)";
                SqlCommand commandMensagem = new SqlCommand(queryMensagem, connection);
                commandMensagem.Parameters.AddWithValue("@Remetente", remetenteId);
                commandMensagem.Parameters.AddWithValue("@Destinatario", destinatarioId);
                commandMensagem.Parameters.AddWithValue("@Assunto", assunto);
                commandMensagem.Parameters.AddWithValue("@Mensagem", mensagem);
                commandMensagem.ExecuteNonQuery();

                // Obtem o ID da mensagem recém-inserida
                string queryIdMensagem = "SELECT @@IDENTITY AS MensagemID";
                SqlCommand commandIdMensagem = new SqlCommand(queryIdMensagem, connection);
                object result = commandIdMensagem.ExecuteScalar();

                // Verifica se o resultado é DBNull
                if (result != DBNull.Value)
                {
                    int MensagemID = Convert.ToInt32(result);

                    // Insere o relacionamento na tabela UsuarioMensagemRelacionamento
                    string queryRelacionamento = "INSERT INTO UsuarioMensagemRelacionamento (UsuarioID, MensagemID, Destinatario, Saida) VALUES (@Remetente, @MensagemID, @Destinatario, 1)";
                    SqlCommand commandRelacionamento = new SqlCommand(queryRelacionamento, connection);
                    commandRelacionamento.Parameters.AddWithValue("@Remetente", remetenteId);
                    commandRelacionamento.Parameters.AddWithValue("@MensagemID", MensagemID);
                    commandRelacionamento.Parameters.AddWithValue("@Destinatario", destinatarioId);
                    commandRelacionamento.ExecuteNonQuery();
                }
                else
                {
                    // Trata o caso em que o resultado é DBNull (pode adicionar lógica de tratamento aqui)
                    MessageBox.Show("Erro ao obter o ID da mensagem recém-inserida.");
                }
            }
        }

        private void LimparCampos()
        {
            tbDestinatario.Text = "";
            tbMensagem.Text = "";
        }

        private void tbUsuario_TextChanged(object sender, EventArgs e)
        {

        } //não excluir nem usar essa função

        private void btLimpar_Click(object sender, EventArgs e)
        {
            tbDestinatario.Clear();
            tbMensagem.Clear();
        }

        // Automatia a inserção do dominio no email do destinatario
        private void tbDestinatario_TextChanged(object sender, EventArgs e)
        {
            string dominio = "@wavemail.com";

            if (!tbDestinatario.Text.EndsWith(dominio))
            {
                // Salvar a posição do cursor antes de adicionar o domínio
                int posicaoCursor = tbDestinatario.SelectionStart;

                // Adicionar o domínio ao texto
                tbDestinatario.Text += dominio;

                // Restaurar a posição do cursor para antes do "@" (posição inicial + comprimento do texto adicionado)
                tbDestinatario.SelectionStart = posicaoCursor + dominio.IndexOf('@');
            }
        }
    }
}
