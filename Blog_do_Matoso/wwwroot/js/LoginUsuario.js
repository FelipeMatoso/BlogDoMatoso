$("#formsLogin").submit(function (e) {
    e.preventDefault();
    let nome = $("#loginUsuario").val();
    let senha = $("#loginSenha").val();
    let cookie = $("#loginCheckbox");

    let objCadastro = MontaObjetoDeUsuario(nome, senha);

    if (ValidaUsuarioNoBancoLogin(objCadastro) == true) {
            console.log("entro validacao do banco")
        }
        else {
            console.log("saiu false")
        }

    limpaCamposCadastro()
})

function MontaObjetoDeUsuario(nome, senha) {
    let obj = {
        nome: nome,
        senha: senha,
    };
    return obj;
}

function ValidaUsuarioNoBancoLogin(objCadastro) {
    let valida;
    console.log("entro validacao")
    console.log(objCadastro)
    $.ajax({
        method: "GET",
        url: "/home/ValidaUserLogin",
        dataType: 'json',
        data: objCadastro,
        async: false,
        beforeSend: function () {
            console.log("Validando Usuario...");
        }
    })
        .fail(function (response) {
            console.log("erro" + response)
        })
        .done(function (response) {
            console.log(response +" foda");
            valida = response;
            return response;
        });
    return valida;
}

function ValidaCookie(aceitaCookie) {
    if (aceitaCookie.is(':checked') == true) {
        return "aceito";
    }
}
function CookieMaker(objCadastro) {
    localStorage.setItem('nomeUsuario', objCadastro.nome)
    localStorage.setItem('senhaUsuario', objCadastro.senha)
    console.log("biscoito feito");
}

function limpaCamposCadastro() {
    $("#loginUsuario").val('');
     $("#loginSenha").val('');
}