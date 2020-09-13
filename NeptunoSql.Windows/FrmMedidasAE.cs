using NeptunoSql.BusinessLayer;
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
    public partial class FrmMedidasAE : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            servicio = new ServicioMedidas();
            if (medida != null)
            {
                txtMedida.Text = medida.Denominacion;
                txtAbreviatura.Text = medida.Abreviatura;
                esEdicion = true;
            }
        }
        private bool esEdicion = false;
        private FrmMedidas frm;
        public FrmMedidasAE(FrmMedidas frmMedidas)
        {
            InitializeComponent();
            frm = frmMedidas;
        }

        private Medida medida;
        private IServicioMedidas servicio;

        internal Medida GetMedida()
        {
            return medida;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (medida == null)
                {
                    medida = new Medida();
                }
                medida.Denominacion = txtMedida.Text;
                medida.Abreviatura = txtAbreviatura.Text.ToUpper();

                if (ValidarObjeto())
                {
                    if (!esEdicion)
                    {
                        servicio.Guardar(medida);
                        frm.AgregarFila(medida);
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

        private void InicializarControles()
        {
            txtAbreviatura.Clear();
            txtMedida.Clear();
            txtMedida.Focus();
            medida = null;
        }

        private bool ValidarObjeto()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (servicio.Existe(medida))
            {
                valido = false;
                errorProvider1.SetError(txtMedida, "Medida o abreviatura repetida");
            }
            return valido;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtMedida.Text) ||
                string.IsNullOrWhiteSpace(txtMedida.Text))
            {
                valido = false;
                errorProvider1.SetError(txtMedida, "Debe ingresar una medida");
            }
            if (string.IsNullOrEmpty(txtAbreviatura.Text) ||
                string.IsNullOrWhiteSpace(txtAbreviatura.Text))
            {
                valido = false;
                errorProvider1.SetError(txtAbreviatura, "Debe ingresar una abreviatura");
            }
            return valido;
        }

        internal void SetMedida(Medida medida)
        {
            this.medida = medida;
        }
    }
}
