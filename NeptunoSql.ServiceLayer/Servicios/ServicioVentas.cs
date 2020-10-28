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
    public class ServicioVentas : IServicioVentas
    {
        private IRepositorioVentas repositorioVentas;
        private IRepositorioDetalleVentas repositorioDetalleVentas;
        private IRepositorioProductos repositorioProductos;
        private IRepositorioKardex repositorioKardex;
        private ConexionBd conexion;

        public ServicioVentas()
        {

        }

        public void FacturarVenta(int ventaId)
        {
            try
            {
                conexion = new ConexionBd();
                repositorioVentas = new RepositorioVentas(conexion.AbrirConexion());
                repositorioVentas.FacturarVenta(ventaId);
                conexion.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public decimal GetTotalVenta(int ventaId)
        {
            try
            {
                conexion = new ConexionBd();
                repositorioVentas = new RepositorioVentas(conexion.AbrirConexion());
                decimal total = repositorioVentas.GetTotalVenta(ventaId);
                conexion.CerrarConexion();
                return total;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Venta venta)
        {
            conexion = new ConexionBd();
            SqlTransaction transaction = null;
            try
            {
                SqlConnection cn = conexion.AbrirConexion();
                transaction = cn.BeginTransaction();
                repositorioVentas = new RepositorioVentas(cn, transaction);
                repositorioDetalleVentas = new RepositorioDetalleVentas(cn, transaction);
                repositorioProductos = new RepositorioProductos(cn, transaction);
                repositorioKardex = new RepositorioKardex(transaction, cn);

                repositorioVentas.Guardar(venta);
                foreach (var detalleVenta in venta.DetalleVentas)
                {
                    detalleVenta.Venta = venta;
                    Kardex kardex = repositorioKardex.GetUltimoKardex(detalleVenta.Producto);
                    if (kardex == null)
                    {
                        kardex = new Kardex();
                        kardex.Producto = detalleVenta.Producto;
                        kardex.Fecha = venta.Fecha;
                        kardex.Movimiento = $"Venta numero {venta.VentaId}";
                        kardex.Entrada = 0;
                        kardex.Salida = detalleVenta.Cantidad;
                        kardex.Saldo = detalleVenta.Cantidad;
                    }
                    else
                    {
                        kardex.Fecha = venta.Fecha;
                        kardex.Movimiento = $"Venta numero {venta.VentaId}";
                        kardex.Entrada = 0;
                        kardex.Salida = detalleVenta.Cantidad;
                        kardex.Saldo -= detalleVenta.Cantidad;
                    }
                    repositorioKardex.Guardar(kardex);
                    detalleVenta.Kardex = kardex;
                    repositorioDetalleVentas.Guardar(detalleVenta);
                    repositorioProductos.ActualizarStock(detalleVenta.Producto, -detalleVenta.Cantidad);
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
