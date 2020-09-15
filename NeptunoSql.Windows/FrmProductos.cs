using NeptunoSql.BusinessLayer.Entities;
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
    public partial class FrmProductos : Form
    {
        private IServicioProductos servicio;
        private List<Producto> lista;
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void MostrarDatosEnGrilla()
        {
            DgvDatos.Rows.Clear();
            foreach (var producto in lista)
            {
                AgregarFila(producto);
            }
        }

        public void AgregarFila(Producto producto)
        {
            var r = ConstruirFila();
            SetearFila(r, producto);
            AgregarFila(r);
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Producto producto)
        {
            r.Cells[cmnCategoria.Index].Value = producto.Categoria.NombreCategoria;
            r.Cells[cmnDescripcion.Index].Value = producto.Descripcion;
            r.Cells[cmnMarca.Index].Value = producto.Marca.NombreMarca;
            r.Cells[cmnPUnitario.Index].Value = producto.PrecioUnitario;
            r.Cells[cmnStock.Index].Value = producto.Stock;
            r.Cells[cmnSuspendido.Index].Value = producto.Suspendido;
            r.Tag = producto;
        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(DgvDatos);
            return r;
        }
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void Actualizar()
        {
            try
            {
                servicio = new ServicioProductos();
                lista = servicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {
                Helper.MensajeBox(ex.Message,Tipo.Error);
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmProductosAE frm = new FrmProductosAE();
            frm.Text = "Agregar Producto";
            frm.ShowDialog(this);
        }
    }
}
