@ModelType AnalistaPessoaViewModel

@Code
    ViewData("Title") = "PrincipalAnalista"
End Code
@*Iria continuar porém por falta de tempo nao foi possível acrecentar futuras edições


    @Html.HiddenFor(Function(model) model.Pessoa.Id)
    <h2>Área do Analista de Suporte</h2>
    @Using (Html.BeginForm("RegistrarAnalista", "AnalistaSuporte", FormMethod.Post, New With {.id = "registrarAnalistaForm", .class = "form-horizontal", .role = "form", .enctype = "multipart/form-data"}))
        @Html.AntiForgeryToken()

        @<text>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.AnalistaSuporte.GerenciamentoPessoal, "Informe o procedimento realizado", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.AnalistaSuporte.GerenciamentoPessoal, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.AnalistaSuporte.GerenciamentoPessoal, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.AnalistaSuporte.RegistroChamados, "Informe o chamado realizado", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.AnalistaSuporte.RegistroChamados, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.AnalistaSuporte.RegistroChamados, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.AnalistaSuporte.Treinamentos, "Foi feito algum treinamento? se sim, qual?", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.AnalistaSuporte.Treinamentos, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.AnalistaSuporte.Treinamentos, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <button type="submit" class="btn btn-primary">Registrar</button>
                </div>
            </div>
        </text>
    End Using
    *@
    @Html.Partial("~/Views/Pessoa/_DadosUsuario.vbhtml", Model.Pessoa)