using Almacen.Application.Contracts;
using Almacen.Application.Contracts.Repositories;
using Almacen.Domain.DTOs;
using Almacen.Domain.DTOs.ProveedorDTO;
using Almacen.Domain.Entities;
using Almacen.Domain.InputModels.Proveedor;

namespace Almacen.Application.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _repository;

        public ProveedorService(IProveedorRepository repository)
        {
            this._repository = repository;
        }

        public ProveedorDTO Get(int id)
        {
            var proveedor = _repository.Get(s => s.Id_Proveedor == id);
            return proveedor.AsDTO();
        }

        public List<ProveedorDTO> List()
        {
            return _repository
                .GetAll().ToList()
                .ConvertAll(proveedor => proveedor.AsDTO());
        }

        public bool Insert(NewProveedor newProveedor)
        {
            Proveedor proveedor = new Proveedor(newProveedor.Nombre_Proveedor, newProveedor.Telefono, newProveedor.Correo);
            _repository.Insert(proveedor);
            _repository.Save();
            return true;
        }

        public bool Update(ExistingProveedor existingProveedor)
        {
            Proveedor proveedor = _repository.Get(s => s.Id_Proveedor == existingProveedor.Id_Proveedor);
            proveedor.Update(existingProveedor.Nombre_Proveedor, existingProveedor.Telefono, existingProveedor.Correo);
            _repository.Update(proveedor);
            _repository.Save();
            return true;
        }

        public bool Delete(int Id_Proveedor)
        {
            Proveedor proveedor = _repository.Get(s => s.Id_Proveedor == Id_Proveedor);
            _repository.Delete(proveedor);
            _repository.Save();
            return true;
        }
    }
}
