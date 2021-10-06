using Fiap.Aula03.Web.Exemplo01.Models;
using Fiap.Aula03.Web.Exemplo01.Persistencia;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.Controllers
{
    public class AtorController : Controller
    {
        private FiapFlixContext _context;

        public AtorController(FiapFlixContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Cadastrar(Ator ator)
        {
            _context.Atores.Add(ator);
            _context.SaveChanges();
            TempData["msg"] = "Ator cadastrado";
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            ViewBag.atores = _context.Atores.ToList();
            return View();
        }
    }
}
