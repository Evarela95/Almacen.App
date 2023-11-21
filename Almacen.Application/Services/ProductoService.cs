using Almacen.Application.Contracts;
using Almacen.Application.Contracts.Repositories;
using Almacen.Domain.DTOs;
using Almacen.Domain.Entities;
using Almacen.Domain.InputModels.Producto;

namespace Almacen.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            this._repository = repository;
        }

        public ProductoDTO Get(int id)
        {
            var producto = _repository.Get(s => s.Id_Producto == id);
            return producto.AsDTO();
        }

        public List<ProductoDTO> List()
        {
            return _repository
                .GetAll().ToList()
                .ConvertAll(producto => producto.AsDTO());
        }

        public bool Insert(NewProducto newProducto)
        {
            Producto producto = new Producto(newProducto.Nombre_Producto, newProducto.Descripcion, newProducto.Precio_Compra, newProducto.Precio_Venta,
                newProducto.Id_Marca, newProducto.Id_Proveedor, newProducto.Id_Categoria);
            _repository.Insert(producto);
            _repository.Save();
            return true;
        }

        public bool Update(ExistingProducto existingProducto)
        {
            Producto producto = _repository.Get(s => s.Id_Producto == existingProducto.Id_Producto);
            producto.Update(existingProducto.Nombre_Producto, existingProducto.Descripcion, existingProducto.Precio_Compra, existingProducto.Precio_Venta,
                existingProducto.Id_Marca, existingProducto.Id_Proveedor, existingProducto.Id_Categoria);
            _repository.Update(producto);
            _repository.Save();
            return true;
        }

        public bool Delete(int id)
        {
            Producto categoria = _repository.Get(s => s.Id_Producto == id);
            _repository.Delete(categoria);
            _repository.Save();
            return true;
        }
    }
}
