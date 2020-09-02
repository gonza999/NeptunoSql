using System;
using System.Windows.Forms;
using NeptunoSql.BusinessLayer.Entities;

namespace NeptunoSql.Windows
{
    public partial class FrmMarcasAE : Form
    {
        public FrmMarcasAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (marca != null)
            {
                TextBoxMarca.Text = marca.NombreMarca;
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
                DialogResult = DialogResult.OK;
            }

        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }
    }
}
