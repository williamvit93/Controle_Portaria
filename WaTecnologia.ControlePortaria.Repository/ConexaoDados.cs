using System.Configuration;
using System.Data.SqlClient;

namespace WaTecnologia.ControlePortaria.Repository
{
    public class ConexaoDados
    {
        private string connectionString;

        public ConexaoDados()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PortariaDB"].ToString();
        }

        public SqlConnection AbrirConexao()
        {
            var connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }

        public void FecharConexao(SqlConnection connection)
        {
            connection.Close();
        }
    }
}
