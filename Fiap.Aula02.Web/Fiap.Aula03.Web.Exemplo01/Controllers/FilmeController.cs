using Fiap.Aula03.Web.Exemplo01.Models;
using Fiap.Aula03.Web.Exemplo01.Persistencia;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Fiap.Aula03.Web.Exemplo01.Controllers
{
    public class FilmeController : Controller
    {
        private FiapFlixContext _context;

        //Construtor que recebe o DbContext por injeção de dependência
        public FilmeController(FiapFlixContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            var filme = _context.Filmes.Find(id); //Pesquisa pela PK
            _context.Filmes.Remove(filme); //Remove pelo objeto
            _context.SaveChanges(); //Commit
            TempData["msg"] = "Filme removido";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Filme filme)
        {
            _context.Filmes.Update(filme); //Atualiza o filme no banco
            _context.SaveChanges(); //Commit
            TempData["msg"] = "Filme atualizado!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var filme = _context.Filmes.Find(id);
            return View(filme);
        }

        [HttpPost]
        public IActionResult Cadastrar(Filme filme)
        {
            _context.Filmes.Add(filme); //Adiciona o filme no contexto
            _context.SaveChanges(); //Commit
            TempData["msg"] = "Filme cadastrado!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        //? -> permite valor null
        public IActionResult Index(string nomeBusca, Genero? generoBusca)
        {      
            //Contains() -> pesquisa por parte da string 
            var filmes = _context.Filmes.Where(f => 
                (f.Nome.Contains(nomeBusca) || nomeBusca == null) && 
                (f.Genero == generoBusca || generoBusca == null)).ToList();
            return View(filmes);
        }
    }
}
