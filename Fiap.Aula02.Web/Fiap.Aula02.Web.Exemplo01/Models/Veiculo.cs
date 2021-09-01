using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula02.Web.Exemplo01.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }

        [Display(Name = "Automático")]
        public bool Automatico { get; set; }
        public decimal Valor { get; set; }

        //Modifica o type do input (dataType) e o texto do label (display)
        [DataType(DataType.Date), Display(Name = "Data de Compra")]        
        public DateTime DataCompra { get; set; }

        public Combustivel Combustivel { get; set; }

        public string Cor { get; set; }
    }

    public enum Combustivel
    {
        Etanol, Gasolina, Flex, Diesel, Eletrico, Hibrido
    }

}
