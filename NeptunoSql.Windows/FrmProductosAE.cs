using NeptunoSql.BusinessLayer;
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
    public partial class FrmProductosAE : Form
    {
        public FrmProductosAE()
        {
            InitializeComponent();
        }
        private FrmProductos frm;
        public FrmProductosAE(FrmProductos frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        private IServicioProductos servicioProductos = new ServicioProductos();
        private IServicioCategorias servicioCategorias = new ServicioCategorias();
        private IServicioMedidas servicioMedidas = new ServicioMedidas();

        private readonly string imagenNoDisponible = Application.StartupPath + "\\Imagenes\\"+ "Imagen no disponible.png";
        private readonly string archivoNoEncontrado = Application.StartupPath + "\\Imagenes\\" + "Error.png";
        private readonly string rutaCarpetaImagenes = Application.StartupPath + "\\Imagenes\\";
        private string rutaDelArchivo = ""; 
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarMarcaComboBox(ref cmbMarca);
            Helper.CargarCategoriaComboBox(ref cmbCategoria);
            Helper.CargarMedidaComboBox(ref cmbMedida);

            if (producto!=null)
            {
                txtCodigoDeBarras.Text = producto.CodigoBarra;
                txtDescripcion.Text = producto.Descripcion;
                txtPrecioDeVenta.Text = producto.PrecioUnitario.ToString();
                ckbSuspendido.Checked = producto.Suspendido;
                cmbCategoria.SelectedValue = producto.Categoria.CategoriaId;
                cmbMarca.SelectedValue = producto.Marca.MarcaId;
                cmbMedida.SelectedValue = producto.Medida.MedidaId;
                if (producto.Imagen!=null)
                {
                    try
                    {
                        pbxProducto.Image = Image.FromFile(producto.Imagen);
                    }
                    catch (Exception)
                    {
                        pbxProducto.Image = Image.FromFile(archivoNoEncontrado);
                        
                    }
                }
                else
                {
                    pbxProducto.Image = Image.FromFile(imagenNoDisponible);
                }
            }
        }

        private Producto producto;
        private IServicioProductos servicio=new ServicioProductos();
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            FrmProductosAE frm = new FrmProductosAE();
            frm.Text = "Agregar Producto";
            frm.ShowDialog(this);
            Helper.CargarMarcaComboBox(ref cmbMarca);
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            FrmCategoriasAE frm = new FrmCategoriasAE();
            frm.Text = "Agregar Categoria";
            frm.ShowDialog(this);
            Helper.CargarCategoriaComboBox(ref cmbCategoria);
        }

        private void btnMedida_Click(object sender, EventArgs e)
        {
            FrmMedidasAE frm = new FrmMedidasAE();
            frm.Text = "Agregar Medida";
            frm.ShowDialog(this);
            Helper.CargarMedidaComboBox(ref cmbMedida);
        }
        private bool esEdicion = false;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {

                if (producto == null)
                {
                    producto = new Producto();
                }

                producto.Categoria =(Categoria) cmbCategoria.SelectedItem;
                producto.Medida = cmbMedida.SelectedItem as Medida;
                producto.Marca = (Marca)cmbMarca.SelectedItem;
                producto.CodigoBarra = txtCodigoDeBarras.Text;
                producto.Descripcion = txtDescripcion.Text;
                producto.PrecioUnitario =decimal.Parse(txtPrecioDeVenta.Text);
                producto.Suspendido = ckbSuspendido.Checked;
                if (!string.IsNullOrEmpty(rutaDelArchivo))
                {
                    producto.Imagen = rutaDelArchivo;
                }
                else
                {
                    producto.Imagen = imagenNoDisponible;
                }

                if (ValidarObjeto())
                {
                    if (!esEdicion)
                    {
                        servicio.Guardar(producto);
                        if (frm != null)
                        {
                            frm.AgregarFila(producto);
                        }
                        Helper.MensajeBox("Registro guardado", Tipo.Success);
                        DialogResult dr = MessageBox.Show("Desea agregar otro registro?", "Confirmar",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.No)
                        {
                            DialogResult = DialogResult.Cancel;
                        }
                        else
                        {
                            InicializarControles();
                        }
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                    }

                }
            }

        }

        internal Producto GetProducto()
        {
            return producto;
        }

        internal void SetProducto(Producto producto)
        {
            this.producto=producto;
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;

            if (string.IsNullOrEmpty(txtDescripcion.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtDescripcion.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtDescripcion, "Debe ingresar un descripción");
            }
            if (!decimal.TryParse((txtPrecioDeVenta.Text),out decimal precio))
            {
                valido = false;
                errorProvider1.SetError(txtPrecioDeVenta, "Debe ingresar un precio de venta");
            }
            else if (precio<=0 || precio>int.MaxValue)
            {
                valido = false;
                errorProvider1.SetError(txtPrecioDeVenta, "Debe ingresar un precio valido,fuera del rango permitido");

            }
            if (cmbCategoria.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(cmbCategoria, "Debe seleccionar una categoria");

            }
            if (cmbMarca.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cmbMarca, "Debe seleccionar una marca");

            }
            if (cmbMedida.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cmbMedida, "Debe seleccionar una medida");

            }

            return valido;
        }

        private void InicializarControles()
        {
            txtCodigoDeBarras.Clear();
            txtDescripcion.Focus();
            txtPrecioDeVenta.Focus();
            producto = null;
        }

        private bool ValidarObjeto()
        {
            errorProvider1.Clear();
            bool valido = true;
            //if (servicio.Existe(producto))
            //{
            //    errorProvider1.SetError(txtDescripcion, "Descripcion repetida");
            //    valido = false;
            //}
            return valido;
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            FrmMarcasAE frm = new FrmMarcasAE();
            frm.Text = "Agregar Marca";
            frm.ShowDialog(this);
            Helper.CargarMarcaComboBox(ref cmbMarca);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.InitialDirectory = Application.StartupPath + @"\Imagenes";
            openFileDialog.Filter = "Imagenes (*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files(*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            DialogResult dr = openFileDialog.ShowDialog(this);
            if (dr==DialogResult.OK)
            {
                pbxProducto.Image = Image.FromFile(openFileDialog.FileName);
                rutaDelArchivo = openFileDialog.FileName;
            }
        }
    }
}
