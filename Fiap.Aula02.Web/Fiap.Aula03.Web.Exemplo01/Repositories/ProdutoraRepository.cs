using Fiap.Aula03.Web.Exemplo01.Models;
using Fiap.Aula03.Web.Exemplo01.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.Repositories
{
    public class ProdutoraRepository : IProdutoraRepository
    {
        private FiapFlixContext _context;

        public ProdutoraRepository(FiapFlixContext context)
        {
            _context = context;
        }

        public void Cadastrar(Produtora produtora)
        {
            _context.Produtoras.Add(produtora);
        }

        public IList<Produtora> Listar()
        {
            return _context.Produtoras.Include(p => p.Endereco).ToList();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
