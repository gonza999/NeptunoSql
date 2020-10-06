using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunoSql.BusinessLayer.Entities
{
   public class DetalleIngreso
    {
        public int DetalleIngresoId { get; set; }

        public Ingreso Ingreso { get; set; }

        public Producto Producto { get; set; }
        public decimal Cantidad { get; set; }

        public Kardex Kardex { get; set; }
    }
}
