Imports Microsoft.VisualBasic

Public Class Order
    Property id As Integer
    Property d As Date
    Property client As Client
    Property discount As Integer
    Property initial_price As Double
    Property final_price As Double

    Property products As Collection

    Property dao As DAOOrder

    Public Sub New(ByRef clie As Client, ByRef i_price As Double, ByRef f_price As Double, ByRef disc As Integer, prod As Collection)
        Me.d = Date.Today()
        Me.client = clie
        Me.discount = disc
        Me.initial_price = i_price
        Me.final_price = f_price
        Me.products = prod
        Me.dao = New DAOOrder

    End Sub

    Public Sub createOrder()

        Me.dao.creOrder(Me)

        Me.dao.getLastId(Me)

    End Sub

    Public Sub createDetalles_Pedido()
        For Each p As Product In products
            Me.dao.creDetalles_Pedido(Me.id, p)
        Next
    End Sub

End Class
