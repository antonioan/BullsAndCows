Public Class Splash

    Dim i As Integer = 4

    Private Sub Splash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label4.Text = "v" & My.Settings.myVersion
        Label7.Text = My.Settings.Difficulty
        Select Case My.Settings.Difficulty
            Case "H3LL"
                Label7.ForeColor = Color.DarkRed
            Case "SUP3RN0VA"
                Label7.ForeColor = Color.FromArgb(192, 0, 0)
            Case "Mario"
                Label7.ForeColor = Color.Red
        End Select
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label6.Text = "Dismissed in " & i & "..."
        i -= 1
        If i = -1 Then
            formmain.show()
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        mySettings.Show()
        Me.Close()
    End Sub

    Private Sub All_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click, Label1.Click, Label3.Click, Label4.Click, Label5.Click, Label6.Click, Label7.Click, Me.Click
        FormMain.Show()
        Me.Close()
    End Sub
End Class