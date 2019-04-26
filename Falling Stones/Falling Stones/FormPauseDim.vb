Public Class FormPauseDim

    Private Sub FormPauseDim_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Location = If(My.Settings.GameMode = 1, FormGameM1.Location, FormGameM2.Location)
        Me.Size = If(My.Settings.GameMode = 1, FormGameM1.Size, FormGameM2.Size)
        Me.BringToFront()
    End Sub

    Private Sub FormPauseDim_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If My.Settings.GameMode = 1 Then FormGameM1.paused = False Else FormGameM2.paused = False
        End If
    End Sub
End Class