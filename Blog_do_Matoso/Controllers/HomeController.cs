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


        public Depoimentos SalvaDepoimentoBD(string nome, string depoimento,string data)
        {
            Depoimentos depoimentos = new Depoimentos
            {
                Nome=nome ,
                Depoimento=depoimento ,
                Data=data
            };
            return dataService.SalvaDepoimentoDB(depoimentos);

        }

        public bool ValidaUserLogin(string nome, string senha)
        {
            Usuarios usuario = new Usuarios
            {
                Nome=nome ,
                Senha=senha
            };
            return LoginUsuario.LoginVerificaExistente(usuario);
        }

        public string MudaSenhaUsuario(string nome, string senha) //nao utilizada
        {
            Usuarios usuario = new Usuarios
            {
                Nome=nome ,
                Senha=senha
            };

            return dataService.AlteraSenhaUsuario(usuario , "banana");
            
        }


        public bool ValidaUserCadastroDB(string nome)
        {
            return dataService.CadastroValidaUsuarioExistenteDB(nome);
        }
        public Usuarios CadastraUsuario(string nome , string senha)
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
