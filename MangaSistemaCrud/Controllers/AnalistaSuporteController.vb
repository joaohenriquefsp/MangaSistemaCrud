Imports System.Web.Mvc
Imports System.Threading.Tasks
Imports System.Net

Namespace Controllers
    Public Class AnalistaSuporteController
        Inherits Controller
        Private ReadOnly db As New MangaDbContext()


        ' GET: AnalistaSuporte
        <HttpGet>
        <Route("Analista")>
        Function PrincipalAnalista(id As Integer) As ActionResult
            ' Buscar o usuário pelo ID no banco de dados
            Dim pessoa = db.Pessoas.Find(id)

            ' Verificar se a pessoa foi encontrada
            If pessoa Is Nothing Then
                Return HttpNotFound()
            End If

            ' Buscar o analista suporte associado a esta pessoa (exemplo)
            Dim analistaSuporte = db.AnalistasSuporte.FirstOrDefault(Function(a) a.PessoaId = id)

            ' Criar o ViewModel combinando Pessoa e AnalistaSuporte
            Dim viewModel As New AnalistaPessoaViewModel With {
                .Pessoa = pessoa,
                .AnalistaSuporte = analistaSuporte
            }

            ' Retornar a view PrincipalAnalista com o ViewModel
            Return View(viewModel)
        End Function


        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Async Function RegistrarAnalista(id As Integer, <Bind(Include:="GerenciamentoPessoal,RegistroChamados,Treinamentos")> ByVal analista As AnalistaSuporte) As Task(Of ActionResult)
            If ModelState.IsValid Then
                ' Associar o ID da pessoa ao analista suporte
                analista.PessoaId = id

                ' Adicionar o novo analista suporte ao contexto
                db.AnalistasSuporte.Add(analista)
                Await db.SaveChangesAsync()

                ' Redirecionar para a ação PrincipalAnalista com o ID da pessoa
                Return RedirectToAction("PrincipalAnalista", "AnalistaSuporte", New With {.id = id})
            End If

            ' Se houver erros de validação, retorna para a view com os erros
            Return View()
        End Function






    End Class
End Namespace