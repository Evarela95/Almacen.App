using Almacen.Application.Contracts;
using Almacen.Domain.InputModels.Categoria;
using Almacen.Infrastructure.Authorization;
using Microsoft.AspNetCore.Authorization;
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


        [Authorize(Policy = PolicyTypes.Guests.Read)]
        public IActionResult Index()
        {
            var categorias = _service.List();
            return View(categorias);
        }





        public IActionResult AgregarCategoria()
        {
            return View(new NewCategoria());
        }



        [HttpPost]
        [Authorize(Policy = PolicyTypes.Guests.Create)]
        public IActionResult AgregarCategoria(NewCategoria newCategoria)
        {
            if (ModelState.IsValid)
            {
                if (!_service.Insert(newCategoria))
                {
                    ModelState.AddModelError(string.Empty, "Error");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View(new NewCategoria());

        }



        [HttpGet]
        [Route("/categorias/ActualizarCategoria/{id_categoria}")]
        public IActionResult ActualizarCategoria([FromRoute] int id_categoria)
        {
            ExistingCategoria existingCategoria = _service.Get(id_categoria);
            return View(existingCategoria);

        }

        [HttpPost]
        [Route("/categorias/ActualizarCategoria/{id_categoria}")]
        [Authorize(Policy = PolicyTypes.Guests.Edit)]
        public IActionResult ActualizarCategoria(ExistingCategoria existingCategoria)
        {
            if (ModelState.IsValid)
            {
                if (!_service.Update(existingCategoria))
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar");

                    return View(existingCategoria);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            return View(existingCategoria);
        }





        [HttpDelete]
        [Route("/api/v1/categorias/Eliminar/{id_categoria}")]
        [Authorize(Policy = PolicyTypes.Guests.Delete)]
        public JsonResult Eliminar([FromRoute] int id_categoria)
        {
            if (_service.Delete(id_categoria))
            {
                return Json(new { success = true });
            }

            return Json(new { success = false, errorMessage = "Error al eliminar" });
        }
    }
}
