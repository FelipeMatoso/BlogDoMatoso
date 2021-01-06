using System;
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
        public int IdUsuario { get; set; }
        public int Nome { get; set; }
        public int Senha { get; set; }

    }
}
