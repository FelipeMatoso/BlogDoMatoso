function checaLogin() {
    console.log("entro")
    let algo = localStorage.getItem("nomeUsuario");
    $("#IconeUsuario").text(`${algo}`)
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
