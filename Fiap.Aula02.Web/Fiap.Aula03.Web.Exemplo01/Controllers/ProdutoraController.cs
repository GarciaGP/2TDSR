using Fiap.Aula03.Web.Exemplo01.Models;
using Fiap.Aula03.Web.Exemplo01.Persistencia;
using Fiap.Aula03.Web.Exemplo01.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.Controllers
{
    public class ProdutoraController : Controller
    {
        private IProdutoraRepository _produtoraRepository;

        public ProdutoraController(IProdutoraRepository produtoraRepository)
        {
            _produtoraRepository = produtoraRepository;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produtora produtora)
        {
            _produtoraRepository.Cadastrar(produtora);
            _produtoraRepository.Salvar();
            TempData["msg"] = "Produtora registrada";
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            //Include -> inclui o relacionamento no resultado da pesquisa
            var lista = _produtoraRepository.Listar();
            return View(lista);
        }
    }
}
