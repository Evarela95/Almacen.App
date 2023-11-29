using Almacen.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Almacen.Web.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductoService _service;


        public ProductosController(IProductoService service)
        {
            this._service = service;
        }


        public IActionResult Index()
        {
         
            var sucursales = _service.List();
            return View(sucursales);
        }
    }
}
