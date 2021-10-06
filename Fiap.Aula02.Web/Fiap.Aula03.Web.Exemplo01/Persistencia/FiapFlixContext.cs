using Fiap.Aula03.Web.Exemplo01.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Aula03.Web.Exemplo01.Persistencia
{
    //Classe que gerencia as entidades
    public class FiapFlixContext : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Ator> Atores { get; set; }
        public DbSet<Produtora> Produtoras { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<AtorFilme> AtoresFilmes { get; set; }

        //Construtor que recebe a string de conexão do banco
        public FiapFlixContext(DbContextOptions op) : base(op) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurar a chave composta da tabela associativa
            modelBuilder.Entity<AtorFilme>().HasKey(a => new { a.AtorId, a.FilmeId });

            //Configurar o relacionamento do filme com a tabela associativa
            modelBuilder.Entity<AtorFilme>()
                .HasOne(a => a.Filme)
                .WithMany(a => a.AtoresFilmes)
                .HasForeignKey(a => a.FilmeId);

            //Configurar o relacionamento do ator com a tabela associativa
            modelBuilder.Entity<AtorFilme>()
                .HasOne(a => a.Ator)
                .WithMany(a => a.AtoresFilmes)
                .HasForeignKey(a => a.AtorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
