Public Class Stats

    Private Sub Stats_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = My.User.Name.Split("\").Last & "'s Statistics"

        lbl1.Text = FormMain.Label7.Text
        lbl2.Text = FormMain.Label13.Text
        lbl3.Text = My.Settings.todayrounds
        lbl4.Text = My.Settings.alltimerounds
        lbl5.Text = My.Settings.todaygiveups
        lbl6.Text = My.Settings.alltimegiveups
        lbl7.Text = My.Settings.todaywins
        lbl8.Text = My.Settings.alltimewins
        lbl9.Text = My.Settings.todaytries
        lbl10.Text = My.Settings.alltimetries
        lbl11.Text = My.Settings.todayscore
        lbl12.Text = My.Settings.alltimescore
        Label14.Text = "Today: " & Date.Today
    End Sub
End Class