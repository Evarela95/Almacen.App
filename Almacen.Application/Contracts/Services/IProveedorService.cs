using Almacen.Domain.DTOs;
using Almacen.Domain.DTOs.ProveedorDTO;
using Almacen.Domain.InputModels.Proveedor;

namespace Almacen.Application.Contracts
{
    public interface IProveedorService
    {
        ProveedorDTO Get(int id);

        List<ProveedorDTO> List();

        bool Insert(NewProveedor newProveedor);

        bool Update(ExistingProveedor existingProveedor);

        bool Delete(int Id_Proveedor);
    }
}
