using MiInventario.BLL.Models;
using MiInventario.DAL.Entities;
using MiInventario.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiInventario.BLL.Services
{
    public class ProductoService
    {
        private readonly ProductoRepository _repo = new ProductoRepository();

        public List<Producto> ObtenerTodos()
        {
            return _repo.GetAll().Select(p => new Producto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Cantidad = p.Cantidad,
                Precio = p.Precio
            }).ToList();
        }

        public void Agregar(Producto p)
        {
            if (string.IsNullOrWhiteSpace(p.Nombre))
                throw new Exception("Nombre requerido");

            _repo.Add(new ProductoEntity
            {
                Nombre = p.Nombre,
                Cantidad = p.Cantidad,
                Precio = p.Precio
            });
        }

        public void Eliminar(int id)
        {
            _repo.Delete(id);
        }
    }
}
