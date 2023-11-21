using Almacen.Application.Contracts;
using Almacen.Application.Contracts.Repositories;
using Almacen.Domain.DTOs;
using Almacen.Domain.Entities;
using Almacen.Domain.InputModels.Categoria;

namespace Almacen.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            this._repository = repository;
        }

        public CategoriaDTO Get(int id)
        {
            var categoria = _repository.Get(s => s.Id_Categoria == id);
            return categoria.AsDTO();
        }

        public List<CategoriaDTO> List()
        {
            return _repository
                .GetAll().ToList()
                .ConvertAll(categoria => categoria.AsDTO());
        }

        public bool Insert(NewCategoria newCategoria)
        {
            Categoria categoria = new Categoria(newCategoria.Nombre_Categoria);
            _repository.Insert(categoria);
            _repository.Save();
            return true;
        }

        public bool Update(ExistingCategoria existingCategoria)
        {
            Categoria categoria = _repository.Get(s => s.Id_Categoria == existingCategoria.Id_Categoria);
            categoria.Update(existingCategoria.Nombre_Categoria);
            _repository.Update(categoria);
            _repository.Save();
            return true;
        }

        public bool Delete(int id)
        {
            Categoria categoria = _repository.Get(s => s.Id_Categoria == id);
            _repository.Delete(categoria);
            _repository.Save();
            return true;
        }
    }
}
