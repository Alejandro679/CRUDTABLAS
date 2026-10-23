using Microsoft.Data.SqlClient;

namespace TiendaApp.Data
{
    /// <summary>
    /// Si no existe TiendaDB.mdf junto al ejecutable, lo crea con las tablas
    /// Categorias y Productos (mismo esquema del ejercicio) y lo deja desasociado
    /// para que luego se adjunte con AttachDbFilename.
    /// Si ya copió su propio TiendaDB.mdf (creado desde Visual Studio), no hace nada.
    /// </summary>
    public static class DbInicializador
    {
        public static void Inicializar()
        {
            string ruta = Conexion.RutaMdf;
            if (File.Exists(ruta)) return;

            string nombreTemporal = "TiendaDB_" + Guid.NewGuid().ToString("N");
            string masterCs = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True;Pooling=False";

            using var conn = new SqlConnection(masterCs);
            conn.Open();

            Ejecutar(conn, $"CREATE DATABASE [{nombreTemporal}] ON (NAME = N'TiendaDB', FILENAME = N'{ruta.Replace("'", "''")}')");
            Ejecutar(conn, $"USE [{nombreTemporal}]");

            Ejecutar(conn, @"
CREATE TABLE [dbo].[Categorias] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Nombre] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)");

            Ejecutar(conn, @"
CREATE TABLE [dbo].[Productos] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]      NVARCHAR (100) NOT NULL,
    [Precio]      DECIMAL (18, 2) NOT NULL,
    [CategoriaId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Productos_Categorias] FOREIGN KEY ([CategoriaId]) REFERENCES [dbo].[Categorias] ([Id]) ON DELETE CASCADE
)");

            Ejecutar(conn, "USE [master]");
            Ejecutar(conn, $"EXEC sp_detach_db @dbname = N'{nombreTemporal}'");
        }

        private static void Ejecutar(SqlConnection conn, string sql)
        {
            using var cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
