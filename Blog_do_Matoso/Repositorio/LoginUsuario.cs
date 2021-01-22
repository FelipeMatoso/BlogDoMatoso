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

        public object LoginVerificaExistente(Usuarios usuario)
        {
            var usuarioDB = dBcontext.Usuarios.FirstOrDefault(user => user.Senha==usuario.Senha && user.Nome==usuario.Nome );

            if (usuarioDB!=null)
                return new {sucess=true , usuarioId = usuarioDB.Id };
            else
                return new {sucess=false };
        }
    }
}
