using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula02.Web.Exemplo01.Controllers
{
    public class ProdutoController : Controller
    {
        //produto/index
        //produto
        public IActionResult Index()
        {
            return View();
        }
    }
}
