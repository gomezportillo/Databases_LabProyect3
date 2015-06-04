Imports Microsoft.VisualBasic

Public Class DAOOrder

    Property _orders As Collection

    Public Sub New()
        Me._orders = New Collection
    End Sub


    Public Function creOrder(ByRef o As Order) As Integer 'returns # of changed rows (should be 1)
        Return DBBroker.getInstance().change("INSERT INTO Pedidos(FechaPedido, Cliente, DescuentoAplicado, PrecioPedido) VALUES ('" & o.d & "', " & o.client.telephone & ", " & o.discount & ", '" & CStr(o.final_price) & "');")
    End Function


    Public Function creDetalles_Pedido(ByVal n_order As Integer, ByRef p As Product) As Integer
        Return DBBroker.getInstance().change("INSERT INTO Detalles_de_pedidos VALUES ('" & n_order & "','" & p.id & "', '" & p.amount & "');")
    End Function


    Public Sub getLastId(ByRef o As Order)
        Dim reader As OleDb.OleDbDataReader = DBBroker.getInstance.read("SELECT MAX(IdPedido) FROM Pedidos")
        reader.Read()
        o.id = CInt(reader.GetValue(0).ToString())
    End Sub

End Class

