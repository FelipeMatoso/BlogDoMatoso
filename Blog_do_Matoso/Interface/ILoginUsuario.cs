using Blog_do_Matoso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_do_Matoso.Interface
{
    public interface ILoginUsuario
    {
        bool ValidacaoUsuarioLogin(string nome , string senha);
    }
}
