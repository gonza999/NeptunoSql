using NeptunoSql.BusinessLayer.Entities;
using NeptunoSql.ServiceLayer.Servicios.Facades;
using System;
using System.Collections.Generic;

namespace NeptunoSql.ServiceLayer.Servicios
{
    public class ServicioProductos : IServicioProductos
    {
        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(Producto producto)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Producto producto)
        {
            throw new NotImplementedException();
        }

        public List<Producto> GetLista()
        {
            throw new NotImplementedException();
        }

        public Producto GetProductoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Producto producto)
        {
            throw new NotImplementedException();
        }
    }
}
