Public Class Ticket_Interface

    Property _order As Order

    Private Sub Ticket_Interface_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RichTextBox_Ticket.Text += "TELEBURYER" & vbTab & "# order " & _order.id & vbCrLf
        RichTextBox_Ticket.Text += vbCrLf & "Date: " & _order.d & vbCrLf
        RichTextBox_Ticket.Text += vbCrLf & vbTab & "---------------------------------------------------" & vbCrLf
        RichTextBox_Ticket.Text += vbCrLf & "Client: " & _order.client.telephone & vbTab & " Calle: " & _order.client.address & vbCrLf
        RichTextBox_Ticket.Text += vbCrLf & "Client Points Acumulated: " & _order.client.points & vbTab & "Redeem points: " & _order.discount & vbCrLf
        RichTextBox_Ticket.Text += vbCrLf & "Amount" & vbTab & "Product" & vbTab & vbTab & "Unit price" & vbTab & vbTab & "Total price" & vbCrLf

        For Each p As Product In _order.products
            Dim n_tabs As String = vbTab & vbTab
            If p.description.Length > 8 Then
                n_tabs = vbTab
            End If
            RichTextBox_Ticket.Text += vbCrLf & p.amount & vbTab & p.description & n_tabs & p.price & vbTab & vbTab & (p.amount * p.price)
        Next

        RichTextBox_Ticket.Text += vbCrLf & vbTab & "---------------------------------------------------"

        Dim discount_price As Decimal
        If _order.discount > 0 Then
            discount_price = CDec(_order.initial_price * _order.discount / 100)
        Else
            discount_price = 0
        End If

        RichTextBox_Ticket.Text += vbCrLf & "Total without discount: " & vbTab & vbTab & vbTab & vbTab & _order.initial_price & " €"
        RichTextBox_Ticket.Text += vbCrLf & "Applied discount: " & _order.discount & "%" & vbTab & vbTab & vbTab & vbTab & discount_price & " €"
        RichTextBox_Ticket.Text += vbCrLf & "TOTAL: " & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & _order.final_price & " €" & vbCrLf

        RichTextBox_Ticket.Text += vbCrLf & vbCrLf & vbTab & "THANKS FOR COMING TO TELEBURYER"


        RichTextBox_Ticket.SelectionAlignment = HorizontalAlignment.Center
    End Sub
   
End Class
