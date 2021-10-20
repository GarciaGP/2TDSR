using Fiap.Aula03.Web.Exemplo01.Models;
using Fiap.Aula03.Web.Exemplo01.Persistencia;
using Fiap.Aula03.Web.Exemplo01.Repositories;
using Fiap.Aula03.Web.Exemplo01.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.Controllers
{
    public class AtorController : Controller
    {
        private IAtorRepository _atorRepository;

        public AtorController(IAtorRepository atorRepository)
        {
            _atorRepository = atorRepository;
        }

        [HttpPost]
        public IActionResult Cadastrar(Ator ator)
        {
            _atorRepository.Cadastrar(ator);
            _atorRepository.Salvar();
            TempData["msg"] = "Ator cadastrado";
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var viewModel = new AtorViewModel()
            {
                Lista = _atorRepository.Listar()
            };
            return View(viewModel);
        }
    }
}
