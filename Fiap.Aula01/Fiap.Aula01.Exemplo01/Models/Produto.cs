using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Aula01.Exemplo01.Models
{
    //Classe abstrata -> não pode ser instanciada e PODE ter métodos abstratos, sem implementação
    abstract class Produto
    {
        //Propriedades (Getters e Setters)
        //prop -> tab tab (Cria uma propriedade)
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }

        //Métodos
        public void Vender()
        {
            //Diminuir em 1 a Quantidade
            Quantidade--;
        }

        //Sobrecarga do método Vender que recebe a qtd
        public void Vender(int qtd)
        {
            Quantidade -= qtd;
        }

        //Sobrecarga (Overload) de métodos: método com mesmo nome e parâmetros diferentes (tipo, ordem ou qtd)
        public decimal CalcularDesconto(decimal porcentagem)
        {
            return Preco - Preco * porcentagem / 100;
        }

        public virtual decimal CalcularDesconto(string cupom)
        {
            //O Cupom FIAP50 dá 50% de desconto 
            if (cupom == "FIAP50")
            {
                return Preco * 0.5m;
            }
            return Preco;
        }

        //virtual -> permite a sobrescrita do método
        public virtual decimal CalcularDesconto()
        {
            //Retorar o Preço com 5% de desconto
            return Preco * 0.95m; //m define o tipo como decimal
        }

        //Método abstrato, sem implementação
        public abstract void AtualizarPrecoComJuros(decimal juros);

        public override string ToString()
        {
            return $"Nome: {Nome}, Preço: {Preco}, Quantidade: {Quantidade}";
        }

        //Construtores
        public Produto(string nome)
        {
            Nome = nome;
        }

    }
}
