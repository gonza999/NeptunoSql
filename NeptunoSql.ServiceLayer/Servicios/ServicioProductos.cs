using NeptunoSql.BusinessLayer.Entities;
using NeptunoSql.DataLayer;
using NeptunoSql.DataLayer.Repositorios;
using NeptunoSql.DataLayer.Repositorios.Facades;
using NeptunoSql.ServiceLayer.Servicios.Facades;
using System;
using System.Collections.Generic;

namespace NeptunoSql.ServiceLayer.Servicios
{
    public class ServicioProductos : IServicioProductos
    {
        private IRepositorioProductos repositorio;
        private ConexionBd conexion;
        private IRepositorioMarcas repositorioMarcas;
        private IRepositorioCategorias repositorioCategorias;
        private IRepositorioMedidas repositorioMedidas;
        public ServicioProductos()
        {

        }
        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(Producto producto)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Producto producto)
        {
            throw new NotImplementedException();
        }

        public List<Producto> GetLista()
        {
            try
            {
                conexion = new ConexionBd();
                repositorioMarcas=new RepositorioMarcas(conexion.AbrirConexion());
                repositorioCategorias=new RepositorioCategorias(conexion.AbrirConexion());
                repositorioMedidas=new RepositorioMedidas(conexion.AbrirConexion());
                repositorio = new RepositorioProductos(conexion.AbrirConexion(),repositorioMarcas,repositorioCategorias,repositorioMedidas);
                var lista = repositorio.GetLista();
                conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Producto GetProductoPorCodigoDeBarras(string codigo)
        {
            try
            {
                conexion = new ConexionBd();
                repositorioMarcas = new RepositorioMarcas(conexion.AbrirConexion());
                repositorioCategorias = new RepositorioCategorias(conexion.AbrirConexion());
                repositorioMedidas = new RepositorioMedidas(conexion.AbrirConexion());
                repositorio = new RepositorioProductos(conexion.AbrirConexion(), repositorioMarcas, repositorioCategorias, repositorioMedidas);
                var producto = repositorio.GetProductoPorCodigoDeBarras(codigo);
                conexion.CerrarConexion();
                return producto;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Producto GetProductoPorId(int id)
        {
            try
            {
                conexion = new ConexionBd();
                repositorioMarcas = new RepositorioMarcas(conexion.AbrirConexion());
                repositorioCategorias = new RepositorioCategorias(conexion.AbrirConexion());
                repositorioMedidas = new RepositorioMedidas(conexion.AbrirConexion());
                repositorio = new RepositorioProductos(conexion.AbrirConexion(), repositorioMarcas, repositorioCategorias, repositorioMedidas);
                var producto = repositorio.GetProductoPorId(id);
                conexion.CerrarConexion();
                return producto;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Producto producto)
        {
            try
            {
                conexion = new ConexionBd();
                repositorio = new RepositorioProductos(conexion.AbrirConexion());
                repositorio.Guardar(producto);
                conexion.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
