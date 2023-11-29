using Almacen.Application.Contracts;
using Almacen.Application.Contracts.Repositories;
using Almacen.Domain.DTOs;
using Almacen.Domain.DTOs.SucursalDTO;
using Almacen.Domain.Entities;
using Almacen.Domain.InputModels.Sucursal;

namespace Almacen.Application.Services
{
    public class SucursalService : ISucursalService
    {
        private readonly ISucursalRepository _repository;

        public SucursalService(ISucursalRepository repository)
        {
            this._repository = repository;
        }

        public SucursalDTO Get(int id)
        {
            var sucursal = _repository.Get(s => s.Id_Sucursal == id);
            return sucursal.AsDTO();
        }

        public List<SucursalDTO> List()
        {
            return _repository
                .GetAll().ToList()
                .ConvertAll(sucursal => sucursal.AsDTO());
        }

        public bool Insert(NewSucursal newSucursal)
        {
            Sucursal sucursal = new Sucursal(newSucursal.Nombre_Sucursal, newSucursal.Telefono, newSucursal.Correo, newSucursal.Direccion);
            _repository.Insert(sucursal);
            _repository.Save();
            return true;
        }

        public bool Update(ExistingSucursal existingSucursal)
        {
            Sucursal sucursal = _repository.Get(s => s.Id_Sucursal == existingSucursal.Id_Sucursal);
            sucursal.Update(existingSucursal.Nombre_Sucursal, existingSucursal.Telefono, existingSucursal.Correo, existingSucursal.Direccion);
            _repository.Update(sucursal);
            _repository.Save();
            return true;
        }

        public bool Delete(int id)
        {
            Sucursal sucursal = _repository.Get(s => s.Id_Sucursal == id);
            _repository.Delete(sucursal);
            _repository.Save();
            return true;
        }
    }
}
