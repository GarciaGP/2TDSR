using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.Models
{
    [Table("Tbl_Ator_Filme")]
    public class AtorFilme
    {
        public Ator Ator { get; set; }
        public int AtorId { get; set; }
        public Filme Filme { get; set; }
        public int FilmeId { get; set; }
    }
}
