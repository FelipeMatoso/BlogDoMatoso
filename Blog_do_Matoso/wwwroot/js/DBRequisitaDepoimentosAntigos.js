

function Ajax1() {



    return $.ajax({
        method: "GET",
        url: "/home/PrimeiroRequestDBdeDepoimentos",
    })
        .fail(function (error) {
            console.log("falhou no request de depoiemntos antigos");
            console.log(error)
        })
        .done(function (depoimentos) {
            console.log(depoimentos)
            let i = 0
            while (depoimentos[i] != null) {
                postaConteudo(depoimentos[i]);
                i++
            }
        });
}









