Imports System.Web.Mvc
Imports System.Threading.Tasks
Imports System.Net
Namespace Controllers
    Public Class PessoaController
        Inherits Controller
        Private ReadOnly db As New MangaDbContext()

        ' GET: Pessoa

        Function Login() As ActionResult
            Return View()
        End Function


        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function Login(model As Pessoa) As ActionResult
            If ModelState.IsValidField("Email") AndAlso ModelState.IsValidField("Senha") Then
                Using db

                    Dim usuario = db.Pessoas.FirstOrDefault(Function(p) p.Email = model.Email AndAlso p.Senha = model.Senha)

                    If usuario IsNot Nothing Then
                        
                        If usuario.TipoFuncionario = "Desenvolvedor" Then
                            Return RedirectToAction("PrincipalDesenvolvedor", "Desenvolvedor", New With {.id = usuario.Id}) ' Redireciona para a página inicial após o login
                        ElseIf usuario.TipoFuncionario = "Analista de Suporte" Then
                            Return RedirectToAction("PrincipalAnalista", "AnalistaSuporte", New With {.id = usuario.Id})
                        End If
                    Else
                            ' Login inválido, adicionar mensagem de erro
                            ModelState.AddModelError("", "Usuário ou senha inválidos.")
                        Return View(model)
                    End If
                End Using
            End If

            ' erro de validação, retornar para a view com os erros
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

        ' GET: Pessoa/DadosUsuarioView
        Public Function _DadosUsuario(id As Integer) As ActionResult
            Using db
                Dim usuario = db.Pessoas.Find(id)
                If usuario Is Nothing Then
                    Return HttpNotFound()
                End If
                Return View(usuario)
            End Using
        End Function
        ' POST: Pessoa/AtualizarSenha
        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function AtualizarSenha(id As Integer, novaSenha As String, confirmaSenha As String) As ActionResult
            Dim pessoa = db.Pessoas.Find(id)
            If pessoa IsNot Nothing AndAlso novaSenha = confirmaSenha Then
                pessoa.Senha = novaSenha
                db.SaveChanges()
                If pessoa.TipoFuncionario = "Desenvolvedor" Then
                    Return RedirectToAction("PrincipalDesenvolvedor", "Desenvolvedor", New With {.id = pessoa.Id}) ' Redireciona para a página inicial após o login
                ElseIf pessoa.TipoFuncionario = "Analista de Suporte" Then
                    Return RedirectToAction("PrincipalAnalista", "AnalistaSuporte", New With {.id = pessoa.Id})
                End If
            End If
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End Function

    End Class
End Namespace