using NeptunoSql.BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunoSql.DataLayer.Repositorios.Facades
{
    public interface IRepositorioVentas
    {
        void Guardar(Venta venta);
        decimal GetTotalVenta(int ventaId);
        void FacturarVenta(int ventaId);
    }
}
