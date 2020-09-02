using System.Collections.Generic;
using NeptunoSql.BusinessLayer.Entities;

namespace NeptunoSql.ServiceLayer.Servicios.Facades
{
    public interface IServicioMarcas
    {
        Marca GetMarcaPorId(int id);
        List<Marca> GetLista();
        void Guardar(Marca marca);
        void Borrar(int id);
        bool Existe(Marca marca);
        bool EstaRelacionado(Marca marca);

    }
}
