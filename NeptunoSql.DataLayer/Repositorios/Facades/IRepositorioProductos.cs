﻿using NeptunoSql.BusinessLayer.Entities;
using System.Collections.Generic;

namespace NeptunoSql.DataLayer.Repositorios.Facades
{
    public interface IRepositorioProductos
    {
        Producto GetProductoPorId(int id);
        List<Producto> GetLista();
        List<Producto> GetLista(int marcaId);

        List<Producto> GetLista(Categoria categoria);
        void Guardar(Producto producto);
        void Borrar(int id);
        bool Existe(Producto producto);
        bool EstaRelacionado(Producto producto);
        void ActualizarStock(Producto producto, decimal cantidad);
        Producto GetProductoPorCodigoDeBarras(string codigo);
        List<Producto> GetLista(string descripcion);
    }
}
