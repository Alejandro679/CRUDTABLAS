using System.Data;
using Microsoft.Data.SqlClient;
using TiendaApp.Data;

namespace TiendaApp.Controllers
{
    public class ProductoController
    {
        /// <summary>
        /// Devuelve la información combinada de Productos y Categorias (INNER JOIN)
        /// con la estructura que espera el DataSet del informe.
        /// </summary>
        public DataTable ObtenerDatosParaReporte()
        {
            return ObtenerDatosParaReporteFiltrado(null, null, null);
        }

        /// <summary>
        /// Igual que el anterior pero con filtros opcionales (consulta parametrizada).
        /// </summary>
        public DataTable ObtenerDatosParaReporteFiltrado(int? categoriaId, decimal? precioMin, decimal? precioMax)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = Conexion.GetConnection())
            {
                string query = @"SELECT p.Id, p.Nombre, p.Precio, c.Nombre AS Categoria
                                 FROM Productos p
                                 INNER JOIN Categorias c ON p.CategoriaId = c.Id
                                 WHERE 1=1"; // 1=1 facilita concatenar condiciones AND

                if (categoriaId.HasValue && categoriaId.Value > 0)
                    query += " AND p.CategoriaId = @categoriaId";
                if (precioMin.HasValue)
                    query += " AND p.Precio >= @precioMin";
                if (precioMax.HasValue)
                    query += " AND p.Precio <= @precioMax";

                query += " ORDER BY c.Nombre, p.Nombre";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (categoriaId.HasValue && categoriaId.Value > 0)
                        cmd.Parameters.AddWithValue("@categoriaId", categoriaId.Value);
                    if (precioMin.HasValue)
                        cmd.Parameters.AddWithValue("@precioMin", precioMin.Value);
                    if (precioMax.HasValue)
                        cmd.Parameters.AddWithValue("@precioMax", precioMax.Value);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }
    }
}
