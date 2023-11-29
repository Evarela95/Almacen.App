using Almacen.Application.Contracts;
using Almacen.Domain.InputModels.Marca;
using Microsoft.AspNetCore.Mvc;

namespace Almacen.Web.Controllers
{
    public class MarcasController : Controller
    {

        private readonly IMarcaService _service;

        public MarcasController(IMarcaService service)
        {
            this._service = service;
        }


        public IActionResult Index()
        {
            var marcas = _service.List();
            return View(marcas);
        }





        public IActionResult AgregarMarca()
        {
            return View(new NewMarca());
        }

        [HttpPost]
        public IActionResult AgregarMarca(NewMarca newMarca)
        {
            if (ModelState.IsValid)
            {
                if (!_service.Insert(newMarca))
                {
                    ModelState.AddModelError(string.Empty, "Error");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View(new NewMarca());

        }






        [HttpGet]
        [Route("/marcas/ActualizarMarca/{Id_Marca}")]
        public IActionResult ActualizarMarca([FromRoute] int Id_Marca)
        {
            ExistingMarca existingMarca = _service.Get(Id_Marca);
            return View(existingMarca);
        }



        [HttpPost]
        [Route("/marcas/ActualizarMarca/{Id_Marca}")]
        public IActionResult ActualizarMarca(ExistingMarca existingMarca)
        {
            if (ModelState.IsValid)
            {
                if (!_service.Update(existingMarca))
                {
                    ModelState.AddModelError(string.Empty, "Error");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View(existingMarca);
        }




        [HttpDelete]
        [Route("/api/v1/marcas/delete/{Id_Marca}")]
        public JsonResult Delete([FromRoute] int Id_Marca)
        {
            if (_service.Delete(Id_Marca))
            {
                return Json(new { success = true });
            }

            return Json(new { success = false, errorMessage = "Error al eliminar" });
        }
    }
}
