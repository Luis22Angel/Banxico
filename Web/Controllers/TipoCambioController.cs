using Microsoft.AspNetCore.Mvc;
using Web.Conexion;
using Web.Models;

namespace Web.Controllers
{
	public class TipoCambioController : Controller
	{
		TipoCambioDatos _cambio = new TipoCambioDatos();
		public IActionResult ListaCambio()
		{
			var lista = _cambio.ListarCambio();
			return View(lista);
		}
		public IActionResult GuardarCambio()
		{
			return View();
		}

		[HttpPost]
		public IActionResult GuardarCambio(TipoCambioModel cambioModel)
		{
            if (!ModelState.IsValid)
                return View();

            var resp = _cambio.Guardar(cambioModel);

			if (resp)
				return RedirectToAction("ListaCambio");
			else
				return View();
		}

        public IActionResult EditarCambio(int IdTipoCambio)
        {
			var cambio = _cambio.ObtenerTipoCambio(IdTipoCambio);
            return View(cambio);
        }

		[HttpPost]
        public IActionResult EditarCambio(TipoCambioModel cambioModel)
        {
			if (!ModelState.IsValid)
				return View();

            var resp = _cambio.Editar(cambioModel);

            if (resp)
                return RedirectToAction("ListaCambio");
            else
				return View();
			
            
        }

		public IActionResult Eliminar(int IdTipoCambio)
		{
			var cambio = _cambio.ObtenerTipoCambio(IdTipoCambio);
			return View(cambio);
		}

		[HttpPost]
        public IActionResult Eliminar(TipoCambioModel IdTipoCambio)
        {
			var resp = _cambio.Eliminar(IdTipoCambio.Id);

			if (resp)
				return RedirectToAction("ListaCambio");
			else
				return View();
        }
    }
}
