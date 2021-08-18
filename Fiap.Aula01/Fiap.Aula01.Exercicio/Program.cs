using Fiap.Aula01.Exercicio.Exceptions;
using Fiap.Aula01.Exercicio.Models;
using System;
using System.Collections.Generic;

namespace Fiap.Aula01.Exercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ler a quantidade de clientes
            Console.WriteLine("Digite a quantidade de clientes");
            var quantidade = int.Parse(Console.ReadLine());

            //Instanciar uma lista de clientes
            var clientes = new List<Cliente>();

            //Laço para ler os clientes e adicionar na lista
            for (int i = 0; i < quantidade; i++)
            {
                //Ler os dados do cliente (Id, Nome e Cpf)
                Console.WriteLine("Digite o Id do cliente");
                var id = long.Parse(Console.ReadLine());

                Console.WriteLine("Digite o Nome do cliente");
                var nome = Console.ReadLine();

                Console.WriteLine("Digite o Cpf do cliente");
                var cpf = Console.ReadLine();

                //Instanciar um cliente com os dados
                var cliente = new Cliente(id, nome) { Cpf = cpf };

                //Adicionar o cliente na lista
                clientes.Add(cliente);
            }

            //Ler os dados da conta corrente (Agencia, Número, Data Abertura, Tipo)
            Console.WriteLine("Digite o número da conta");
            var numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da agência");
            var agencia = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data de abertura");
            var data = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Digite o tipo da conta (comum, especial, premium)");
            var tipo = (TipoConta)Enum.Parse(typeof(TipoConta), Console.ReadLine(), true);

            //Instanciar uma conta corrente com os dados
            var conta = new ContaCorrente(agencia, numero, clientes, tipo) { DataAbertura = data };

            //Exibir os dados da conta
            Console.WriteLine(conta);

            //Declarar uma variável para armazenar a escolha do usuário
            int opcao;
            //Laço
            do
            {
                //Menu com as opções 1-Depositar 2-Retirar 3-Exibir Dados 0-Sair
                Console.WriteLine("\nEscolha: \n1-Depositar \n2-Retirar \n3-Exibir Dados \n0-Sair");
                //Ler a opção do usuário
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        //Ler o valor que será depositado
                        Console.WriteLine("Digite o valor para depósito");
                        var valor = decimal.Parse(Console.ReadLine());
                        try
                        {
                            //Depositar
                            conta.Depositar(valor);
                            //Mensagem de sucesso
                            Console.WriteLine($"Valor depositado! Novo saldo: {conta.Saldo}");
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 2:
                        //Ler o valor que será retirado (tratar a exception)
                        Console.WriteLine("Digite o valor para retirada");
                        valor = decimal.Parse(Console.ReadLine());
                        try
                        {
                            //Retirar
                            conta.Retirar(valor);
                            //Mensagem de sucesso
                            Console.WriteLine($"Valor retirado! Novo saldo: {conta.Saldo}");
                        }
                        catch (SaldoInsuficienteException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 3:
                        Console.WriteLine(conta);
                        break;
                    case 0:
                        Console.WriteLine("Finalizando o sistema");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (opcao != 0);
        }//main
    }//class
}//namespace
