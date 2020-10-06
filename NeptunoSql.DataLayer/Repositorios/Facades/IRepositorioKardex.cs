using NeptunoSql.BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunoSql.DataLayer.Repositorios.Facades
{
    public interface IRepositorioKardex
    {
        void Guardar(Kardex kardex);
        Kardex GetUltimoKardex(Producto producto);
    }
}
