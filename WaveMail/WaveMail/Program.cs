using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaveMail
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WaveMail;Integrated Security=True;";
            Tabelas criadorTabela = new Tabelas(connectionString);
            criadorTabela.CriarTabelaUsuarios();
            criadorTabela.CriarTabelaMensagens();
            criadorTabela.CriarTabelaRelacionamento();

            Application.Run(new Login());
        }
    }
}
