using System;
using System.Collections.Generic;
using NeptunoSql.BusinessLayer.Entities;
using NeptunoSql.DataLayer;
using NeptunoSql.DataLayer.Repositorios;
using NeptunoSql.DataLayer.Repositorios.Facades;
using NeptunoSql.ServiceLayer.Servicios.Facades;

namespace NeptunoSql.ServiceLayer.Servicios
{
    public class ServicioMarcas:IServicioMarcas
    {
        private ConexionBd _conexion;
        private IRepositorioMarcas _repositorio;


        public List<Marca> GetLista()
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioMarcas(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Marca marca)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioMarcas(_conexion.AbrirConexion());
                _repositorio.Guardar(marca);
                _conexion.CerrarConexion();

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
                _conexion = new ConexionBd();
                _repositorio = new RepositorioMarcas(_conexion.AbrirConexion());
                var existe = _repositorio.Existe(marca);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Marca marca)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioMarcas(_conexion.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(marca);
                _conexion.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public void Borrar(int id)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioMarcas(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public Marca GetMarcaPorId(int id)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioMarcas(_conexion.AbrirConexion());
                var marca= _repositorio.GetMarcaPorId(id);
                _conexion.CerrarConexion();
                return marca;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


    }
}
