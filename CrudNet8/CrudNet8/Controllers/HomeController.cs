using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CrudNet8.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Portada()
        {
            return View();
        }
    }
}