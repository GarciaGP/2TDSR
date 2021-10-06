using Fiap.Aula03.Web.Exemplo01.Models;
using Fiap.Aula03.Web.Exemplo01.Persistencia;
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
        private FiapFlixContext _context;

        public ProdutoraController(FiapFlixContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produtora produtora)
        {
            _context.Produtoras.Add(produtora);
            _context.SaveChanges();
            TempData["msg"] = "Produtora registrada";
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            //Include -> inclui o relacionamento no resultado da pesquisa
            var lista = _context.Produtoras.Include(p => p.Endereco).ToList();
            return View(lista);
        }
    }
}
