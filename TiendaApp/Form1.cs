using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using TiendaApp.Controllers;
using TiendaApp.Data;
using TiendaApp.Models;

namespace TiendaApp
{
    public partial class Form1 : Form
    {
        private TiendaContext _context = null!;
        private int _productoIdSeleccionado = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Crea TiendaDB.mdf junto al ejecutable si todavía no existe
                DbInicializador.Inicializar();
                _context = new TiendaContext();

                CargarCategorias();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con la base de datos local (LocalDB):\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- MÉTODOS DE SOPORTE ---
        private void CargarCategorias()
        {
            // Insertar datos de prueba en categorías si está vacío
            if (!_context.Categorias.Any())
            {
                _context.Categorias.AddRange(
                    new Categoria { Nombre = "Electrónica" },
                    new Categoria { Nombre = "Ropa" }
                );
                _context.SaveChanges();
            }

            var categorias = _context.Categorias.AsNoTracking().OrderBy(c => c.Nombre).ToList();

            cmbCategorias.DataSource = categorias.ToList();
            cmbCategorias.DisplayMember = "Nombre";
            cmbCategorias.ValueMember = "Id";

            // Combo del filtro: incluye la opción "Todas" (Id = 0)
            var filtro = new List<Categoria> { new Categoria { Id = 0, Nombre = "Todas" } };
            filtro.AddRange(categorias);
            cmbFiltroCategoria.DataSource = filtro;
            cmbFiltroCategoria.DisplayMember = "Nombre";
            cmbFiltroCategoria.ValueMember = "Id";
        }

        private void CargarProductos()
        {
            // READ: carga productos incluyendo los datos de la tabla relacionada Categorias
            var productos = _context.Productos
                .AsNoTracking()
                .Include(p => p.Categoria)
                .Select(p => new
                {
                    p.Id,
                    Producto = p.Nombre,
                    p.Precio,
                    Categoria = p.Categoria.Nombre,
                    p.CategoriaId
                }).ToList();

            dgvProductos.DataSource = productos;

            // Ocultar columna de ID de categoría
            if (dgvProductos.Columns["CategoriaId"] != null)
                dgvProductos.Columns["CategoriaId"]!.Visible = false;
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            if (cmbCategorias.Items.Count > 0)
                cmbCategorias.SelectedIndex = 0;
            _productoIdSeleccionado = 0;
            btnGuardar.Text = "Guardar";
        }

        // --- ACCIONES CRUD ---

        // CREATE / UPDATE
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                !decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Por favor, rellene los campos correctamente.");
                return;
            }

            if (cmbCategorias.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una categoría.");
                return;
            }

            if (_productoIdSeleccionado == 0)
            {
                // CREATE
                var nuevoProducto = new Producto
                {
                    Nombre = txtNombre.Text.Trim(),
                    Precio = precio,
                    CategoriaId = (int)cmbCategorias.SelectedValue
                };
                _context.Productos.Add(nuevoProducto);
            }
            else
            {
                // UPDATE
                var productoExistente = _context.Productos.Find(_productoIdSeleccionado);
                if (productoExistente != null)
                {
                    productoExistente.Nombre = txtNombre.Text.Trim();
                    productoExistente.Precio = precio;
                    productoExistente.CategoriaId = (int)cmbCategorias.SelectedValue;
                }
            }

