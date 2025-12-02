using CadAlunoTorloni.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadAlunoTorloni.Controllers
{
    public class FrutasController : Controller
    {
        private readonly ILogger<FrutasController> _logger;

        public FrutasController(ILogger<FrutasController> logger)
        {
            _logger = logger;
        }

        //criar uma lista de frutas
        private static List<Fruta> frutas = new List<Fruta>
        {
            new Fruta{ Id = 1, Nome = "Banana", Cor = "amarelo", Categorias = "Tropical" },
            new Fruta{ Id = 2, Nome = "Uva", Cor = "roxo", Categorias = "Tropical" },
            new Fruta{ Id = 3, Nome = "Maçã", Cor = "vermelho", Categorias = "Citrica"},
            new Fruta{ Id = 4, Nome = "Limão", Cor = "verde", Categorias = "Citrica" },
            new Fruta{ Id = 5, Nome = "Abacaxi", Cor = "amarelo", Categorias = "Citrica" },
        };

        public IActionResult Index()
        {
            return View(frutas);
        }

                [HttpPost]
        public IActionResult Create(Fruta fruta)
        {
            fruta.Id = frutas.Max(f => f.Id) + 1;
            frutas.Add(fruta);
            return RedirectToAction("Index");
        }

        public IActionResult FrutasCitricas()
        {
            return View(frutas);
        }
        public IActionResult FrutasTropicais()
        {
            return View(frutas);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]


        public IActionResult Error()
        {
            return View("Error!");
        }
        


    }
}