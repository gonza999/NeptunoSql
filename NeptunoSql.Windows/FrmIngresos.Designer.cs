namespace NeptunoSql.Windows
{
    partial class FrmIngresos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabStock = new System.Windows.Forms.TabControl();
            this.tabIngresos = new System.Windows.Forms.TabPage();
            this.pickerFechaStock = new System.Windows.Forms.DateTimePicker();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.cmnMarcas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnBorrar = new System.Windows.Forms.DataGridViewImageColumn();
            this.linkProductosStock = new System.Windows.Forms.LinkLabel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMovimientos = new System.Windows.Forms.TabPage();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.pickerFechaFinalMov = new System.Windows.Forms.DateTimePicker();
            this.pickerFechaInicialMov = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tabKardex = new System.Windows.Forms.TabPage();
            this.txtMedida = new System.Windows.Forms.TextBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.dgvKardex = new System.Windows.Forms.DataGridView();
            this.pickerFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.pickerFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.linkProductosKardex = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBuscarKardex = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabStock.SuspendLayout();
            this.tabIngresos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.tabMovimientos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.tabKardex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabStock
            // 
            this.tabStock.Controls.Add(this.tabIngresos);
            this.tabStock.Controls.Add(this.tabMovimientos);
            this.tabStock.Controls.Add(this.tabKardex);
            this.tabStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabStock.Location = new System.Drawing.Point(0, 0);
            this.tabStock.Name = "tabStock";
            this.tabStock.SelectedIndex = 0;
            this.tabStock.Size = new System.Drawing.Size(661, 449);
            this.tabStock.TabIndex = 0;
            // 
            // tabIngresos
            // 
            this.tabIngresos.Controls.Add(this.pickerFechaStock);
            this.tabIngresos.Controls.Add(this.dgvDatos);
            this.tabIngresos.Controls.Add(this.linkProductosStock);
            this.tabIngresos.Controls.Add(this.btnCancelar);
            this.tabIngresos.Controls.Add(this.btnGuardar);
            this.tabIngresos.Controls.Add(this.txtEmpleado);
            this.tabIngresos.Controls.Add(this.txtReferencia);
            this.tabIngresos.Controls.Add(this.label3);
            this.tabIngresos.Controls.Add(this.label2);
            this.tabIngresos.Controls.Add(this.label1);
            this.tabIngresos.Location = new System.Drawing.Point(4, 22);
            this.tabIngresos.Name = "tabIngresos";
            this.tabIngresos.Padding = new System.Windows.Forms.Padding(3);
            this.tabIngresos.Size = new System.Drawing.Size(653, 423);
            this.tabIngresos.TabIndex = 0;
            this.tabIngresos.Text = "Ingreso de Stock";
            this.tabIngresos.UseVisualStyleBackColor = true;
            // 
            // pickerFechaStock
            // 
            this.pickerFechaStock.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pickerFechaStock.Location = new System.Drawing.Point(112, 84);
            this.pickerFechaStock.Name = "pickerFechaStock";
            this.pickerFechaStock.Size = new System.Drawing.Size(200, 20);
            this.pickerFechaStock.TabIndex = 8;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnMarcas,
            this.cmnDescripcion,
            this.cmnCantidad,
            this.cmnBorrar});
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDatos.Location = new System.Drawing.Point(3, 169);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(647, 251);
            this.dgvDatos.TabIndex = 7;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            // 
            // cmnMarcas
            // 
            this.cmnMarcas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnMarcas.HeaderText = "Marca";
            this.cmnMarcas.Name = "cmnMarcas";
            this.cmnMarcas.ReadOnly = true;
            // 
            // cmnDescripcion
            // 
            this.cmnDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnDescripcion.HeaderText = "Descripcion";
            this.cmnDescripcion.Name = "cmnDescripcion";
            this.cmnDescripcion.ReadOnly = true;
            // 
            // cmnCantidad
            // 
            this.cmnCantidad.HeaderText = "Cantidad";
            this.cmnCantidad.Name = "cmnCantidad";
            this.cmnCantidad.ReadOnly = true;
            this.cmnCantidad.Width = 65;
            // 
            // cmnBorrar
            // 
            this.cmnBorrar.HeaderText = "Borrar";
            this.cmnBorrar.Image = global::NeptunoSql.Windows.Properties.Resources.delete_20px;
            this.cmnBorrar.Name = "cmnBorrar";
            this.cmnBorrar.ReadOnly = true;
            this.cmnBorrar.Width = 40;
            // 
            // linkProductosStock
            // 
            this.linkProductosStock.AutoSize = true;
            this.linkProductosStock.Location = new System.Drawing.Point(24, 123);
            this.linkProductosStock.Name = "linkProductosStock";
            this.linkProductosStock.Size = new System.Drawing.Size(165, 13);
            this.linkProductosStock.TabIndex = 6;
            this.linkProductosStock.TabStop = true;
            this.linkProductosStock.Text = "[Click acá para ver los productos]";
            this.linkProductosStock.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkProductosStock_LinkClicked);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = global::NeptunoSql.Windows.Properties.Resources.Cancelar;
            this.btnCancelar.Location = new System.Drawing.Point(538, 104);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(101, 51);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::NeptunoSql.Windows.Properties.Resources.Aceptar;
            this.btnGuardar.Location = new System.Drawing.Point(538, 19);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(101, 51);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Location = new System.Drawing.Point(112, 47);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.Size = new System.Drawing.Size(259, 20);
            this.txtEmpleado.TabIndex = 1;
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(112, 19);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(164, 20);
            this.txtReferencia.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fecha :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Empleado :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Referencias :";
            // 
            // tabMovimientos
            // 
            this.tabMovimientos.Controls.Add(this.dgvMovimientos);
            this.tabMovimientos.Controls.Add(this.pickerFechaFinalMov);
            this.tabMovimientos.Controls.Add(this.pickerFechaInicialMov);
            this.tabMovimientos.Controls.Add(this.label4);
            this.tabMovimientos.Controls.Add(this.btnBuscar);
            this.tabMovimientos.Location = new System.Drawing.Point(4, 22);
            this.tabMovimientos.Name = "tabMovimientos";
            this.tabMovimientos.Padding = new System.Windows.Forms.Padding(3);
            this.tabMovimientos.Size = new System.Drawing.Size(653, 423);
            this.tabMovimientos.TabIndex = 1;
            this.tabMovimientos.Text = "Historico de Movimientos";
            this.tabMovimientos.UseVisualStyleBackColor = true;
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvMovimientos.Location = new System.Drawing.Point(3, 73);
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.Size = new System.Drawing.Size(647, 347);
            this.dgvMovimientos.TabIndex = 12;
            // 
            // pickerFechaFinalMov
            // 
            this.pickerFechaFinalMov.Location = new System.Drawing.Point(332, 15);
            this.pickerFechaFinalMov.Name = "pickerFechaFinalMov";
            this.pickerFechaFinalMov.Size = new System.Drawing.Size(200, 20);
            this.pickerFechaFinalMov.TabIndex = 10;
            // 
            // pickerFechaInicialMov
            // 
            this.pickerFechaInicialMov.Location = new System.Drawing.Point(113, 15);
            this.pickerFechaInicialMov.Name = "pickerFechaInicialMov";
            this.pickerFechaInicialMov.Size = new System.Drawing.Size(200, 20);
            this.pickerFechaInicialMov.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Abrir por fecha : ";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::NeptunoSql.Windows.Properties.Resources.search_40px;
            this.btnBuscar.Location = new System.Drawing.Point(547, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(98, 44);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // tabKardex
            // 
            this.tabKardex.Controls.Add(this.txtMedida);
            this.tabKardex.Controls.Add(this.txtCategoria);
            this.tabKardex.Controls.Add(this.txtMarca);
            this.tabKardex.Controls.Add(this.dgvKardex);
            this.tabKardex.Controls.Add(this.pickerFechaFinal);
            this.tabKardex.Controls.Add(this.pickerFechaInicial);
            this.tabKardex.Controls.Add(this.label10);
            this.tabKardex.Controls.Add(this.label9);
            this.tabKardex.Controls.Add(this.linkProductosKardex);
            this.tabKardex.Controls.Add(this.label8);
            this.tabKardex.Controls.Add(this.label7);
            this.tabKardex.Controls.Add(this.label6);
            this.tabKardex.Controls.Add(this.label5);
            this.tabKardex.Controls.Add(this.btnBuscarKardex);
            this.tabKardex.Location = new System.Drawing.Point(4, 22);
            this.tabKardex.Name = "tabKardex";
            this.tabKardex.Padding = new System.Windows.Forms.Padding(3);
            this.tabKardex.Size = new System.Drawing.Size(653, 423);
            this.tabKardex.TabIndex = 2;
            this.tabKardex.Text = "Kardex";
            this.tabKardex.UseVisualStyleBackColor = true;
            // 
            // txtMedida
            // 
            this.txtMedida.Location = new System.Drawing.Point(95, 104);
            this.txtMedida.Name = "txtMedida";
            this.txtMedida.Size = new System.Drawing.Size(200, 20);
            this.txtMedida.TabIndex = 16;
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(95, 77);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(200, 20);
            this.txtCategoria.TabIndex = 15;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(95, 50);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(200, 20);
            this.txtMarca.TabIndex = 14;
            // 
            // dgvKardex
            // 
            this.dgvKardex.AllowUserToAddRows = false;
            this.dgvKardex.AllowUserToDeleteRows = false;
            this.dgvKardex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKardex.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvKardex.Location = new System.Drawing.Point(322, 3);
            this.dgvKardex.Name = "dgvKardex";
            this.dgvKardex.ReadOnly = true;
            this.dgvKardex.Size = new System.Drawing.Size(328, 417);
            this.dgvKardex.TabIndex = 13;
            // 
            // pickerFechaFinal
            // 
            this.pickerFechaFinal.Location = new System.Drawing.Point(95, 182);
            this.pickerFechaFinal.Name = "pickerFechaFinal";
            this.pickerFechaFinal.Size = new System.Drawing.Size(200, 20);
            this.pickerFechaFinal.TabIndex = 10;
            // 
            // pickerFechaInicial
            // 
            this.pickerFechaInicial.Location = new System.Drawing.Point(95, 148);
            this.pickerFechaInicial.Name = "pickerFechaInicial";
            this.pickerFechaInicial.Size = new System.Drawing.Size(200, 20);
            this.pickerFechaInicial.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Fecha final :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Fecha inicial :";
            // 
            // linkProductosKardex
            // 
            this.linkProductosKardex.AutoSize = true;
            this.linkProductosKardex.Location = new System.Drawing.Point(89, 17);
            this.linkProductosKardex.Name = "linkProductosKardex";
            this.linkProductosKardex.Size = new System.Drawing.Size(165, 13);
            this.linkProductosKardex.TabIndex = 7;
            this.linkProductosKardex.TabStop = true;
            this.linkProductosKardex.Text = "[Click acá para ver los productos]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Medida :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Categoria : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Marca :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Producto :";
            // 
            // btnBuscarKardex
            // 
            this.btnBuscarKardex.Image = global::NeptunoSql.Windows.Properties.Resources.search_40px;
            this.btnBuscarKardex.Location = new System.Drawing.Point(20, 258);
            this.btnBuscarKardex.Name = "btnBuscarKardex";
            this.btnBuscarKardex.Size = new System.Drawing.Size(275, 44);
            this.btnBuscarKardex.TabIndex = 12;
            this.btnBuscarKardex.UseVisualStyleBackColor = true;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Borrar";
            this.dataGridViewImageColumn1.Image = global::NeptunoSql.Windows.Properties.Resources.delete_40px;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 65;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 449);
            this.ControlBox = false;
            this.Controls.Add(this.tabStock);
            this.Name = "FrmIngresos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmIngresos";
            this.Load += new System.EventHandler(this.FrmIngresos_Load);
            this.tabStock.ResumeLayout(false);
            this.tabIngresos.ResumeLayout(false);
            this.tabIngresos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.tabMovimientos.ResumeLayout(false);
            this.tabMovimientos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.tabKardex.ResumeLayout(false);
            this.tabKardex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabStock;
        private System.Windows.Forms.TabPage tabIngresos;
        private System.Windows.Forms.TabPage tabMovimientos;
        private System.Windows.Forms.TabPage tabKardex;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkProductosStock;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DateTimePicker pickerFechaStock;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker pickerFechaFinalMov;
        private System.Windows.Forms.DateTimePicker pickerFechaInicialMov;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvKardex;
        private System.Windows.Forms.Button btnBuscarKardex;
        private System.Windows.Forms.DateTimePicker pickerFechaFinal;
        private System.Windows.Forms.DateTimePicker pickerFechaInicial;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel linkProductosKardex;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMedida;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnMarcas;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCantidad;
        private System.Windows.Forms.DataGridViewImageColumn cmnBorrar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}