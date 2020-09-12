using NeptunoSql.BusinessLayer;
using NeptunoSql.DataLayer;
using NeptunoSql.DataLayer.Repositorios;
using NeptunoSql.DataLayer.Repositorios.Facades;
using NeptunoSql.ServiceLayer.Servicios.Facades;
using System;
using System.Collections.Generic;

namespace NeptunoSql.ServiceLayer.Servicios
{
    public class ServicioMedidas : IServicioMedidas
    {
        private ConexionBd conexion;
        private IRepositorioMedidas repositorio;
        public void Borrar(int id)
        {
            try
            {
                conexion = new ConexionBd();
                repositorio = new RepositorioMedidas(conexion.AbrirConexion());
                repositorio.Borrar(id);
                conexion.CerrarConexion();
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
                conexion = new ConexionBd();
                repositorio = new RepositorioMedidas(conexion.AbrirConexion());
                var relacionado = repositorio.EstaRelacionado(medida);
                conexion.CerrarConexion();
                return relacionado;

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
                conexion = new ConexionBd();
                repositorio = new RepositorioMedidas(conexion.AbrirConexion());
                var existe = repositorio.Existe(medida);
                conexion.CerrarConexion();
                return existe;

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
                conexion = new ConexionBd();
                repositorio = new RepositorioMedidas(conexion.AbrirConexion());
                var lista = repositorio.GetLista();
                conexion.CerrarConexion();
                return lista;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Medida GetMedidaPorId(int id)
        {
            try
            {
                conexion = new ConexionBd();
                repositorio = new RepositorioMedidas(conexion.AbrirConexion());
                var medida = repositorio.GetMedidaPorId(id);
                conexion.CerrarConexion();
                return medida;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Medida medida)
        {
            try
            {
                conexion = new ConexionBd();
                repositorio = new RepositorioMedidas(conexion.AbrirConexion());
                repositorio.Guardar(medida);
                conexion.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
