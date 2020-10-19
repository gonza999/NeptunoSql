using NeptunoSql.BusinessLayer.Entities;
using System.Collections.Generic;

namespace NeptunoSql.ServiceLayer.Servicios.Facades
{
    public interface IServicioProductos
    {
        Producto GetProductoPorId(int id);
        List<Producto> GetLista();
        List<Producto> GetLista(int marcaId);
        List<Producto> GetLista(Categoria categoria);
        void Guardar(Producto producto);
        void Borrar(int id);
        bool Existe(Producto producto);
        bool EstaRelacionado(Producto producto);
        Producto GetProductoPorCodigoDeBarras(string codigo);
        List<Producto> GetLista(string descripcion);
    }
}
