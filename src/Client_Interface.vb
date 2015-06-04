Public Class Client_Interface
    Private _c As Client

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If telephone_textbox.Text <> String.Empty Then
            _c = New Client(telephone_textbox.Text)

            Try
                _c.readClient()
            Catch
                information_label.ForeColor = Color.Red
                information_label.Text = "Client was not registered " & vbCrLf & "Please enter a address to finish the registration"
                Exit Sub
            End Try

            information_label.ForeColor = Color.Green
            information_label.Text = "Client already registered"
            address_textbox.Text = _c.address
          
        End If
    End Sub

    Private Sub Client_Interface_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        Main_Interface.ProductsButton.Enabled = False
    End Sub

    Private Sub Client_Interface_Close(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        Main_Interface.ProductsButton.Enabled = True
    End Sub

    Private Sub Continue_Button_Click(sender As Object, e As EventArgs) Handles Continue_Button.Click
        If ListViewClients.SelectedItems.Count > 0 Then
            Order_Interface._myclient = _c
            Order_Interface.Show()
            Me.Close()
        Else
            information_label.ForeColor = Color.Red
            information_label.Text = "Select a client"
        End If

    End Sub


    Private Sub Add_Button_Click(sender As Object, e As EventArgs) Handles Add_Button.Click
        If telephone_textbox.Text <> String.Empty And address_textbox.Text <> String.Empty Then

            _c = New Client(telephone_textbox.Text, address_textbox.Text)

            Try
                _c.createClient()
            Catch ex As Exception
                information_label.ForeColor = Color.Red
                information_label.Text = "Error registrating new client."
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            information_label.Text = "Success registrating new client."
            information_label.ForeColor = Color.Green
        End If
    End Sub


    Private Sub Update_Button_Click(sender As Object, e As EventArgs) Handles Update_Button.Click
        If telephone_textbox.Text <> String.Empty And address_textbox.Text <> String.Empty Then

            _c = New Client(telephone_textbox.Text, address_textbox.Text)

            Try
                _c.updateClient()
            Catch ex As Exception
                information_label.ForeColor = Color.Red
                information_label.Text = "Error updating new client"
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            information_label.Text = "Success updating new client"
            information_label.ForeColor = Color.Green
        End If


    End Sub

    Private Sub LoadDB()
        _c = New Client()

        Try
            _c.readAll()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim item As ListViewItem
        For Each c As Client In _c.dao._people
            item = New ListViewItem(c.telephone)
            item.SubItems.Add(c.address)
            ListViewClients.Items.Add(item)
        Next

    End Sub

    Private Sub ListViewClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewClients.SelectedIndexChanged
        If ListViewClients.SelectedItems.Count > 0 Then

            _c = New Client(ListViewClients.SelectedItems(0).Text)

            Try
                _c.readClient()
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            telephone_textbox.Text = _c.telephone
            address_textbox.Text = _c.address
        End If
    End Sub
End Class
