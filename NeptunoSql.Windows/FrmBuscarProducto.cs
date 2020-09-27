using NeptunoSql.BusinessLayer.Entities;
using NeptunoSql.ServiceLayer.Servicios;
using NeptunoSql.ServiceLayer.Servicios.Facades;
using NeptunoSql.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeptunoSql.Windows
{
    public partial class FrmBuscarProducto : Form
    {
        public FrmBuscarProducto()
        {
            InitializeComponent();
        }

        public FrmBuscarProducto(FrmIngresos frm)
        {
            this.frm = frm;
            InitializeComponent();
        }

        private readonly IServicioProductos servicioProductos=new ServicioProductos();
        private FrmIngresos frm;

        private void FrmBuscarProducto_Load(object sender, EventArgs e)
        {
            CargarProductosEnGrilla();
            Helper.CargarCategoriaComboBox(ref cmbCategoria);
            Helper.CargarMedidaComboBox(ref cmbMedida);
        }

        private void CargarProductosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            List<Producto> lista=servicioProductos.GetLista();
            foreach (var p in lista)
            {
                var r = Helper.ConstruirFila(ref dgvDatos);
                SetearFila(r,p);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Producto p)
        {
            r.Cells[cmnProducto.Index].Value = p.ToString();
            r.Tag = p;
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex!=1)
            {
                return;
            }
            DataGridViewRow r = dgvDatos.Rows[e.RowIndex];
            Producto p =(Producto) r.Tag;
            frm.AgregarFila(p);
        }
    }
}
