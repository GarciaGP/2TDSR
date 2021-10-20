using Fiap.Aula03.Web.Exemplo01.Models;
using Fiap.Aula03.Web.Exemplo01.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.Repositories
{
    public class AtorRepository : IAtorRepository
    {
        private FiapFlixContext _context;

        public AtorRepository(FiapFlixContext context)
        {
            _context = context;
        }

        public IList<Ator> BuscarPorFilme(int filmeId)
        {
            return _context.AtoresFilmes
                .Where(a => a.FilmeId == filmeId)
                .Select(a => a.Ator)
                .ToList();
        }

        public void Cadastrar(Ator ator)
        {
            _context.Atores.Add(ator);
        }

        public IList<Ator> Listar()
        {
            return _context.Atores.ToList();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
