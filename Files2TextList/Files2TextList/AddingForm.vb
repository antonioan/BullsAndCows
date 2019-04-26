Public Class AddingForm

    Public Sub AddFiles(ByVal filepath() As String)
        Form1.Enabled = False
        Form1.Refresh()
        Show()
        Refresh()
        ProgressBar1.Maximum = filepath.Count
        Dim random As Random = New Random()

        'Label2.ForeColor = Color.Black
        'Dim StepChange As Integer = Math.Ceiling(filepath.Count / 255), StepCount As Integer = 0, Ascending As Boolean = True

        Dim cArrived As Boolean = True, cStart() As Integer = {0, 0, 0}, cEnd() As Integer = {0, 0, 0}
        Label2.ForeColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256))
        cStart(0) = Label2.ForeColor.R
        cStart(1) = Label2.ForeColor.G
        cStart(2) = Label2.ForeColor.B
        Label2.Refresh()

        For Each file As String In filepath
            If Form1.ListView1.Items.Count >= 3000 Then
                MsgBox("Files2TextList™ can only convert a maximum number of 3000 items at a time." & vbCrLf & "Only the first 3000 items will be added to the list.", MsgBoxStyle.Exclamation, "Hold on!")
                Exit For
            End If
            Dim newitem As ListViewItem = New ListViewItem(IO.Path.GetFileNameWithoutExtension(file))
            newitem.SubItems.Add("")
            newitem.SubItems.Add(file)
            Form1.ListView1.Items.Add(newitem)
            ProgressBar1.PerformStep()
            ProgressBar1.Refresh()
            If filepath.Count > 100 Then
                ProgressBar1.Value -= 1
                ProgressBar1.Value += 1
            End If

            'If filepath.Count < 1500 Then
            '    If StepCount = StepChange Then
            '        If Label2.ForeColor.R + StepChange > 255 Then
            '            Ascending = False
            '        ElseIf Label2.ForeColor.R - StepChange < 0 Then
            '            Ascending = True
            '        End If
            '        If Ascending = True Then
            '            Label2.ForeColor = Color.FromArgb(Label2.ForeColor.R + Math.Ceiling(filepath.Count / 255), _
            '                                              Label2.ForeColor.G + Math.Ceiling(filepath.Count / 255), _
            '                                              Label2.ForeColor.B + Math.Ceiling(filepath.Count / 255))
            '        Else
            '            Label2.ForeColor = Color.FromArgb(Label2.ForeColor.R - Math.Ceiling(filepath.Count / 255), _
            '                                              Label2.ForeColor.G - Math.Ceiling(filepath.Count / 255), _
            '                                              Label2.ForeColor.B - Math.Ceiling(filepath.Count / 255))
            '        End If
            '        StepCount = 0
            '    Else
            '        StepCount += 1
            '    End If
            'ElseIf filepath.Count >= 1500 And filepath.Count < 2250 Then
            '    Label2.ForeColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256))
            'End If

            If cArrived = True Then
enter1:         cEnd(0) = random.Next(256)
                cEnd(1) = random.Next(256)
                cEnd(2) = random.Next(256)
                cArrived = False
                GoTo enter2
            Else
enter2:         If cStart(0) = cEnd(0) And cStart(1) = cEnd(1) And cStart(2) = cEnd(2) Then
                    cArrived = True
                    GoTo enter1
                Else
                    If cStart(0) > cEnd(0) Then
                        cStart(0) -= 1
                    ElseIf cStart(0) < cEnd(0) Then
                        cStart(0) += 1
                    End If
                    If cStart(1) > cEnd(1) Then
                        cStart(1) -= 1
                    ElseIf cStart(1) < cEnd(1) Then
                        cStart(1) += 1
                    End If
                    If cStart(2) > cEnd(2) Then
                        cStart(2) -= 1
                    ElseIf cStart(2) < cEnd(2) Then
                        cStart(2) += 1
                    End If
                    Label2.ForeColor = Color.FromArgb(cStart(0), cStart(1), cStart(2))
                End If
            End If
            Label2.Refresh()
        Next
        Close()
    End Sub

    Private Sub AddingForm_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Form1.Enabled = True
        Form1.Refresh()
    End Sub
End Class