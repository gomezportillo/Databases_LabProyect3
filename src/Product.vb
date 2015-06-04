Imports Microsoft.VisualBasic

Public Class Product
    Property id As Integer
    Property description As String
    Property price As Double
    Property amount As Integer
    Property dao As DAOProduct

    Public Sub New(ByVal id As Integer, ByVal descripcion As String, ByVal price As Double)
        Me._id = id
        Me._description = descripcion
        Me._price = price
        Me._dao = New DAOProduct()
    End Sub

    Public Sub New(ByVal id As Integer, ByVal descripcion As String, ByVal price As Double, ByVal amou As Integer)
        Me._id = id
        Me._description = descripcion
        Me._price = price
        Me._amount = amou
        Me._dao = New DAOProduct()
    End Sub


    Public Sub New()
        Me._dao = New DAOProduct()
    End Sub

    Public Sub New(ByVal id As Integer)
        Me._id = id
        Me._dao = New DAOProduct()
    End Sub

    Public Sub read()
        Me._dao.reProduct(Me)
    End Sub

    Public Sub readAll()
        Me._dao.reAllProducts(Me)
    End Sub

    Public Function delete() As Integer
        Return Me._dao.delProduct(Me)
    End Function

    Public Function update() As Integer
        Return Me._dao.upProduct(Me)
    End Function

    Public Function create() As Integer
        Return Me._dao.creProduct(Me)
    End Function


End Class
