function checaLogin() {
    console.log("entro")
    let UserLogin = localStorage.getItem("nomeUsuario");
    $("#IconeUsuario").text(`${UserLogin}`)
    $("#MeuPerfilNome").text(`${UserLogin}`)
    $("#MeuPerfilNickName-btn").html(`${UserLogin}`)
    EscondeCaixasDeLogin();

}

function EscondeCaixasDeLogin() {
    if (localStorage.getItem("nomeUsuario") != null) {
        $("#CaixaLogin").attr("hidden", true);
        $("#BoxInsereDepoimento").attr("hidden", false);
    }
    else {
        $("#BoxInsereDepoimento").attr("hidden", true);
        $("#CaixaUserLogado").attr("hidden", true);
    }
}
