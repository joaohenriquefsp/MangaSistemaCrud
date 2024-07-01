@ModelType MangaSistemaCrud.Pessoa
@Code
    ViewData("Title") = "Registrar"
End Code

<ul class="navbar-nav navbar-left">
   
    <button type="button" class="btn btn-secondary" data-toggle="modal" data-target="#RegistrarModal">
        Registrar
    </button>
</ul>

<div class="modal fade" id="RegistrarModal" tabindex="-1" role="dialog" aria-labelledby="RegistrarModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="RegistrarModalLabel">Registrar</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                @* Conteúdo do formulário de Registrar aqui *@
               
                @Using Html.BeginForm("Registrar", "Pessoa", FormMethod.Post, New With {.id = "registrarFormModal"})
                    @Html.AntiForgeryToken()

                    @Html.LabelFor(Function(p) p.Nome, "Nome")
                    @Html.EditorFor(Function(p) p.Nome, New With {.htmlAttributes = New With {.class = "form-control"}})


                    @Html.LabelFor(Function(p) p.CPF, "CPF")
                    @Html.EditorFor(Function(p) p.CPF, New With {.htmlAttributes = New With {.class = "form-control"}})


                    @Html.LabelFor(Function(p) p.DataNascimento, "Data de Nascimento")
                    @Html.EditorFor(Function(p) p.DataNascimento, New With {.htmlAttributes = New With {.class = "form-control"}})


                    @Html.LabelFor(Function(p) p.Email, "Email")
                    @Html.EditorFor(Function(p) p.Email, New With {.htmlAttributes = New With {.class = "form-control"}})


                    @Html.LabelFor(Function(p) p.Senha, "Senha")
                    @Html.PasswordFor(Function(p) p.Senha, New With {.htmlAttributes = New With {.class = "form-control"}})


                    @Html.LabelFor(Function(p) p.TipoFuncionario, "Tipo de Funcionário")
                    @Html.DropDownListFor(Function(p) p.TipoFuncionario,
                                                                 New SelectList(New Object() {
                                                                     New With {.Value = "Desenvolvedor", .Text = "Desenvolvedor"},
                                                                     New With {.Value = "Analista de Suporte", .Text = "Analista de Suporte"}
                                                                 }, "Value", "Text"),
                                                                 "Selecione um tipo",
                                                                 New With {.class = "form-control"})


                    @<text>
                        <div Class="modal-footer">
                            <input type="submit" value="Enviar" Class="btn btn-primary" />
                            <Button type="button" Class="btn btn-secondary" data-dismiss="modal">Fechar</Button>
                        </div>
                    </text>

                End Using
            </div>
            
        </div>
    </div>
</div>

@section Scripts
    @Scripts.Render("~/bundles/jqueryval")
    <script>
        $(document).ready(function () {
            $('#registrarLink').click(function (e) {
                e.preventDefault();
                $('#RegistrarModal').modal('show');
            });
        });
    </script>
End Section