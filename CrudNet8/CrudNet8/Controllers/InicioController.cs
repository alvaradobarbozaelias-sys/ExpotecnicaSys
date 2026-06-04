//using CrudNet8.Datos;
//using CrudNet8.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics;

//namespace CrudNet8.Controllers
//{
//    public class InicioController : Controller
//    {
//        //Agrego el contexto 
//        private readonly ApplicationDbContext _contexto;

//        public InicioController(ApplicationDbContext contexto)
//        {
//            _contexto = contexto;
//        }


//        [HttpGet]
//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpGet]
//        public IActionResult Crear()
//        {
//            return View();
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Crear(ContactoM contacto)
//        {
//            if (ModelState.IsValid)
//            {
//                //Agregar la fecha y hora actual
//                contacto.FechaInscripcion = DateTime.Now;

//                _contexto.Contactos.Add(contacto);
//                await _contexto.SaveChangesAsync();//Para que lo guarde en la base de datos.
//                return RedirectToAction(nameof(Index));
//            }
//            return View();
//        }

//        [HttpGet]
//        public IActionResult Editar(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var contacto = _contexto.Contactos.Find(id);
//            if (contacto == null)
//            {
//                return NotFound();
//            }

//            return View(contacto);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Editar(ContactoM contacto)
//        {
//            if (ModelState.IsValid)
//            {
//                //Agregar la fecha y hora actual
//                //contacto.FechaInscripcion = DateTime.Now;

//                _contexto.Update(contacto);
//                await _contexto.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }

//            return View();
//        }

//        [HttpGet]
//        public IActionResult Borrar(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var contacto = _contexto.Contactos.Find(id);
//            if (contacto == null)
//            {
//                return NotFound();
//            }

//            return View(contacto);
//        }

//        [HttpPost, ActionName("Borrar")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> BorrarContacto(int? id)
//        {
//            var contacto = await _contexto.Contactos.FindAsync(id);
//            if (contacto == null)
//            {
//                return View();
//            }

//            //Borrado
//            _contexto.Contactos.Remove(contacto);
//            await _contexto.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        [HttpGet]
//        public IActionResult Detalle(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var contacto = _contexto.Contactos.Find(id);
//            if (contacto == null)
//            {
//                return NotFound();
//            }

//            return View(contacto);
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}
