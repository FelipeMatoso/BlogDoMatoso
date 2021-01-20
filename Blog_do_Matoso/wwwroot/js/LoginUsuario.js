
$("#formsLogin").submit(function (e) {
    e.preventDefault();
    let nomeLogin = $("#loginUsuario").val();
    let senhaLogin = $("#loginSenha").val();

    let objCadastro = MontaObjetoDeUsuario(nomeLogin, senhaLogin);
    if (ValidaUsuarioNoBancoLogin(objCadastro) == true) {
        console.log("entro validacao do banco e retornou true")
        localStorage.setItem("nomeUsuario", objCadastro.nome)
        document.location.reload(true);
    }
    else {
        console.log("validou e nao tem Usuario existente")
        limpaCamposCadastro()
    }

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
        headers: 'json',
        data: objCadastro,
        async: false,
        beforeSend: function () {
            console.log("Validando Usuario...");
        },
        success: function (response) {
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

function limpaCamposCadastro() {
    $("#loginUsuario").val('');
    $("#loginSenha").val('');
}

$("#LogOut-btn").click(function () {
    localStorage.removeItem("nomeUsuario");
    console.log("clicou botao");
    checaLogin();
    document.location.reload(true);
})