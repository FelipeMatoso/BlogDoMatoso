import { ajax } from "jquery";


$("#formsCadastro").submit(function (e) {
    e.preventDefault();
    console.log("entro");
    let nome = $("#nome").val();
    let senha = $("#senha").val();
    let aceitaCookie = $("#cookieLogin").val();

    if (ValidaFormsCadastro(nome.length, senha.length) == 1) {
        let objCadastro = MontaObjetoDeUsuario(nome, senha)
        if (ValidaUsuarioNoBanco(objCadastro) == true) {
            if (ValidaCookie(aceitaCookie) == "aceito") {
                console.log(objCadastro);
                CookieMaker(objCadastro);
            }
            else {

            }
        }

    }
    else
        if (this > 2) {
        }
})

function MontaObjetoDeUsuario(nome, senha) {
    let obj = {
        nome: nome,
        senha: senha,
    };
    return obj;
}

function ValidaFormsCadastro(nome, senha) {
    if (nome >= 4 && senha >= 2) {
        if (aceitaCookie == "on") {
            return 1;
        }
        else return 2;
    }
    else {
        console.log("Nome com " + nome + ", sendo minimo 4")
        console.log("Senha com " + senha + ", sendo minimo 2")
        return 0;
    }
}

function ValidaUsuarioNoBanco(objCadastro) {
    $.ajax({
        method: "POST",
        url: "/home/SalvaDepoimentoBD",
        dataType: 'json',
        data: objCadastro,
        beforeSend: function (msg) {
            console.log(msg)
        }
    })
        .done(function (depoimentos) {

        });
}
function ValidaCookie(aceitaCookie) {
    if (aceitaCookie == "on") {
        return "aceito";
    }
}

function CookieMaker(objCadastro) {
    localStorage.setItem('nomeUsuario', objCadastro.nome)
    localStorage.setItem('senhaUsuario', objCadastro.senha)
    console.log("biscoito feito");

}