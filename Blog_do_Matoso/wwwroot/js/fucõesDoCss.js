let loginBool = false
function displayBarraLogin() {
    console.log("troca style")
    console.log(loginBool)
    if (loginBool == false) {
        $("#login_usuario").css({ "display": "flex" })
        $("#login_senha").css({ "display": "flex" })

        loginBool = true
    }
    else {
        $("#login_usuario").css({ "display": "none" })
        $("#login_senha").css({ "display": "none" })
        loginBool = false
    }
}

let cadastroBool = false
function displayCaixaCadastro() {
    console.log(cadastroBool)

    if (cadastroBool == false) {
        console.log("vamos de cadastro!")

        $("#cadastro_popUP").css({ "display": "grid", "background": "blue" })

        cadastroBool = true
    }
    else {
        $("#cadastro_popUP").css({ "display": "none" })

        cadastroBool = false
    }

}



