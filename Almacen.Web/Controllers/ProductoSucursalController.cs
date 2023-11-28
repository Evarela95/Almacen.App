using Almacen.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Almacen.Web.Controllers
{
    public class ProductoSucursalController : Controller
    {
        private readonly IProducto_SucursalService _service;


        public ProductoSucursalController(IProducto_SucursalService service)
        {
            this._service = service;
        }
    }
}
