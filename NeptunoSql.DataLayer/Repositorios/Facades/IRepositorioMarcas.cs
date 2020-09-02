using System.Collections.Generic;
using NeptunoSql.BusinessLayer.Entities;

namespace NeptunoSql.DataLayer.Repositorios.Facades
{
    public interface IRepositorioMarcas
    {
        Marca GetMarcaPorId(int id);
        List<Marca> GetLista();
        void Guardar(Marca marca);
        void Borrar(int id);
        bool Existe(Marca marca);
        bool EstaRelacionado(Marca marca);
    }
}
