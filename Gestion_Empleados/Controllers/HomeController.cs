using Gestion_Empleados.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Gestion_Empleados.Data;

namespace Gestion_Empleados.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Contexto _contexto;
        public HomeController(ILogger<HomeController> logger, Contexto contexto)
        {
            _logger = logger;
            _contexto = contexto;   
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var contexto = _contexto.Mensajes.Include(m => m.Remitente);
                return View(await contexto.ToListAsync());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                return RedirectToAction("Privacy");
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }





        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        // Procesar inicio de sesión
        [HttpPost]
        public async Task<IActionResult> Login(string usuario, string password)
        {
            // Realizar lógica de autenticación

            //Usuario user = _context.Usuarios.FirstOrDefault(u => u.Nombre == usuario);
            Empleado empleado = _contexto.Empleados.FirstOrDefault(e => e.Nombre == usuario);

            //string pass = Encript.GetSHA256(password);

            if (empleado != null && password == "111111")
            {
                string rolusuario = empleado.Rol.ToString();



                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario),
                    new Claim(ClaimTypes.Role, rolusuario), //  asignación de rol
                    new Claim("UserId", empleado.EmpleadoId.ToString())
                };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                if (rolusuario == "Administrador")
                {
                    return RedirectToAction("Index", "Home");
                }

                if (rolusuario == "Usuario")
                {
                    return RedirectToAction("Index", "Home");
                }

            }

                return RedirectToAction("Error", "Home");

        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }


        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}

