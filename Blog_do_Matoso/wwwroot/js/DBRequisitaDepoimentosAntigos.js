

function Ajax1() {

    return $.ajax({
        method: "GET",
        url: "/home/PrimeiroRequestDBdeDepoimentos",
    }).done(function (depoimentos) {


        let i=0
        while (depoimentos[i]!= null) {
            postaConteudo(depoimentos[i]);
            i++
        }
    });
}


function Ajax2() {
    return $.ajax({
        method: "GET",
        url: "/home/SalvaDepoimentoBD",
    }).done(function (texto) {
        console.log(texto)

    });
}






