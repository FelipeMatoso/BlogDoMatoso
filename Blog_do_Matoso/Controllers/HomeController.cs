﻿using Blog_do_Matoso.Business;
using Blog_do_Matoso.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;



namespace Blog_do_Matoso.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IDataService dataService;
        private readonly IValidaDepoimento validaDepoimento;
        public HomeController(IDataService dataService , IValidaDepoimento validaDepoimento)
        {
            this.dataService=dataService;
            this.validaDepoimento=validaDepoimento;
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
            return dataService.SalvaDados(depoimentos);

        }

        public bool validaUserCadastroDB(string nome)
        {
            return dataService.ValidacaoUsuario(nome);
        }
        //public bool validaUserLogin(string nome, string senha){}
        public Usuario SalvaUsuario(string nome , string senha)
        {
            Usuario usuario = new Usuario
            {
                Nome=nome,
                Senha=senha
            };
            return dataService.SalvaUsuarioDB(usuario);
        }

    }
}