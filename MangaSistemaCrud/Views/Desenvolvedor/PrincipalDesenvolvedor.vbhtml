@ModelType DesenvolvedorPessoaViewModel

@Code
    ViewData("Title") = "PrincipalDesenvolvedor"
End Code

<h2>PrincipalDesenvolvedor</h2>

@Html.Partial("~/Views/Pessoa/_DadosUsuario.vbhtml", Model.Pessoa)