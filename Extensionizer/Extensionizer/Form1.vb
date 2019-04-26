Public Class Form1

    Private Sub Panel1_DragDrop(sender As Object, e As DragEventArgs) Handles Panel1.DragDrop, ListView1.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files
            Dim name As String = IO.Path.GetFileName(path)
            ListView1.Items.Add("""" & name & """ (" & path & ")").SubItems.Add(path)
        Next
        TextBox1.Focus()
        TextBox1.SelectAll()
        ListView1.Show()
        Panel1.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Panel1_DragEnter(sender As Object, e As DragEventArgs) Handles Panel1.DragEnter, ListView1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
            Panel1.BorderStyle = BorderStyle.Fixed3D
        End If
    End Sub

    Private Sub Panel1_DragLeave(sender As Object, e As EventArgs) Handles Panel1.DragLeave, ListView1.DragLeave
        Panel1.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ListView1.Items.Clear()
        ListView1.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each item As ListViewItem In ListView1.Items
            Dim path As String = item.SubItems(1).Text
            Dim myext As String = TextBox1.Text
            TextBox1.Text = TextBox1.Text.Replace(".", "")
            If IO.File.Exists(path) Then
                My.Computer.FileSystem.RenameFile(path, IO.Path.GetFileNameWithoutExtension(path) & "." & myext)
            End If
        Next
        ListView1.Items.Clear()
        ListView1.Hide()
    End Sub
End Class
