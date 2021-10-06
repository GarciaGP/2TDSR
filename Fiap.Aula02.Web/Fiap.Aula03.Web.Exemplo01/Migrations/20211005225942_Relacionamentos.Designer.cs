﻿// <auto-generated />
using System;
using Fiap.Aula03.Web.Exemplo01.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fiap.Aula03.Web.Exemplo01.Migrations
{
    [DbContext(typeof(FiapFlixContext))]
    [Migration("20211005225942_Relacionamentos")]
    partial class Relacionamentos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fiap.Aula03.Web.Exemplo01.Models.Ator", b =>
                {
                    b.Property<int>("AtorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("Dt_Nascimento");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AtorId");

                    b.ToTable("Tbl_Ator");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Exemplo01.Models.AtorFilme", b =>
                {
                    b.Property<int>("AtorId")
                        .HasColumnType("int");

                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.HasKey("AtorId", "FilmeId");

                    b.HasIndex("FilmeId");

                    b.ToTable("Tbl_Ator_Filme");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Exemplo01.Models.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("EnderecoId");

                    b.ToTable("Tbl_Endereco");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Exemplo01.Models.Filme", b =>
                {
                    b.Property<int>("FilmeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Ano")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("datetime2")
                        .HasColumnName("Data_Lancamento");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<bool>("MaiorIdade")
                        .HasColumnType("bit")
                        .HasColumnName("Maior_Idade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProdutoraId")
                        .HasColumnType("int");

                    b.Property<string>("Sinopse")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("FilmeId");

                    b.HasIndex("ProdutoraId");

                    b.ToTable("Tbl_Filme");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Exemplo01.Models.Produtora", b =>
                {
                    b.Property<int>("ProdutoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ProdutoraId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Tbl_Produtora");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Exemplo01.Models.AtorFilme", b =>
                {
                    b.HasOne("Fiap.Aula03.Web.Exemplo01.Models.Ator", "Ator")
                        .WithMany("AtoresFilmes")
                        .HasForeignKey("AtorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiap.Aula03.Web.Exemplo01.Models.Filme", "Filme")
                        .WithMany("AtoresFilmes")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ator");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Exemplo01.Models.Filme", b =>
                {
                    b.HasOne("Fiap.Aula03.Web.Exemplo01.Models.Produtora", "Produtora")
                        .WithMany("Filmes")
                        .HasForeignKey("ProdutoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produtora");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Exemplo01.Models.Produtora", b =>
                {
                    b.HasOne("Fiap.Aula03.Web.Exemplo01.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Exemplo01.Models.Ator", b =>
                {
                    b.Navigation("AtoresFilmes");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Exemplo01.Models.Filme", b =>
                {
                    b.Navigation("AtoresFilmes");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Exemplo01.Models.Produtora", b =>
                {
                    b.Navigation("Filmes");
                });
#pragma warning restore 612, 618
        }
    }
}
