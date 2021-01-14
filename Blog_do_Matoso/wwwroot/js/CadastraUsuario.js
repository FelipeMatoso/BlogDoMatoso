$("#formsCadastro").submit(function (e) {
    e.preventDefault();
    let nome = $("#cadastroNome").val();
    let senha = $("#cadastroSenha").val();

    let objCadastro;
    if (ValidaFormsCadastro(nome.length, senha.length) == "validado") {
        objCadastro = MontaObjetoDeUsuario(nome, senha)

        if (ValidaUsuarioNoBancoCadastro(objCadastro) == true) {
            $("#usuarioExistente").attr("hidden", true);
            console.log("entro validacao do banco")
            SalvaUsuarioDB(objCadastro);
            limpaCamposCadastro()

        }
        else {
            $("#usuarioExistente").attr("hidden", false);
        }
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
        return "validado";
    }
    else {
        if (nome< 4) {
            alert("Nome com " + nome + ", sendo minimo 4");
        }
        alert("Senha com " + senha + ", sendo minimo 2");
        return 0;
    }
}

function ValidaUsuarioNoBancoCadastro(objCadastro) {
    let valida

    $.ajax({
        method: "GET",
        url: "/home/ValidaUserCadastroDB",
        dataType: 'json',
        data: objCadastro,
        async:false,
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
        url: "/home/CadastraUsuario",
        dataType: 'json',
        data: objCadastro,
        beforeSend: function (msg) {
            console.log(msg)
        }
    })
        .done(function () {
            alert("Usuário "+objCadastro.nome +" salvo com sucesso!");
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

function limpaCamposCadastro(){
    $("#cadastroNome").val('');
    $("#cadastroSenha").val('');
}