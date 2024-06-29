Imports System
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Public Class AnalistaSuporte
    Public Property Id As Integer
    Public Property PessoaId As Integer ' Chave estrangeira para Pessoa
    Public Property GerenciamentoPessoal As String
    Public Property RegistroChamados As String
    Public Property Treinamentos As String

    ' Navegação
    Public Overridable Property Pessoa As Pessoa
End Class