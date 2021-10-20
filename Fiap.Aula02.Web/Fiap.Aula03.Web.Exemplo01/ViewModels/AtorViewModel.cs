using Fiap.Aula03.Web.Exemplo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.ViewModels
{
    public class AtorViewModel
    {
        public Ator Ator { get; set; }

        public IList<Ator> Lista { get; set; }
    }
}
