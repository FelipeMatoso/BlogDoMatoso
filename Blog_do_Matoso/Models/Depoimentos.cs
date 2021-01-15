using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_do_Matoso.Models
{
    public class Depoimentos
    {
        [Key]
        public int Id { get; }
        [ ForeignKey("Usuario")]
        public int IdUsuario { get; }
        public string Nome { get; set; }
        public string Depoimento { get; set; }
        public string Data { get; set; }


    }


}
