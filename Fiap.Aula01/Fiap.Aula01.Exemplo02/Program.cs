using Fiap.Aula01.Exemplo02.Exceptions;
using Fiap.Aula01.Exemplo02.Models;
using Fiap.Aula01.Exemplo02.Repositories;
using System;

namespace Fiap.Aula01.Exemplo02
{
    class Program
    {
        //alt + enter ou ctrl + .
        static void Main(string[] args)
        {

            //Instanciar um Esporte
            var esporte = new Esporte();

            //Atribuir um TipoEsporte
            esporte.Tipo = TipoEsporte.Individual;

            //Validar se o esporte é individual
            if (esporte.Tipo == TipoEsporte.Individual)
            {
                //cw tab tab
                Console.WriteLine("O esporte é individual");
            }

            //Exibir o TipoEsporte
            Console.WriteLine($"O esporte é do tipo {esporte.Tipo}");

            //Declarar a variável para armazenar a escolha do usuário
            int opcao;

            //Instanciar o Repository
            IEsporteRepository repository = new EsporteRepository();

            //Laço de repetição
            do
            {
                //Apresentar um menu com as opções: 1-Cadastrar 2-Listar 0-Sair
                Console.WriteLine("Escolha: \n1-Cadastrar \n2-Listar \n0-Sair");
                //Ler a escolha do usuário
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        //1-Ler os dados do esporte 
                        Console.WriteLine("Digite o Id");
                        var id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o nome");
                        var nome = Console.ReadLine();

                        Console.WriteLine("Digite a quantidade de competidores");
                        var qtd = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o tipo de esporte (individual, coletivo, dupla)");
                        //Ler uma String e transformar em um dos valores do enum: .Parse(Enum, String, IgnoreCase);
                        var tipo = (TipoEsporte)Enum.Parse(typeof(TipoEsporte), Console.ReadLine(), true);

                        //Instanciar um esporte e cadastrar no repository
                        var cadastro = new Esporte()
                        {
                            Id = id, Nome = nome, QuantidadeCompetidores = qtd, Tipo = tipo
                        };
                        repository.Cadastrar(cadastro);
                        break;
                    case 2:
                        //2-Recuperar os esportes e exibir os dados (Tratar a exception)
                        try
                        {
                            var lista = repository.Listar();
                            foreach (var item in lista)
                            {
                                Console.WriteLine($"Nome: {item.Nome}, Competidores: {item.QuantidadeCompetidores}, Id: {item.Id}, Tipo: {item.Tipo}");
                            }
                        } catch (EmptyListException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 0:
                        Console.WriteLine("Obrigado! Finalizando o sistema...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (opcao != 0);

        }//main
    }//class
}//namespace
