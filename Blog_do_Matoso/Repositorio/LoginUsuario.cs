using Blog_do_Matoso.Interface;
using Blog_do_Matoso.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_do_Matoso.Business
{
    public class LoginUsuario : ILoginUsuario
    {
        DBcontext dBcontext;

        public LoginUsuario(DBcontext dBcontext)
        {
            this.dBcontext=dBcontext;
        }

        public bool ValidacaoUsuarioLogin(string nome , string senha)
        {

            //valida se o login é login aceito
            return true;
        }
    }
}
