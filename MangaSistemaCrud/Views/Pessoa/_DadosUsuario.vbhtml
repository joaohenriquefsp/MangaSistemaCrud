@Code
    ViewData("Title") = "_DadosUsuario"
End Code

<h2>Meus Dados</h2>


<table class="table">
    <tr>
        <th>Id</th>
        <td>@Model.Id</td>
    </tr>
    <tr>
        <th>Nome</th>
        <td>@Model.Nome</td>
    </tr>
    <tr>
        <th>CPF</th>
        <td>@Model.CPF</td>
    </tr>
    <tr>
        <th>Data de Nascimento</th>
        <td>@Model.DataNascimento</td>
    </tr>
    <tr>
        <th>Email</th>
        <td>@Model.Email</td>
    </tr>
    <tr>
        <th>Senha</th>
        <td>
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#TrocarSenhaModal">
               Trocar
            </button>
            <div class="modal fade" id="TrocarSenhaModal" tabindex="-1" role="dialog" aria-labelledby="TrocarSenhaModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="TrocarSenhaModalLabel">Trocar Senha</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            @Using Html.BeginForm("AtualizarSenha", "Pessoa", FormMethod.Post, New With {.id = "formAtualizarSenha"})
                                @Html.AntiForgeryToken()
                                @Html.Hidden("id", Model.Id)
                                @Html.Label("novaSenha", "Nova Senha")
                                @Html.Password("novaSenha", String.Empty, New With {.placeholder = "Nova Senha", .class = "form-control"})
                                @Html.Label("confirmaSenha", "Confirmar Senha")
                                @Html.Password("confirmaSenha", String.Empty, New With {.placeholder = "Nova Senha", .class = "form-control"})
                                @<text>
                                    <input type="submit" value="Atualizar Senha" Class="btn btn-primary" />
                                </text>

                            End Using
                        </div>

                    </div>
                </div>
            </div>

        </td>
    </tr>
</table>

@section Scripts
    @Scripts.Render("~/bundles/jqueryval")
    <script>
        $(document).ready(function () {
            $('#TrocarSenhaLink').click(function (e) {
                e.preventDefault();
                $('#TrocarSenhaModal').modal('show');
            });
        });
    </script>
End Section