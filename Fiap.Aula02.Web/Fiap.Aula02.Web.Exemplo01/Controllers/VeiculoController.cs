using Fiap.Aula02.Web.Exemplo01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula02.Web.Exemplo01.Controllers
{
    public class VeiculoController : Controller
    {
        //Armazenar os veículos cadatrados, simular um DB
        private static List<Veiculo> _banco = new List<Veiculo>();
        //Atributo que armazena o id do veículo
        private static int id;

        //URL: /veiculo/index ou /veiculo
        public IActionResult Index()
        {
            //Enviar a lista para a view
            return View(_banco);
        }

        //URL: /veiculo/cadastrar
        [HttpGet] //Abrir a página com o formulário HTML
        public IActionResult Cadastrar()
        {            
            return View();
        }

        [HttpPost] //Recupera os dados do formulário e adicionar na lista
        public IActionResult Cadastrar(Veiculo veiculo)
        {
            //Setar o Id do veiculo
            veiculo.Id = ++id;
            //Adicionar o veiculo na lista
            _banco.Add(veiculo);
            //Mensagem de sucesso
            TempData["msg"] = "Veículo cadastrado!";
            //Redirect
            return RedirectToAction("cadastrar");
        }
    }
}
