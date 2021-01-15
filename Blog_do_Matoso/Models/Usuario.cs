using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_do_Matoso.Models
{
    public class Usuario
        {
            [Key]
            public int Id { get; set; }

            public string Nome { get; set; }
            public string Senha { get; set; }
            public int DepoimentoId { get; set; }
        }

}
