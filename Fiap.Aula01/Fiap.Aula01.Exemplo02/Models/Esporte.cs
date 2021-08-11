using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Aula01.Exemplo02.Models
{
    class Esporte
    {
        //prop tab tab
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QuantidadeCompetidores { get; set; }

        //propriedade para armazenar o tipo de esporte
        public TipoEsporte Tipo { get; set; }

    }

    enum TipoEsporte
    {
        Individual, Coletivo, Dupla
    }
    
}
