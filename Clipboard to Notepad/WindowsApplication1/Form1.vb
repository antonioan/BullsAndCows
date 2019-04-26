Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadClipboardAndAutoComplete()
    End Sub

    Public Sub LoadClipboardAndAutoComplete()
        Dim text = My.Computer.Clipboard.GetText()
        If text IsNot Nothing Then RichTextBox1.Text = My.Computer.Clipboard.GetText()
        Dim autocomplete = New AutoCompleteStringCollection
        Dim suggest = My.Settings.SuggestLocation
        Dim first As String = ""
        If suggest.Count > 0 Then first = suggest(0)
        For Each str As String In suggest
            autocomplete.Add(str)
        Next
        TextBox2.AutoCompleteCustomSource = autocomplete
        TextBox2.Text = first
        Me.Text = "Clipboard to Notepad: Ready"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim name = TextBox1.Text
        If name = "" Then
            MessageBox.Show("File name is empty!", "Clipboard to Notepad: Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If Not name.ValidFileName Then
            MessageBox.Show("Invalid file name!", "Clipboard to Notepad: Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        Dim loc = TextBox2.Text
        If loc = "" Then
            MessageBox.Show("Directory name is empty!", "Clipboard to Notepad: Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If Not My.Computer.FileSystem.DirectoryExists(loc) Then
            MessageBox.Show("Directory not found!", "Clipboard to Notepad: Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        Dim fullpath = My.Computer.FileSystem.CombinePath(loc, name) & ".txt"
        If My.Computer.FileSystem.FileExists(fullpath) Then
            MessageBox.Show("File with same name already found!", "Clipboard to Notepad: Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If RichTextBox1.Text = "" Then
            If Not MessageBox.Show("It's empty! Are you sure?", "Clipboard to Notepad: Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then Exit Sub
        End If

        Dim lines = RichTextBox1.Lines
        Dim count = lines.Count
        Dim perc = 0
        Me.Text = String.Format("Clipboard to Notepad: {0}% (Line {1} of {2})", CDbl(perc / count * 100).ToString("F1"), perc, count)
        Using sw As New IO.StreamWriter(fullpath)
            sw.Write(lines(0))
            perc += 1
            Me.Text = String.Format("Clipboard to Notepad: {0}% (Line {1} of {2})", CDbl(perc / count * 100).ToString("F1"), perc, count)
            Refresh()
            For i As Integer = 1 To lines.Count - 1
                sw.Write(Environment.NewLine & lines(i))
                perc += 1
                Me.Text = String.Format("Clipboard to Notepad: {0}% (Line {1} of {2})", CDbl(perc / count * 100).ToString("F1"), perc, count)
                Refresh()
            Next
            sw.Close()
        End Using

        loc = IO.Path.GetDirectoryName(fullpath)
        If My.Settings.SuggestLocation.IndexOf(loc) = -1 Then My.Settings.SuggestLocation.Insert(0, loc)
        My.Settings.Save() : My.Settings.Reload()
        If MessageBox.Show("Successfully created the file!" & vbCrLf & "To keep this program open?", "Clipboard to Notepad: Done", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Close()
        Else
            TextBox1.Clear()
            RichTextBox1.Clear()
            LoadClipboardAndAutoComplete()
        End If
    End Sub

    Private Sub RichTextBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles RichTextBox1.MouseDoubleClick
        AcceptButton = Nothing
        RichTextBox1.ReadOnly = False
        RichTextBox1.BackColor = Color.White
        Label4.Hide()
        RichTextBox1.Focus()
    End Sub

    Private Sub Label4_MouseDown(sender As Object, e As MouseEventArgs) Handles Label4.MouseDown
        Label4.ForeColor = Color.Red
    End Sub

    Private Sub Label4_MouseUp(sender As Object, e As MouseEventArgs) Handles Label4.MouseUp
        Label4.ForeColor = Color.Gray
    End Sub

    Private Sub Label4_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Label4.MouseDoubleClick
        AcceptButton = Nothing
        RichTextBox1.ReadOnly = False
        RichTextBox1.BackColor = Color.White
        Label4.Hide()
        RichTextBox1.Focus()
    End Sub

    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
        If My.Computer.Keyboard.CtrlKeyDown Then
            Using fbd As New FolderBrowserDialog
                With fbd
                    .Description = "Choose a folder to save the text file in:"
                    .RootFolder = Environment.SpecialFolder.Desktop
                    .ShowNewFolderButton = True
                    fbd.ShowDialog()
                    If .SelectedPath IsNot Nothing AndAlso .SelectedPath <> "" Then TextBox2.Text = .SelectedPath
                End With
            End Using
        End If
    End Sub
End Class

Public Module Extensions
    <System.Runtime.CompilerServices.Extension()> _
    Public Function IndexOf(strcoll As Collections.Specialized.StringCollection, strfind As String) As Integer
        For i As Integer = 0 To strcoll.Count - 1
            If strcoll(i) = strfind Then Return i
        Next
        Return -1
    End Function
    <System.Runtime.CompilerServices.Extension()> _
    Public Function ValidFileName(str As String) As Boolean
        Dim InvalidChars() As String = {"\", "/", ":", "*", "?", "<", ">", "|", Chr(34).ToString()}
        For Each ch As String In InvalidChars
            If str.Contains(ch) Then Return False
        Next
        Return True
    End Function
End Module