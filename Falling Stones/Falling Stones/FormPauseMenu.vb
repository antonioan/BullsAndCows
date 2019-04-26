Public Class FormPauseMenu

    Private Sub FormPauseMenu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point((FormPauseDim.Width - Me.Width) / 2 + FormPauseDim.Left, (FormPauseDim.Height - Me.Height) / 2 + FormPauseDim.Top)
        If FormSettings.Visible Then FormSettings.BringToFront() Else Me.BringToFront()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Form1.Close()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If My.Settings.GameMode = 1 Then FormGameM1.Close() Else FormGameM2.Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        FormSettings.Show()
        FormSettings.BringToFront()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If FormSettings.Visible Then FormSettings.Close()
        Close()
        FormPauseDim.Close()
        If My.Settings.GameMode = 1 Then FormGameM1.paused = False Else FormGameM1.paused = False
    End Sub

    Private Sub FormPauseDim_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If My.Settings.GameMode = 1 Then FormGameM1.paused = False Else FormGameM2.paused = False
        End If
    End Sub
End Class