using Blog_do_Matoso.Models;
using System.Collections.Generic;

namespace Blog_do_Matoso
{
    public interface IDataService
    {
        object IniciaDB();
        Depoimentos SalvaDepoimentoDB(Depoimentos depoimento);
        bool CadastroValidaUsuarioExistenteDB(string nome);
        Usuarios CadastraUsuarioDB(Usuarios usuario);
        string AlteraSenhaUsuario(Usuarios usuario , string novaSenha);
        Usuarios ApagaUsuarioDB(Usuarios usuario);
    }
}