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
    public class RepositorioIngresos : IRepositorioIngresos
    {
        private readonly SqlConnection conexion;
        private readonly SqlTransaction transaction;

        public RepositorioIngresos(SqlConnection conexion)
        {
            this.conexion = conexion;
        }

        public RepositorioIngresos(SqlConnection cn, SqlTransaction transaction)
        {
            conexion = cn;
            this.transaction = transaction;
        }

        public void Guardar(Ingreso ingreso)
        {
            try
            {
                var cadenaDeComando = "INSERT INTO Ingresos(Referencia,Empleado,Fecha)" +
                    "VALUES (@referencia,@empleado,@fecha)";
                var comando = new SqlCommand(cadenaDeComando,conexion,transaction);
                comando.Parameters.AddWithValue("@referencia",ingreso.Referencia);
                comando.Parameters.AddWithValue("@empleado",ingreso.Empleado);
                comando.Parameters.AddWithValue("@fecha",ingreso.Fecha);
                comando.ExecuteNonQuery();
                cadenaDeComando = "SELECT @@IDENTITY";
                comando = new SqlCommand(cadenaDeComando,conexion,transaction);
                ingreso.IngresoId =(int)(decimal) comando.ExecuteScalar();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
