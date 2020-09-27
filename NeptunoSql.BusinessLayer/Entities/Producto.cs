using System;

namespace NeptunoSql.BusinessLayer.Entities
{
    public class Producto : ICloneable
    {
        public int ProductoId { get; set; }

        public string Descripcion { get; set; }

        public Marca Marca { get; set; }

        public Categoria Categoria { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Stock { get; set; }

        public string CodigoBarra { get; set; }

        public Medida Medida { get; set; }

        public string Imagen { get; set; }

        public bool Suspendido { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{Marca.NombreMarca} {Descripcion}";
        }
    }
}
