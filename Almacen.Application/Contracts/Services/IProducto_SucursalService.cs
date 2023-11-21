using Almacen.Domain.DTOs;
using Almacen.Domain.InputModels.Producto_Sucursal;

namespace Almacen.Application.Contracts
{
    public interface IProducto_SucursalService
    {
        Producto_SucursalDTO Get(int id);

        List<Producto_SucursalDTO> List();

        bool Insert(NewProducto_Sucursal newProducto_Sucursal);

        bool Update(ExistingProducto_Sucursal existingProducto_Sucursal);

        bool Delete(int id);
    }
}
