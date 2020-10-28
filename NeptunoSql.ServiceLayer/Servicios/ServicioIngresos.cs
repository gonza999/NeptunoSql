using NeptunoSql.BusinessLayer.Entities;
using NeptunoSql.DataLayer;
using NeptunoSql.DataLayer.Repositorios;
using NeptunoSql.DataLayer.Repositorios.Facades;
using NeptunoSql.ServiceLayer.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunoSql.ServiceLayer.Servicios
{
    public class ServicioIngresos:IServicioIngresos
    {
        private IRepositorioIngresos repositorioIngresos;
        private IRepositorioDetallesIngresos repositorioDetalleIngresos;
        private IRepositorioProductos repositorioProductos;
        private IRepositorioKardex repositorioKardex;
        private ConexionBd conexion;

        public ServicioIngresos()
        {

        }

        public void Guardar(Ingreso ingreso)
        {
            conexion = new ConexionBd();
            SqlTransaction transaction = null;
            try
            {
                SqlConnection cn = conexion.AbrirConexion();
                transaction = cn.BeginTransaction();
                repositorioIngresos = new RepositorioIngresos(cn,transaction);
                repositorioDetalleIngresos = new RepositorioDetallesIngresos(cn, transaction);
                repositorioProductos = new RepositorioProductos(cn, transaction);
                repositorioKardex = new RepositorioKardex(transaction,cn);

                repositorioIngresos.Guardar(ingreso);
                foreach (var detalleIngreso in ingreso.DetalleIngresos)
                {
                    detalleIngreso.Ingreso = ingreso;
                    Kardex kardex = repositorioKardex.GetUltimoKardex(detalleIngreso.Producto);
                    if (kardex==null)
                    {
                        kardex = new Kardex();
                        kardex.Producto = detalleIngreso.Producto;
                        kardex.Fecha = ingreso.Fecha;
                        kardex.Movimiento =$"Ingreso numero {ingreso.IngresoId}";
                        kardex.Entrada = detalleIngreso.Cantidad;
                        kardex.Salida = 0;
                        kardex.Saldo = detalleIngreso.Cantidad;
                    }
                    else
                    {
                        kardex.Fecha = ingreso.Fecha;
                        kardex.Movimiento = $"Ingreso numero {ingreso.IngresoId}";
                        kardex.Entrada = detalleIngreso.Cantidad;
                        kardex.Salida = 0;
                        kardex.Saldo += detalleIngreso.Cantidad;
                    }
                    repositorioKardex.Guardar(kardex);
                    detalleIngreso.Kardex = kardex;
                    repositorioDetalleIngresos.Guardar(detalleIngreso);
                    repositorioProductos.ActualizarStock(detalleIngreso.Producto,detalleIngreso.Cantidad);
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception(e.Message);
            }
        }
    }
}
