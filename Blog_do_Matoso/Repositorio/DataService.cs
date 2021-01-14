using Blog_do_Matoso.Business;
using Blog_do_Matoso.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog_do_Matoso
{
    public partial class Startup
    {
        public class DataService : IDataService
        {

            private readonly DBcontext dBcontext;

            public bool ValidacaoUsuarioLogin => throw new NotImplementedException();

            public DataService(DBcontext dBcontext)
            {
                this.dBcontext=dBcontext;
            }

           

            public object IniciaDB()
            {
                return dBcontext.Depoimentos;
            }

            public Depoimentos SalvaDepoimentoDB(Depoimentos depoimento)
            {
                Console.WriteLine(depoimento);
                dBcontext.Depoimentos.Add(depoimento);
                dBcontext.SaveChanges();
                return depoimento;
            }


            public bool ValidacaoUsuarioCadastro(string nome)
            {
                var user = dBcontext.Usuarios.FirstOrDefault(x => x.Nome==nome);

                if (user == null)
                {
                    return true;
                }
                return false;
            }
            public Usuario CadastraUsuarioDB(Usuario usuario)
            {
                Console.WriteLine(usuario);
                dBcontext.Usuarios.Add(usuario);
                dBcontext.SaveChanges();
                return usuario;
            }

            bool IDataService.ValidacaoUsuarioLogin(string nome , string senha)
            {
                throw new NotImplementedException();
            }
        }

    }
}
