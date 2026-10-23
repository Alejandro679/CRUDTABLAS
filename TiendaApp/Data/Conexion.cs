using Microsoft.Data.SqlClient;

namespace TiendaApp.Data
{
    /// <summary>
    /// Centraliza la cadena de conexión hacia TiendaDB.mdf (LocalDB).
    /// Se usa tanto en Entity Framework Core como en ADO.NET (informes).
    /// </summary>
    public static class Conexion
    {
        public static string RutaMdf =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TiendaDB.mdf");

        public static string ConnectionString =>
            $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={RutaMdf};Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
