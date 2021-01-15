
$("#formsLogin").submit(function (e) {
    e.preventDefault();
    let nomeLogin = $("#loginUsuario").val();
    let senhaLogin = $("#loginSenha").val();
    let cookie = $("#loginCheckbox");

    let objCadastro = MontaObjetoDeUsuario(nomeLogin, senhaLogin);

    if (ValidaUsuarioNoBancoLogin(objCadastro) == true) {
        console.log("entro validacao do banco")
    }
    else {
        console.log("retornou para main falso")
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
    $.ajax({
        method: "GET",
        url: "/home/ValidaUserLogin",
       headers:'json',
        data: objCadastro,
        async:false,
        beforeSend: function () {
            console.log("Validando Usuario...");
        },
        success: function (response) {
            console.log(response + " retornado de ajax ValidaUserLogin");
            valida = response;
        },
        error: function (req, status, err) {
            console.log("deu error")
            console.log(req)
            console.log(status)
            console.log(err)


        }
    })
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