Public Class FrmAlarm

    Dim myP As Point = New Point

    Private Sub Main_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseMove
        If e.Button = MouseButtons.Left Then Me.Location = Control.MousePosition - myP
    End Sub

    Private Sub Main_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown, Label1.MouseDown
        myP = Control.MousePosition - Me.Location
    End Sub
End Class