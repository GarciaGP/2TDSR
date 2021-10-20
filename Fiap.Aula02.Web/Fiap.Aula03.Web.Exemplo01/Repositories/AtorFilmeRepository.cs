using Fiap.Aula03.Web.Exemplo01.Models;
using Fiap.Aula03.Web.Exemplo01.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.Repositories
{
    public class AtorFilmeRepository : IAtorFilmeRepository
    {
        private FiapFlixContext _context;

        public AtorFilmeRepository(FiapFlixContext context)
        {
            _context = context;
        }

        public void Cadastrar(AtorFilme atorFilme)
        {
            _context.AtoresFilmes.Add(atorFilme);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
