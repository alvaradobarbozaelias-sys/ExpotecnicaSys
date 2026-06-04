using CrudNet8.Datos;
using Microsoft.AspNetCore.Mvc;
using CrudNet8.Models;

namespace CrudNet8.Controllers
{
    public class CrudJuezLogController : Controller
    {
         readonly ApplicationDbContext _context;
        public CrudJuezLogController(ApplicationDbContext context)
        {
        _context = context;
        }

        [HttpGet]
        public IActionResult EvaluacionV()
        {
            return View("~/Views/JuezV/EvaluacionV.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarCalificacion(Models.ViewModels.CevaluacionVM evaluacionVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage1"] = "Por favor, complete todos los campos obligatorios.";
                return View("~/Views/JuezV/EvaluacionV.cshtml", evaluacionVM);
            }
            try
            {
                var nuevaCalificacion = new Models.EvaluacionesM
                {
                    Categoria = evaluacionVM.CevCategoriaVM,
                    Proyecto = evaluacionVM.CevProyectoVM,
                    Evaluador = evaluacionVM.CevEvaluadorVM,
                    Fecha = evaluacionVM.CevFechaVM,
                    PuntajeObtenido = evaluacionVM.CevPuntajeObtenidoVM,
                    Observaciones = evaluacionVM.CevObservacionesVM
                };

                _context.Evaluaciones.Add(nuevaCalificacion);
                _context.SaveChanges();

                TempData["SuccessMessage2"] = "Calificación creada correctamente.";
                return RedirectToAction("JuezLogV", "Dashboards");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage3"] = "Ocurrió un error al guardar el usuario." + "  " + ex.Message;
                return View("~/Views/JuezV/EvaluacionV.cshtml");
            }
        }
    }
}
