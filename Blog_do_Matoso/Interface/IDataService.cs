using Blog_do_Matoso.Models;
using System.Collections.Generic;

namespace Blog_do_Matoso
{
    public interface IDataService
    {
        object IniciaDB();
        Depoimentos SalvaDepoimentoDB(Depoimentos depoimento);
        bool ValidacaoUsuarioCadastro(string nome);
        Usuario CadastraUsuarioDB(Usuario usuario);
        bool ValidacaoUsuarioLogin(string nome , string senha);
    }
}