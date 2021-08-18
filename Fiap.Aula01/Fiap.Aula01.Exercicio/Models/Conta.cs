using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Aula01.Exercicio.Models
{
    abstract class Conta
    {
        public int Agencia { get; set; }
        public int Numero { get; set; }
        public decimal Saldo { get; protected set; }
        public DateTime DataAbertura { get; set; }
        public IList<Cliente> Clientes { get; set; }

        public Conta(int agencia, int numero, IList<Cliente> clientes)
        {
            Agencia = agencia;
            Numero = numero;
            Clientes = clientes;
        }

        public override string ToString()
        {
            var aux = "";
            //Percorre a lista de clientes para armzenar os dados na variável auxiliar (aux)
            foreach (var item in Clientes)
            {
                aux += item + "\n";
            }
            return $"{aux}Agência: {Agencia}, Número: {Numero}, Saldo: {Saldo}\nData de Abertura: {DataAbertura}";
        }

        public abstract void Retirar(decimal valor);
        public void Depositar(decimal valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("O valor deve ser maior do que zero");
            }
            Saldo += valor;
        }
    }
}
