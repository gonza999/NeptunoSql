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
    public class RepositorioVentas : IRepositorioVentas
    {
        private readonly SqlConnection cn;
        private readonly SqlTransaction transaction;

        public RepositorioVentas(SqlConnection cn, SqlTransaction transaction)
        {
            this.cn = cn;
            this.transaction = transaction;
        }

        public void Guardar(Venta venta)
        {
            try
            {
                var cadenaDeComando = "INSERT INTO Ventas(Fecha,SubTotal,Descuentos,Total)" +
                    "VALUES (@fecha,@sub,@desc,@total)";
                var comando = new SqlCommand(cadenaDeComando, cn, transaction);
                comando.Parameters.AddWithValue("@fecha", venta.Fecha);
                comando.Parameters.AddWithValue("@sub", venta.SubTotal);
                comando.Parameters.AddWithValue("@desc", venta.Descuentos);
                comando.Parameters.AddWithValue("@total", venta.Total);
                comando.ExecuteNonQuery();
                cadenaDeComando = "SELECT @@IDENTITY";
                comando = new SqlCommand(cadenaDeComando, cn, transaction);
                venta.VentaId = (int)(decimal)comando.ExecuteScalar();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
