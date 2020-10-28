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
    public partial class FrmPago : Form
    {
        public FrmPago()
        {
            InitializeComponent();
        }
        private decimal importeVenta;
        private int ventaId;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            txtImporteTotal.Text = importeVenta.ToString();
            txtVenta.Text = ventaId.ToString();
        }

        internal void SetImporteYVenta(decimal importeVenta, int ventaId)
        {
            this.importeVenta = importeVenta;
            this.ventaId = ventaId;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtImportePagado.Text) 
                || string.IsNullOrWhiteSpace(txtImportePagado.Text))
            {
                valido = false;
                errorProvider1.SetError(txtImportePagado,"Debe ingresar el importe a pagar");
            }
            decimal pagado = 0;
            if(!decimal.TryParse(txtImportePagado.Text,out pagado))
            {
                valido = false;
                errorProvider1.SetError(txtImportePagado, "Debe ingresar un importe valido");
            }
            if (string.IsNullOrEmpty(txtVuelto.Text)
              || string.IsNullOrWhiteSpace(txtVuelto.Text))
            {
                valido = false;
                errorProvider1.SetError(txtVuelto, "Debe ingresar el vuelto");
            }
            decimal vuelto = 0;
            if (!decimal.TryParse(txtVuelto.Text, out vuelto))
            {
                valido = false;
                errorProvider1.SetError(txtVuelto, "Debe ingresar un vuelto valido");
            }
            return valido;
        }
    }
}
