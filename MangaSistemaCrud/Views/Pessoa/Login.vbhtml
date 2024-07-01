@ModelType MangaSistemaCrud.Pessoa
@Code
    ViewData("Title") = "Login"
End Code

<h2>Login</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()

    @<div>
        @Html.LabelFor(Function(m) m.Email)
        @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
       
    </div>

    @<div>
        @Html.LabelFor(Function(m) m.Senha, "Senha")
        @Html.PasswordFor(Function(m) m.Senha, New With {.class = "form-control"})
        
    </div>

    @<text>
    <input type="submit" value="Enviar" Class="btn btn-primary" />
     
    </text>


End Using
@Html.Partial("_Registrar")



