$("#TrocaSenha-btn").click(function () {
    var objUsuario = {
        nome: localStorage.getItem("nomeUsuario"),
        id: localStorage.getItem("IdUsuario"),
        novaSenha: $("#NovaSenha").val()
    };

    $.ajax({
        method: "GET",
        url: "/home/MudaSenhaUsuario",
        headers: 'json',
        data: objUsuario,
        beforeSend: function () {
            console.log("Trocando senha...");
        },
        success: function (response) {
            console.log(response);
        },
        error: function (req, status, err) {
            console.log("deu error")
            console.log(req)
            console.log(status)
            console.log(err)
        }
    })
})


$("#ApagaConta-btn").click(function () {
    console.log("apagou conta")

    var objUsuario = {
        nome: localStorage.getItem("nomeUsuario"),
        senha: localStorage.getItem("idUsuario")
    };



    $.ajax({
        method: "GET",
        url: "/home/ApagaUsuario",
        headers: 'json',
        data: objUsuario,
        beforeSend: function () {
            console.log("Apagando senha");
        },
        success: function (response) {
            console.log(response);
        },
        error: function (req, status, err) {
            console.log("deu error")
            console.log(req)
            console.log(status)
            console.log(err)
        }
    })
})



