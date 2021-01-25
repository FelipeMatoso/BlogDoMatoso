using Blog_do_Matoso.Models;
using System.Collections.Generic;

namespace Blog_do_Matoso
{
    public interface IDataService
    {
        object IniciaDB();
        Depoimentos SalvaDepoimentoDB(Depoimentos depoimento);
        bool CadastroValidaUsuarioExistenteDB(string nome);
        string CadastraUsuarioDB(Usuarios usuario);
        string AlteraSenhaUsuario(Usuarios usuario , string novaSenha);
        object PegaApenasDepoimentosUsuario();
        string DescriptografaSenha(string usuario);
        string ApagaUsuarioDB(Usuarios usuario);
        object RequestDepoimentosPessoais(int idUsuario);
    }
}