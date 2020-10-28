using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunoSql.BusinessLayer.Entities.Enums
{
    public enum EstadoVenta:byte
    {
        EnProceso=1,
        Facturada=2,
        Anulada=3
    }
}
