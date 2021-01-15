using Blog_do_Matoso.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Blog_do_Matoso.Interface;


namespace Blog_do_Matoso.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IDataService dataService;
        private readonly ILoginUsuario validacaoLoginUsuario;


        public HomeController(IDataService dataService , ILoginUsuario validacaoLoginUsuario)
        {
            this.dataService=dataService;
            this.validacaoLoginUsuario=validacaoLoginUsuario;
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

            return validacaoLoginUsuario.LoginVerificaExistente(nome , senha);
        }
        public string AcessaLogin(string nome, string senha)
        {
                return "Acessa Login Aqui";   
        }


        public bool ValidaUserCadastroDB(string nome)
        {
            return dataService.CadastroValidausuarioExistenteDB(nome);
        }
        public Usuario CadastraUsuario(string nome , string senha)
        {
            Usuario usuario = new Usuario
            {
                Nome=nome,
                Senha=senha
            };
            return dataService.CadastraUsuarioDB(usuario);
        }

    }
}
