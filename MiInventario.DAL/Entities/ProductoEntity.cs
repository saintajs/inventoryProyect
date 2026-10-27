using System;
using System.Collections.Generic;
using System.Text;

namespace MiInventario.DAL.Entities
{
    public class ProductoEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
