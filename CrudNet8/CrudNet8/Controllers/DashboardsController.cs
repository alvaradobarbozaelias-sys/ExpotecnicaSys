using CrudNet8.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudNet8.Controllers
{
    public class DashboardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AdminLogV()
        {
            ViewBag.NombreCompletoAdminJuez = HttpContext.Session.GetString("NombreCompleto");
            return View();
        }

        public IActionResult JuezLogV()
        {
            ViewBag.NombreCompletoAdminJuez = HttpContext.Session.GetString("NombreCompleto");
            return View();
        }

        public IActionResult RegresarDashboardAdmin()
        {
            ViewBag.NombreCompletoUsuario = HttpContext.Session.GetString("NombreCompleto");
            return View("~/Views/Dashboards/AdminLogV.cshtml");
        }

        public IActionResult RegresarDashboardJuez()
        {
            ViewBag.NombreCompletoUsuario = HttpContext.Session.GetString("NombreCompleto");
            return View("~/Views/Dashboards/JuezLogV.cshtml");
        }
        public IActionResult ProbarConexion()
        {
            var conn = _context.Database.GetDbConnection().ConnectionString;
            return Content(conn); // Esto mostrará la cadena de conexión en el navegador
        }
    }
}
