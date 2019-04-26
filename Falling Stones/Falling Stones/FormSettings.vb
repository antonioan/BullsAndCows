Public Class FormSettings

    Dim onlychecking As Boolean = True
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If sender Is Nothing Or sender.Text = "" Then Exit Sub
        Close()
    End Sub

    Private Sub RadioButtonM_CheckedChanged(sender As RadioButton, e As System.EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
        If onlychecking Then Exit Sub
        If sender Is Nothing Or sender.Text = "" Then Exit Sub
        My.Settings.GameMode = If(RadioButton1.Checked, 1, 2)
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub RadioButtonD_CheckedCanged(sender As RadioButton, e As System.EventArgs) Handles RadioButton3.CheckedChanged, RadioButton4.CheckedChanged
        If onlychecking Then Exit Sub
        If sender Is Nothing Or sender.Text = "" Then Exit Sub
        My.Settings.GameDiff = If(RadioButton4.Checked, 1, 2)
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If onlychecking Then Exit Sub
        If sender Is Nothing Or sender.Text = "" Then Exit Sub
        My.Settings.GameSpeed = ComboBox1.SelectedIndex
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub ComboBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.TextChanged
        If onlychecking Then Exit Sub
        If sender Is Nothing Or sender.Text = "" Then Exit Sub
        If ComboBox1.Items.Contains(ComboBox1.Text) = False Then ComboBox1.Text = "Medium"
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        If onlychecking Then Exit Sub
        If sender Is Nothing Or sender.Text = "" Then Exit Sub
        If IsNumeric(TextBox1.Text) Then
            My.Settings.GameModeInt = TextBox1.Text
            My.Settings.Save()
            My.Settings.Reload()
        Else
            TextBox1.Text = 30
        End If
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        '4,5
        Label4.ForeColor = If(RadioButton1.Checked, Color.Red, Color.LightGray)
        Label5.ForeColor = If(RadioButton2.Checked, Color.Red, Color.LightGray)

        '8,7
        Label8.ForeColor = If(RadioButton4.Checked, Color.Red, Color.LightGray)
        Label7.ForeColor = If(RadioButton3.Checked, Color.Red, Color.LightGray)
    End Sub

    Private Sub FormSettings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        RadioButton1.Checked = My.Settings.GameMode = 1
        RadioButton2.Checked = My.Settings.GameMode = 2
        RadioButton4.Checked = My.Settings.GameDiff = 1
        RadioButton3.Checked = My.Settings.GameDiff = 2
        ComboBox1.SelectedIndex = My.Settings.GameSpeed
        TextBox1.Text = My.Settings.GameModeInt
        Refresh()
        onlychecking = False
    End Sub
End Class