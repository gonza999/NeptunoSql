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
    public class RepositorioKardex : IRepositorioKardex
    {
        private readonly SqlConnection conexion;
        private readonly SqlTransaction transaction;

        public RepositorioKardex(SqlTransaction transaction,SqlConnection conexion)
        {
            this.conexion = conexion;
            this.transaction = transaction;
        }

        public Kardex GetUltimoKardex(Producto producto)
        {
            Kardex kardex = null;
            try
            {
                var cadenaDeComando = "SELECT ProductoId,Fecha,Movimiento,Entrada,Salida,Saldo " +
                    "FROM Kardex WHERE ProductoId=@id AND Fecha = (SELECT MAX(FECHA) FROM Kardex " +
                    "WHERE ProductoId=@id)";
                var comando = new SqlCommand(cadenaDeComando,conexion,transaction);
                comando.Parameters.AddWithValue("@id",producto.ProductoId);
                var reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    kardex = new Kardex();
                    kardex.Producto = producto;
                    kardex.Fecha = reader.GetDateTime(1);
                    kardex.Movimiento = reader.GetString(2);
                    kardex.Entrada = reader.GetDecimal(3);
                    kardex.Salida = reader.GetDecimal(4);
                    kardex.Saldo = reader.GetDecimal(5);
                }
                reader.Close();
                return kardex;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public void Guardar(Kardex kardex)
        {
            try
            {
                var cadenaDeComando = "INSERT INTO Kardex (ProductoId,Fecha,Movimiento,Entrada, " +
                    "Salida, Saldo) VALUES (@id,@fecha,@mov,@entrada,@salida,@saldo)";
                var comando = new SqlCommand(cadenaDeComando,conexion,transaction);
                comando.Parameters.AddWithValue("@id",kardex.Producto.ProductoId);
                comando.Parameters.AddWithValue("@fecha",kardex.Fecha);
                comando.Parameters.AddWithValue("@mov",kardex.Movimiento);
                comando.Parameters.AddWithValue("@entrada",kardex.Entrada);
                comando.Parameters.AddWithValue("@salida",kardex.Salida);
                comando.Parameters.AddWithValue("@saldo",kardex.Saldo);
                comando.ExecuteNonQuery();
                cadenaDeComando = "SELECT @@IDENTITY";
                comando = new SqlCommand(cadenaDeComando,conexion,transaction);
                kardex.KardexId =(int)(decimal) comando.ExecuteScalar();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
