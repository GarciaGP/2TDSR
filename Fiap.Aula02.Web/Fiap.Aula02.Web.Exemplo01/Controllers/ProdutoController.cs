using Fiap.Aula02.Web.Exemplo01.Models;
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

        //produto/cadastrar
        [HttpGet] //Abrir a página com o formulário HTML
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost] //Recuperar os dados enviados pelo usuário (acionado após o submit do formulário)
        public IActionResult Cadastrar(Produto produto)
        {
            //Enviar informações para a view: (Perde as informações no redirect)
            ViewData["nome"] = $"Nome do produto através da ViewData = {produto.Nome}";
            ViewData["preco"] = produto.Preco;
            ViewBag.categoria = $"Categoria através da ViewBag {produto.Categoria}";
            ViewBag.produto = produto; //envia todo o objeto Produto para a view

            //TempData: mantém as informações após um redirect
            TempData["mensagem"] = "Produto cadastrado!";
            TempData["nome"] = produto.Nome;

            //return RedirectToAction("Cadastrar"); //Redirect para o método (Action) Cadastrar
            //Retorna para a view com o objeto Produto
            return View(produto); //Forward
            //return Content($"Nome: {produto.Nome}, Preço: {produto.Preco}, Categoria: {produto.Categoria}"); //Retorna um texto para o browser
        }

    }
}