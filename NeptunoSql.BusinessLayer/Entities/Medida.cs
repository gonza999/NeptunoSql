using System;

namespace NeptunoSql.BusinessLayer
{
    public class Medida : ICloneable
    {
        public int MedidaId { get; set; }

        public string Denominacion { get; set; }

        public string Abreviatura { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
