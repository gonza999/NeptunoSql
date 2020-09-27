using Microsoft.VisualBasic;
using NeptunoSql.BusinessLayer.Entities;
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
    public partial class FrmIngresos : Form
    {
        public FrmIngresos()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkProductosStock_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarProducto frm = new FrmBuscarProducto(this);
            frm.Text = "Buscar Producto";
            frm.ShowDialog(this);
        }
        private List<Producto> lista = new List<Producto>();
        public void AgregarFila(Producto producto)
        {
            if (!lista.Contains(producto))
            {
                lista.Add(producto);
                var r = Helper.ConstruirFila(ref dgvDatos);
                SetearFila(r, producto);
                AgregarFila(r); 
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Producto producto)
        {
            r.Cells[cmnDescripcion.Index].Value = producto.Descripcion;
            r.Cells[cmnMarcas.Index].Value = producto.Marca.NombreMarca;
            r.Tag = producto;
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 2:
                    var cantidad=Interaction.InputBox("Ingrese la cantidad",
                        "Ingreso de stock","0",Screen.PrimaryScreen.WorkingArea.Bottom/2, Screen.PrimaryScreen.WorkingArea.Height/2);
                    if (!double.TryParse(cantidad,out double stock))
                    {
                        return;
                    }
                    else if (stock<=0 || stock>=int.MaxValue)
                    {
                        return;
                    }
                    DataGridViewCell celda=dgvDatos.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    celda.Value = stock;
                    break;
                case 3:
                         dgvDatos.Rows.RemoveAt(e.RowIndex);
                    break;
                default:break;
            }         
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtEmpleado.Text) ||
                string.IsNullOrWhiteSpace(txtEmpleado.Text))
            {
                valido = false;
                errorProvider1.SetError(txtEmpleado, "Debe ingresar una empleado");
            }
            if (string.IsNullOrEmpty(txtReferencia.Text) ||
                string.IsNullOrWhiteSpace(txtReferencia.Text))
            {
                valido = false;
                errorProvider1.SetError(txtReferencia, "Debe ingresar una referencia");
            }
            if (pickerFechaStock.Value.Date>=DateTime.Today)
            {
                valido = false;
                errorProvider1.SetError(pickerFechaStock, "Fecha mal ingresada");
            }
            if (dgvDatos.Rows.Count==0)
            {
                valido = false;
                errorProvider1.SetError(linkProductosStock, "Debe seleccionar al menos un producto");
            }
            else
            {
                foreach (DataGridViewRow r in dgvDatos.Rows)
                {
                    DataGridViewCell celda = r.Cells[2];
                    if (celda.Value==null)
                    {
                        valido = false;
                        celda.Style.BackColor = Color.Red;
                    }
                    else
                    {
                        celda.Style.BackColor = Color.White;
                    }
                }
            }

            
            return valido;
        }
    }
}
