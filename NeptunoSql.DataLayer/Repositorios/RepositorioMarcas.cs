using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using NeptunoSql.BusinessLayer.Entities;
using NeptunoSql.DataLayer.Repositorios.Facades;

namespace NeptunoSql.DataLayer.Repositorios
{
    public class RepositorioMarcas:IRepositorioMarcas
    {
        private readonly SqlConnection _sqlConnection;

        public RepositorioMarcas(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public Marca GetMarcaPorId(int id)
        {
            try
            {
                Marca marca = null;
                string cadenaComando = "SELECT MarcaId, NombreMarca FROM Marcas WHERE MarcaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    marca = ConstruirMarca(reader);
                    reader.Close();
                }

                return marca;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public List<Marca> GetLista()
        {
            List<Marca> lista = new List<Marca>();
            try
            {
                string cadenaComando = "SELECT MarcaId, NombreMarca FROM Marcas";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Marca marca = ConstruirMarca(reader);
                    lista.Add(marca);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Marca ConstruirMarca(SqlDataReader reader)
        {
            return new Marca
            {
                MarcaId = reader.GetInt32(0),
                NombreMarca = reader.GetString(1)
            };
        }

        public void Guardar(Marca marca)
        {
            if (marca.MarcaId==0)
            {
                //Nuevo registro
                try
                {
                    string cadenaComando = "INSERT INTO Marcas VALUES(@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", marca.NombreMarca);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    marca.MarcaId = (int)(decimal)comando.ExecuteScalar();

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
            else
            {
                //Edición
                try
                {
                    string cadenaComando = "UPDATE Marcas SET NombreMarca=@nombre WHERE MarcaId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", marca.NombreMarca);
                    comando.Parameters.AddWithValue("@id", marca.MarcaId);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
        }

        public void Borrar(int id)
        {
            try
            {
                string cadenaComando = "DELETE FROM Marcas WHERE MarcaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Marca marca)
        {
            try
            {
                SqlCommand comando;
                if (marca.MarcaId == 0)
                {
                    string cadenaComando = "SELECT MarcaId, NombreMarca FROM Marcas WHERE NombreMarca=@nombre";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", marca.NombreMarca);

                }
                else
                {
                    string cadenaComando = "SELECT MarcaId, NombreMarca FROM Marcas WHERE NombreMarca=@nombre AND Marcaid<>@id";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", marca.NombreMarca);
                    comando.Parameters.AddWithValue("@id", marca.MarcaId);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Marca marca)
        {
            return false;
        }
    }
}
