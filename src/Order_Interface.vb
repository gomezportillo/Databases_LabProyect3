Public Class Order_Interface

    Private _p As Product
    Property _myclient As Client

    Private Sub CloseForm(sender As Object, e As EventArgs) Handles Me.FormClosing
        Main_Interface.ProductsButton.Enabled = True
    End Sub

    Private Sub LoadForm(sender As Object, e As EventArgs) Handles Me.Load
        Main_Interface.ProductsButton.Enabled = False
        LoadDB()
        Client_info.Text = "Client: " & _myclient.telephone & " Address: " & _myclient.address
    End Sub

    Private Sub LoadDB()
        listViewProductsAvailable.Items.Clear()

        _p = New Product()
        Try
            _p.readAll()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim item As ListViewItem
        For Each pAux As Product In _p.dao._products
            item = New ListViewItem(System.Convert.ToString(pAux.id))
            item.SubItems.Add(System.Convert.ToString(pAux.price))
            item.SubItems.Add(pAux.description)
            listViewProductsAvailable.Items.Add(item)
        Next
    End Sub

    Private Sub FinishOrderButton_Click(sender As Object, e As EventArgs) Handles FinishOrderButton.Click
        If CDbl(label_price.Text) > 0 Then
            Dim p As Product
            For Each i As ListViewItem In listViewProductsClient.Items
                p = New Product(CInt(i.SubItems(1).Text), i.SubItems(3).Text, (CDbl(i.SubItems(2).Text) / CDbl(i.SubItems(0).Text)), CInt(i.SubItems(0).Text))
                Discount_Interface._products.Add(p)
            Next

            Discount_Interface._client = _myclient
            Discount_Interface._initial_price = CDbl(label_price.Text)
            Discount_Interface.Show()
            Me.Close()
        Else
            info_label.Text = "Please select at " & vbCrLf & "least one product"
            info_label.ForeColor = Color.Red
        End If

    End Sub


    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click

        If product_amount.Value <= 0 Then
            info_label.Text = "Please introduce amount"
            info_label.ForeColor = Color.Red
            Exit Sub

        ElseIf listViewProductsAvailable.SelectedItems.Count > 0 Then
            Dim id_selected As String = listViewProductsAvailable.SelectedItems(0).SubItems(0).Text

            For Each i As ListViewItem In listViewProductsClient.Items 'If we have already introduced this item
                If i.SubItems(1).Text = id_selected Then
                    i.SubItems(0).Text = CStr(CDbl(i.SubItems(0).Text) + product_amount.Value)

                    Dim pri As Double = (product_amount.Value * CDbl(listViewProductsAvailable.SelectedItems(0).SubItems(1).Text))
                    i.SubItems(2).Text = CStr(CDbl(i.SubItems(2).Text) + pri)
                    label_price.Text = CStr(CDbl(label_price.Text) + pri)
                    Exit Sub
                End If

            Next

            Dim item As ListViewItem
            item = New ListViewItem(System.Convert.ToString(product_amount.Value))

            item.SubItems.Add(listViewProductsAvailable.SelectedItems(0).SubItems(0))

            Dim price As Double = CDbl(listViewProductsAvailable.SelectedItems(0).SubItems(1).Text) * product_amount.Value
            item.SubItems.Add(System.Convert.ToString(price))

            item.SubItems.Add(listViewProductsAvailable.SelectedItems(0).SubItems(2))

            listViewProductsClient.Items.Add(item)

            label_price.Text = CStr(CDbl(label_price.Text) + price)

            info_label.Text = "Product added"
            info_label.ForeColor = Color.Green
        End If
    End Sub


    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        If listViewProductsClient.SelectedItems.Count > 0 Then
            Dim p As ListViewItem = listViewProductsClient.SelectedItems(0)
            label_price.Text = CStr(CDbl(label_price.Text) - CInt(p.SubItems(2).Text))
            listViewProductsClient.Items.Remove(CType(p, ListViewItem))
        End If

    End Sub

End Class
