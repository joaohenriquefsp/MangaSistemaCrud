Imports System.Web.Mvc

Namespace Controllers
    Public Class DesenvolvedorController
        Inherits Controller
        Private ReadOnly db As New MangaDbContext()
        ' GET: Desenvolvedor
        <HttpGet>
        <Route("Desenvolvedor/{id:int}")>
        Function PrincipalDesenvolvedor(id As Integer) As ActionResult
            ' Buscar o usuário pelo ID no banco de dados
            Dim pessoa = db.Pessoas.Find(id)

            ' Verificar se a pessoa foi encontrada
            If pessoa Is Nothing Then
                Return HttpNotFound()
            End If

            ' Buscar o analista suporte associado a esta pessoa (exemplo)
            Dim desenvolvedor = db.Desenvolvedores.FirstOrDefault(Function(a) a.PessoaId = id)

            ' Criar o ViewModel combinando Pessoa e AnalistaSuporte
            Dim viewModel As New DesenvolvedorPessoaViewModel With {
                .Pessoa = pessoa,
                .Desenvolvedor = desenvolvedor
            }

            ' Retornar a view PrincipalAnalista com o ViewModel
            Return View(viewModel)
        End Function
    End Class
End Namespace