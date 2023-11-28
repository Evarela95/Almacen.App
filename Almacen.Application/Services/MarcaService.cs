using Almacen.Application.Contracts;
using Almacen.Application.Contracts.Repositories;
using Almacen.Domain.DTOs;
using Almacen.Domain.DTOs.MarcaDTO;
using Almacen.Domain.Entities;
using Almacen.Domain.InputModels.Marca;

namespace Almacen.Application.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _repository;

        public MarcaService(IMarcaRepository repository)
        {
            this._repository = repository;
        }

        public MarcaDTO Get(int id)
        {
            var marca = _repository.Get(s => s.Id_Marca == id);
            return marca.AsDTO();
        }

        public List<MarcaDTO> List()
        {
            return _repository
                .GetAll().ToList()
                .ConvertAll(marca => marca.AsDTO());
        }

        public bool Insert(NewMarca newMarca)
        {
            Marca marca = new Marca(newMarca.Nombre_Marca);
            _repository.Insert(marca);
            _repository.Save();
            return true;
        }

        public bool Update(ExistingMarca existingMarca)
        {
            Marca marca = _repository.Get(s => s.Id_Marca == existingMarca.Id_Marca);
            marca.Update(existingMarca.Nombre_Marca);
            _repository.Update(marca);
            _repository.Save();
            return true;
        }

        public bool Delete(int id)
        {
            Marca marca = _repository.Get(s => s.Id_Marca == id);
            _repository.Delete(marca);
            _repository.Save();
            return true;
        }
    }
}
