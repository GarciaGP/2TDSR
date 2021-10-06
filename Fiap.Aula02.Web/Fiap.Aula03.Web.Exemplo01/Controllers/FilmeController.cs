using Fiap.Aula03.Web.Exemplo01.Models;
using Fiap.Aula03.Web.Exemplo01.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public IActionResult Detalhes(int id)
        {
            //Pesquisa o filme pelo Id, incluindo o relacionamento com a produtora
            var filme = _context.Filmes.Include(f => f.Produtora)
                .Where(f => id == f.FilmeId).FirstOrDefault();

            //Enviar a lista de atores para o select
            var atores = _context.Atores.ToList();
            ViewBag.atoresSelect = new SelectList(atores, "AtorId", "Nome");

            //Envia a lista de atores relacionados com o filme
            ViewBag.atores = _context.AtoresFilmes.Where(a => a.FilmeId == id).Select(a => a.Ator).ToList();

            return View(filme);
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
            CarregarProdutoras();
            var filme = _context.Filmes.Find(id);
            return View(filme);
        }

        //Enviar o select list para preencher as opções do select de produtoras
        private void CarregarProdutoras()
        {
            var lista = _context.Produtoras.OrderBy(p => p.Nome).ToList();
            ViewBag.produtoras = new SelectList(lista, "ProdutoraId", "Nome");
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
            CarregarProdutoras();
            return View();
        }

        //? -> permite valor null
        public IActionResult Index(string nomeBusca, Genero? generoBusca)
        {      
            //Contains() -> pesquisa por parte da string 
            var filmes = _context.Filmes.Where(f => 
                (f.Nome.Contains(nomeBusca) || nomeBusca == null) && 
                (f.Genero == generoBusca || generoBusca == null)).Include(f => f.Produtora).ToList();
            return View(filmes);
        }
    }
}
