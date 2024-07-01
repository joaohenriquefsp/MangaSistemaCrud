Imports System.Web.Mvc
Imports System.Threading.Tasks
Namespace Controllers
    Public Class PessoaController
        Inherits Controller
        Private ReadOnly db As New MangaDbContext()

        ' GET: Pessoa
        Function Login() As ActionResult
            Return View()
        End Function


        <HttpPost>
        Public Function Login(model As Pessoa) As ActionResult
            If ModelState.IsValidField("Email") AndAlso ModelState.IsValidField("Senha") Then
                Using db

                    Dim usuario = db.Pessoas.FirstOrDefault(Function(p) p.Email = model.Email AndAlso p.Senha = model.Senha)

                    If usuario IsNot Nothing Then
                        ' Login válido, pode armazenar informações de sessão ou cookie de autenticação aqui, se necessário
                        ' Exemplo: Session("UsuarioLogado") = usuario

                        Return RedirectToAction("Index", "Home") ' Redireciona para a página inicial após o login
                    Else
                        ' Login inválido, adicionar mensagem de erro
                        ModelState.AddModelError("", "Usuário ou senha inválidos.")
                        Return View(model)
                    End If
                End Using
            End If

            ' Se chegou aqui, significa que houve um erro de validação, retornar para a view com os erros
            Return View(model)
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Async Function Registrar(<Bind(Include:="Nome,CPF,DataNascimento,Email,Senha,TipoFuncionario,Administrador")> pessoa As Pessoa) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Pessoas.Add(pessoa) 'create Pessoa
                Await db.SaveChangesAsync()
                Return RedirectToAction("Login")
            End If

            Return View(pessoa)
        End Function


    End Class
End Namespace