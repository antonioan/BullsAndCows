Public Class Over_GAVEUP

    Private Sub Over_GAVEUP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label20.Text = "SCORE: 0"
        Label7.Text = My.Settings.Difficulty
        Label9.Text = FormMain.totalalmosts
        Label11.Text = FormMain.totalexactlies
        Label2.Text = FormMain.totaltries
        Label24.Text = FormMain.SolvingLose
        Label34.Text = "(The Numbers Were: " & FormMain.masterNums(1) & ", " & FormMain.masterNums(2) & ", " & FormMain.masterNums(3) & ", " & FormMain.masterNums(4) & ")"
        Label16.Text = "* " & FormMain.diff(True) & " (Difficulty Bonus)"
        Label19.Text = "(" & Label9.Text & " * 5 + " & Label11.Text & " * 10) / " & Label2.Text & " * " & Label16.Text.Split("(").First.Replace("*", "").Trim & " = " & _
            CInt((((Label9.Text * 5) + (Label11.Text * 10)) / Label2.Text) * FormMain.diff(True))
        If Label24.Text > 0 Then Label27.ForeColor = Color.FromName("Firebrick") Else Label27.ForeColor = Color.Gray
        If FormMain.HelpEnabled = True Then Label31.Text = "YES" Else Label31.Text = "NO"

        Dim sum As Int64 = Label19.Text.Split("=").Last.Trim
        If Label24.Text > 0 Then
            For i As Integer = 1 To Label24.Text
                sum *= 0.8
            Next
        End If
        If FormMain.HelpEnabled = True And FormMain.diff() <> 1 And FormMain.diff() <> 8 Then
            Label32.ForeColor = Color.FromName("Firebrick")
            sum *= 0.5
        Else : Label32.ForeColor = Color.Gray
        End If
        sum *= 0.3
        Label20.Text = "SCORE: " & sum.ToString("N0")
        My.Settings.todayscore += sum
        My.Settings.alltimescore += sum
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FormMain.Enabled = True
        FormMain.Activate()
        mySettings.Button2.PerformClick()
        Me.Close()
    End Sub
End Class