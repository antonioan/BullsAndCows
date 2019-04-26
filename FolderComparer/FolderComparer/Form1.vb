Public Class Form1
    Private Sub GetAllFiles(Directory As String, ByRef OutputList As ListView, PreNum As Integer, Optional MainDirectory As String = "", Optional SkipLV3 As Boolean = False)
        If MainDirectory = "" Then
            MainDirectory = Directory
            OutputList.Items.Clear()
            OutputList.Columns(2).Text = "Directory | " & Directory
            SkipLV3 = True
        End If

        For Each filePath In IO.Directory.GetFiles(Directory)
            Dim item As ListViewItem = OutputList.Items.Add(PreNum & "." & OutputList.Items.Count + 1)
            item.SubItems.Add(IO.Path.GetFileName(filePath))

            Dim dir As String
            Try
                dir = IO.Path.GetDirectoryName(filePath).Replace(MainDirectory, "")
                If dir = "" OrElse dir.Last <> "\" Then dir &= "\"
            Catch
                dir = "|DIRECTORY NAME TOO LONG|"
            End Try
            item.SubItems.Add(dir)


            'ListView3
            If Not SkipLV3 AndAlso PreNum = 2 AndAlso ListView1.Items.Count > 0 Then
                Dim dir1 As String = ListView1.Columns(2).Text.Split("|")(1).Substring(1)
                If IO.Directory.GetFiles(dir1).Contains(filePath) Then
                    Dim item3 = ListView3.Items(item.Index)
                    item3.Text &= ", " & item.Text
                    item3.ForeColor = Color.Black
                Else
                    ListView3.Items.Add(item.Clone)
                End If
            ElseIf Not SkipLV3 AndAlso PreNum = 1 Then
                ListView3.Items.Add(item.Clone)
            End If
        Next

        For Each dirPath In IO.Directory.GetDirectories(Directory)
            GetAllFiles(dirPath, OutputList, PreNum, MainDirectory, SkipLV3)
        Next
    End Sub

    Private Sub ListView1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then _
            e.Effect = DragDropEffects.Copy Else e.Effect = DragDropEffects.None
    End Sub
    Private Sub ListView1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            If filePaths.Count = 1 AndAlso IO.Directory.Exists(filePaths(0)) Then
                GetAllFiles(filePaths(0), ListView1, 1)
            ElseIf filePaths.Count = 2 AndAlso IO.Directory.Exists(filePaths(0)) AndAlso IO.Directory.Exists(filePaths(1)) Then
                GetAllFiles(filePaths(0), ListView1, 1)
                GetAllFiles(filePaths(1), ListView2, 2)
            End If
        End If
    End Sub

    Private Sub ListView2_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView2.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then _
            e.Effect = DragDropEffects.Copy Else e.Effect = DragDropEffects.None
    End Sub
    Private Sub ListView2_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView2.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            If filePaths.Count = 1 AndAlso IO.Directory.Exists(filePaths(0)) Then _
                GetAllFiles(filePaths(0), ListView2, 2)
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged

    End Sub

    Private Sub ListView3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView3.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Compare(ListView1, ListView2, ListView3)
    End Sub

    Private Sub Compare(List1 As ListView, List2 As ListView, OutputList As ListView)
        For Each item1 As ListViewItem In ListView1.Items
            OutputList.Items.Add(item1.Clone)
        Next

        For Each item2 As ListViewItem In ListView2.Items
            Dim Found = False, Num = "", i = 0
            For Each item1 As ListViewItem In ListView1.Items
                If item1.SubItems(1).Text = item2.SubItems(1).Text AndAlso
                    item1.SubItems(2).Text = item2.SubItems(2).Text Then
                    Num = item1.Text
                    i = item1.Index
                    Found = True
                    Exit For
                End If
            Next
            If Not Found Then
                OutputList.Items.Add(item2.Clone)
            Else
                Dim item = OutputList.Items(i)
                item.Text = Num & ", " & item.Text
                item.ForeColor = Color.Black
            End If
        Next
    End Sub
End Class