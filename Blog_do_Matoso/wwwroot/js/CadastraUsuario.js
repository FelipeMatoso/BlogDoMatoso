$("#formsCadastro").submit(function (e) {
    e.preventDefault();
    let nome1 = $("#cadastroNome").val();
    let nome = capitalizeFirstLetter(nome1); 
    let senha = $("#cadastroSenha").val();

    let objCadastro;
    if (ValidaFormsCadastro(nome.length, senha.length) == "validado") {
        objCadastro = MontaObjetoDeUsuario(nome, senha)

        if (ValidaUsuarioNoBancoCadastro(objCadastro) == true) {
            $("#usuarioExistente").attr("hidden", true);
            limpaCamposCadastro();
            SalvaUsuarioDB(objCadastro);
            document.location.reload(true);
        }
        else {
            $("#usuarioExistente").attr("hidden", false);
        }
    }

})

function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

function MontaObjetoDeUsuario(nome, senha) {
    let obj = {
        nome: nome,
        senha: senha,
    };
    return obj;
}

function ValidaFormsCadastro(nome, senha) {
    if (nome >= 4 && nome <= 30 && senha >= 2 && senha <= 16) {
        return "validado";
    }
    else {
        if (nome < 4) {
            alert("Nome com " + nome + ", sendo minimo 4");
        }
        else {
            alert("Nome excedeu o máximo de 30 caracteres");
        }
        if (senha < 2) {
            alert("Senha com " + nome + ", sendo minimo 4");
        }
        else {
            alert("Senha excedeu excedeu o máximo de 16 caracteres");

        }
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
        async: false,
        beforeSend: function () {
            console.log("Validando Usuario...");
        }
    })
        .done(function (response) {
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
        async: false,
        data: objCadastro,
        beforeSend: function (msg) {
            console.log("Salvando em banco..")
        }
    })
        .done(function (response) {
            console.log(response)
            console.log("falhou")
        })
        .fail(function (response) {
            alert("Usuário " + objCadastro.nome + " salvo com sucesso!");
        })
}

function limpaCamposCadastro() {
    console.log("TA LIMPANDO")
    $("#ModalCadastros").modal('toggle');
}