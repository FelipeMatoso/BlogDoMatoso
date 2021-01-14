using Blog_do_Matoso.Models;
using System.Collections.Generic;

namespace Blog_do_Matoso
{
    public interface IDataService
    {
        object IniciaDB();
        Depoimentos SalvaDados(Depoimentos depoimento);
        bool ValidacaoUsuario(string nome);
        Usuario SalvaUsuarioDB(Usuario usuario);
    }
}