Imports Microsoft.VisualBasic

Public Class Client
    Property telephone As String
    Property address As String
    Property points As Integer
    Property dao As DAOClient

    Public Sub New(ByVal tlpn As String, ByVal addr As String)
        Me.telephone = tlpn
        Me.address = addr
        Me.points = 0
        dao = New DAOClient()
    End Sub

    Public Sub New(ByVal tlpn As String)
        Me.telephone = tlpn
        dao = New DAOClient()
    End Sub

    Public Sub New()
        dao = New DAOClient()
    End Sub

    Public Sub readClient()
        Me.dao.rePerson(Me)
    End Sub

    Public Function deleteClient() As Integer
        Return Me.dao.delPerson(Me)
    End Function

    Public Function updateClient() As Integer
        Return Me.dao.upPerson(Me)
    End Function

    Public Function createClient() As Integer
        Return Me.dao.crePerson(Me)
    End Function

    Public Sub readAll()
        Me.dao.reAllPerson(Me)
    End Sub

End Class
