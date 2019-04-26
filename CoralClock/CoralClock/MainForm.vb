Public Class MainForm

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        If RadioButton3.Checked Then
            FrmTimer.Show()
        ElseIf RadioButton2.Checked Then
            FrmStopper.Show()
        Else 'If RadioButton1.Checked Then
            Form1.Show()
        End If
        Hide()
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        Close()
    End Sub
End Class