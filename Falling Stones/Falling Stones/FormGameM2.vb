Public Class FormGameM2

    Public paused As Boolean = False
    Private Sub FormGameM2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        paused = True
        Me.FormBorderStyle = If(My.Settings.WindowMode <> 1, FormBorderStyle.FixedSingle, FormBorderStyle.None)
        Me.Size = IIf(My.Settings.WindowMode <> 3, My.Computer.Screen.Bounds.Size, My.Settings.WindowCustom)
        If My.Settings.WindowMode <> 3 Then Me.Location = New Point(0, 0)
        FormSettings.Show()
    End Sub

    'Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
    '    If My.Settings.GameMode = 1 Then
    '        Close()
    '        FormGameM1.Show()
    '    End If
    '    If FormSettings.Visible Then paused = True Else Me.Text = "Falling Stones - Mode: " & My.Settings.GameMode & ", Diff: " & My.Settings.GameDiff & ", Speed: " & My.Settings.GameSpeed + 1
    '    If Me.WindowState = FormWindowState.Minimized Then paused = True
    '    If paused Then
    '        FormPauseDim.Show()
    '        FormPauseMenu.Show()
    '    Else
    '        FormPauseDim.Close()
    '        FormPauseMenu.Close()
    '    End If
    'End Sub

    'Private Sub FormGameM2_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    '    FormPauseDim.Close()
    '    FormPauseMenu.Close()
    'End Sub
End Class