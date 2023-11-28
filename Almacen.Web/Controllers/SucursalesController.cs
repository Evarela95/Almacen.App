using Almacen.Application.Contracts;
using Almacen.Domain.InputModels.Sucursal;
using Microsoft.AspNetCore.Mvc;

namespace Almacen.Web.Controllers
{
    public class SucursalesController : Controller
    {

        private readonly ISucursalService _service;


        public SucursalesController(ISucursalService service)
        {
            this._service = service;
        }
        public IActionResult Index()
        {
            var sucursales = _service.List();
            return View(sucursales);
        }



        public IActionResult AgregarSucursal()
        {
            return View(new NewSucursal());
        }



        [HttpPost]
        public IActionResult AgregarSucursal(NewSucursal newSucursal)
        {
            if (ModelState.IsValid)
            {
                if (!_service.Insert(newSucursal))
                {
                    ModelState.AddModelError(string.Empty, "Error");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View(new NewSucursal());

        }




        [HttpGet]
        [Route("/sucursales/ActualizarSucursal/{id_sucursal}")]
        public IActionResult ActualizarSucursal([FromRoute] int id_sucursal)
        {
            ExistingSucursal existingSucursal = _service.Get(id_sucursal);
            return View(existingSucursal);
        }

        [HttpPost]
        [Route("/sucursales/ActualizarSucursal/{id_sucursal}")]
        public IActionResult ActualizarSucursal(ExistingSucursal existingSucursal)
        {
            if (ModelState.IsValid)
            {
                if (!_service.Update(existingSucursal))
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar");
 
                    return View(existingSucursal);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
     
            return View(existingSucursal);
        }



        [HttpDelete]
        [Route("/api/v1/sucursales/Eliminar/{id_sucursal}")]
        public JsonResult Eliminar([FromRoute] int id_sucursal)
        {
            if (_service.Delete(id_sucursal))
            {
                return Json(new { success = true });
            }

            return Json(new { success = false, errorMessage = "Error al eliminar" });
        }

    }
}
