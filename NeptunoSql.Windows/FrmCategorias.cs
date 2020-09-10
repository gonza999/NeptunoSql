using NeptunoSql.BusinessLayer.Entities;
using NeptunoSql.ServiceLayer.Servicios;
using NeptunoSql.ServiceLayer.Servicios.Facades;
using NeptunoSql.Windows.Helpers;
using NeptunoSql.Windows.Helpers.Enum;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NeptunoSql.Windows
{
    public partial class FrmCategorias : Form
    {
        public FrmCategorias()
        {
            InitializeComponent();
        }
        private List<Categoria> lista;
        private IServicioCategorias servicio;
        private void MostrarEnGrilla()
        {
            DataGridViewDatos.Rows.Clear();
            foreach (var categoria in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, categoria);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DataGridViewDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Categoria Categoria)
        {
            r.Cells[cmnCategoria.Index].Value = Categoria.NombreCategoria;

            r.Tag = Categoria;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DataGridViewDatos);
            return r;
        }

        private void FrmCategorias_Load(object sender, System.EventArgs e)
        {
            try
            {
                servicio = new ServicioCategorias();
                lista = servicio.GetLista();
                MostrarEnGrilla();
            }
            catch (Exception ex)
            {

                Helper.MensajeBox(ex.Message,Tipo.Error);
            }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}
