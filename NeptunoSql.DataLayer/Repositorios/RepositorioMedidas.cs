using NeptunoSql.BusinessLayer;
using NeptunoSql.DataLayer.Repositorios.Facades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NeptunoSql.DataLayer.Repositorios
{
    public class RepositorioMedidas : IRepositorioMedidas
    {
        private SqlConnection conexion;

        public RepositorioMedidas(SqlConnection conexion)
        {
            this.conexion = conexion;
        }
        public void Borrar(int id)
        {
            try
            {
                var cadenaDeComando = "DELETE Medidas WHERE MedidaId=@id";
                var comando = new SqlCommand(cadenaDeComando,conexion);
                comando.Parameters.AddWithValue("@id",id);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Medida medida)
        {
            try
            {
                var cadenaDeComando = "SELECT MedidaId FROM Productos WHERE MedidaId=@id";
                var comando = new SqlCommand(cadenaDeComando,conexion);
                comando.Parameters.AddWithValue("@id",medida.MedidaId);
                var reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(Medida medida)
        {
            try
            {
                SqlCommand comando;
                if (medida.MedidaId == 0)
                {
                    string cadenaComando = "SELECT MedidaId, Abreviatura,Denominacion FROM Medidas WHERE (Abreviatura=@abv OR Denominacion=@deno)";
                    comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@abv", medida.Abreviatura);
                    comando.Parameters.AddWithValue("@deno", medida.Denominacion);

                }
                else
                {
                    string cadenaComando = "SELECT MedidaId, Abreviatura,Denominacion FROM Medidas WHERE (Abreviatura=@abv OR Denominacion=@deno) AND MedidaId<>@id";
                    comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@abv", medida.Abreviatura);
                    comando.Parameters.AddWithValue("@id", medida.MedidaId);
                    comando.Parameters.AddWithValue("@deno", medida.Denominacion);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Medida> GetLista()
        {
            try
            {
                List<Medida> lista = new List<Medida>();
                var cadenaDeComando = "SELECT MedidaId,Denominacion,Abreviatura FROM Medidas";
                var comando = new SqlCommand(cadenaDeComando, conexion);
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Medida medida = ConstruirMedida(reader);
                    lista.Add(medida);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Medida ConstruirMedida(SqlDataReader reader)
        {
            return new Medida()
            {
                MedidaId = reader.GetInt32(0),
                Denominacion = reader.GetString(1),
                Abreviatura = reader.GetString(2)
            };
        }

        public Medida GetMedidaPorId(int id)
        {
            try
            {
                Medida medida = null;
                string cadenaComando = "SELECT MedidaId, Denominacion,Abreviatura FROM Medidas WHERE MedidaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    medida = ConstruirMedida(reader);
                    reader.Close();
                }

                return medida;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Medida medida)
        {

            SqlCommand comando;
            string cadenaDeComando;
            if (medida.MedidaId == 0)
            {
                try
                {
                    cadenaDeComando = "INSERT INTO Medidas (Denominacion,Abreviatura) VALUES (@denominacion,@abv)";
                    comando = new SqlCommand(cadenaDeComando, conexion);
                    comando.Parameters.AddWithValue("@denominacion", medida.Denominacion);
                    comando.Parameters.AddWithValue("@abv", medida.Abreviatura);
                    comando.ExecuteNonQuery();
                    cadenaDeComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaDeComando, conexion);
                    medida.MedidaId = (int)(decimal)comando.ExecuteScalar();
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }
            else
            {
                try
                {
                    cadenaDeComando = "UPDATE Medidas SET Denominacion=@denominacion,Abreviatura=@abv WHERE MedidaId=@id";
                    comando = new SqlCommand(cadenaDeComando, conexion);
                    comando.Parameters.AddWithValue("@denominacion", medida.Denominacion);
                    comando.Parameters.AddWithValue("@abv", medida.Abreviatura);
                    comando.Parameters.AddWithValue("@id", medida.MedidaId);
                    comando.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }

        }
    }
}
