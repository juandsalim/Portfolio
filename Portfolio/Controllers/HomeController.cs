using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Servicios;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RepositorioProyectos repositorioProyectos;
        private readonly IservicioEmail iservicioEmail;

        public HomeController(ILogger<HomeController> logger, RepositorioProyectos repositorioProyectos,IservicioEmail iservicioEmail)
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.iservicioEmail = iservicioEmail;
        }

        public IActionResult Index()
        {
            
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();  
            var modelo = new HomeIndexViewModel() { Proyectos= proyectos };
            return View(modelo);
        }
        
        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }
        public IActionResult Contacto()
        {
            return View();
        }
        [HttpPost] //indica que la siguiente clase recive un http post
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            await iservicioEmail.Enviar(contactoViewModel);
            return RedirectToAction("Gracias");
        }
        public IActionResult Gracias()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}