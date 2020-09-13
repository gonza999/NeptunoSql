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
            dgvDatos.Rows.Clear();
            foreach (var categoria in lista)
            {
                AgregarFila(categoria);
            }
        }

        public void AgregarFila(Categoria categoria)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, categoria);
            AgregarFila(r);
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Categoria Categoria)
        {
            r.Cells[cmnCategoria.Index].Value = Categoria.NombreCategoria;

            r.Tag = Categoria;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void FrmCategorias_Load(object sender, System.EventArgs e)
        {
            Actualizar();
        }

        private void Actualizar()
        {
            try
            {
                servicio = new ServicioCategorias();
                lista = servicio.GetLista();
                MostrarEnGrilla();
            }
            catch (Exception ex)
            {

                Helper.MensajeBox(ex.Message, Tipo.Error);
            }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmCategoriasAE frm = new FrmCategoriasAE(this);
            frm.Text = "Agregar";
            frm.ShowDialog(this);
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Categoria categoria = (Categoria)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja a la categoria {categoria.NombreCategoria}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (!servicio.EstaRelacionado(categoria))
                        {
                            servicio.Borrar(categoria.CategoriaId);
                            dgvDatos.Rows.Remove(r);
                            Helper.MensajeBox("Registro borrado", Tipo.Success);
                        }
                        else
                        {
                            Helper.MensajeBox("Baja denegada,registro relacionado", Tipo.Error);
                        }
                    }
                    catch (Exception exception)
                    {
                        Helper.MensajeBox(exception.Message, Tipo.Error);

                    }
                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Categoria categoria = (Categoria)r.Tag;
                Categoria categoriaClon = (Categoria)categoria.Clone();
                FrmCategoriasAE frm = new FrmCategoriasAE(this);
                frm.Text = "Editar Marca";
                frm.SetCategoria(categoria);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        categoria = frm.GetCategoria();
                        servicio.Guardar(categoria);
                        SetearFila(r, categoria);
                        Helper.MensajeBox("Registro Agregado", Tipo.Success);
                    }
                    catch (Exception exception)
                    {
                        Helper.MensajeBox(exception.Message, Tipo.Error);
                    }
                }


            }
        }
    }
}
