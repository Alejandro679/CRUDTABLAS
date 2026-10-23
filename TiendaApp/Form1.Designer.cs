namespace TiendaApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvProductos = new DataGridView();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblPrecio = new Label();
            txtPrecio = new TextBox();
            lblCategoria = new Label();
            cmbCategorias = new ComboBox();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            gbReportes = new GroupBox();
            lblFiltroCat = new Label();
            cmbFiltroCategoria = new ComboBox();
            lblMin = new Label();
            txtFiltroMin = new TextBox();
            lblMax = new Label();
            txtFiltroMax = new TextBox();
            btnVistaPrevia = new Button();
            btnReporteFiltrado = new Button();
            btnExportarPDF = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            gbReportes.SuspendLayout();
            SuspendLayout();
            //
            // dgvProductos
            //
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 12);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(860, 260);
            dgvProductos.TabIndex = 0;
            dgvProductos.CellClick += dgvProductos_CellClick;
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblNombre.Location = new Point(12, 293);
            lblNombre.Name = "lblNombre";
            lblNombre.Text = "Nombre";
            //
            // txtNombre
            //
            txtNombre.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtNombre.Location = new Point(100, 290);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(250, 23);
            txtNombre.TabIndex = 1;
            //
            // lblPrecio
            //
            lblPrecio.AutoSize = true;
            lblPrecio.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblPrecio.Location = new Point(12, 328);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Text = "Precio";
            //
            // txtPrecio
            //
            txtPrecio.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtPrecio.Location = new Point(100, 325);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(250, 23);
            txtPrecio.TabIndex = 2;
            //
            // lblCategoria
            //
            lblCategoria.AutoSize = true;
            lblCategoria.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCategoria.Location = new Point(12, 363);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Text = "Categoría";
            //
            // cmbCategorias
            //
            cmbCategorias.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cmbCategorias.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategorias.Location = new Point(100, 360);
            cmbCategorias.Name = "cmbCategorias";
            cmbCategorias.Size = new Size(250, 23);
            cmbCategorias.TabIndex = 3;
            //
            // btnGuardar
            //
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGuardar.Location = new Point(12, 405);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(80, 30);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnEditar
            //
            btnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditar.Location = new Point(98, 405);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(80, 30);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            //
            // btnEliminar
            //
            btnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEliminar.Location = new Point(184, 405);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(80, 30);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            //
            // btnLimpiar
            //
            btnLimpiar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLimpiar.Location = new Point(270, 405);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(80, 30);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            //
            // gbReportes
            //
            gbReportes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            gbReportes.Controls.Add(lblFiltroCat);
            gbReportes.Controls.Add(cmbFiltroCategoria);
            gbReportes.Controls.Add(lblMin);
            gbReportes.Controls.Add(txtFiltroMin);
            gbReportes.Controls.Add(lblMax);
            gbReportes.Controls.Add(txtFiltroMax);
            gbReportes.Controls.Add(btnVistaPrevia);
            gbReportes.Controls.Add(btnReporteFiltrado);
            gbReportes.Controls.Add(btnExportarPDF);
            gbReportes.Location = new Point(400, 283);
            gbReportes.Name = "gbReportes";
            gbReportes.Size = new Size(472, 170);
            gbReportes.TabIndex = 8;
            gbReportes.TabStop = false;
            gbReportes.Text = "Informes y filtros";
            //
            // lblFiltroCat
            //
            lblFiltroCat.AutoSize = true;
            lblFiltroCat.Location = new Point(15, 30);
            lblFiltroCat.Name = "lblFiltroCat";
            lblFiltroCat.Text = "Categoría";
            //
            // cmbFiltroCategoria
            //
            cmbFiltroCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroCategoria.Location = new Point(100, 27);
            cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            cmbFiltroCategoria.Size = new Size(200, 23);
            cmbFiltroCategoria.TabIndex = 0;
            //
            // lblMin
            //
            lblMin.AutoSize = true;
            lblMin.Location = new Point(15, 65);
            lblMin.Name = "lblMin";
            lblMin.Text = "Precio mín.";
            //
            // txtFiltroMin
            //
            txtFiltroMin.Location = new Point(100, 62);
            txtFiltroMin.Name = "txtFiltroMin";
            txtFiltroMin.Size = new Size(90, 23);
            txtFiltroMin.TabIndex = 1;
            //
            // lblMax
            //
            lblMax.AutoSize = true;
            lblMax.Location = new Point(210, 65);
            lblMax.Name = "lblMax";
            lblMax.Text = "Precio máx.";
            //
            // txtFiltroMax
            //
            txtFiltroMax.Location = new Point(290, 62);
            txtFiltroMax.Name = "txtFiltroMax";
            txtFiltroMax.Size = new Size(90, 23);
            txtFiltroMax.TabIndex = 2;
            //
            // btnVistaPrevia
            //
            btnVistaPrevia.Location = new Point(15, 110);
            btnVistaPrevia.Name = "btnVistaPrevia";
            btnVistaPrevia.Size = new Size(130, 35);
            btnVistaPrevia.TabIndex = 3;
            btnVistaPrevia.Text = "Vista previa (todo)";
            btnVistaPrevia.UseVisualStyleBackColor = true;
            btnVistaPrevia.Click += btnVistaPrevia_Click;
            //
            // btnReporteFiltrado
            //
            btnReporteFiltrado.Location = new Point(155, 110);
            btnReporteFiltrado.Name = "btnReporteFiltrado";
            btnReporteFiltrado.Size = new Size(150, 35);
            btnReporteFiltrado.TabIndex = 4;
            btnReporteFiltrado.Text = "Vista previa (filtrada)";
            btnReporteFiltrado.UseVisualStyleBackColor = true;
            btnReporteFiltrado.Click += btnReporteFiltrado_Click;
            //
            // btnExportarPDF
            //
            btnExportarPDF.Location = new Point(315, 110);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(140, 35);
            btnExportarPDF.TabIndex = 5;
            btnExportarPDF.Text = "Exportar a PDF";
            btnExportarPDF.UseVisualStyleBackColor = true;
            btnExportarPDF.Click += btnExportarPDF_Click;
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 470);
            Controls.Add(dgvProductos);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblPrecio);
            Controls.Add(txtPrecio);
            Controls.Add(lblCategoria);
            Controls.Add(cmbCategorias);
            Controls.Add(btnGuardar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(btnLimpiar);
            Controls.Add(gbReportes);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Tienda - CRUD Multitabla";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            gbReportes.ResumeLayout(false);
            gbReportes.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProductos;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblPrecio;
        private TextBox txtPrecio;
        private Label lblCategoria;
        private ComboBox cmbCategorias;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private GroupBox gbReportes;
        private Label lblFiltroCat;
        private ComboBox cmbFiltroCategoria;
        private Label lblMin;
        private TextBox txtFiltroMin;
        private Label lblMax;
        private TextBox txtFiltroMax;
        private Button btnVistaPrevia;
        private Button btnReporteFiltrado;
        private Button btnExportarPDF;
    }
}
