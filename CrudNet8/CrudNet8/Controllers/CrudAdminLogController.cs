using CrudNet8.Datos;
using CrudNet8.Models;
using CrudNet8.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudNet8.Controllers
{
    public class CrudAdminLogController : Controller
    {
        readonly ApplicationDbContext _context;
        public CrudAdminLogController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ResultadosV()
        {
            return View("~/Views/AdminV/ResultadosV.cshtml");
        }

        public IActionResult CreateCategoriaV()
        {
            return View("~/Views/CrudCategoriaV/CreateCategoriaV.cshtml");
        }

        public IActionResult ReadCategoriaV()
        {
            return View("~/Views/CrudCategoriaV/ReadCategoriaV.cshtml");
        }

        public IActionResult UpdateCategoriaV()
        {
            return View("~/Views/CrudCategoriaV/UpdateCategoriaV.cshtml");
        }

        public IActionResult DeleteCategoriaV()
        {
            return View("~/Views/CrudCategoriaV/DeleteCategoriaV.cshtml");
        }

        public IActionResult CancelarCateg()
        {
            return RedirectToAction("CreateCategoriaV");
        }

        public IActionResult LeerCategoria()
        {
            //Traer solo las categorías activas de la base de datos
            var categorias = _context.Categoria
                .Where(c => c.EstadoCategoria == true)
                .ToList();

            // Mapear a ViewModel
            var RcategoriaVMs = categorias.Select(c => new RcategoriaVM
            {
                RidCategoriaVM = c.IdCategoria,
                RnombreCategoriaVM = c.NombreCategoria,
                RdescripcionCategoriaVM = c.DescripcionCategoria
            }).ToList();

            //// Pasar a la vista dentro de un objeto anónimo o un ViewModel contenedor
            //var model = new
            //{
            //    RcategoriaVMs = RcategoriaVMs
            //};

            return View("~/Views/CrudCategoriaV/ReadCategoriaV.cshtml", RcategoriaVMs);
        }

        public IActionResult LeerResultados()
        {
            var evaluaciones = _context.Evaluaciones.ToList();
            // Mapear a ViewModel
            var RevaluacionVMs = evaluaciones.Select(e => new RevaluacionVM
            {
                RidEvaluacionVM = e.IdEvaluacion,
                RevCategoriaVM = e.Categoria,
                RevProyectoVM = e.Proyecto,
                RevEvaluadorVM = e.Evaluador,
                RevFechaVM = e.Fecha,
                RevPuntajeObtenidoVM = e.PuntajeObtenido,
                RevObservacionesVM = e.Observaciones
            }).ToList();

            return View("~/Views/AdminV/LeerResultados.cshtml", RevaluacionVMs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarCateg(Models.ViewModels.CcategoriaVM categoriaVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage1"] = "Por favor, complete todos los campos obligatorios.";
                return View("~/Views/CrudCategoriaV/CreateCategoriaV.cshtml", categoriaVM);
            }
            try
            {
                // Verificar si la categoria existe en la base de datos
                var categoriaExistente = _context.Categoria.FirstOrDefault(c => c.NombreCategoria == categoriaVM.NombreCategoriaVM);
                if (categoriaExistente != null)
                {
                    TempData["ErrorMessage2"] = "La categoria ya existe, intente una nueva.";
                    return View("~/Views/CrudCategoriaV/CreateCategoriaV.cshtml", categoriaVM);
                }

                var nuevaCategoria = new Models.CategoriaM
                {
                    NombreCategoria = categoriaVM.NombreCategoriaVM,
                    DescripcionCategoria = categoriaVM.DescripcionCategoriaVM,
                    EstadoCategoria = true
                };

                _context.Categoria.Add(nuevaCategoria);
                _context.SaveChanges();

                TempData["SuccessMessage3"] = "Categoria creada correctamente.";
                return RedirectToAction("LeerCategoria", "CrudAdminLog");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage4"] = "Ocurrió un error al guardar el usuario." + "  "+ ex.Message;
                return View("~/Views/CrudCategoriaV/CreateCategoriaV.cshtml", categoriaVM);
            }
        }

        public IActionResult ActualizarCateg(UcategoriaVM categoriaVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage5"] = "Por favor, complete todos los campos obligatorios.";
                return View("~/Views/CrudCategoriaV/UpdateCategoriaV.cshtml", categoriaVM);
            }

            try
            {
                // Verificar si la categoría existe en la base de datos
                var categoriaExistente = _context.Categoria.FirstOrDefault(c => c.IdCategoria == categoriaVM.UidCategoriaVM);

                if (categoriaExistente == null)
                {
                    TempData["ErrorMessage6"] = $"No existe ninguna categoría con ID {categoriaVM.UidCategoriaVM}.";
                    return View("~/Views/CrudCategoriaV/UpdateCategoriaV.cshtml", categoriaVM);
                }

                var nombreDuplicado = _context.Categoria
                    .FirstOrDefault(c => c.NombreCategoria == categoriaVM.UnombreCategoriaVM
                                         && c.IdCategoria != categoriaVM.UidCategoriaVM);
                if (nombreDuplicado != null)
                {
                    TempData["ErrorMessage7"] = "Ya existe otra categoría con ese nombre.";
                    return View("~/Views/CrudCategoriaV/UpdateCategoriaV.cshtml", categoriaVM);
                }

                categoriaExistente.NombreCategoria = categoriaVM.UnombreCategoriaVM;
                categoriaExistente.DescripcionCategoria = categoriaVM.UdescripcionCategoriaVM;
                categoriaExistente.EstadoCategoria = categoriaVM.UestadoCategoriaVM;

                _context.SaveChanges();

                TempData["SuccessMessage8"] = "Categoría actualizada correctamente.";
                return RedirectToAction("LeerCategoria");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage9"] = "Ocurrió un error al actualizar la categoría: " + ex.Message;
                return View("~/Views/CrudCategoriaV/UpdateCategoriaV.cshtml", categoriaVM);
            }
        }

        public IActionResult EliminarCategLogico(DcategoriaVM categoriaVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage10"] = "Por favor, complete todos los campos obligatorios.";
                return View("~/Views/CrudCategoriaV/UpdateCategoriaV.cshtml", categoriaVM);
            }

            try
            {
                // Verificar si la categoría existe en la base de datos
                var categoriaExistente = _context.Categoria.FirstOrDefault(c => c.IdCategoria == categoriaVM.DidCategoriaVM);

                if (categoriaExistente == null)
                {
                    TempData["ErrorMessage11"] = $"No existe ninguna categoría con ID {categoriaVM.DidCategoriaVM}.";
                    return View("~/Views/CrudCategoriaV/UpdateCategoriaV.cshtml", categoriaVM);
                }

                categoriaExistente.EstadoCategoria = categoriaVM.DestadoCategoriaVM;

                _context.SaveChanges();

                TempData["SuccessMessage12"] = "Categoría eliminada correctamente.";
                return RedirectToAction("LeerCategoria");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage13"] = "Ocurrió un error al eliminar la categoría: " + ex.Message;
                return View("~/Views/CrudCategoriaV/UpdateCategoriaV.cshtml", categoriaVM);
            }
        }
    }
}
