using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NeptunoSql.BusinessLayer.Entities;
using NeptunoSql.ServiceLayer.Servicios;
using NeptunoSql.ServiceLayer.Servicios.Facades;
using NeptunoSql.Windows.Helpers;
using NeptunoSql.Windows.Helpers.Enum;

namespace NeptunoSql.Windows
{
    public partial class FrmMarcas : Form
    {
        public FrmMarcas()
        {
            InitializeComponent();
        }

        private List<Marca> lista;
        private IServicioMarcas _servicio;

        private void MostrarEnGrilla()
        {
            DataGridViewDatos.Rows.Clear();
            foreach (var marca in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, marca);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DataGridViewDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Marca marca)
        {
            r.Cells[cmnMarca.Index].Value = marca.NombreMarca;

            r.Tag = marca;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DataGridViewDatos);
            return r;
        }

        private void tsbCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FrmMarcas_Load(object sender, System.EventArgs e)
        {
            try
            {
                _servicio = new ServicioMarcas();
                lista = _servicio.GetLista();
                MostrarEnGrilla();
            }
            catch (Exception ex)
            {

                Helper.MensajeBox(ex.Message, Tipo.Error);
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmMarcasAE frm = new FrmMarcasAE();
            frm.Text = "Nueva Marca";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Marca marca = frm.GetMarca();
                    if (!_servicio.Existe(marca))
                    {
                        _servicio.Guardar(marca);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, marca);
                        AgregarFila(r);
                        Helper.MensajeBox("Registro Agregado", Tipo.Success);

                    }
                    else
                    {
                        Helper.MensajeBox("Marca repetida", Tipo.Error);
                    }
                }
                catch (Exception exception)
                {
                    Helper.MensajeBox(exception.Message, Tipo.Error);
                }
            }

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (DataGridViewDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DataGridViewDatos.SelectedRows[0];
                Marca marca = (Marca)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja a la marca {marca.NombreMarca}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (!_servicio.EstaRelacionado(marca))
                        {
                            _servicio.Borrar(marca.MarcaId);
                            DataGridViewDatos.Rows.Remove(r);
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
            if (DataGridViewDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DataGridViewDatos.SelectedRows[0];
                Marca marca = (Marca) r.Tag;
                //MarcaDto marcaAux =(Marca) marca.Clone();
                FrmMarcasAE frm = new FrmMarcasAE();
                frm.Text = "Editar Marca";
                frm.SetMarca(marca);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        marca = frm.GetMarca();
                        if (!_servicio.Existe(marca))
                        {
                            _servicio.Guardar(marca);
                            SetearFila(r, marca);
                            Helper.MensajeBox("Registro Agregado", Tipo.Success);
                        }
                        else
                        {
                            Helper.MensajeBox("Marca Repetida", Tipo.Error);
                        }
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
