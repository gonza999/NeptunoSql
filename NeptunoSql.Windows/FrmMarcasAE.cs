using System;
using System.Windows.Forms;
using NeptunoSql.BusinessLayer.Entities;
using NeptunoSql.ServiceLayer.Servicios;
using NeptunoSql.ServiceLayer.Servicios.Facades;
using NeptunoSql.Windows.Helpers;
using NeptunoSql.Windows.Helpers.Enum;

namespace NeptunoSql.Windows
{
    public partial class FrmMarcasAE : Form
    {
        public FrmMarcasAE(FrmMarcas frm )
        {
            InitializeComponent();
            this.frm = frm;
        }
        private FrmMarcas frm;
        private bool esEdicion = false;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            servicio = new ServicioMarcas();
            if (marca != null)
            {
                TextBoxMarca.Text = marca.NombreMarca;
                esEdicion = true;
            }
        }

        private Marca marca;
        public void SetMarca(Marca marca)
        {
            this.marca = marca;
        }

        public Marca GetMarca()
        {
            return marca;
        }



        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(TextBoxMarca.Text.Trim()) &&
                string.IsNullOrWhiteSpace(TextBoxMarca.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(TextBoxMarca, "Debe ingresar una marca");
            }

            return valido;
        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            if (ValidarDatos())
            {

                if (marca == null)
                {
                    marca = new Marca();
                }
                
                marca.NombreMarca = TextBoxMarca.Text;
                
                if (ValidarObjeto())
                {
                    if (!esEdicion)
                    {
                        servicio.Guardar(marca);
                        frm.AgregarFila(marca);
                        Helper.MensajeBox("Registro guardado", Tipo.Success);
                        DialogResult dr = MessageBox.Show("Desea agregar otro registro?", "Confirmar",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr==DialogResult.No)
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

        private void InicializarControles()
        {
            TextBoxMarca.Clear();
            TextBoxMarca.Focus();
            marca = null;
        }

        private IServicioMarcas servicio;
        private bool ValidarObjeto()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (servicio.Existe(marca))
            {
                errorProvider1.SetError(TextBoxMarca,"Marca repetida");
                valido = false;
            }
            return valido;
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }
    }
}
