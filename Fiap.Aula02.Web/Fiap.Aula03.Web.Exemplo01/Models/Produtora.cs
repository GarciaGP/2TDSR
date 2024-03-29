﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.Models
{
    [Table("Tbl_Produtora")]
    public class Produtora
    {
        [Column("Id")]
        public int ProdutoraId { get; set; }

        [Required, MaxLength(150)]
        public string Nome { get; set; }

        //Relacionamento um-para-muitos
        public virtual ICollection<Filme> Filmes { get; set; }

        //Relacionamento um-para-um
        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
    }
}