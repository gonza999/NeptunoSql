using System;

namespace NeptunoSql.BusinessLayer.Entities
{
    public class Categoria : ICloneable
    {
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
