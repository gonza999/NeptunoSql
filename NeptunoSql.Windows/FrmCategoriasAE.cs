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
    public partial class FrmCategoriasAE : Form
    {
        private FrmCategorias frmCategorias;

        public FrmCategoriasAE(FrmCategorias frmCategorias)
        {
            InitializeComponent();
            this.frmCategorias = frmCategorias;
        }

        public FrmCategoriasAE()
        {
            InitializeComponent();
            frmCategorias = null;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            servicio = new ServicioCategorias();
            if (categoria != null)
            {
                txtCategoria.Text = categoria.NombreCategoria;
                txtDescripcion.Text = categoria.Descripcion;
                esEdicion = true;
            }
        }
        private IServicioCategorias servicio;
        private Categoria categoria;
        private bool esEdicion = false;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (categoria == null)
                {
                    categoria = new Categoria();
                }
                categoria.NombreCategoria = txtCategoria.Text;
                categoria.Descripcion = txtDescripcion.Text;
                if (!esEdicion)
                {
                    try
                    {
                        servicio.Guardar(categoria);
                        if (frmCategorias != null)
                        {
                            frmCategorias.AgregarFila(categoria);

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
                    catch (Exception ex)
                    {
                        Helper.MensajeBox(ex.Message, Tipo.Error);
                    }
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void InicializarControles()
        {
            txtCategoria.Clear();
            txtDescripcion.Clear();
            txtCategoria.Focus();
            categoria = null;
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtCategoria.Text) ||
                string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCategoria, "Debe ingresar una categoria");
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDescripcion, "Debe ingresar una descripcion");
            }
            return valido;
        }

        internal void SetCategoria(Categoria categoria)
        {
            this.categoria = categoria;
        }

        internal Categoria GetCategoria()
        {
            return categoria;
        }
    }
}
