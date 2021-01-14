$("#formsLogin").submit(function (e) {
    e.preventDefault();
    console.log("entro");
    let nome = $("#loginUsuario").val();
    let senha = $("#loginSenha").val();
    let cookie = $("#loginCheckbox");

    let objCadastro = MontaObjetoDeUsuario(nome, senha);

    if (ValidaUsuarioNoBancoLogin(objCadastro) == true) {
            console.log("entro validacao do banco")
            //SalvaUsuarioDB(objCadastro);
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
    let valida
    $.ajax({
        method: "GET",
        url: "/home/validaUserLogin",
        dataType: 'json',
        data: objCadastro,
        async: false,
        beforeSend: function () {
            console.log("Validando Usuario...");
        }
    })
        .done(function (response) {
            console.log(response);
            valida = response;
            return response;
        });
    return valida;
}

function SalvaUsuarioDB(objCadastro) {
    $.ajax({
        method: "POST",
        url: "/home/SalvaUsuario",
        dataType: 'json',
        data: objCadastro,
        beforeSend: function (msg) {
            console.log(msg)
        }
    })
        .done(function () {
            alert("Usuário salvo  com sucesso!");
        })
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