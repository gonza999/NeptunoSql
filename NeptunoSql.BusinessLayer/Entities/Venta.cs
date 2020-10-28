using NeptunoSql.BusinessLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunoSql.BusinessLayer.Entities
{
    public class Venta
    {
        public int VentaId { get; set; }

        public DateTime Fecha { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Descuentos { get; set; }

        public decimal Total { get; set; }

        public List<DetalleVenta> DetalleVentas { get; set; } = new List<DetalleVenta>();

        public EstadoVenta Estado { get; set; }
    }
}
