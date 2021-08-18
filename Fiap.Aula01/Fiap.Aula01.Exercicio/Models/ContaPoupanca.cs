using Fiap.Aula01.Exercicio.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Aula01.Exercicio.Models
{
    class ContaPoupanca : Conta, IContaInvestimento
    {
        public decimal Taxa { get; set; }

        public ContaPoupanca(int agencia, int numero, IList<Cliente> clientes, 
                    decimal taxa) : base(agencia, numero, clientes)
        {
            Taxa = taxa;
        }

        public decimal CalcularRetornoInvestimento()
        {
            return Saldo * 4 / 100;
        }
        
        /**a taxa de retirada é um valor em reais, o método deve verificar se o saldo é suficiente,
         * se for, descontar também a taxa de retirada, se não, lance uma exceção. */
        public override void Retirar(decimal valor)
        {
           if (valor + Taxa > Saldo)
            {
                throw new SaldoInsuficienteException("Saldo insuficiente");
            }
            Saldo -= valor;
        }
    }
}