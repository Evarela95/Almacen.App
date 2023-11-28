using Almacen.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Almacen.Web.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _service;

        public CategoriasController(ICategoriaService service)
        {
            this._service = service;
        }



        public IActionResult Index()
        {
            var categorias = _service.List();
            return View(categorias);
        }
    }
}
