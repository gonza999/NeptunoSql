using NeptunoSql.BusinessLayer.Entities;
using NeptunoSql.DataLayer.Repositorios.Facades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunoSql.DataLayer.Repositorios
{
    public class RepositorioDetallesIngresos : IRepositorioDetallesIngresos
    {
        private readonly SqlConnection conexion;

        private readonly SqlTransaction transaction;

        public RepositorioDetallesIngresos(SqlConnection conexion)
        {
            this.conexion = conexion;
        }

        public RepositorioDetallesIngresos(SqlConnection cn, SqlTransaction transaction)
        {
            conexion = cn;
            this.transaction = transaction;
        }

        public void Guardar(DetalleIngreso detalle)
        {
            try
            {
                var cadenaDeComando = "INSERT INTO DetalleIngresos (IngresoId,ProductoId,Cantidad,KardexId)" +
                    "VALUES (@ingreso,@producto,@cantidad,@kardex)";
                var comando = new SqlCommand(cadenaDeComando,conexion,transaction);
                comando.Parameters.AddWithValue("@ingreso",detalle.Ingreso.IngresoId);
                comando.Parameters.AddWithValue("@producto",detalle.Producto.ProductoId);
                comando.Parameters.AddWithValue("@cantidad",detalle.Cantidad);
                comando.Parameters.AddWithValue("@kardex",detalle.Kardex.KardexId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
