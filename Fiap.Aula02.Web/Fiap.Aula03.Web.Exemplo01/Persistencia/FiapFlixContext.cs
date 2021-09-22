using Fiap.Aula03.Web.Exemplo01.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Aula03.Web.Exemplo01.Persistencia
{
    //Classe que gerencia as entidades
    public class FiapFlixContext : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }

        //Construtor que recebe a string de conexão do banco
        public FiapFlixContext(DbContextOptions op) : base(op) { }        
    }
}
