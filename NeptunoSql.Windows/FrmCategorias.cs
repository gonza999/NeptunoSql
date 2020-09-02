using NeptunoSql.BusinessLayer.Entities;
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
        private List<Categoria> _lista;
        private void MostrarEnGrilla()
        {
            DataGridViewDatos.Rows.Clear();
            foreach (var categoria in _lista)
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

    }
}
