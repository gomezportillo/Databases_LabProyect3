Public Class Discount_Interface

    Property _client As Client
    Property _initial_price As Double
    Property _order As Order
    Property _products As Collection = New Collection()

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        Label_Remaining_Points.Text = CStr(CDbl(Label_Initial_Points.Text) - CDbl(NumericUpDown1.Value))

        Label_Final_Price.Text = CStr(CDbl(Label_Initial_Price.Text) - (NumericUpDown1.Value * CDbl(Label_Initial_Price.Text)) / 100)
    End Sub

    Private Sub Discount_Interface_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (_client.points < 25) Then
            NumericUpDown1.Maximum = _client.points
        Else
            NumericUpDown1.Maximum = 25
        End If

        Label_Initial_Price.Text = CStr(_initial_price)
        Label_Initial_Points.Text = CStr(_client.points)

        Label_Remaining_Points.Text = CStr(_client.points)
        Label_Final_Price.Text = CStr(_initial_price)

    End Sub

    Private Sub Deliver_Button_Click(sender As Object, e As EventArgs) Handles Deliver_Button.Click
        _client.points = CInt(Label_Remaining_Points.Text)
        Dim used_points As Integer = CInt(CDbl(Label_Initial_Points.Text) - CDbl(Label_Remaining_Points.Text))

        _order = New Order(_client, CDbl(Label_Initial_Price.Text), CDbl(Label_Final_Price.Text), used_points, _products)

        _order.createOrder()

        _order.createDetalles_Pedido()

        Dim remaining_points As Integer

        If NumericUpDown1.Value = 0 Then
            remaining_points = CInt(_client.points + Math.Ceiling(CDec(Label_Final_Price.Text)))
        Else
            remaining_points = CInt(Label_Remaining_Points.Text)
        End If

        _client.points = remaining_points

        _client.updateClient()

        Ticket_Interface._order = _order
        Ticket_Interface.Show()
        Me.Close()
    End Sub

End Class
