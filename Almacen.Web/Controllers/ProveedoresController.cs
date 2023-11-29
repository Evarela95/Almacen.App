using Almacen.Application.Contracts;
using Almacen.Domain.InputModels.Proveedor;
using Almacen.Domain.InputModels.Sucursal;
using Microsoft.AspNetCore.Mvc;

namespace Almacen.Web.Controllers
{
    public class ProveedoresController : Controller
    {

        private readonly IProveedorService _service;


        public ProveedoresController(IProveedorService service)
        {
            this._service = service;
        }


        public IActionResult Index()
        {
            var proveedores = _service.List();
            return View(proveedores);
        }



        public IActionResult AgregarProveedor()
        {
            return View(new NewProveedor());
        }



        [HttpPost]
        public IActionResult AgregarProveedor(NewProveedor newProveedor)
        {
            if (ModelState.IsValid)
            {
                if (!_service.Insert(newProveedor))
                {
                    ModelState.AddModelError(string.Empty, "Error");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View(new NewProveedor());

        }




        [HttpGet]
        [Route("/proveedores/ActualizarProveedor/{Id_Proveedor}")]
        public IActionResult ActualizarProveedor([FromRoute] int Id_Proveedor)
        {
            ExistingProveedor existingProveedor = _service.Get(Id_Proveedor);
            return View(existingProveedor);
        }

        [HttpPost]
        [Route("/proveedores/ActualizarProveedor/{Id_Proveedor}")]
        public IActionResult ActualizarProveedor(ExistingProveedor existingProveedor)
        {
            if (ModelState.IsValid)
            {
                if (!_service.Update(existingProveedor))
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar");

                    return View(existingProveedor);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            return View(existingProveedor);
        }



        [HttpDelete]
        [Route("/api/v1/proveedores/Eliminar/{Id_Proveedor}")]
        public JsonResult Eliminar([FromRoute] int Id_Proveedor)
        {
            if (_service.Delete(Id_Proveedor))
            {
                return Json(new { success = true });
            }

            return Json(new { success = false, errorMessage = "Error al eliminar" });
        }



    }
}
