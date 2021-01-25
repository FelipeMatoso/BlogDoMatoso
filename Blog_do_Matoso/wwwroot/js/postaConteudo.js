function montaDepoimento(objeto, boolParaBotoes) {
    let corpoDepoimentos;
    if (boolParaBotoes == false) {
        corpoDepoimentos = $("#grid-posts");
    }
    else {
        corpoDepoimentos = $("#grid-depoimentos-pessoais");
    }

    let divMae = $("<div>");
    divMae.addClass("grid-depoimentos");

    let divNome = $("<div>");
    divNome.text(objeto.nome);
    divNome.addClass("depoimento-nome-classe");

    let divDepoimento = $("<div>");
    divDepoimento.text(objeto.depoimento);
    divDepoimento.addClass("depoimento-text-classe");

    let divData = $("<div>");
    divData.text(objeto.data);
    divData.addClass("depoimento-tempo-classe");

    divMae.append(divNome);
    divMae.append(divDepoimento);
    divMae.append(divData);


    if (boolParaBotoes == true) {
        let divDecicoes = $("<div>");
        divDecicoes.addClass("depoimento-decisao-pessoal")

        let divBtnApagar = $("<button>").attr('data-id', objeto.id);
        divBtnApagar.text("Apagar");
        divBtnApagar.addClass("alert-warning btn depoimento-btn-apaga-classe");
        divBtnApagar.css("margin-right", "12px")

        let divBtnLike = $("<button>").attr('data-id', objeto.id);
        divBtnLike.text("Like");
        divBtnLike.addClass("alert-light btn depoimento-btn-like-classe");
        divBtnLike.css("margin-left", "12px")


        divDecicoes.append(divBtnApagar);
        divDecicoes.append(divBtnLike);

        divMae.append(divDecicoes)
       
        return postaConteudo(corpoDepoimentos, divMae);
    }
    else { return postaConteudo(corpoDepoimentos, divMae) }
}
$(document).ready(function () {
    $(".depoimento-btn-apaga-classe").bind("click", function () {
        apagaDepoimentoDB(this)
    })

    $(".depoimento-btn-like-classe").bind("click", function () {
        likeDepoimentoDB(this)
    })
})

function postaConteudo(corpoDepoimentos, divMae) {

    corpoDepoimentos.prepend(divMae);

}