            _context.SaveChanges();
            CargarProductos();
            LimpiarFormulario();
            MessageBox.Show("Operación realizada con éxito.");
        }

        // Seleccionar registro para editar desde el DataGridView
        private void dgvProductos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                CargarFilaEnFormulario(dgvProductos.Rows[e.RowIndex]);
        }

        private void CargarFilaEnFormulario(DataGridViewRow row)
        {
            _productoIdSeleccionado = Convert.ToInt32(row.Cells["Id"].Value);
            txtNombre.Text = row.Cells["Producto"].Value?.ToString();
            txtPrecio.Text = row.Cells["Precio"].Value?.ToString();
            cmbCategorias.SelectedValue = Convert.ToInt32(row.Cells["CategoriaId"].Value);

            btnGuardar.Text = "Actualizar";
        }

        // Botón Editar: carga la fila seleccionada en los campos para modificarla
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto de la lista para editar.");
                return;
            }
            CargarFilaEnFormulario(dgvProductos.CurrentRow);
        }

        // DELETE
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_productoIdSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un producto de la lista para eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro de eliminar este producto?",
                "Confirmar", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                var producto = _context.Productos.Find(_productoIdSeleccionado);
                if (producto != null)
                {
                    _context.Productos.Remove(producto);
                    _context.SaveChanges();
                    CargarProductos();
                    LimpiarFormulario();
                    MessageBox.Show("Producto eliminado.");
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        // =====================  INFORMES  =====================

        // Vista previa del informe completo (sin filtros)
        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            var controller = new ProductoController();
            DataTable datos = controller.ObtenerDatosParaReporte();

            if (datos != null && datos.Rows.Count > 0)
            {
                var visor = new FormReporte(datos, "Sin filtros (todos los productos)");
                visor.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay datos disponibles para mostrar en el reporte.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Vista previa con filtros dinámicos (categoría + rango de precios)
        private void btnReporteFiltrado_Click(object sender, EventArgs e)
        {
            ObtenerFiltros(out int? categoriaId, out decimal? precioMin, out decimal? precioMax, out string descripcion);

            var controller = new ProductoController();
            DataTable datosFiltrados = controller.ObtenerDatosParaReporteFiltrado(categoriaId, precioMin, precioMax);

            if (datosFiltrados != null && datosFiltrados.Rows.Count > 0)
            {
                var visor = new FormReporte(datosFiltrados, descripcion);
                visor.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se encontraron productos que coincidan con los filtros seleccionados.",
                    "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Exporta directamente a PDF (respeta los filtros indicados)
        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                ObtenerFiltros(out int? categoriaId, out decimal? precioMin, out decimal? precioMax, out string descripcion);

                var controller = new ProductoController();
                DataTable datos = controller.ObtenerDatosParaReporteFiltrado(categoriaId, precioMin, precioMax);

                if (datos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Configurar el reporte en memoria (sin controles visuales)
                var reporteLocal = new LocalReport();
                reporteLocal.ReportPath = Path.Combine(Application.StartupPath, "InformeProductos.rdlc");

                reporteLocal.SetParameters(new[] { new ReportParameter("FiltroUsuario", descripcion) });

                var rds = new ReportDataSource("DataSetProductos", datos);
                reporteLocal.DataSources.Clear();
                reporteLocal.DataSources.Add(rds);

                // Renderizar a PDF (arreglo de bytes)
                byte[] bytesPdf = reporteLocal.Render("PDF");

                using var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Archivos PDF (*.pdf)|*.pdf",
                    FileName = "Reporte_Productos_y_Categorias.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, bytesPdf);
                    MessageBox.Show("¡PDF generado y guardado con éxito!", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Captura los filtros de la interfaz y arma el texto para el encabezado del informe
        private void ObtenerFiltros(out int? categoriaId, out decimal? precioMin, out decimal? precioMax, out string descripcion)
        {
            categoriaId = null;
            if (cmbFiltroCategoria.SelectedValue != null)
            {
                int id = Convert.ToInt32(cmbFiltroCategoria.SelectedValue);
                if (id > 0) categoriaId = id;
            }

            precioMin = null;
            if (!string.IsNullOrWhiteSpace(txtFiltroMin.Text) && decimal.TryParse(txtFiltroMin.Text, out decimal pMin))
                precioMin = pMin;

            precioMax = null;
            if (!string.IsNullOrWhiteSpace(txtFiltroMax.Text) && decimal.TryParse(txtFiltroMax.Text, out decimal pMax))
                precioMax = pMax;

            string nombreCategoria = categoriaId.HasValue ? cmbFiltroCategoria.Text : "Todas";
            string txtMinInfo = precioMin.HasValue ? $"${precioMin.Value}" : "Mínimo";
            string txtMaxInfo = precioMax.HasValue ? $"${precioMax.Value}" : "Máximo";
            descripcion = $"Categoría: {nombreCategoria} | Rango Precios: ({txtMinInfo} - {txtMaxInfo})";
        }
    }
}
