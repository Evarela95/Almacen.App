using Almacen.Domain.DTOs;
using Almacen.Domain.DTOs.SucursalDTO;
using Almacen.Domain.InputModels.Sucursal;

namespace Almacen.Application.Contracts
{
    public interface ISucursalService
    {
        SucursalDTO Get(int id_sucursal);

        List<SucursalDTO> List();

        bool Insert(NewSucursal newSucursal);

        bool Update(ExistingSucursal existingSucursal);

        bool Delete(int id_sucursal);
    }
}
