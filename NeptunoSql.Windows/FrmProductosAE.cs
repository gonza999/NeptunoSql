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
    public partial class FrmProductosAE : Form
    {
        public FrmProductosAE()
        {
            InitializeComponent();
        }
        private IServicioMarcas servicioMarcas = new ServicioMarcas();
        private IServicioCategorias servicioCategorias = new ServicioCategorias();
        private IServicioMedidas servicioMedidas = new ServicioMedidas();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarMarcaComboBox(ref cmbMarca);
            Helper.CargarCategoriaComboBox(ref cmbCategoria);
            Helper.CargarMedidaComboBox(ref cmbMedida);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            FrmMarcasAE frm = new FrmMarcasAE();
            frm.Text = "Agregar Marca";
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
    }
}
