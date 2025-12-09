using System.Threading.Tasks;
using CadAlunoTorloni.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CadastroAluno.Controllers
{
    public class AlunoController : Controller
    {
        private readonly CadAlunoTorloniContext _context;

        private readonly ILogger<AlunoController> _logger;

        public AlunoController(ILogger<AlunoController> logger, CadAlunoTorloniContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Criar uma Lista de Aluno
        public static List<Aluno> Alunos = new List<Aluno>
    {
    new Aluno { Id = 1, Nome = "Nicolly", Idade = 17 },
    new Aluno { Id = 2, Nome = "Davi", Idade = 17 },
 
   };


          public async Task<IActionResult> Index()
        {
            var Alunos = await _context.Alunos.ToListAsync();
            return View(Alunos);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        // Metodo para salvar um aluno, sem uma view
        [HttpPost]
        public IActionResult Create(Aluno aluno)
        {
            // cria o próximo id
            aluno.Id = Alunos.Max(a => a.Id) + 1;

            // salvar no array
            Alunos.Add(aluno);

            // redireciona o usuário para o index
            return RedirectToAction(nameof (Index));
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }

    internal class Alunos
    {
        public int Id { get; internal set; }
    }
}