using Fiap.Aula03.Web.Exemplo01.Models;
using Fiap.Aula03.Web.Exemplo01.Persistencia;
using Fiap.Aula03.Web.Exemplo01.Repositories;
using Fiap.Aula03.Web.Exemplo01.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fiap.Aula03.Web.Exemplo01.Controllers
{
    public class FilmeController : Controller
    {
        private IFilmeRepository _filmeRepository;
        private IAtorRepository _atorRepository;
        private IProdutoraRepository _produtoraRepository;
        private IAtorFilmeRepository _atorFilmeRepository;

        //Construtor que recebe o DbContext por injeção de dependência
        public FilmeController(IAtorFilmeRepository atorFilmeRepository, 
                                IProdutoraRepository produtoraRepository,
                                IFilmeRepository filmeRepository, 
                                IAtorRepository atorRepository)
        {
            _filmeRepository = filmeRepository;
            _atorRepository = atorRepository;
            _produtoraRepository = produtoraRepository;
            _atorFilmeRepository = atorFilmeRepository;
        }

        [HttpPost]
        public IActionResult Adicionar(AtorFilme atorFilme)
        {
            _atorFilmeRepository.Cadastrar(atorFilme);
            _atorFilmeRepository.Salvar();
            TempData["msg"] = "Adicionado!";
            return RedirectToAction("Detalhes", new { id = atorFilme.FilmeId });
        }

        [HttpGet]
        public IActionResult Detalhes(int id)
        {
            //Pesquisa o filme pelo Id, incluindo o relacionamento com a produtora
            //var filme = _filmeRepository.BuscarPorId(id);

            //Pesquisa todos os filmes
            var atores = _atorRepository.Listar();

            //Pesquisa os atores relacionados com o filme
            var atoresFilme = _atorRepository.BuscarPorFilme(id);

            //Filtrar a lista, retirando os atores já relacionados com o filme
            var listaFiltrada = atores.Where(a => !atoresFilme.Any(a1 => a1.AtorId == a.AtorId));

            //Envia as opções do select
            //ViewBag.atoresSelect = new SelectList(listaFiltrada, "AtorId", "Nome");
            //Envia os atores relacionados com o filme
            //ViewBag.atores = atoresFilme;

            var viewModel = new FilmeViewModel()
            {
                Filme = _filmeRepository.BuscarPorId(id),
                Select = new SelectList(listaFiltrada, "AtorId", "Nome"),
                Lista = atoresFilme
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _filmeRepository.Remover(id);
            _filmeRepository.Salvar();
            TempData["msg"] = "Filme removido";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Filme filme)
        {
            _filmeRepository.Atualizar(filme);
            _filmeRepository.Salvar();
            TempData["msg"] = "Filme atualizado!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarProdutoras();
            var filme = _filmeRepository.BuscarPorId(id);
            return View(filme);
        }

        //Enviar o select list para preencher as opções do select de produtoras
        private void CarregarProdutoras()
        {
            var lista = _produtoraRepository.Listar();
            ViewBag.produtoras = new SelectList(lista, "ProdutoraId", "Nome");
        }

        [HttpPost]
        public IActionResult Cadastrar(Filme filme)
        {
            _filmeRepository.Cadastrar(filme);
            _filmeRepository.Salvar();
            TempData["msg"] = "Filme cadastrado!";
            return RedirectToAction("Detalhes", new { id = filme.FilmeId });
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
            var filmes = _filmeRepository.BuscarPor(f => 
                (f.Nome.Contains(nomeBusca) || nomeBusca == null) && 
                (f.Genero == generoBusca || generoBusca == null));
            return View(filmes);
        }
    }
}
