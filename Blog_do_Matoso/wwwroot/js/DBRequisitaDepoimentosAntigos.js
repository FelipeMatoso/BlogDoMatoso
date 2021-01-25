

function Ajax1() {

    return $.ajax({
        method: "GET",
        url: "/home/PrimeiroRequestDBdeDepoimentos",
        async: false,
    })
        .fail(function (error) {
            console.log("falhou no request de depoiemntos antigos");
            console.log(error)
        })
        .done(function (depoimentos) {
            console.log(depoimentos)
            let i = 0
            if (depoimentos == null) {
                console.log("Sem depoimentos")
            }
            else {
                while (depoimentos[i] != null) {
                    montaDepoimento(depoimentos[i], false);
                    i++
                }
            }
        });
}


function AjaxDepoimentosPessoais() {
    let id = { idUsuario: localStorage.getItem("idUsuario") }

    return $.ajax({
        method: "GET",
        url: "/home/RequestDepoimentosPessoais",
        dataType: 'json',
        data: id,
    })
        .fail(function (error) {
            console.log("falhou no request de depoiemntos antigos");
            console.log(error)
        })
        .done(function (depoimentos) {
            console.log(depoimentos)
            let i = 0
            while (depoimentos[i] != null) {
                montaDepoimento(depoimentos[i], true);
                i++
            }
        });
}









