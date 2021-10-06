using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.Models
{
    [Table("Tbl_Ator")]
    public class Ator
    {
        [Column("Id")]
        public int AtorId { get; set; }

        //Relacionamento muitos-para-muitos
        public ICollection<AtorFilme> AtoresFilmes { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; }

        [Column("Dt_Nascimento"), Display(Name = "Data de Nascimento"), DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        
        [Display(Name = "Gênero")]
        public GeneroAtor Genero { get; set; }
    }

    public enum GeneroAtor
    {
        Feminino, Masculino, Outros
    }
}
