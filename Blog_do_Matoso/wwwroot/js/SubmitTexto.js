
$("#botaoSubmit").on("click", function (e) {
    event.preventDefault();
    SubmitDica();

})

function SubmitDica() {
    console.log("clicou ajuda")

    let offset = new Date()
    offset.getUTCDay("pt-br")
    offset = JSON.stringify(offset).split("T")
    offset[1] = offset[0][9] + offset[0][10] + '/' + offset[0][6] + offset[0][7] + '/' + offset[0][1] + offset[0][2] + offset[0][3] + offset[0][4]

    let colaboradorNome = localStorage.getItem("nomeUsuario");
    JSON.stringify(colaboradorNome);

    let colaboradorTexto = $("#depoimento").val();
    let Nome = capitalizeFirstLetter(colaboradorNome)

    if (colaboradorTexto.length <5) {
        console.log("Você não escreveu nada")
    }
    else {
        let pessoa = {
            nome: Nome,
            depoimento: colaboradorTexto,
            data: offset[1]
        }
        alert("Obrigado " + colaboradorNome + " por ajudar! Agredeço muito pela dica!")
        console.log(pessoa)

        postaConteudo(pessoa);
        SalvaDepoimentoDB(pessoa);
    }


    limpaCampos()
}


function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}



function SalvaDepoimentoDB(objeto) {
    $.ajax({
        method: "POST",
        url: "/home/SalvaDepoimentoBD",
        dataType: 'json',
        data: objeto,
        beforeSend: function (msg) {
            console.log(msg)
        }
    })
        .done(function (depoimentos) {

        });
}

function limpaCampos() {
    $("#depoimento").focus();
    $("#depoimento").val("");
}