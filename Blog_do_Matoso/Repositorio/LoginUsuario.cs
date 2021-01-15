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

        public bool LoginVerificaExistente(string nome , string senha)
        {
            var user = true;
            //var user = dBcontext.Usuarios.FirstOrDefault;
            if (true)
            {
                return user;
            }
        }
    }
}
