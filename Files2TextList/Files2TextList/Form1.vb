Public Class Form1

    Private Sub Form1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Not e.Alt And Not e.Shift Then
            If e.Control Then
                If e.KeyCode = Keys.Delete Then
                    ListView1.Items.Clear()
                    'ElseIf e.KeyCode = Keys.Enter Then
                    '    If Button1.Enabled Then Button1.PerformClick()
                End If
            ElseIf e.Control = False Then
                If e.KeyCode = Keys.Delete Then
                    If ListView1.SelectedItems.Count > 0 Then
                        For Each item As ListViewItem In ListView1.SelectedItems
                            item.Remove()
                        Next
                    End If
                ElseIf e.KeyCode = Keys.Insert Then
                    ChooseFiles()
                End If
            End If
        End If
    End Sub

    Public Sub AutoResizeColumns()
        For Each col As ColumnHeader In ListView1.Columns
            col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            Dim a As Integer = col.Width
            col.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
            Dim b As Integer = col.Width
            If a > b Then col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent) Else _
                col.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
        Next
    End Sub

    Public Sub ChooseFiles()
        Dim ofd As New OpenFileDialog
        With ofd
            .Filter = "All files|*.*"
            .Title = "Choose the files you'd like to add to the list:"
            .Multiselect = True
            .ShowDialog()
            AddingForm.AddFiles(.FileNames)
            UpdateOutput()
        End With
    End Sub

    Public Sub Convert(Optional ByVal SelectedOnly As Boolean = False)
        If SelectedOnly And ListView1.SelectedItems.Count = 0 Then Exit Sub
        OutputForm.Convert(IIf(SelectedOnly, ListView1.SelectedItems, ListView1.Items))
    End Sub

    Public Sub UpdateOutput()
        ListView1.LabelEdit = False
        For Each item As ListViewItem In ListView1.Items
            Dim temp As String = String.Format("{0}{1}{2}{3}", IIf(CheckBox2.Checked, TextBox1.Text, ""), item.Text, IIf(CheckBox1.Checked, IO.Path.GetExtension(item.SubItems.Item(2).Text), ""), IIf(CheckBox3.Checked, TextBox2.Text, ""))
            If item.SubItems.Item(1).Text <> temp Then item.SubItems.Item(1).Text = temp
        Next
        AutoResizeColumns()
        ListView1.LabelEdit = True
    End Sub

    Private Sub ConvertAllToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ConvertAllToolStripMenuItem.Click
        Convert()
    End Sub

    Private Sub ConvertSelectedToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ConvertSelectedToolStripMenuItem.Click
        Convert(True)
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Button1.Enabled = IIf(ListView1.Items.Count > 0, True, False)
        TextBox1.Enabled = CheckBox2.Checked
        TextBox2.Enabled = CheckBox3.Checked
        If ListView1.LabelEdit = False Then ListView1.LabelEdit = True
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Convert()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged, CheckBox3.CheckedChanged, TextBox1.TextChanged, TextBox2.TextChanged
        UpdateOutput()
    End Sub

    Private Sub ListView1_ColumnClick(sender As System.Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
        If e.Column = 0 Then If ListView1.Sorting = SortOrder.Ascending Then ListView1.Sorting = SortOrder.Descending Else ListView1.Sorting = SortOrder.Ascending
        ListView1.Sort()
    End Sub

    Private Sub ListView1_AfterLabelEdit(sender As System.Object, e As System.Windows.Forms.LabelEditEventArgs) Handles ListView1.AfterLabelEdit
        e.CancelEdit = True
        Dim item As ListViewItem = ListView1.Items.Item(e.Item)
        Dim filepath As String = item.SubItems.Item(2).Text
        If e.Label = "" Then
            ListView1.Items.Item(e.Item).Text = IO.Path.GetFileNameWithoutExtension(filepath)
        ElseIf e.Label = item.Text Then
            Exit Sub
        Else
            ListView1.Items.Item(e.Item).Text = e.Label
        End If
        UpdateOutput()
        ListView1.Sort()
        ListView1.FindItemWithText(filepath, True, 0, True).EnsureVisible()
        ListView1.LabelEdit = False
    End Sub

    Private Sub Panel1_DragDrop(sender As Object, e As DragEventArgs) Handles ListView1.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files
            Dim newitem As ListViewItem = New ListViewItem(IO.Path.GetFileNameWithoutExtension(path))
            newitem.SubItems.Add("")
            newitem.SubItems.Add(path)
            ListView1.Items.Add(newitem)
        Next
        UpdateOutput()
        ListView1.Show()
    End Sub

    Private Sub Panel1_DragEnter(sender As Object, e As DragEventArgs) Handles ListView1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
End Class
