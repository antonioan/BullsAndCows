Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PictureBox1.Image = If(My.Settings.AllowVolume, My.Resources.VolumeLowNoBG, My.Resources.VolumeMuteNoBG)
    End Sub

    Private Sub PictureBox1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseClick
        If My.Settings.AllowVolume Then
            PictureBox1.Image = My.Resources.VolumeMuteNoBG
            My.Settings.AllowVolume = False
        Else
            PictureBox1.Image = My.Resources.VolumeLowNoBG
            My.Settings.AllowVolume = True
        End If
        PictureBox1.Refresh()
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        LaunchGame()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        FormOptions.Show()
        FormOptions.Refresh()
        FormOptions.TabControl1.SelectedTab = FormOptions.TabPage1
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        FormOptions.Show()
        FormOptions.Refresh()
        FormOptions.TabControl1.SelectedTab = FormOptions.TabPage2
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Close()
    End Sub

    Public Sub LaunchGame()
        If My.Settings.GameMode = 1 Then FormGameM1.Show() Else FormGameM2.Show()
        FormGameM1.Refresh()
        FormGameM2.Refresh()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If FormGameM1.Visible Or FormGameM2.Visible Then
            If Me.Visible Then Me.Hide()
            If My.Settings.GameMode = 1 Then
                If FormGameM1.paused Then
                    If FormPauseDim.Visible = False Then FormPauseDim.Show()
                    If FormPauseMenu.Visible = False Then FormPauseMenu.Show()
                Else
                    If FormPauseDim.Visible Then FormPauseDim.Close()
                    If FormPauseMenu.Visible Then FormPauseMenu.Close()
                End If
                If FormPauseDim.Visible Then FormPauseDim.Location = FormGameM1.Location
                If FormGameM1.WindowState = FormWindowState.Minimized Then FormGameM1.paused = True
                If FormSettings.Visible Then FormGameM1.paused = True Else FormGameM1.Text = "Falling Stones - Mode: " & My.Settings.GameMode & ", Diff: " & My.Settings.GameDiff & ", Speed: " & My.Settings.GameSpeed + 1
                FormGameM1.Timer1.Enabled = Not FormGameM1.paused
            Else
                If FormGameM2.paused Then
                    If FormPauseDim.Visible = False Then FormPauseDim.Show()
                    If FormPauseMenu.Visible = False Then FormPauseMenu.Show()
                Else
                    If FormPauseDim.Visible Then FormPauseDim.Close()
                    If FormPauseMenu.Visible Then FormPauseMenu.Close()
                End If
                If FormPauseDim.Visible Then FormPauseDim.Location = FormGameM1.Location
                If FormGameM2.WindowState = FormWindowState.Minimized Then FormGameM2.paused = True
                If FormSettings.Visible Then FormGameM2.paused = True Else FormGameM2.Text = "Falling Stones - Mode: " & My.Settings.GameMode & ", Diff: " & My.Settings.GameDiff & ", Speed: " & My.Settings.GameSpeed + 1
                FormGameM2.Timer1.Enabled = Not FormGameM2.paused
            End If
            If FormPauseMenu.Visible Then FormPauseMenu.Location = New Point((FormPauseDim.Width - FormPauseMenu.Width) / 2 + FormPauseDim.Left, (FormPauseDim.Height - FormPauseMenu.Height) / 2 + FormPauseDim.Top)
            If FormSettings.Visible And FormPauseMenu.Visible Then
                If FormSettings.ComboBox1.Focused = False Then FormSettings.BringToFront()
            Else
                FormPauseMenu.BringToFront()
            End If
        Else
            If Me.Visible = False Then
                Me.Show()
                Me.BringToFront()
            End If
            If FormPauseDim.Visible Then FormPauseDim.Close()
            If FormPauseMenu.Visible Then FormPauseMenu.Close()
        End If
    End Sub
End Class
