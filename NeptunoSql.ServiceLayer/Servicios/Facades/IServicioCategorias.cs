using NeptunoSql.BusinessLayer.Entities;
using System.Collections.Generic;

namespace NeptunoSql.ServiceLayer.Servicios.Facades
{
    public interface IServicioCategorias
    {
        Categoria GetCategoriaPorId(int id);
        List<Categoria> GetLista();
        void Guardar(Categoria categoria);
        void Borrar(int id);
        bool Existe(Categoria categoria);
        bool EstaRelacionado(Categoria categoria);
    }
}
