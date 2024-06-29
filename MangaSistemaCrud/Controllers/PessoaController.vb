Imports System.Web.Mvc

Namespace Controllers
    Public Class PessoaController
        Inherits Controller

        ' GET: Pessoa
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace