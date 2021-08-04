using Fiap.Aula01.Exemplo01.Models;
using System;


namespace Fiap.Aula01.Exemplo01
{
    /*
     * ALT + Enter ou CTRL + . (sugestão de correção)
     * prop, cw -> tab tab
     * $"" -> interpolação de String, permite adicionar valores através das {}
     * 
     * Solution -> Workspace
     * Project -> Project
     * Namespace -> Package
     * using -> import
     * : -> extends
     * base -> super
     * 
     * virtual -> permite a sobrescrita do método
     * override -> palavra reservada
     * 
     * Tipos de dados (não tem primitivos, int, long, string são abreviaturas para as classes)
     * Padrão de nomenclatura:
     *  Métodos/Classes -> UpperCamelCase
     *  Atributos -> começam com _
     *  Propriedades -> public string Nome {get; set;}
     * 
     * Modificadores de acesso:
     * public -> Todos
     * private -> Somente a classe
     * protected -> A classe e as classes filhas
     * internal -> Mesmo projeto
     * protected internal -> A classe, classes filhas e classes do mesmo projeto
     * protected private -> A classe e classes filhas do mesmo projeto
     * 
    */
    class Program
    {
        static void Main(string[] args) 
        {
            //Instanciar um aluno e atribuir um nome
            Aluno aluno = new Aluno();

            aluno.Rm = 123; //Set
            Console.WriteLine(aluno.Rm); //Get
            //aluno.nome = "Luis";

            //Ler o nome, preço e qtd do produto
            //cw -> tab tab (Console.WriteLine)
            Console.WriteLine("Digite o nome do produto");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o preço");
            decimal preco = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Digite a quantidade");
            int qtd = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a marca");
            string marca = Console.ReadLine();

            //Instanciar um produto e atribuir os valores
            Produto produto = new Eletronico(nome, marca) 
            {                 
                Preco = preco,
                Quantidade = qtd
            };
            //CTRL + K + C (Comenta as linhas selecionadas)
            //produto.Nome = nome;
            //produto.Preco = preco;
            //produto.Quantidade = qtd;

            //Exibir os valores do produto
            Console.WriteLine($"Nome: {produto.Nome}, Preço: {produto.Preco}, Qtd: {produto.Quantidade}");

            //Ler o juros (10(%), 5(%))
            Console.WriteLine("Digite o juros");
            decimal juros = decimal.Parse(Console.ReadLine());

            //Atualizar o preço 
            produto.AtualizarPrecoComJuros(juros);

            //Exibir o novo preço
            Console.WriteLine($"Novo preço: {produto.Preco}");

            //Ler o cupom e exibir o valor com desconto
            Console.WriteLine("Digite o cupom");
            string cupom = Console.ReadLine();

            //decimal valorComDesconto = produto.CalcularDesconto(cupom);
            //Console.WriteLine($"O valor com desconto é {valorComDesconto}");
            Console.WriteLine($"O valor com desconto é {produto.CalcularDesconto(cupom)}");

            //Exibir os valores do produto
            Console.WriteLine(produto);

        }//main
    }//class
}//namespace
