using DevExpress.XtraEditors.Filtering.Templates;
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
    /// Forms que recupera os dados da row selecionada na tabela Mensagem. "Responder" fecha estte forms e abre o forms "EnviarEmail", "Voltar" apenas fecha este forms
    /// </summary>
    public partial class LerEmail : Form
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WaveMail;Integrated Security=True;";
        private int MensagemID;
        private int UsuarioID;
        private int RemetenteID;
        public LerEmail(int MensagemID, int UsuarioID, int RemetenteID)
        {
            InitializeComponent();
            this.MensagemID = MensagemID;
            this.UsuarioID = UsuarioID;
            this.RemetenteID = RemetenteID;
            MarcarLido(MensagemID, UsuarioID, RemetenteID);
            CarregarMensagem(MensagemID);
        }

        private void CarregarMensagem(int MensagemID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT RemetenteID, Assunto, Corpo FROM Mensagens WHERE ID = @MensagemID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MensagemID", MensagemID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int remetenteId = Convert.ToInt32(reader["RemetenteID"]);
                        string assunto = reader["Assunto"].ToString();
                        string corpo = reader["Corpo"].ToString();

                        // Preencha os campos no formulário com os detalhes da mensagem
                        tbRemetente.Text = ObterNomeUsuario(remetenteId);
                        tbAssunto.Text = assunto;
                        tbMensagem.Text = corpo;
                    }
                }
            }
        }

        private void MarcarLido(int MensagemID, int UsuarioID, int RemetenteID)
        {
            if (RemetenteID == UsuarioID)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Mensagens SET LidoR = @True WHERE ID = @MensagemID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@True", 1);
                    command.Parameters.AddWithValue("@MensagemID", MensagemID);

                    command.ExecuteNonQuery();
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query2 = "UPDATE Mensagens SET LidoD = @True WHERE ID = @MensagemID";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Parameters.AddWithValue("@True", 1);
                    command2.Parameters.AddWithValue("@MensagemID", MensagemID);

                    command2.ExecuteNonQuery();
                }

            }
        }

        private string ObterNomeUsuario(int UsuarioId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Usuario FROM Usuarios WHERE ID = @UsuarioID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UsuarioID", UsuarioId);

                object result = command.ExecuteScalar();

                return result != null ? result.ToString() : "";
            }
        }

        private void btResponder_Click(object sender, EventArgs e)
        {
            EnviarEmail enviarEmail = new EnviarEmail(UsuarioID);
            enviarEmail.ShowDialog();
            this.Close();
        }

        private void btVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
