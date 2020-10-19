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
    public partial class FrmVentas : Form
    {
        public FrmVentas()
        {
            InitializeComponent();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            FrmBuscarProductoVenta frm = new FrmBuscarProductoVenta(this);
            frm.ShowDialog(this);
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            ManejarBarraHerramientas(true);
            txtCodigoBarra.Enabled = false;
            servicio = new ServicioProductos();
        }

        private void ManejarBarraHerramientas(bool v)
        {
            tsbVenta.Enabled = v;
            tsbCancelar.Enabled = !v;
            tsbFinalizar.Enabled = !v;
            tsbBuscar.Enabled = !v;
            tsbCerrar.Enabled = v;
            tsbDescuentos.Enabled = !v;
            //tsbPagar.Enabled = v;
            tsbConsultar.Enabled = v;
        }

        private void tsbVenta_Click(object sender, EventArgs e)
        {
            ManejarBarraHerramientas(false);
            txtCodigoBarra.Enabled = true;
        }
        private IServicioProductos servicio;
        private void txtCodigoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==Convert.ToChar(Keys.Enter))
            {
                if (string.IsNullOrEmpty(txtCodigoBarra.Text) ||
                    string.IsNullOrWhiteSpace(txtCodigoBarra.Text))
                {
                    return;
                }
                Producto producto=servicio.GetProductoPorCodigoDeBarras(txtCodigoBarra.Text);

                if (producto==null)
                {
                    //TODO: Se puede sacar un msj de error
                    return;
                }
                AgregarProductoEnGrilla(producto);
                ActualizarTotales();
                txtCodigoBarra.Clear();
            }
        }

        private void ActualizarTotales()
        {
            decimal total = CalcularTotal();
            txtSubtotal.Text = total.ToString("# $");
            txtTotal.Text = total.ToString("# $");
            lblTotal.Text = total.ToString("# $");

        }

        private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow r in dgvDatos.Rows)
            {
                total +=(decimal) r.Cells[cmnPrecioTotal.Index].Value;
            }
            return total;
        }

        private void AgregarProductoEnGrilla(Producto producto)
        {
            var r = Helper.ConstruirFila(ref dgvDatos);
            SetearFila(r,producto);
            AgregarFila(r);
            var index = InformarUltimaFilaAgregada()-1;
            IngresarCantidad(index);
        }

        private void IngresarCantidad(int index)
        {
            var cantidad = Interaction.InputBox("Ingrese la cantidad vendida",
                     "Ingreso de cantidad", "1", Screen.PrimaryScreen.WorkingArea.Bottom / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);
            if (!decimal.TryParse(cantidad, out decimal cantidadVendida))
            {
                return;
            }
            else if (cantidadVendida <= 0 || cantidadVendida >= int.MaxValue)
            {
                //TODO: Hacer el control de la cantidad que se vende por el stock
                return;
            }
            DataGridViewCell celdaCantidad = dgvDatos.Rows[index].Cells[cmnCantidad.Index];
            celdaCantidad.Value = cantidadVendida;
            DataGridViewCell celdaPrecio = dgvDatos.Rows[index].Cells[cmnPrecioUnitario.Index];
            DataGridViewCell celdaTotal = dgvDatos.Rows[index].Cells[cmnPrecioTotal.Index];
            celdaTotal.Value = cantidadVendida*(decimal)celdaPrecio.Value;
        }

        private int InformarUltimaFilaAgregada()
        {
            return dgvDatos.Rows.Count;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Producto producto)
        {
            r.Cells[cmnProducto.Index].Value = producto.ToString();
            r.Cells[cmnPrecioUnitario.Index].Value = producto.PrecioUnitario;
            r.Cells[cmnCantidad.Index].Value = 1;
            r.Cells[cmnDescuento.Index].Value = 0;
            r.Cells[cmnPrecioTotal.Index].Value =producto.PrecioUnitario;
            r.Tag = producto;
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==5)
            {
                dgvDatos.Rows.RemoveAt(e.RowIndex);
                ActualizarTotales();
            }
        }

        public void AgregarProductoEnVenta(Producto producto,decimal cantidad)
        {
            var r = Helper.ConstruirFila(ref dgvDatos);
            SetearFila(r, producto);
            AgregarFila(r);
            r.Cells[cmnCantidad.Index].Value = cantidad;
            r.Cells[cmnPrecioTotal.Index].Value = cantidad * producto.PrecioUnitario;
            ActualizarTotales();
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            CancelarVenta();
        }

        private void CancelarVenta()
        {
            InicializarGrilla();
            InicializarTotales();
            ManejarBarraHerramientas(true);
        }

        private void InicializarTotales()
        {
            txtTotal.Clear();
            txtSubtotal.Clear();
            txtDescuentos.Clear();
            lblTotal.Text = "0,00";
            txtCodigoBarra.Enabled = false;
        }

        private void InicializarGrilla()
        {
            dgvDatos.Rows.Clear();
        }

        private void tsbFinalizar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count==0)
            {
                return;
            }
            Venta venta = new Venta();
            venta.Fecha = DateTime.Now;
            venta.SubTotal = CalcularTotal();
            venta.Descuentos = CalcularTotalDescuentos();
            venta.Total = venta.SubTotal - venta.Descuentos;
            venta.DetalleVentas = CargarDetalleVentas();
        }

        private List<DetalleVenta> CargarDetalleVentas()
        {
            List<DetalleVenta> detalleVentas = new List<DetalleVenta>();
            foreach (DataGridViewRow r in dgvDatos.Rows)
            {
                DetalleVenta detalleVenta = new DetalleVenta();
                detalleVenta.Producto =(Producto) r.Tag;
                detalleVenta.PrecioUnitario =(decimal) r.Cells[cmnPrecioUnitario.Index].Value;
                detalleVenta.Cantidad = (decimal)r.Cells[cmnCantidad.Index].Value;
                detalleVenta.Descuento = (decimal)r.Cells[cmnDescuento.Index].Value;
                detalleVenta.Total = (decimal)r.Cells[cmnPrecioTotal.Index].Value;

                detalleVentas.Add(detalleVenta);
            }
            return detalleVentas;
        }

        private decimal CalcularTotalDescuentos()
        {
            decimal total = 0;
            foreach (DataGridViewRow r in dgvDatos.Rows)
            {
                total += (decimal)r.Cells[cmnDescuento.Index].Value;
            }
            return total;
        }
    }
}
