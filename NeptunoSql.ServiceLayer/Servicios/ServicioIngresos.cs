using NeptunoSql.DataLayer;
using NeptunoSql.DataLayer.Repositorios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunoSql.ServiceLayer.Servicios
{
    public class ServicioIngresos
    {
        private IRepositorioIngresos repositorioIgresos;
        private IRepositorioDetallesIngresos repositorioDetalleIngresos;
        private IRepositorioProductos repositorioProductos;
        private ConexionBd conexion;
    }
}
