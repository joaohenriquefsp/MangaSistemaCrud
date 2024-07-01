Imports System.Data.Entity

Public Class MangaDbContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("DefaultConnection")
    End Sub

    Public Property Pessoas As DbSet(Of Pessoa)
    Public Property AnalistasSuporte As DbSet(Of AnalistaSuporte)
    Public Property Desenvolvedores As DbSet(Of Desenvolvedor)

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)
        modelBuilder.Entity(Of Desenvolvedor)().HasRequired(Function(d) d.Pessoa).WithMany().HasForeignKey(Function(d) d.PessoaId)
        modelBuilder.Entity(Of AnalistaSuporte)().HasRequired(Function(a) a.Pessoa).WithMany().HasForeignKey(Function(a) a.PessoaId)

        modelBuilder.Entity(Of Pessoa)().ToTable("Pessoas")
        modelBuilder.Entity(Of AnalistaSuporte)().ToTable("AnalistasSuporte")
        modelBuilder.Entity(Of Desenvolvedor)().ToTable("Desenvolvedores")

    End Sub

End Class