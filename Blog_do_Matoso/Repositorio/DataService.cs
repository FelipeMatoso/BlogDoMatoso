using Blog_do_Matoso.Models;
using System;
using System.Linq;

namespace Blog_do_Matoso
{
    public partial class Startup
    {
        public class DataService : IDataService
        {

            readonly DBcontext dBcontext;


            public DataService(DBcontext dBcontext)
            {
                this.dBcontext=dBcontext;
            }



            public object IniciaDB()
            {
                Console.WriteLine(dBcontext.Depoimentos);
                return dBcontext.Depoimentos;
            }

            public Depoimentos SalvaDepoimentoDB(Depoimentos depoimento)
            {
                Console.WriteLine(depoimento);
                dBcontext.Depoimentos.Add(depoimento);
                dBcontext.SaveChanges();
                return depoimento;
            }


            public bool CadastroValidaUsuarioExistenteDB(string nome)
            {
                var user = dBcontext.Usuarios.FirstOrDefault(x => x.Nome==nome);

                if (user==null)
                {
                    return true;
                }
                return false;
            }

            public Usuarios CadastraUsuarioDB(Usuarios usuario)
            {
                Console.WriteLine(usuario);
                dBcontext.Usuarios.Add(usuario);
                dBcontext.SaveChanges();
                return usuario;
            }

            public Usuarios ApagaUsuarioDB(Usuarios usuario)
            {
                Usuarios usuarioDB = dBcontext.Usuarios.Find(usuario);
                dBcontext.Usuarios.Remove(usuarioDB);
                //implementar depois a limpeza dos depoimentos
                dBcontext.SaveChanges();
                return usuario;
            }

            public string AlteraSenhaUsuario(Usuarios usuario , string novaSenha)
            {
                var usuarioDB = dBcontext.Usuarios.FirstOrDefault(user => user.Nome==usuario.Nome && user.Senha==usuario.Senha);

                if (usuarioDB!=null)
                {
                    usuarioDB.Senha=novaSenha;
                    dBcontext.Usuarios.Update(usuarioDB);
                    //dBcontext.SaveChanges();
                    return "Senha alterada com sucesso";
                }
                else
                    return  "Erro ao trocar senha";
            }




        }

    }
}
