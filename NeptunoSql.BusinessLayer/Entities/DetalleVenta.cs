using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunoSql.BusinessLayer.Entities
{
    public class DetalleVenta
    {
        public int DetalleVentaId { get; set; }

        public Venta Venta { get; set; }

        public Producto Producto { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Cantidad { get; set; }

        public decimal Descuento { get; set; }

        public decimal Total { get; set; }

        public Kardex Kardex { get; set; }
    }
}
