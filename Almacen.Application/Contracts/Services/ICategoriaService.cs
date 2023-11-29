using Almacen.Domain.DTOs;
using Almacen.Domain.DTOs.CategoriaDTO;
using Almacen.Domain.InputModels.Categoria;

namespace Almacen.Application.Contracts
{
    public interface ICategoriaService
    {
        CategoriaDTO Get(int id_categoria);

        List<CategoriaDTO> List();

        bool Insert(NewCategoria newCategoria);

        bool Update(ExistingCategoria existingCategoria);

        bool Delete(int id_categoria);
    }
}
