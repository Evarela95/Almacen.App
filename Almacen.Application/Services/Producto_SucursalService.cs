using Almacen.Application.Contracts;
using Almacen.Application.Contracts.Repositories;
using Almacen.Domain.DTOs;
using Almacen.Domain.DTOs.Producto_SucursalDTO;
using Almacen.Domain.Entities;
using Almacen.Domain.InputModels.Producto_Sucursal;

namespace Almacen.Application.Services
{
    public class Producto_SucursalService : IProducto_SucursalService
    {
        private readonly IProducto_SucursalRepository _repository;

        public Producto_SucursalService(IProducto_SucursalRepository repository)
        {
            this._repository = repository;
        }

        public Producto_SucursalDTO Get(int id)
        {
            var producto_sucursal = _repository.Get(s => s.Id == id);
            return producto_sucursal.AsDTO();
        }

        public List<Producto_SucursalDTO> List()
        {
            return _repository
                .GetAll().ToList()
                .ConvertAll(producto_sucursal => producto_sucursal.AsDTO());
        }

        public bool Insert(NewProducto_Sucursal newProducto_Sucursal)
        {
            Producto_Sucursal producto_sucursal = new Producto_Sucursal(newProducto_Sucursal.Id_Producto, 
                newProducto_Sucursal.Id_Sucursal, newProducto_Sucursal.Cantidad);
            _repository.Insert(producto_sucursal);
            _repository.Save();
            return true;
        }

        public bool Update(ExistingProducto_Sucursal existingProducto_Sucursal)
        {
            Producto_Sucursal producto_sucursal = _repository.Get(s => s.Id == existingProducto_Sucursal.Id);
            producto_sucursal.Update(existingProducto_Sucursal.Cantidad, existingProducto_Sucursal.Id_Producto, existingProducto_Sucursal.Id_Sucursal);
            _repository.Update(producto_sucursal);
            _repository.Save();
            return true;
        }

        public bool Delete(int id)
        {
            Producto_Sucursal producto_sucursal = _repository.Get(s => s.Id == id);
            _repository.Delete(producto_sucursal);
            _repository.Save();
            return true;
        }


    }
}
