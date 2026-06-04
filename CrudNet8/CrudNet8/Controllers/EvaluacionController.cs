using Microsoft.AspNetCore.Mvc;

namespace CrudNet8.Controllers
{
    public class EvaluacionController : Controller
    {
        // Lista estática simulando la base de datos temporal
        //private static List<Evaluacion> _evaluaciones = new List<Evaluacion>();

        // Vista formulario
        //public IActionResult Evaluacion()
        //{
        //    return View();
        //}

        //// Guardar evaluación (POST)
        //[HttpPost]
        //public IActionResult GuardarEvaluacion(Evaluacion evaluacion)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        evaluacion.Fecha = DateTime.Now; // Guardar fecha actual

        //        // 🔹 Calcula el total automáticamente
        //        if (evaluacion.Rubrica != null && evaluacion.Rubrica.Count > 0)
        //        {
        //            // evaluacion.Calificacion = evaluacion.Rubrica.Values.Sum().ToString();
        //        }

        //        _evaluaciones.Add(evaluacion); // Guardar en la lista temporal

        //        ViewBag.Mensaje = "✅ Evaluación guardada correctamente.";
        //        ModelState.Clear(); // Limpia el formulario
        //        return View("Evaluacion");
        //    }

        //    // Si algo falla, vuelve al formulario con los datos
        //    return View("Evaluacion", evaluacion);
        //}

        //// Historial de evaluaciones
        //public IActionResult Resultados()
        //{
        //    return View(_evaluaciones);
        //}

        //// Vista opcional de Cards
        //public IActionResult Cards()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult EliminarTodo()
        //{
        //    _evaluaciones.Clear(); // Limpia la lista de evaluaciones
        //    return RedirectToAction("Resultados"); // Vuelve a la vista Resultados vacía
        //}
    }
}

