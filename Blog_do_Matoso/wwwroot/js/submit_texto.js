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

    let colaboradorNome = $("#nome-feedback").val();
    let colaboradorTexto = $("#depoimento").val();

    let Nome = capitalizeFirstLetter(colaboradorNome)

    if (ConfereConteudo(colaboradorNome) == true) {
        let pessoa = {
            nome: Nome,
            depoimento: colaboradorTexto,
            data: offset[1]
        }
        alert("Obrigado " + colaboradorNome + " por ajudar! Agredeço muito pela dica!")

        limpaCampos()
        postaConteudo(pessoa);
        SalvaDepoimentoDB(pessoa);
    }
    else {
        alert("Nome " + colaboradorNome + " inváido")
        limpaCampos()
    }
}


function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

function ConfereConteudo(nome) {
    var aprovado = false

    if (nome == "Plinio" || nome == "Matoso" || nome == "Felipe" || nome == "Ademir" || nome == "Falavinha" || nome == "Evandro") {
        aprovado = true
    }
    return aprovado;
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
    $("#nome-feedback").val("");
    $("#nome-feedback").focus();
    $("#depoimento").val("");
}