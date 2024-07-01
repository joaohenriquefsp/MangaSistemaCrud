Imports System
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Security.Cryptography


Public Class Pessoa
    <Key>
    Public Property Id As Integer
    <DisplayName("Nome Completo")>
    <Required(ErrorMessage:="O campo nome deve ser obrigatorio")>
    <MaxLength(100, ErrorMessage:="No máximo 100 caracteres!1")>
    Public Property Nome As String

    <Required(ErrorMessage:="O campo{0} é requirido")>
    Public Property CPF As String

    Public Property DataNascimento As Date

    <DisplayName("E-mail")>
    <Required(ErrorMessage:="O campo nome deve ser obrigatorio")>
    <EmailAddress(ErrorMessage:="Email em formato inválido")>
    Public Property Email As String

    <DisplayName("Senha")>
    <Required(ErrorMessage:="O campo senha deve ser obrigatorio")>
    Public Property Senha As String

    <DisplayName("Tipo do Funcionário")>
    <Required(ErrorMessage:="O campo Tipo Funcionário deve ser obrigatório")>
    Public Property TipoFuncionario As String ' Adicionado para representar o tipo de funcionário
    <DisplayName("Administrador")>
    Public Property Administrador As Boolean ' Adicionado para indicar se é um administrador
End Class