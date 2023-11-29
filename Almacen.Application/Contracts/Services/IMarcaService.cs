using Almacen.Domain.DTOs;
using Almacen.Domain.DTOs.MarcaDTO;
using Almacen.Domain.InputModels.Marca;

namespace Almacen.Application.Contracts
{
    public interface IMarcaService
    {
        MarcaDTO Get(int id);

        List<MarcaDTO> List();

        bool Insert(NewMarca newMarca);

        bool Update(ExistingMarca existingMarca);

        bool Delete(int Id_Marca);
    }
}
