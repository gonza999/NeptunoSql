using NeptunoSql.BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunoSql.ServiceLayer.Servicios.Facades
{
    public interface IServicioIngresos
    {
        void Guardar(Ingreso ingreso);
    }
}
