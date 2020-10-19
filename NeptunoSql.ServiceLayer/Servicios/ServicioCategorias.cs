using NeptunoSql.BusinessLayer.Entities;
using NeptunoSql.DataLayer.Repositorios;
using NeptunoSql.ServiceLayer.Servicios.Facades;
using NeptunoSql.DataLayer.Repositorios.Facades;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using NeptunoSql.DataLayer;

namespace NeptunoSql.ServiceLayer.Servicios
{
    public class ServicioCategorias : IServicioCategorias
    {
        private ConexionBd conexion;
        private IRepositorioCategorias repositorio;

        public ServicioCategorias()
        {

        }
        public void Borrar(int id)
        {
            try
            {
                conexion = new ConexionBd();
                repositorio = new RepositorioCategorias(conexion.AbrirConexion());
                repositorio.Borrar(id);
                conexion.CerrarConexion();
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
                conexion = new ConexionBd();
                repositorio = new RepositorioCategorias(conexion.AbrirConexion());
                bool relacionado = repositorio.EstaRelacionado(categoria);
                conexion.CerrarConexion();
                return relacionado;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(Categoria categoria)
        {
            try
            {
                conexion = new ConexionBd();
                repositorio = new RepositorioCategorias(conexion.AbrirConexion());
                bool existe = repositorio.Existe(categoria);
                conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Categoria GetCategoria(string nombreCategoria)
        {
            try
            {
                conexion = new ConexionBd();
                repositorio = new RepositorioCategorias(conexion.AbrirConexion());
                Categoria categoria = repositorio.GetCategoria(nombreCategoria);
                conexion.CerrarConexion();
                return categoria;
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
                conexion = new ConexionBd();
                repositorio = new RepositorioCategorias(conexion.AbrirConexion());
                var categoria = repositorio.GetCategoriaPorId(id);
                conexion.CerrarConexion();
                return categoria;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Categoria> GetLista()
        {
            try
            {
                conexion = new ConexionBd();
                repositorio = new RepositorioCategorias(conexion.AbrirConexion());
                var lista = repositorio.GetLista();
                conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Categoria categoria)
        {
            try
            {
                conexion = new ConexionBd();
                repositorio = new RepositorioCategorias(conexion.AbrirConexion());
                repositorio.Guardar(categoria);
                conexion.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
