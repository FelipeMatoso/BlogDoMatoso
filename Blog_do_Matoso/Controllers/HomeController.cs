using Blog_do_Matoso.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Blog_do_Matoso.Interface;
using System.Security.Cryptography;

namespace Blog_do_Matoso.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IDataService dataService;
        private readonly ILoginUsuario LoginUsuario;


        public HomeController(IDataService dataService , ILoginUsuario validacaoLoginUsuario)
        {
            this.dataService=dataService;
            this.LoginUsuario=validacaoLoginUsuario;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Texting()
        {
            return View();
        }
        public IActionResult PaginaUsuario()
        {
            return View();
        }

        public IActionResult Sobre()
        {
            return View();
        }

        [ResponseCache(Duration = 0 , Location = ResponseCacheLocation.None , NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId=Activity.Current?.Id??HttpContext.TraceIdentifier });
        }

        public object PrimeiroRequestDBdeDepoimentos()
        {
            return dataService.IniciaDB();
        }

        public object RequestDepoimentosPessoais(int idUsuario)
        {
            return dataService.RequestDepoimentosPessoais(idUsuario);
        }




        public Depoimentos SalvaDepoimentoBD(string nome , int usuarioId, string depoimento , string data)
        {
            Depoimentos depoimentos = new Depoimentos
            {
                Nome=nome ,
                IdUsuario = usuarioId,
                Depoimento=depoimento ,
                Data=data
            };
            return dataService.SalvaDepoimentoDB(depoimentos);

        }

        public object ApagaDepoimentoDB(int idDepoimento)
        {
            return LoginUsuario.ApagaDepoimentoDB(idDepoimento);
        }
        public object ValidaUserLogin(string nome , string senha)
        {
            Usuarios usuario = new Usuarios
            {
                Nome=nome ,
                Senha=senha
            };
            return LoginUsuario.LoginVerificaExistente(usuario);
        }


        public string MudaSenhaUsuario(string nome , int id , string novaSenha) 
        {
            Usuarios usuario = new Usuarios
            {
                Nome=nome ,
                Id=id
            };

            return dataService.AlteraSenhaUsuario(usuario , novaSenha);
        }

        public string ApagaUsuario (string nome, string senha)
        {
            Usuarios usuario = new Usuarios
            {
                Nome=nome ,
                Senha=senha,
            };
            return dataService.ApagaUsuarioDB(usuario);
        }


        public bool ValidaUserCadastroDB(string nome)
        {
            return dataService.CadastroValidaUsuarioExistenteDB(nome);
        }

        public string CadastraUsuario(string nome , string senha)
        {
            Usuarios usuario = new Usuarios
            {
                Nome=nome,
                Senha=senha
            };
            return dataService.CadastraUsuarioDB(usuario);
        }

    }
}
