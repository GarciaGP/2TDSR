using Fiap.Aula03.Web.Exemplo01.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.ViewModels
{
    public class FilmeViewModel
    {
        public Filme Filme { get; set; }
        public SelectList Select { get; set; }
        public IList<Ator> Lista { get; set; }
    }
}
