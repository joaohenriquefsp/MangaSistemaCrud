Imports System
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Public Class Desenvolvedor
    Public Property Id As Integer
    Public Property PessoaId As Integer ' Chave estrangeira para Pessoa
    Public Property ProjetosEmDesenvolvimento As String
    Public Property LinguagensUtilizadas As String

    ' Navegação
    Public Overridable Property Pessoa As Pessoa
End Class