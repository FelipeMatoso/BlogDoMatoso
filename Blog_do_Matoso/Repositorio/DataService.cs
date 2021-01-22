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
                return dBcontext.Depoimentos;
            }

            public Depoimentos SalvaDepoimentoDB(Depoimentos depoimento)
            {
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

            public string CadastraUsuarioDB(Usuarios usuario)
            {
                if (dBcontext.Usuarios.Add(usuario)!=null)
                {
                    dBcontext.SaveChanges();
                    return "Salvo com sucess";
                }
                else
                    return "Erro em Salvar no banco";
            }

            public string ApagaUsuarioDB(Usuarios usuario)
            {
                var usuarioDB = dBcontext.Usuarios.FirstOrDefault(user => user.Nome==usuario.Nome&&user.Senha==usuario.Senha);
                if (usuarioDB!=null)
                {
                    dBcontext.Usuarios.Remove(usuarioDB);
                    //implementar depois a limpeza dos depoimentos
                    dBcontext.SaveChanges();
                    return "Apagou usuario";
                }
                return "Nao encontrou usuario para apagar";
            }

            public string DescriptografaSenha(string usuario)
            {
                var senha = dBcontext.Usuarios.FirstOrDefault(user => user.Nome==usuario);
                if (senha==null)
                {
                    return "nao achou usuario";
                }
                else
                    return senha.Senha;
            }

            public string AlteraSenhaUsuario(Usuarios usuario , string novaSenha)
            {
                var usuarioDB = dBcontext.Usuarios.FirstOrDefault(user => user.Nome==usuario.Nome&&user.Id==usuario.Id);
                if (usuarioDB!=null)
                {
                    usuarioDB.Senha=novaSenha;
                    dBcontext.Usuarios.Update(usuarioDB);
                    //dBcontext.SaveChanges();
                    return "Senha alterada com sucesso";
                }
                else
                    return "Erro ao trocar senha";
            }

            public object PegaApenasDepoimentosUsuario()
            {
                Usuarios usuario = new Usuarios
                {
                    Nome="Felipe Modena" ,
                    Senha="1234" ,

                };
                return dBcontext.Usuarios.Where(user => user.Nome==usuario.Nome&&user.Senha==usuario.Senha);
            }

        }

    }
}
