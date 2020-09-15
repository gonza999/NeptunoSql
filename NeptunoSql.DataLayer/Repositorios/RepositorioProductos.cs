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

        public RepositorioProductos(SqlConnection conexion, IRepositorioMarcas repositorioMarcas,
             IRepositorioCategorias repositorioCategorias, IRepositorioMedidas repositorioMedidas)
        {
            this.conexion = conexion;
            this.repositorioCategorias = repositorioCategorias;
            this.repositorioMarcas = repositorioMarcas;
            this.repositorioMedidas = repositorioMedidas;
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
            throw new System.NotImplementedException();
        }

        public void Guardar(Producto producto)
        {
            throw new System.NotImplementedException();
        }
    }
}
