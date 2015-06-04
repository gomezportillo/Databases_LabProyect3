Public Class Main_Interface
    Dim _connected As Boolean = False
    Dim _path As String

    Private Sub SelectDBButton_Click(sender As Object, e As EventArgs) Handles SelectDBButton.Click
        openFileDialog.Filter = "Access 2007 (*.accdb)|*.accdb" 'Filters the extension of the files you can select
        openFileDialog.Multiselect = False 'Only one file
        openFileDialog.CheckFileExists = True 'Checking
        openFileDialog.CheckPathExists = True
        openFileDialog.FileName = "Teleburyer.accdb" 'Initial file name in the file browser bar

        If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            _connected = True
            DBBroker.FILE_PATH = openFileDialog.FileName
            Me.Text = "Teleburyer - CONNECTED TO " & openFileDialog.SafeFileName.ToUpper
            SelectDBButton.Text = "Database selected"
            SelectDBButton.BackColor = Color.Green
            CallButton.Enabled = True
            ProductsButton.Enabled = True
        Else
            Me.Text = "Teleburyer - ERROR CONNECTING TO " & openFileDialog.SafeFileName.ToUpper
        End If

    End Sub


    Private Sub ProductsButton_Click(sender As Object, e As EventArgs) Handles ProductsButton.Click
        If _connected Then
            Products_Interface.Show()
        Else
            MessageBox.Show("Please consider connecting to the database", "Error - connect to the database")
        End If
    End Sub


    Private Sub CallButton_Click(sender As Object, e As EventArgs) Handles CallButton.Click
        If _connected Then
            Client_Interface.Show()
        Else
            MessageBox.Show("Please consider connecting to the database", "Error - connect to the database")
        End If
    End Sub

    Private Sub InformationButton_Click(sender As Object, e As EventArgs) Handles InformationButton.Click
        MessageBox.Show("Diego.Molero@alu.uclm.es " & vbCrLf & "PedroManuel.GomezPortillo@alu.uclm.es", "Developer team", MessageBoxButtons.OK)
    End Sub

    Private Sub MainInterface_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class
