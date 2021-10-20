using Fiap.Aula03.Web.Exemplo01.Models;
using Fiap.Aula03.Web.Exemplo01.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private FiapFlixContext _context;

        public FilmeRepository(FiapFlixContext context)
        {
            _context = context;
        }

        public void Atualizar(Filme filme)
        {
            _context.Filmes.Update(filme);
        }

        public IList<Filme> BuscarPor(Expression<Func<Filme, bool>> filtro)
        {
            return _context.Filmes.Where(filtro).Include(f => f.Produtora).ToList();
        }

        public Filme BuscarPorId(int id)
        {
            return _context.Filmes.Where(f => f.FilmeId == id)
                .Include(f => f.Produtora)
                .FirstOrDefault();
        }

        public void Cadastrar(Filme filme)
        {
            _context.Filmes.Add(filme);
        }

        public IList<Filme> Listar()
        {
            return _context.Filmes.Include(f => f.Produtora).ToList();
        }

        public void Remover(int id)
        {
            var filme = _context.Filmes.Find(id);
            _context.Filmes.Remove(filme);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
