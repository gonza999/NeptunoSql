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
    public partial class FrmMedidas : Form
    {
        public FrmMedidas()
        {
            InitializeComponent();
        }
        private IServicioMedidas servicio;
        private List<Medida> lista;
        private void FrmMedidas_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void Actualizar()
        {
            try
            {
                servicio = new ServicioMedidas();
                lista = servicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {
                Helper.MensajeBox(ex.Message, Tipo.Error);
            }
        }

        private void MostrarDatosEnGrilla()
        {
            DgvDatos.Rows.Clear();
            foreach (var medida in lista)
            {
                AgregarFila(medida);
            }
        }

        public void AgregarFila(Medida medida)
        {
            var r = ConstruirFila();
            SetearFila(r, medida);
            AgregarFila(r);
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Medida medida)
        {
            r.Cells[cmnMedida.Index].Value = medida.Denominacion;
            r.Cells[cmnAbv.Index].Value = medida.Abreviatura;
            r.Tag = medida;
        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(DgvDatos);
            return r;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmMedidasAE frm = new FrmMedidasAE(this);
            frm.Text = "Agregar Medida";
            frm.ShowDialog(this);
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (DgvDatos.SelectedRows.Count > 0)
            {
                var r = DgvDatos.SelectedRows[0];
                Medida medida = (Medida)r.Tag;
                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja a la medida {medida.Denominacion}?",
              "Confirmar Baja",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (!servicio.EstaRelacionado(medida))
                        {
                            servicio.Borrar(medida.MedidaId);
                            DgvDatos.Rows.Remove(r);
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
            if (DgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DgvDatos.SelectedRows[0];
                Medida medida = (Medida)r.Tag;
                Medida medidaClon = (Medida)medida.Clone();
                FrmMedidasAE frm = new FrmMedidasAE(this);
                frm.Text = "Editar Medida";
                frm.SetMedida(medida);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        medida = frm.GetMedida();
                        servicio.Guardar(medida);
                        SetearFila(r, medida);
                        Helper.MensajeBox("Registro Editado", Tipo.Success);

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

