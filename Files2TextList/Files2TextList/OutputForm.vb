Public Class OutputForm

    'My Temp Folder is "C:\Users\Family\AppData\Local\Temp"
    Dim tempfile As String = My.Computer.FileSystem.SpecialDirectories.Temp & "/Files2TextList_Temp.txt"
    Dim BackToFiles As Boolean = False

    Public Sub Convert(ByVal items As ListView.ListViewItemCollection)
        RichTextBox1.Clear()
        Using newfile As New System.IO.StreamWriter(System.IO.File.Create(tempfile))
            For Each item As ListViewItem In items
                RichTextBox1.Text &= item.SubItems.Item(1).Text & vbCrLf
                newfile.Write(item.SubItems.Item(1).Text)
                newfile.WriteLine()
            Next
        End Using
        Show()
        Form1.Hide()
    End Sub

    Public Sub Convert(ByVal items As ListView.SelectedListViewItemCollection)
        RichTextBox1.Clear()
        Using newfile As New System.IO.StreamWriter(System.IO.File.Create(tempfile))
            For Each item As ListViewItem In items
                RichTextBox1.Text &= item.SubItems.Item(1).Text & vbCrLf
                newfile.Write(item.SubItems.Item(1).Text)
                newfile.WriteLine()
            Next
        End Using
        Show()
        Form1.Hide()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            My.Computer.Clipboard.SetText(My.Computer.FileSystem.ReadAllText(tempfile))
        Catch
            MsgBox("Couldn't Copy the Output to Clipboard!", MsgBoxStyle.Exclamation, "Error!")
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim sfd As New SaveFileDialog
        With sfd
            .FileName = "TextList1.txt"
            .DefaultExt = ".txt"
            .AddExtension = True
            .Filter = "Text files (*.txt)|*.txt|All files﻿ (*.*)|*.*"
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .Title = "Choose where to save the file:"
            .ShowDialog()
            Try
                If DialogResult.OK Then
                    If My.Computer.FileSystem.FileExists(.FileName) Then My.Computer.FileSystem.DeleteFile(.FileName)
                    My.Computer.FileSystem.CopyFile(tempfile, .FileName)
                End If
            Catch
                MsgBox("There was an error while saving the file!" & vbCrLf & "Please try to re-convert the items.", MsgBoxStyle.Exclamation, "Error!")
            End Try
        End With
    End Sub

    Private Sub OutputForm_FormClosing(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosing
        If My.Computer.FileSystem.FileExists(tempfile) Then My.Computer.FileSystem.DeleteFile(tempfile)
        If Not BackToFiles Then Form1.Close()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Form1.Show()
        BackToFiles = True
        Close()
    End Sub
End Class