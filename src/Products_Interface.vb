Public Class Products_Interface

    Private _p As Product

    Private Sub ButtonCleanLabels_Click(sender As Object, e As EventArgs) Handles ButtonCleanLabels.Click
        TextBoxID.Text = String.Empty
        TextBoxPrice.Text = String.Empty
        TextBoxDescription.Text = String.Empty
    End Sub

    Private Sub CloseForm(sender As Object, e As EventArgs) Handles Me.FormClosing
        Main_Interface.CallButton.Enabled = True
    End Sub

    Private Sub LoadForm(sender As Object, e As EventArgs) Handles Me.Load
        Main_Interface.CallButton.Enabled = False
        LoadDB()
    End Sub

    Private Sub LoadDB()
        listViewProducts.Items.Clear()

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
            listViewProducts.Items.Add(item)
        Next
    End Sub


    Private Sub listViewProducts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listViewProducts.SelectedIndexChanged
        If listViewProducts.SelectedItems.Count > 0 Then 'just in case u (accidentaly) click in an empty row
            TextBoxID.Text = listViewProducts.SelectedItems(0).SubItems(0).Text
            TextBoxPrice.Text = listViewProducts.SelectedItems(0).SubItems(1).Text
            TextBoxDescription.Text = listViewProducts.SelectedItems(0).SubItems(2).Text
        End If
    End Sub


    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        If TextBoxID.Text <> String.Empty And TextBoxPrice.Text <> String.Empty And TextBoxDescription.Text <> String.Empty Then
            Try
                System.Convert.ToInt32(TextBoxID.Text)
                System.Convert.ToDouble(TextBoxPrice.Text)
            Catch ex As Exception
                MessageBox.Show("Please insert the values in a correct format", "Error in format of values")
                Exit Sub
            End Try

            Try
                _p = New Product(System.Convert.ToInt32(TextBoxID.Text), TextBoxDescription.Text, System.Convert.ToDecimal(TextBoxPrice.Text))
                _p.create()
                LoadDB()
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source)
            End Try

        Else
            MessageBox.Show("Please introduce all the values")
        End If

    End Sub


    Private Sub ButtonUpdate_Click(sender As Object, e As EventArgs) Handles ButtonUpdate.Click
        If TextBoxID.Text <> String.Empty And TextBoxPrice.Text <> String.Empty And TextBoxDescription.Text <> String.Empty Then
            Try
                System.Convert.ToInt32(TextBoxID.Text)
                System.Convert.ToDouble(TextBoxPrice.Text)
            Catch ex As Exception
                MessageBox.Show("Please insert the values in a correct format", "Error in format of values")
                Exit Sub
            End Try

            Try
                _p = New Product(System.Convert.ToInt32(TextBoxID.Text), TextBoxDescription.Text, System.Convert.ToDouble(TextBoxPrice.Text))
                _p.update()
                LoadDB()
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source)
                Exit Sub
            End Try

        Else
            MessageBox.Show("Please introduce all the values")
        End If
    End Sub


    Private Sub ButtonDelete_Click(sender As Object, e As EventArgs) Handles ButtonDelete.Click
        If TextBoxID.Text <> String.Empty And TextBoxPrice.Text <> String.Empty And TextBoxDescription.Text <> String.Empty Then
            Try
                System.Convert.ToInt32(TextBoxID.Text)
            Catch ex As Exception
                MessageBox.Show("Please insert the values in a correct format", "Error in format of values")
                Exit Sub
            End Try

            Try
                _p = New Product(System.Convert.ToInt32(TextBoxID.Text))
                _p.delete()
                LoadDB()
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source)
                Exit Sub
            End Try

        Else
            MessageBox.Show("Please introduce all the values")
        End If
    End Sub
End Class
