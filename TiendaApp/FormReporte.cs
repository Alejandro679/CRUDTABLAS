using System.Data;
using Microsoft.Reporting.WinForms;

namespace TiendaApp
{
    public partial class FormReporte : Form
    {
        // Datos combinados de las tablas y texto descriptivo del filtro
        private readonly DataTable _datosReporte;
        private readonly string _descripcionFiltro;

        public FormReporte(DataTable datos, string descripcionFiltro)
        {
            InitializeComponent();
            _datosReporte = datos;
            _descripcionFiltro = descripcionFiltro;
        }

        private void FormReporte_Load(object? sender, EventArgs e)
        {
            try
            {
                // 1. Limpiar configuraciones previas del visor
                reportViewer1.LocalReport.DataSources.Clear();

                // 2. Ruta del archivo de diseño .rdlc (se copia al directorio de salida)
                reportViewer1.LocalReport.ReportPath =
                    Path.Combine(Application.StartupPath, "InformeProductos.rdlc");

                // 3. Parámetro definido en el RDLC
                reportViewer1.LocalReport.SetParameters(new[]
                {
                    new ReportParameter("FiltroUsuario", _descripcionFiltro)
                });

                // 4. Vincular el DataTable ("DataSetProductos" = nombre del dataset en el RDLC)
                var rds = new ReportDataSource("DataSetProductos", _datosReporte);
                reportViewer1.LocalReport.DataSources.Add(rds);

                // 5. Renderizar el reporte
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la vista previa: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
