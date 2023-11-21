using Almacen.Domain.DTOs;
using Almacen.Domain.InputModels.Producto;

namespace Almacen.Application.Contracts
{
    public interface IProductoService
    {
        ProductoDTO Get(int id);

        List<ProductoDTO> List();

        bool Insert(NewProducto newProducto);

        bool Update(ExistingProducto existingProducto);

        bool Delete(int id);
    }
}
