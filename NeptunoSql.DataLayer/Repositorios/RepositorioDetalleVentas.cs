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
    public class RepositorioDetalleVentas : IRepositorioDetalleVentas
    {
        private readonly SqlConnection cn;
        private readonly SqlTransaction transaction;

        public RepositorioDetalleVentas(SqlConnection cn, SqlTransaction transaction)
        {
            this.cn = cn;
            this.transaction = transaction;
        }

        public void Guardar(DetalleVenta detalle)
        {
            try
            {
                var cadenaDeComando = "INSERT INTO DetalleVentas (VentaId,ProductoId,PrecioUnitario,Cantidad,Descuento,PrecioTotal,KardexId)" +
                    "VALUES (@venta,@producto,@precio,@cantidad,@desc,@total,@kardex)";
                var comando = new SqlCommand(cadenaDeComando, cn, transaction);
                comando.Parameters.AddWithValue("@venta", detalle.Venta.VentaId);
                comando.Parameters.AddWithValue("@producto", detalle.Producto.ProductoId);
                comando.Parameters.AddWithValue("@precio",detalle.PrecioUnitario);
                comando.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                comando.Parameters.AddWithValue("@desc",detalle.Descuento);
                comando.Parameters.AddWithValue("@total",detalle.Total);
                comando.Parameters.AddWithValue("@kardex", detalle.Kardex.KardexId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
