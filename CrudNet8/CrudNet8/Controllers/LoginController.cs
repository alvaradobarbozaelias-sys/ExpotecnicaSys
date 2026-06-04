using CrudNet8.Datos; // Para que reconozca ApplicationDbContext
using CrudNet8.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudNet8.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        // aquí tus acciones (Index GET, Index POST, etc.)

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_context.Usuarios.Any(u => u.Username == model.Usernamein && u.PasswordHash == model.Passwordin))
            {
                // Aqui se guarda el idrol y idusuario en variables de sesion
                var usuario = _context.Usuarios
                    .Include(u => u.Persona)
                    .Include(u => u.Rol)
                    .FirstOrDefault(u => u.Username == model.Usernamein);

                HttpContext.Session.SetInt32("IdRol", usuario.IdRol);
                HttpContext.Session.SetInt32("IdUsuario", usuario.IdUsuario);
                HttpContext.Session.SetString("Cedula", usuario.Cedula);
                HttpContext.Session.SetString("Username", usuario.Username);
                HttpContext.Session.SetString("Sexo", usuario.Persona.Sexo);
                HttpContext.Session.SetString("FechaNacimiento", usuario.Persona.FechaNacimiento.ToString("yyyy-MM-dd"));

                // Aca va la logica para redirigir a diferentes vistas segun el rol
                if (usuario.IdRol == 0)
                {
                    var NombreCompleto = usuario.Persona.Nombre1 + " " + usuario.Persona.Nombre2 + " " + usuario.Persona.Ap1 + " " + usuario.Persona.Ap2;
                    HttpContext.Session.SetString("NombreCompleto", NombreCompleto);
                    return RedirectToAction("JuezLogV", "Dashboards");
                }
                else if (usuario.IdRol == 1)
                {
                    var NombreCompleto = usuario.Persona.Nombre1 + " " + usuario.Persona.Nombre2 + " " + usuario.Persona.Ap1 + " " + usuario.Persona.Ap2;
                    HttpContext.Session.SetString("NombreCompleto", NombreCompleto);
                    return RedirectToAction("AdminLogV", "Dashboards");
                }
                return View("~/Views/Login/Index.cshtml");
            }
            else
            {
                // Credenciales inválidas, muestra un mensaje de error
                ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos.");
                return View(model);
            }
        }
    }
}