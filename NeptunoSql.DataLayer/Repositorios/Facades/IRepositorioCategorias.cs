using NeptunoSql.BusinessLayer.Entities;
using System.Collections.Generic;

namespace NeptunoSql.DataLayer.Repositorios.Facades
{
    public interface IRepositorioCategorias
    {
        Categoria GetCategoriaPorId(int id);
        List<Categoria> GetLista();
        void Guardar(Categoria categoria);
        void Borrar(int id);
        bool Existe(Categoria categoria);
        bool EstaRelacionado(Categoria categoria);
    }
}
