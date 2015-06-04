Imports Microsoft.VisualBasic

Public Class DAOProduct
    Property _products As Collection
    
    Public Sub New()
        Me._products = New Collection
    End Sub

    Public Sub reProduct(ByRef p As Product)
        Dim reader As OleDb.OleDbDataReader = DBBroker.getInstance.read("SELECT * FROM Productos WHERE IdProducto='" & p.id & "';")
        reader.Read()
        p.id = CInt(reader.GetString(0))
        p.price = CDbl(reader.GetString(1))
        p.description = reader.GetString(2)
    End Sub


    Public Function delProduct(ByVal p As Product) As Integer 'returns # of changed rows (should be 1)
        Return DBBroker.getInstance().change("DELETE FROM Productos WHERE idProducto=" & p.id & ";")
    End Function


    Public Function upProduct(ByVal p As Product) As Integer 'returns # of changed rows (should be 1)
        Return DBBroker.getInstance().change("UPDATE Productos SET PrecioProducto='" & System.Convert.ToString(p.price) & "', DescripciónProducto='" & p.description & "' WHERE IdProducto=" & p.id & ";")
    End Function


    Public Function creProduct(ByVal p As Product) As Integer 'returns # of changed rows (should be 1)
        Return DBBroker.getInstance().change("INSERT INTO Productos VALUES ('" & p.id & "','" & p.description & "', '" & p.price & "');")
    End Function


    Public Sub reAllProducts(ByRef p As Product) 'returns an OleDBDataReader data structure
        Dim readerAux As OleDb.OleDbDataReader = DBBroker.getInstance().read("SELECT * FROM Productos ORDER BY idProducto;")

        While readerAux.Read()                                  'id / descrption / price
            p.dao._products.Add(New Product(CInt(readerAux.GetValue(0)), readerAux.GetString(1), CDbl(readerAux.GetValue(2))))
        End While
    End Sub
End Class
