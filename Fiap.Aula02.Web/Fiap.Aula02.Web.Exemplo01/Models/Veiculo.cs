using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula02.Web.Exemplo01.Models
{
    public class Veiculo
    {
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public bool Automatico { get; set; }
        public decimal Valor { get; set; }
    }
}

/** Criar uma página para cadastrar o Veiculo (utilizando tag helpers)
 *  "Cadastrar" o veiculo em uma lista na controller
 *      private static IList<Veiculo> _banco;
 *  Criar uma página para listar todos os veiculos
 */
