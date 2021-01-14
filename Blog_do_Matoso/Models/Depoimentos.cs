using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog_do_Matoso.Models
{
    public class Depoimentos
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Depoimento { get; set; }
        public string Data { get; set; }


    }

    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Senha { get; set; }
        public int DepoimentoId { get; set; }
        public List<Depoimentos> Depoimentos;
    }
}
