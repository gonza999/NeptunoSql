using NeptunoSql.BusinessLayer.Entities;
using NeptunoSql.DataLayer.Repositorios.Facades;
using System.Collections.Generic;

namespace NeptunoSql.DataLayer.Repositorios
{
    public class RepositorioProductos : IRepositorioProductos
    {
        public void Borrar(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool EstaRelacionado(Producto producto)
        {
            throw new System.NotImplementedException();
        }

        public bool Existe(Producto producto)
        {
            throw new System.NotImplementedException();
        }

        public List<Producto> GetLista()
        {
            throw new System.NotImplementedException();
        }

        public Producto GetProductoPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Guardar(Producto producto)
        {
            throw new System.NotImplementedException();
        }
    }
}
