function apagaDepoimentoDB(btnApagar) {
    console.log("apagou")

    console.log(btnApagar)
    console.log(btnApagar.dataset.id)

    AjaxApagaDepoimento( typeof btnApagar.dataset.id)

}

function AjaxApagaDepoimento(id) {
    let idDepoimento = { idDepoiemento: id };
    $.ajax({
        method: "POST",
        url: "/home/ApagaDepoimentoDB",
        headers: 'json',
        data: idDepoimento,
        async: true,
        beforeSend: function () {
            console.log("Apagando depoimento...");
        },
        success: function (response) {
            console.log(response)
            console.log("Depoimento de id" + id + ", de " + localStorage.getItem("idUsuario") + "apagado ")
        },
        error: function (req, status, err) {
            console.log("deu error")
            console.log(req)
            console.log(status)
            console.log(err)


        }
    })
}

function likeDepoimentoDB(btnLike) {
    console.log("like")
    return true;
}