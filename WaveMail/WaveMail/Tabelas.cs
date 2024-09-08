using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveMail
{
    /// <summary>
    /// Cria as tabelas automaticamente, exige que um Database de nome "WaveMail" exista
    /// </summary>
    public class Tabelas
        {
            private string connectionString;

            public Tabelas(string connectionString)
            {
                this.connectionString = connectionString;
            }

            public void CriarTabelaUsuarios()
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Verifique se a tabela já existe
                    string verificaTabelaQuery = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Usuarios') " +
                                                "BEGIN " +
                                                "CREATE TABLE Usuarios (ID INT PRIMARY KEY IDENTITY(1,1), Usuario NVARCHAR(50) NOT NULL, Senha NVARCHAR(50) NOT NULL); " +
                                                "END";

                    using (SqlCommand command = new SqlCommand(verificaTabelaQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }

            public void CriarTabelaMensagens()
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Verifique se a tabela já existe
                    string verificaTabelaQuery = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Mensagens') " +
                                                "BEGIN " +
                                                "CREATE TABLE Mensagens (ID INT PRIMARY KEY IDENTITY(1,1), RemetenteID INT NULL, DestinatarioID INT NULL, Assunto NVARCHAR(100) NOT NULL, Corpo NVARCHAR(MAX) NOT NULL, NaLixeiraR BIT DEFAULT ((0)) NULL, NaLixeiraD BIT DEFAULT ((0)) NULL, DeletadoR BIT DEFAULT ((0)) NULL, DeletadoD BIT DEFAULT ((0)) NULL, LidoR BIT DEFAULT ((0)) NULL, LidoD BIT DEFAULT ((0)) NULL, " +
                                                "CONSTRAINT FK_Sender FOREIGN KEY (RemetenteID) REFERENCES Usuarios(ID), " +
                                                "CONSTRAINT FK_Receiver FOREIGN KEY (DestinatarioID) REFERENCES Usuarios(ID)); " +
                                                "END";

                    using (SqlCommand command = new SqlCommand(verificaTabelaQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }

            public void CriarTabelaRelacionamento()
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Verifique se a tabela já existe
                    string verificaTabelaQuery = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UsuarioMensagemRelacionamento') " +
                                                "BEGIN " +
                                                "CREATE TABLE UsuarioMensagemRelacionamento (ID INT PRIMARY KEY IDENTITY(1,1), UsuarioID INT NULL, MensagemID INT NULL, Destinatario NVARCHAR(50) NOT NULL, Entrada BIT DEFAULT ((0)) NULL, Saida BIT DEFAULT ((0)) NULL, " +
                                                "CONSTRAINT FK_User FOREIGN KEY (UsuarioID) REFERENCES Usuarios(ID), " +
                                                "CONSTRAINT FK_Message FOREIGN KEY (MensagemID) REFERENCES Mensagens(ID)); " +
                                                "END";

                    using (SqlCommand command = new SqlCommand(verificaTabelaQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }

