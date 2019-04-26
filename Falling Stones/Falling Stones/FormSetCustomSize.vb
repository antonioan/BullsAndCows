Public Class FormSetCustomSize

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If IsNumeric(TextBox1.Text) And IsNumeric(TextBox2.Text) Then
            If TextBox1.Text > My.Computer.Screen.Bounds.Width Or TextBox2.Text > My.Computer.Screen.Bounds.Height Then
                MsgBox("You can't put a size bigger than your screen (" & My.Computer.Screen.Bounds.Width & "x" & My.Computer.Screen.Bounds.Height & ")!" & vbCrLf & "Changes were not saved.", MsgBoxStyle.Critical, "Behold!")
                Exit Sub
            ElseIf TextBox1.Text < 700 Or TextBox2.Text < 450 Then
                MsgBox("You can't put a size smaller than 700x450!" & vbCrLf & "Changes were not saved.", MsgBoxStyle.Critical, "Behold!")
                Exit Sub
            Else
                My.Settings.WindowCustom = New Point(TextBox1.Text, TextBox2.Text)
                My.Settings.Save()
                My.Settings.Reload()
            End If
        Else
            MsgBox("You can only type numbers!" & vbCrLf & "Changes were not saved.", MsgBoxStyle.Critical, "Behold!")
            Exit Sub
        End If
        Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub FormSetCustomSize_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.WindowCustom.X
        TextBox2.Text = My.Settings.WindowCustom.Y
    End Sub
End Class