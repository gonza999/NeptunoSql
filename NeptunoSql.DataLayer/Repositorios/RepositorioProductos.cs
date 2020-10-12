using NeptunoSql.BusinessLayer.Entities;
using NeptunoSql.DataLayer.Repositorios.Facades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NeptunoSql.DataLayer.Repositorios
{
    public class RepositorioProductos : IRepositorioProductos
    {
        private readonly SqlConnection conexion;
        private readonly IRepositorioMarcas repositorioMarcas;
        private readonly IRepositorioCategorias repositorioCategorias;
        private readonly IRepositorioMedidas repositorioMedidas;
        private readonly SqlTransaction transaction;

        public RepositorioProductos(SqlConnection conexion, IRepositorioMarcas repositorioMarcas,
             IRepositorioCategorias repositorioCategorias, IRepositorioMedidas repositorioMedidas)
        {
            this.conexion = conexion;
            this.repositorioCategorias = repositorioCategorias;
            this.repositorioMarcas = repositorioMarcas;
            this.repositorioMedidas = repositorioMedidas;
        }

        public RepositorioProductos(SqlConnection sqlConnection)
        {
            this.conexion = sqlConnection;
        }

        public RepositorioProductos(SqlConnection cn, SqlTransaction transaction)
        {
            conexion = cn;
            this.transaction = transaction;
        }

        public void Borrar(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool EstaRelacionado(Producto producto)
        {
            throw new System.NotImplementedException();
        }

        public bool Existe(Producto producto)
        {
            throw new System.NotImplementedException();
        }

        public List<Producto> GetLista()
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                var cadenaDeComando = "SELECT ProductoId,Descripcion,MarcaId,CategoriaId,PrecioUnitario,Stock,Suspendido " +
                    "FROM Productos";
                var comando = new SqlCommand(cadenaDeComando,conexion);
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Producto producto = ConstruirProducto(reader);
                    lista.Add(producto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Producto ConstruirProducto(SqlDataReader reader)
        {
            return new Producto()
            {
                ProductoId = reader.GetInt32(0),
                Descripcion = reader.GetString(1),
                Marca = repositorioMarcas.GetMarcaPorId(reader.GetInt32(2)),
                Categoria = repositorioCategorias.GetCategoriaPorId(reader.GetInt32(3)),
                PrecioUnitario=reader.GetDecimal(4),
                Stock=reader.GetDecimal(5),
                Suspendido=reader.GetBoolean(6)

            };
        }

        public Producto GetProductoPorId(int id)
        {
            Producto producto = null;
            try
            {
                var cadenaDeComando = "SELECT ProductoId,Descripcion,MarcaId,CategoriaId," +
                    "PrecioUnitario,Stock,CodigoBarra,MedidaId,Imagen,Suspendido FROM " +
                    " Productos WHERE ProductoId=@id";
                var comando = new SqlCommand(cadenaDeComando,conexion);
                comando.Parameters.AddWithValue("@id",id);
                var reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    producto = ConstruirProductoTotal(reader);
                    reader.Close();
                }
                return producto;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Producto ConstruirProductoTotal(SqlDataReader reader)
        {
            return new Producto()
            {
                ProductoId = reader.GetInt32(0),
                Descripcion = reader.GetString(1),
                Marca = repositorioMarcas.GetMarcaPorId(reader.GetInt32(2)),
                Categoria = repositorioCategorias.GetCategoriaPorId(reader.GetInt32(3)),
                PrecioUnitario = reader.GetDecimal(4),
                Stock = reader.GetDecimal(5),
                CodigoBarra =reader[6]!=DBNull.Value? reader.GetString(6):null,
                Medida = repositorioMedidas.GetMedidaPorId(reader.GetInt32(7)),
                Imagen=reader[8]!=DBNull.Value?reader.GetString(8):null,
                Suspendido = reader.GetBoolean(9)

            };
        }

        public void Guardar(Producto producto)
        {
            try
            {
                var cadenaDeComando = "INSERT INTO Productos (Descripcion,MarcaId,CategoriaId,PrecioUnitario," +
                    "CodigoBarra,MedidaId,Imagen,Suspendido) VALUES (@descripcion,@marcaId,@categoriaId,@precio," +
                    "@codigo,@medidaId,@imagen,@suspendido)";
                var comando = new SqlCommand(cadenaDeComando, conexion);
                comando.Parameters.AddWithValue("@descripcion",producto.Descripcion);
                comando.Parameters.AddWithValue("@marcaId",producto.Marca.MarcaId);
                comando.Parameters.AddWithValue("@categoriaId",producto.Categoria.CategoriaId);
                comando.Parameters.AddWithValue("@precio",producto.PrecioUnitario);
                comando.Parameters.AddWithValue("@codigo",producto.CodigoBarra);
                comando.Parameters.AddWithValue("@medidaId",producto.Medida.MedidaId);
                comando.Parameters.AddWithValue("@imagen",producto.Imagen);
                comando.Parameters.AddWithValue("@suspendido",producto.Suspendido);
                comando.ExecuteNonQuery();
                cadenaDeComando = "SELECT @@Identity";
                comando = new SqlCommand(cadenaDeComando,conexion);
                producto.ProductoId = (int)(decimal)comando.ExecuteScalar();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void ActualizarStock(Producto producto, decimal cantidad)
        {
            try
            {
                string cadenaComando = "UPDATE Productos SET Stock=Stock+@cant WHERE ProductoId=@id";
                var comando = new SqlCommand(cadenaComando,conexion,transaction);
                comando.Parameters.AddWithValue("@cant",cantidad);
                comando.Parameters.AddWithValue("@id",producto.ProductoId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message) ;
            }
        }

        public Producto GetProductoPorCodigoDeBarras(string codigo)
        {
            Producto producto = null;
            try
            {
                var cadenaDeComando = "SELECT ProductoId,Descripcion,MarcaId,CategoriaId," +
                    "PrecioUnitario,Stock,CodigoBarra,MedidaId,Imagen,Suspendido FROM " +
                    " Productos WHERE CodigoBarra=@codigo";
                var comando = new SqlCommand(cadenaDeComando, conexion);
                comando.Parameters.AddWithValue("@codigo", codigo);
                var reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    producto = ConstruirProductoTotal(reader);
                    reader.Close();
                }
                return producto;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
