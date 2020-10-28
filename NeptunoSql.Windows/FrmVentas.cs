using Microsoft.VisualBasic;
using NeptunoSql.BusinessLayer.Entities;
using NeptunoSql.BusinessLayer.Entities.Enums;
using NeptunoSql.ServiceLayer.Servicios;
using NeptunoSql.ServiceLayer.Servicios.Facades;
using NeptunoSql.Windows.Helpers;
using NeptunoSql.Windows.Helpers.Enum;
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



        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            FrmBuscarProductoVenta frm = new FrmBuscarProductoVenta(this);
            frm.ShowDialog(this);
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            txtCodigoBarra.Enabled = false;
            servicio = new ServicioProductos();
            servicioVentas = new ServicioVentas();
            ManejarBarraHerramientasVentas(true);
            ManejarBarraHerramientasProductos(false);
            ManejarBarraHerramientasPagarVentas(false);
            ManejarBarraHerramientasFinalVentas(false);


        }


        private void ManejarBarraHerramientasFinalVentas(bool b)
        {
            tsbCancelar.Enabled = b;
            tsbFinalizar.Enabled = b;
        }

        private void ManejarBarraHerramientasPagarVentas(bool b)
        {
            tsbPagar.Enabled = b;
            tsbAnulado.Enabled = b;
        }

        private void ManejarBarraHerramientasProductos(bool b)
        {
            tsbBuscar.Enabled = b;
            tsbDescuentos.Enabled = b;
        }

        private void ManejarBarraHerramientasVentas(bool b)
        {
            tsbVenta.Enabled = b;
            tsbConsultar.Enabled = b;
            tsbCerrar.Enabled = b;
        }

        private void tsbVenta_Click(object sender, EventArgs e)
        {
            ManejarBarraHerramientasVentas(false);
            ManejarBarraHerramientasProductos(true);
            ManejarBarraHerramientasPagarVentas(false);
            ManejarBarraHerramientasFinalVentas(true);
            txtCodigoBarra.Enabled = true;
        }
        private IServicioProductos servicio;
        private void txtCodigoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (string.IsNullOrEmpty(txtCodigoBarra.Text) ||
                    string.IsNullOrWhiteSpace(txtCodigoBarra.Text))
                {
                    return;
                }
                Producto producto = servicio.GetProductoPorCodigoDeBarras(txtCodigoBarra.Text);

                if (producto == null)
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
                total += Convert.ToDecimal(r.Cells[cmnPrecioTotal.Index].Value);
            }
            return total;
        }

        private void AgregarProductoEnGrilla(Producto producto)
        {
            var r = Helper.ConstruirFila(ref dgvDatos);
            SetearFila(r, producto);
            AgregarFila(r);
            var index = InformarUltimaFilaAgregada() - 1;
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
            celdaTotal.Value = cantidadVendida * (decimal)celdaPrecio.Value;
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
            r.Cells[cmnPrecioTotal.Index].Value = producto.PrecioUnitario;
            r.Tag = producto;
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                dgvDatos.Rows.RemoveAt(e.RowIndex);
                ActualizarTotales();
            }
        }

        public void AgregarProductoEnVenta(Producto producto, decimal cantidad)
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
            InicializarControlesVenta();
        }

        private void InicializarControlesVenta()
        {
            InicializarGrilla();
            InicializarTotales();
            ManejarBarraHerramientasVentas(true);
            ManejarBarraHerramientasProductos(false);
            ManejarBarraHerramientasPagarVentas(false);
            ManejarBarraHerramientasFinalVentas(false);

            txtCodigoBarra.Enabled = false;
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
        private IServicioVentas servicioVentas;
        private int ventaId = 0;
        private void tsbFinalizar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count == 0)
            {
                return;
            }
            Venta venta = new Venta();
            venta.Fecha = DateTime.Now;
            venta.SubTotal = CalcularTotal();
            venta.Descuentos = CalcularTotalDescuentos();
            venta.Total = venta.SubTotal - venta.Descuentos;
            venta.Estado = EstadoVenta.EnProceso;
            venta.DetalleVentas = CargarDetalleVentas();
            try
            {
                servicioVentas.Guardar(venta);
                ventaId = venta.VentaId;//Para anular o pagar la venta
                Helper.MensajeBox($"Venta número {venta.VentaId} guardada", Tipo.Success);

                ManejarBarraHerramientasFinalVentas(false);
                ManejarBarraHerramientasVentas(false);
                ManejarBarraHerramientasProductos(false);
                ManejarBarraHerramientasPagarVentas(true);

            }
            catch (Exception ex)
            {
                Helper.MensajeBox(ex.Message, Tipo.Error);
            }
        }

        private List<DetalleVenta> CargarDetalleVentas()
        {
            List<DetalleVenta> detalleVentas = new List<DetalleVenta>();
            foreach (DataGridViewRow r in dgvDatos.Rows)
            {
                DetalleVenta detalleVenta = new DetalleVenta();
                detalleVenta.Producto = (Producto)r.Tag;
                detalleVenta.PrecioUnitario = (decimal)r.Cells[cmnPrecioUnitario.Index].Value;
                detalleVenta.Cantidad = (decimal)r.Cells[cmnCantidad.Index].Value;
                detalleVenta.Descuento = Convert.ToDecimal(r.Cells[cmnDescuento.Index].Value);
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
                total += Convert.ToDecimal(r.Cells[cmnDescuento.Index].Value);
            }
            return total;
        }

        private void tsbPagar_Click(object sender, EventArgs e)
        {
            FrmPago frm = new FrmPago();
            frm.Text = "Pago de Venta";
            var importeVenta = servicioVentas.GetTotalVenta(ventaId);
            frm.SetImporteYVenta(importeVenta, ventaId);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    servicioVentas.FacturarVenta(ventaId);
                    Helper.MensajeBox($"Venta número {ventaId} facturada", Tipo.Success);
                    InicializarControlesVenta();
                    ventaId = 0;
                }
                catch (Exception ex)
                {
                    Helper.MensajeBox(ex.Message, Tipo.Error);
                }
            }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbAnulado_Click(object sender, EventArgs e)
        {
            ManejarBarraHerramientasFinalVentas(true);
            ManejarBarraHerramientasVentas(false);
            ManejarBarraHerramientasProductos(false);
            ManejarBarraHerramientasPagarVentas(false);
        }
    }
}
