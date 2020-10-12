using Microsoft.VisualBasic;
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
    public partial class frmBuscarProductoVenta : Form
    {
        private FrmVentas frm;
        public frmBuscarProductoVenta(FrmVentas frm)
        {
            this.frm = frm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private IServicioProductos servicio = new ServicioProductos();
        private void frmBuscarProductoVenta_Load(object sender, EventArgs e)
        {
            CargarDatosEnGrilla();
        }
        List<Producto> lista;
        private void CargarDatosEnGrilla()
        {
            lista = servicio.GetLista();
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
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
            r.Cells[cmnCategoria.Index].Value = p.Categoria.NombreCategoria;
            r.Cells[cmnPrecio.Index].Value = p.PrecioUnitario;
            r.Cells[cmnCantidad.Index].Value = p.Stock;
            r.Tag = p;
        }
        Producto producto;
        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==4)
            {
                DataGridViewRow r = dgvDatos.Rows[e.RowIndex];
                producto =(Producto) r.Tag;
                var cantidad = Interaction.InputBox("Ingrese la cantidad vendida",
                    "Ingreso de cantidad", "1", Screen.PrimaryScreen.WorkingArea.Bottom / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);
                if (!decimal.TryParse(cantidad, out decimal cantidadVendida))
                {
                    return;
                }
                else if (cantidadVendida <= 0 || cantidadVendida >producto.Stock)
                {
                    //TODO: Se puede sacar un msj de error
                    return;
                }
                frm.AgregarProductoEnVenta(producto,cantidadVendida);
            }
        }
    }
}
