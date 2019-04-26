Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Date.Today <> My.Settings.today Then
            My.Settings.today = Date.Today
            My.Settings.todayrounds = 0
            My.Settings.todaygiveups = 0
            My.Settings.todaywins = 0
            My.Settings.todaytries = 0
            My.Settings.todayscore = 0
            My.Settings.Save()
            My.Settings.Reload()
        End If

        If My.Settings.FirstTime = False Then
            Splash.Show()
            Me.Close()
        End If
        Me.Text = "Almost Exactly v" & My.Settings.myVersion & " - by AAN"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Settings.FirstTime = False
        My.Settings.Save()
        My.Settings.Reload()
        FormMain.Show()
        Me.Close()
    End Sub
End Class
