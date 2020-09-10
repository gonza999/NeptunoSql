using NeptunoSql.BusinessLayer.Entities;
using System.Collections.Generic;

namespace NeptunoSql.ServiceLayer.Servicios.Facades
{
    public interface IServicioProductos
    {
        Producto GetProductoPorId(int id);
        List<Producto> GetLista();
        void Guardar(Producto producto);
        void Borrar(int id);
        bool Existe(Producto producto);
        bool EstaRelacionado(Producto producto);
    }
}
