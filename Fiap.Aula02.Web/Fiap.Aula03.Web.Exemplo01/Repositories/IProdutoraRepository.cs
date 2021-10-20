using Fiap.Aula03.Web.Exemplo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.Repositories
{
    public interface IProdutoraRepository
    {
        void Cadastrar(Produtora produtora);
        IList<Produtora> Listar();
        void Salvar();
    }
}
