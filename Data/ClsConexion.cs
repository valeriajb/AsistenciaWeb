using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace AsistenciaHuellaWeb.Data
{
    public class ClsConexion
    {
        private string CadenaSql = string.Empty;

        public ClsConexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            CadenaSql = builder.GetSection("ConnectionStrings:CadenaSql").Value;
        }

        public SqlConnection GetCadenaSql()
        {
            SqlConnection conexionSql = new SqlConnection(CadenaSql);
            conexionSql.Open();
            return conexionSql;
        }
    }
}
