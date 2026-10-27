using MiInventario.DAL.Context;
using MiInventario.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiInventario.DAL.Repositories
{
    public class ProductoRepository
    {
        public List<ProductoEntity> GetAll()
        {
            using (var ctx = new InventarioContext())
            {
                return ctx.Productos.ToList();
            }
        }

        public void Add(ProductoEntity p)
        {
            using (var ctx = new InventarioContext())
            {
                ctx.Productos.Add(p);
                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new InventarioContext())
            {
                var p = ctx.Productos.Find(id);
                if (p != null)
                {
                    ctx.Productos.Remove(p);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
