using Fiap.Aula03.Web.Exemplo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.Repositories
{
    public interface IFilmeRepository
    {
        void Cadastrar(Filme filme);
        void Atualizar(Filme filme);
        void Remover(int id);
        Filme BuscarPorId(int id);
        IList<Filme> Listar();
        IList<Filme> BuscarPor(Expression<Func<Filme, bool>> filtro);
        void Salvar();
    }
}
