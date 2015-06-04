Imports Microsoft.VisualBasic

Public Class DAOClient
    Property _people As Collection

    Public Sub New()
        Me._people = New Collection
    End Sub

    Public Sub rePerson(ByRef p As Client)
        Dim reader As OleDb.OleDbDataReader = DBBroker.getInstance.read("SELECT * FROM Clientes WHERE Telefono='" & p.telephone & "';")
        reader.Read()
        p.address = reader.GetString(1)
        p.points = reader.GetInt32(2)
    End Sub


    Public Function delPerson(ByVal p As Client) As Integer 'returns # of changed rows (should be 1)
        Return DBBroker.getInstance().change("DELETE FROM Clientes WHERE Telefono='" & p.telephone & "';")
    End Function


    Public Function upPerson(ByVal p As Client) As Integer 'returns # of changed rows (should be 1)
        Return DBBroker.getInstance().change("UPDATE Clientes SET  SaldoDePuntos='" & p.points & "',  Dirección='" & p.address & "' WHERE Telefono='" & p.telephone & "';")
    End Function


    Public Function crePerson(ByVal p As Client) As Integer 'returns # of changed rows (should be 1)
        Return DBBroker.getInstance().change("INSERT INTO Clientes VALUES ('" & p.telephone & "','" & p.address & "', '" & 0 & "');")
    End Function


    Public Sub reAllPerson(ByRef p As Client) 'returns an OleDBDataReader data structure
        Dim readerAux As OleDb.OleDbDataReader = DBBroker.getInstance().read("SELECT * FROM Clientes ORDER BY Telefono;")

        While readerAux.Read()
            p.dao._people.Add(New Client(readerAux.GetString(0), readerAux.GetString(1)))
        End While
    End Sub

End Class
