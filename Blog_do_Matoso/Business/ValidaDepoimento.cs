using Blog_do_Matoso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_do_Matoso.Business
{
    public class ValidaDepoimento : IValidaDepoimento
    {
        public ValidaDepoimento()
        {

        }

        public bool Validacao()
        {
            bool aprovacao = true;

            return aprovacao;
        }
    }
}
