Public Class FormOptions

    Private Sub FormOptions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim h1 As String = My.Settings.HotStop, h2 As String = My.Settings.HotPause, h3 As String = My.Settings.HotChange
        CheckBox10.Checked = My.Settings.ShowLauncherOnExit
        CheckBox11.Checked = My.Settings.EscStopsAsWell
        CheckBox1.Checked = h1.Contains("Ctrl")
        CheckBox2.Checked = h1.Contains("Shift")
        CheckBox3.Checked = h1.Contains("Alt")
        TextBox1.Text = h1.Last
        CheckBox9.Checked = h2.Contains("Ctrl")
        CheckBox7.Checked = h2.Contains("Shift")
        CheckBox8.Checked = h2.Contains("Alt")
        TextBox3.Text = h2.Last
        CheckBox6.Checked = h3.Contains("Ctrl")
        CheckBox4.Checked = h3.Contains("Shift")
        CheckBox5.Checked = h3.Contains("Alt")
        TextBox2.Text = h3.Last
        RadioButton1.Checked = (My.Settings.WindowMode = 1)
        RadioButton2.Checked = (My.Settings.WindowMode = 2)
        RadioButton3.Checked = (My.Settings.WindowMode = 3)
        TextBox4.Text = My.Settings.WindowCustom.X & "x" & My.Settings.WindowCustom.Y
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If sender Is Nothing Or sender.Text = "" Then Exit Sub
        FormSettings.Show()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If sender Is Nothing Or sender.Text = "" Then Exit Sub
        Select Case Asc(TextBox1.Text)
            Case 65 To 90
                TextBox1.Text = TextBox1.Text.ToUpper
            Case 97 To 122
                'Perfect
            Case Else
                MsgBox("You can only associate ABC letters to hotkeys!" & vbCrLf & "Changes were not saved.", MsgBoxStyle.Critical, "Behold!")
                Exit Sub
        End Select
        Select Case Asc(TextBox2.Text)
            Case 65 To 90
                TextBox2.Text = TextBox2.Text.ToUpper
            Case 97 To 122
                'Perfect
            Case Else
                MsgBox("You can only associate ABC letters to hotkeys!" & vbCrLf & "Changes were not saved.", MsgBoxStyle.Critical, "Behold!")
                Exit Sub
        End Select
        Select Case Asc(TextBox3.Text)
            Case 65 To 90
                TextBox3.Text = TextBox3.Text.ToUpper
            Case 97 To 122
                'Perfect
            Case Else
                MsgBox("You can only associate ABC letters to hotkeys!" & vbCrLf & "Changes were not saved.", MsgBoxStyle.Critical, "Behold!")
                Exit Sub
        End Select
        My.Settings.HotStop = If(CheckBox1.Checked, "Ctrl+", "") & If(CheckBox2.Checked, "Shift+", "") & If(CheckBox3.Checked, "Alt+", "") & TextBox1.Text
        My.Settings.HotPause = If(CheckBox9.Checked, "Ctrl+", "") & If(CheckBox7.Checked, "Shift+", "") & If(CheckBox8.Checked, "Alt+", "") & TextBox3.Text
        My.Settings.HotChange = If(CheckBox6.Checked, "Ctrl+", "") & If(CheckBox4.Checked, "Shift+", "") & If(CheckBox5.Checked, "Alt+", "") & TextBox2.Text
        My.Settings.ShowLauncherOnExit = CheckBox10.Checked
        My.Settings.EscStopsAsWell = CheckBox11.Checked
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If sender Is Nothing Or sender.Text = "" Then Exit Sub
        CheckBox10.Checked = True
        CheckBox11.Checked = True
        CheckBox1.Checked = True
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        TextBox1.Text = "Q"
        CheckBox9.Checked = False
        CheckBox7.Checked = False
        CheckBox8.Checked = False
        TextBox3.Text = "P"
        CheckBox6.Checked = True
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        TextBox2.Text = "O"
        Refresh()
        Button1.PerformClick()
    End Sub

    Private Sub RadioButtonW_CheckedChanged(sender As RadioButton, e As System.EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged
        If sender Is Nothing Or sender.Text = "" Then Exit Sub
        If sender.Checked Then My.Settings.WindowMode = sender.Name.Last.ToString
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TextBox4.Text <> My.Settings.WindowCustom.X & "x" & My.Settings.WindowCustom.Y Then TextBox4.Text = My.Settings.WindowCustom.X & "x" & My.Settings.WindowCustom.Y
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If sender Is Nothing Or sender.Text = "" Then Exit Sub
        FormSetCustomSize.Show()
    End Sub
End Class