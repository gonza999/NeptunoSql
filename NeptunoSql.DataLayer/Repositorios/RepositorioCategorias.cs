using NeptunoSql.BusinessLayer.Entities;
using NeptunoSql.DataLayer.Repositorios.Facades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NeptunoSql.DataLayer.Repositorios
{
    public class RepositorioCategorias : IRepositorioCategorias
    {
        private readonly SqlConnection conexion;

        public RepositorioCategorias(SqlConnection conexion)
        {
            this.conexion = conexion;
        }
        public void Borrar(int id)
        {
            try
            {
                string cadenaDeComando = "DELETE Categorias WHERE CategoriaId=@id";
                SqlCommand comando = new SqlCommand(cadenaDeComando, conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Categoria categoria)
        {
            try
            {
                var cadenaDeComando = "SELECT CategoriaId FROM Productos WHERE CategoriaId=@id";
                var comando = new SqlCommand(cadenaDeComando,conexion);
                comando.Parameters.AddWithValue("@id",categoria.CategoriaId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message) ;
            }
        }

        public bool Existe(Categoria categoria)
        {
            try
            {
                SqlCommand comando;
                if (categoria.CategoriaId == 0)
                {
                    string cadenaComando = "SELECT CategoriaId, NombreCategoria FROM Categorias WHERE NombreCategoria=@nombre";
                    comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@nombre", categoria.NombreCategoria);

                }
                else
                {
                    string cadenaComando = "SELECT CategoriaId, NombreCategoria FROM Categorias WHERE NombreCategoria=@nombre AND Categoriaid<>@id";
                    comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@nombre", categoria.NombreCategoria);
                    comando.Parameters.AddWithValue("@id", categoria.CategoriaId);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Categoria GetCategoriaPorId(int id)
        {
            try
            {
                Categoria categoria = null;
                string cadenaDeComando = "SELECT CategoriaId,NombreCategoria,Descripcion FROM Categorias WHERE CategoriaId=@id";
                SqlCommand comando = new SqlCommand(cadenaDeComando, conexion);
                comando.Parameters.AddWithValue("@id",id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    categoria = ConstruirCategoria(reader);
                    reader.Close();
                }
                return categoria;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Categoria> GetLista()
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                string cadenaDeComando = "SELECT CategoriaId,NombreCategoria,Descripcion FROM Categorias";
                SqlCommand comando = new SqlCommand(cadenaDeComando,conexion);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    Categoria categoria =ConstruirCategoria(reader);
                    lista.Add(categoria);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Categoria ConstruirCategoria(SqlDataReader reader)
        {
            return new Categoria()
            {
                CategoriaId=reader.GetInt32(0),
                NombreCategoria=reader.GetString(1),
                Descripcion=reader.GetString(2)
            };
        }

        public void Guardar(Categoria categoria)
        {
            SqlCommand comando;
            if (categoria.CategoriaId==0)
            {
                try
                {
                    var cadenaDeConexion = "INSERT INTO Categorias (NombreCategoria,Descripcion) VALUES (@nombre,@descripcion)";
                    comando = new SqlCommand(cadenaDeConexion, conexion);
                    comando.Parameters.AddWithValue("@nombre", categoria.NombreCategoria);
                    comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                    comando.ExecuteNonQuery();
                    cadenaDeConexion = "SELECT @@Identity";
                    comando = new SqlCommand(cadenaDeConexion, conexion);
                    categoria.CategoriaId = (int)(decimal)comando.ExecuteScalar();
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
                    string cadenaComando = "UPDATE Categorias SET NombreCategoria=@nombre WHERE CategoriaId=@id";
                    comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@nombre", categoria.NombreCategoria);
                    comando.Parameters.AddWithValue("@id", categoria.NombreCategoria);
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
