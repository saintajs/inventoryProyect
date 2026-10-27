using MiInventario.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace MiInventario.DAL.Context
{
    public class InventarioContext : DbContext
    {
        public InventarioContext() : base("name=InventarioDB") { }
        public DbSet<ProductoEntity> Productos { get; set; } = null!;
    }
}
