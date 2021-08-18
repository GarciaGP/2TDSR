using Fiap.Aula01.Exercicio.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Aula01.Exercicio.Models
{
    class ContaCorrente : Conta
    {
        public decimal Limite { get; set; }
        public TipoConta Tipo { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Limite: {Limite}, Tipo: {Tipo}";
        }

        public ContaCorrente(int agencia, int numero, IList<Cliente> clientes, 
                TipoConta tipo) : base (agencia, numero, clientes)
        {
            Tipo = tipo;
            switch (Tipo)
            {
                case TipoConta.Comum:
                    Limite = 0;
                    break;
                case TipoConta.Especial:
                    Limite = 500;
                    break;
                case TipoConta.Premium:
                    Limite = 1000;
                    break;        
            }
            //Ternário (condição ? se verdadeiro : se falso)
            //Limite = Tipo == TipoConta.Especial ? 500 : Tipo == TipoConta.Premium ? 1000 : 0;
        }

        /**
         * Se a conta for comum e o saldo fica negativo depois do saque lance uma exceção e
         * não permita a retirada. Caso a conta seja especial ou premium o saldo pode ficar 
         * negativo até o limite*/
        public override void Retirar(decimal valor)
        {
            if (valor > Saldo + Limite)
            {
                throw new SaldoInsuficienteException("Saldo insuficiente");
            }
            Saldo -= valor;
        }
    }

    enum TipoConta
    {
        Comum, Especial, Premium
    }
}
