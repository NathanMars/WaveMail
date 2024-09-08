using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaveMail
{
    /// <summary>
    /// Tela Principal do sistema. A menustrip no canto superior altera os dados do datagridview de acordo com a opção selecionada
    /// "Enviar Email" abre o forms EnviarEmail, "Log Off" fecha este forms e abre o forms de login novamente
    /// Os botões no canto inferior se tornam visiveis ou não dependendo da opção selecionada no menustrip
    /// "Mover para a Lixeira" só é visivel nas opções Caixa de Entrada e Caixa de Saida e move a row selecionada para a lixeira
    /// "Excluir" só é visivel na opção lixeira e torna a row invisivel para o usuario, "Ler" abre o forms LerEmail com a mensagem atualmente selecionada como parametro
    /// </summary>
    /// <remarks>
    /// Na tabela Mensagens, "NaLixeiraR" e "DeletadoR" se referem aos dados visiveis para o remetente da mensagem, enquando "NaLixeiraD" e "DeletadoD" aos visiveis para o Destinatario
    /// </remarks>
    public partial class Form1 : Form
    {
        private const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = WaveMail; Integrated Security = True;";
        private int UsuarioID;
        private int UltimaJanela = 1; // Marca qual a ultima janela aberta pelo usuario para que ela seja reaberta automaticamente quando ele retornar a este forms
        public Form1(int UsuarioID)
        {
            InitializeComponent();
            this.UsuarioID = UsuarioID;
            CarregarCaixaDeEntrada();
        }
        //Carrega dados onde o usuario atualmente logado é o destinatario
        private void CarregarCaixaDeEntrada()
        {
            UltimaJanela = 1;
            lbInbox.Visible = true;
            lbSaida.Visible = false;
            lbLixeira.Visible = false;
            btExcluir.Visible = false;
            btMover.Visible = true;
            btLer.Visible = true;
            dataGridViewPadrao.Rows.Clear();
            dataGridViewPadrao.Columns["Lido"].Visible = true;
            dataGridViewPadrao.Columns["Conta"].HeaderText = "Remetente";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT M.Assunto, M.Corpo, M.LidoD, U.Usuario AS Remetente " +
                               "FROM Mensagens M " +
                               "JOIN UsuarioMensagemRelacionamento UR ON M.ID = UR.MensagemID " +
                               "JOIN Usuarios U ON M.RemetenteID = U.ID " +
                               "WHERE (UR.UsuarioID = @UsuarioID AND UR.Entrada = 1 AND M.NaLixeiraD = 0) OR (M.DestinatarioID = @UsuarioID AND UR.Saida = 1 AND M.NaLixeiraD = 0)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UsuarioID", SeuIDDeUsuarioLogado());

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    string remetente;
                    string assunto;
                    string corpo;
                    bool lido;
                    while (reader.Read())
                    {
                        remetente = reader["Remetente"].ToString();
                        assunto = reader["Assunto"].ToString();
                        corpo = reader["Corpo"].ToString();
                        lido = Convert.ToBoolean(reader["LidoD"]);

                        dataGridViewPadrao.Rows.Add(remetente, assunto, corpo, lido);

                        dataGridViewPadrao.Rows[dataGridViewPadrao.Rows.Count - 1].Cells["Lido"].Value = lido;
                    }
                }
            }
        }

        //Carrega dados onde o usuario atualmente logado é o remetente
        private void CarregarCaixaDeSaida()
        {
            UltimaJanela = 2;
            lbInbox.Visible = false;
            lbSaida.Visible = true;
            lbLixeira.Visible = false;
            btMover.Visible = true;
            btExcluir.Visible = false;
            btLer.Visible = true;
            dataGridViewPadrao.Rows.Clear();
            dataGridViewPadrao.Columns["Lido"].Visible = true;
            dataGridViewPadrao.Columns["Conta"].HeaderText = "Destinatário";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT M.Assunto, M.Corpo, M.LidoR, U.Usuario AS Destinatario " +
                               "FROM Mensagens M " +
                               "JOIN UsuarioMensagemRelacionamento UR ON M.ID = UR.MensagemID " +
                               "JOIN Usuarios U ON M.DestinatarioID = U.ID " +
                               "WHERE UR.UsuarioID = @UsuarioID AND UR.Saida = 1 AND M.NaLixeiraR = 0";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UsuarioID", SeuIDDeUsuarioLogado());

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    string destinatario;
                    string assunto;
                    string corpo;
                    bool lido;
                    while (reader.Read())
                    {
                        destinatario = reader["Destinatario"].ToString();
                        assunto = reader["Assunto"].ToString();
                        corpo = reader["Corpo"].ToString();
                        lido = Convert.ToBoolean(reader["LidoR"]);

                        dataGridViewPadrao.Rows.Add(destinatario, assunto, corpo, lido);

                        dataGridViewPadrao.Rows[dataGridViewPadrao.Rows.Count - 1].Cells["Lido"].Value = lido;
                    }
                }
            }
        }

        //Carrega dados movidos para a lixeira pelo usuario
        private void CarregarLixeira()
        {
            UltimaJanela = 3;
            lbInbox.Visible = false;
            lbSaida.Visible = false;
            lbLixeira.Visible = true;
            btExcluir.Visible = true;
            btMover.Visible = false;
            btLer.Visible = true;
            dataGridViewPadrao.Rows.Clear();
            dataGridViewPadrao.Columns["Lido"].Visible = false;
            dataGridViewPadrao.Columns["Conta"].HeaderText = "Remetente";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Mostra o lixo da caixa de entrada
                connection.Open();
                string query = "SELECT M.Assunto, M.Corpo, U.Usuario AS Remetente " +
                               "FROM Mensagens M " +
                               "JOIN UsuarioMensagemRelacionamento UR ON M.ID = UR.MensagemID " +
                               "JOIN Usuarios U ON M.RemetenteID = U.ID " +
                              "WHERE M.DestinatarioID = @UsuarioID AND UR.Saida = 1 AND M.NaLixeiraD = 1 AND M.DeletadoD = 0";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UsuarioID", SeuIDDeUsuarioLogado());

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dataGridViewPadrao.Rows.Add(reader["Remetente"], reader["Assunto"], reader["Corpo"]);
                    }
                }
                //mostra o lixo da caixa de saida
                string query2 = "SELECT M.Assunto, M.Corpo, U.Usuario AS Remetente " +
                               "FROM Mensagens M " +
                               "JOIN UsuarioMensagemRelacionamento UR ON M.ID = UR.MensagemID " +
                               "JOIN Usuarios U ON M.RemetenteID = U.ID " +
                               "WHERE (UR.UsuarioID = @UsuarioID2 AND UR.Saida = 1 AND M.NaLixeiraR = 1 AND M.DeletadoR = 0) OR (M.RemetenteID = @UsuarioID2 AND UR.Saida = 1 AND M.NaLixeiraR = 1 AND M.DeletadoR = 0)";
                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.Parameters.AddWithValue("@UsuarioID2", SeuIDDeUsuarioLogado());

                using (SqlDataReader reader2 = command2.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        dataGridViewPadrao.Rows.Add(reader2["Remetente"], reader2["Assunto"], reader2["Corpo"]);
                    }
                }
            }
        }

        //Retorna o ID do usuario atualmente logado
        private int SeuIDDeUsuarioLogado()
        {
            return this.UsuarioID;
        }
        private void dataGridViewPadrao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        } 

        // as proximas 5 funções se referem as opções do menustrip
        private void caixDeEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarCaixaDeEntrada();
        }

        private void caixaDeSaídaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarCaixaDeSaida();
        }

        private void lixeiraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarLixeira();
        }

        private void enviarEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnviarEmail enviarEmail = new EnviarEmail(UsuarioID);
            enviarEmail.ShowDialog();

            // Após enviar a mensagem, recarrega a caixa de saída
            CarregarCaixaDeSaida();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Certifica que a conexão com o banco de dados seja fechada adequadamente
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Close();
            }

            // Exibe o formulário de login
            Login loginForm = new Login();
            loginForm.ShowDialog();
            this.Close();
        }

        // Move a linha selecionada pelo usuario para a lixeira
        private void MoverMensagemParaLixeira(string conta, string assunto, string corpo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
               
                // Lógica para obter o ID da mensagem com base nos detalhes fornecidos.
                int MensagemID = ObterMensagemID(SeuIDDeUsuarioLogado(), conta, assunto, corpo);

                int RemetenteID = ObterRemetenteID(MensagemID);
  
                //Verifica se a mensagem esta na caixa de saida
                if (RemetenteID == SeuIDDeUsuarioLogado()) 
                    {
                    // Encontra a mensagem com base nos detalhes da mensagem
                    string query1 = "UPDATE Mensagens SET NaLixeiraR = 1 WHERE ID = @MensagemID AND NaLixeiraR = 0";
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    command1.Parameters.AddWithValue("@MensagemID", MensagemID);

                    int rowsAffected1 = command1.ExecuteNonQuery();


                    if (rowsAffected1 > 0)
                    {
                        MessageBox.Show("Mensagem movida para a lixeira com sucesso!");
                        // Recarregar a lixeira após mover a mensagem
                        CarregarLixeira();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao mover a mensagem para a lixeira. Certifique-se de que a mensagem existe e tente novamente.");
                    }
                }

                // Se a mensagem estiver na caixa de entrada
                else
                {
                    // Encontra a mensagem com base nos detalhes da mensagem
                    string query = "UPDATE Mensagens SET NaLixeiraD = 1 WHERE ID = @MensagemID AND NaLixeiraD = 0";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MensagemID", MensagemID);

                    int rowsAffected = command.ExecuteNonQuery();


                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Mensagem movida para a lixeira com sucesso!");
                        // Recarregar a lixeira após mover a mensagem
                        CarregarLixeira();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao mover a mensagem para a lixeira. Certifique-se de que a mensagem existe e tente novamente.");
                    }
                }
            }
        }

        // Torna a linha selecionada pelo usuario invisivel apenas para ele
        private void ExcluirMensagem(string remetente, string assunto, string corpo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Lógica para obter o ID da mensagem com base nos detalhes fornecidos.
                int MensagemID = ObterMensagemID(SeuIDDeUsuarioLogado(), remetente, assunto, corpo);
                // Lógica para obter o ID do remetente
                int RemetenteID = ObterRemetenteID(MensagemID);

                if (RemetenteID == SeuIDDeUsuarioLogado()) //Confere se a mensagem esta na caixa de saida
                {
                    // Encontra a mensagem com base nos detalhes da mensagem
                    string query = "UPDATE Mensagens SET DeletadoR = 1 WHERE ID = @MensagemID AND DeletadoR = 0";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MensagemID", MensagemID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Mensagem excluída com sucesso!");
                        // Recarrega a caixa de entrada após excluir a mensagem
                        CarregarLixeira();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir a mensagem. Certifique-se de que a mensagem existe e tente novamente.");
                    }
                }
                else // Se a mensagem estiver na caixa de entrada
                {
                    // Encontra a mensagem com base nos detalhes da mensagem
                    string query = "UPDATE Mensagens SET DeletadoD = 1 WHERE ID = @MensagemID AND DeletadoD = 0";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MensagemID", MensagemID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Mensagem excluída com sucesso!");
                        // Recarrega a caixa de entrada após excluir a mensagem
                        CarregarLixeira();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir a mensagem. Certifique-se de que a mensagem existe e tente novamente.");
                    }
                }
            }
        }

        // Retorna o ID da mensagem
        private int ObterMensagemID(int UsuarioID, string conta, string assunto, string corpo)
            {
                int MensagemID = -1; // Valor padrão caso a mensagem não seja encontrada

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta para obter o ID da mensagem com base nos detalhes fornecidos
                    string query = "SELECT ID FROM Mensagens WHERE (DestinatarioID = @UsuarioID AND Assunto = @Assunto AND Corpo = @Corpo) OR (RemetenteID = @UsuarioID AND Assunto = @Assunto AND Corpo = @Corpo)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UsuarioID", UsuarioID);
                    command.Parameters.AddWithValue("@Assunto", assunto);
                    command.Parameters.AddWithValue("@Corpo", corpo);

                    // Executa a consulta e obtenha o ID da mensagem
                    object result = command.ExecuteScalar();

                    // Verifica se o resultado não é nulo antes de converter para int
                    if (result != null && int.TryParse(result.ToString(), out MensagemID))
                    {
                        return MensagemID;
                    }
                }

                return MensagemID;
            }

        // Recebe o ID da mensagem e retorna o ID do remetente dela
        private int ObterRemetenteID(int MensagemID)
        {
            int RemetenteID = -1; // Valor padrão caso não seja encontrado
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Consulta para obter o ID do remetente com base no ID da mensagem
                string query = "SELECT RemetenteID FROM Mensagens WHERE ID = @MensagemID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MensagemID", MensagemID);

                // Executa a consulta e obtenha o ID do remetente
                using (SqlDataReader reader = command.ExecuteReader())
                {             
                    if (reader.Read())
                    {
                        // Obtém o valor da coluna "RemetenteID"
                        RemetenteID = reader.GetInt32(reader.GetOrdinal("RemetenteID"));
                    }
                }
                return RemetenteID;
                
            }
        }

        // as proximas 3 funções se referem aos botões do canto inferior
        private void btExcluir_Click(object sender, EventArgs e)
            {
                if (dataGridViewPadrao.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridViewPadrao.SelectedRows[0];
                    string conta = selectedRow.Cells["Conta"].Value.ToString();
                    string assunto = selectedRow.Cells["Assunto"].Value.ToString();
                    string corpo = selectedRow.Cells["Corpo"].Value.ToString();

                    ExcluirMensagem(conta, assunto, corpo);
                }
            }

         private void btMover_Click(object sender, EventArgs e)
            {
                if (dataGridViewPadrao.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridViewPadrao.SelectedRows[0];
                    string conta = selectedRow.Cells["Conta"].Value.ToString();
                    string assunto = selectedRow.Cells["Assunto"].Value.ToString();
                    string corpo = selectedRow.Cells["Corpo"].Value.ToString();

                    MoverMensagemParaLixeira(conta, assunto, corpo);
                }
            }

        private void btLer_Click(object sender, EventArgs e)
        {
            if (dataGridViewPadrao.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewPadrao.SelectedRows[0];
                int MensagemID = ObterMensagemID(SeuIDDeUsuarioLogado(), selectedRow.Cells["Conta"].Value.ToString(), selectedRow.Cells["Assunto"].Value.ToString(), selectedRow.Cells["Corpo"].Value.ToString());
                int RemetenteID = ObterRemetenteID(MensagemID);
                int UsuarioID = SeuIDDeUsuarioLogado();
                if (MensagemID != -1)
                {
                    LerEmail lerEmailForm = new LerEmail(MensagemID, UsuarioID, RemetenteID);
                    lerEmailForm.ShowDialog();
                    // Após enviar a mensagem, recarrega a caixa de entrada, saida ou lixeira
                    if (UltimaJanela == 1)
                    {
                        CarregarCaixaDeEntrada();
                    }
                    if (UltimaJanela == 2)
                    {
                        CarregarCaixaDeSaida();
                    }
                    if (UltimaJanela == 3)
                    {
                        CarregarLixeira();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Erro ao obter detalhes da mensagem. Certifique-se de que a mensagem existe e tente novamente.");
                }
            }
        }
    }
    }
