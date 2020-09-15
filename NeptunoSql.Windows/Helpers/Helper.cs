using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NeptunoSql.BusinessLayer;
using NeptunoSql.BusinessLayer.Entities;
using NeptunoSql.ServiceLayer.Servicios;
using NeptunoSql.ServiceLayer.Servicios.Facades;
using NeptunoSql.Windows.Helpers.Enum;

namespace NeptunoSql.Windows.Helpers
{
    public class Helper
    {
        public static void MensajeBox(string mensaje, Tipo tipo)
        {
            switch (tipo)
            {
                case Tipo.Success:
                    MessageBox.Show(mensaje, "Operación Exitosa", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    break;
                case Tipo.Error:
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    break;
                //case Tipo.Warning:
                //    break;
                //case Tipo.Question:
                //    break;
                //default:
                //    break;
            }
        }

        internal static void CargarMedidaComboBox(ref ComboBox cmbMedida)
        {
            IServicioMedidas servicioMedidas = new ServicioMedidas();
            List<Medida> listaMedidas = servicioMedidas.GetLista();
            var defaultCategorias = new Medida() { MedidaId = 0, Denominacion = "-Seleccione Medida-" };
            listaMedidas.Insert(0, defaultCategorias);
            cmbMedida.DataSource = listaMedidas;
            cmbMedida.DisplayMember = "Denominacion";
            cmbMedida.ValueMember = "MedidaId";
            cmbMedida.SelectedIndex = 0;
        }

        internal static void CargarCategoriaComboBox(ref ComboBox cmbCategoria)
        {
            IServicioCategorias servicioCategorias = new ServicioCategorias();
            List<Categoria> listaCategorias = servicioCategorias.GetLista();
            var defaultCategorias = new Categoria() { CategoriaId = 0, NombreCategoria = "-Seleccione Categoria-" };
            listaCategorias.Insert(0, defaultCategorias);
            cmbCategoria.DataSource = listaCategorias;
            cmbCategoria.DisplayMember = "NombreCategoria";
            cmbCategoria.ValueMember = "CategoriaId";
            cmbCategoria.SelectedIndex = 0;
        }

        public static DialogResult MensajeBox(string mensaje)
        {
            return MessageBox.Show(mensaje, "Confirmar operación", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
        }
        public static void CargarMarcaComboBox(ref ComboBox cmbMarca)
        {
            IServicioMarcas servicioMarcas = new ServicioMarcas();
            List<Marca> listaMarcas = servicioMarcas.GetLista();
            var defaultMarca = new Marca() { MarcaId = 0, NombreMarca = "-Seleccione Marca-" };
            listaMarcas.Insert(0, defaultMarca);
            cmbMarca.DataSource = listaMarcas;
            cmbMarca.DisplayMember = "NombreMarca";
            cmbMarca.ValueMember = "MarcaId";
            cmbMarca.SelectedIndex = 0;
        }
    }
}
