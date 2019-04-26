Public Class mySettings

    Private Sub mySettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormMain.Enabled = False
        If My.Settings.Difficulty = RadioButton1.Text Then RadioButton1.Checked = True
        If My.Settings.Difficulty = RadioButton2.Text Then RadioButton2.Checked = True
        If My.Settings.Difficulty = RadioButton3.Text Then RadioButton3.Checked = True
        If My.Settings.Difficulty = RadioButton4.Text Then RadioButton4.Checked = True
        If My.Settings.Difficulty = RadioButton5.Text Then RadioButton5.Checked = True
        If My.Settings.Difficulty = RadioButton6.Text Then RadioButton6.Checked = True
        If My.Settings.Difficulty = RadioButton7.Text Then RadioButton7.Checked = True
        If My.Settings.Difficulty = RadioButton8.Text Then RadioButton8.Checked = True
        Dim st As String = My.Settings.AdvancedBool, a As String = st.Split("|").First, b As String = st.Split("|").Last
        If a = "T" Then CheckBox2.Checked = True
        If b = "T" Then CheckBox3.Checked = True
        Button2.Enabled = FormMain.Visible
    End Sub

    Private Sub mySettings_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim changed As Boolean = False
        If RadioButton1.Checked Then
            If My.Settings.Difficulty <> RadioButton1.Text Then changed = True
            My.Settings.Difficulty = RadioButton1.Text
        End If

        If RadioButton2.Checked Then
            If My.Settings.Difficulty <> RadioButton2.Text Then changed = True
            My.Settings.Difficulty = RadioButton2.Text
        End If

        If RadioButton3.Checked Then
            If My.Settings.Difficulty <> RadioButton3.Text Then changed = True
            My.Settings.Difficulty = RadioButton3.Text
        End If

        If RadioButton4.Checked Then
            If My.Settings.Difficulty <> RadioButton4.Text Then changed = True
            My.Settings.Difficulty = RadioButton4.Text
        End If

        If RadioButton5.Checked Then
            If My.Settings.Difficulty <> RadioButton5.Text Then changed = True
            My.Settings.Difficulty = RadioButton5.Text
        End If

        If RadioButton6.Checked Then
            If My.Settings.Difficulty <> RadioButton6.Text Then changed = True
            My.Settings.Difficulty = RadioButton6.Text
        End If

        If RadioButton7.Checked Then
            If My.Settings.Difficulty <> RadioButton7.Text Then changed = True
            My.Settings.Difficulty = RadioButton7.Text
        End If

        If RadioButton8.Checked Then
            If My.Settings.Difficulty <> RadioButton8.Text Then changed = True
            My.Settings.Difficulty = RadioButton8.Text
        End If

        Dim a As String = "F", b As String = "F"

        If CheckBox2.Checked Then a = "T"
        If CheckBox3.Checked Then b = "T"

        My.Settings.AdvancedBool = a & "|" & b
        My.Settings.Save()
        My.Settings.Reload()

        If changed And Button2.Enabled Then Button2.PerformClick()
        FormMain.Enabled = True
        FormMain.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
        FormMain.TextBox5.SelectAll()
        FormMain.TextBox5.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim changed As Boolean = False
        If RadioButton1.Checked Then My.Settings.Difficulty = RadioButton1.Text
        If RadioButton2.Checked Then My.Settings.Difficulty = RadioButton2.Text
        If RadioButton3.Checked Then My.Settings.Difficulty = RadioButton3.Text
        If RadioButton4.Checked Then My.Settings.Difficulty = RadioButton4.Text
        If RadioButton5.Checked Then My.Settings.Difficulty = RadioButton5.Text
        If RadioButton6.Checked Then My.Settings.Difficulty = RadioButton6.Text
        If RadioButton7.Checked Then My.Settings.Difficulty = RadioButton7.Text
        If RadioButton8.Checked Then My.Settings.Difficulty = RadioButton8.Text

        Dim a As String = "F", b As String = "F"
        If CheckBox2.Checked Then a = "T"
        If CheckBox3.Checked Then b = "T"

        My.Settings.AdvancedBool = a & "|" & b
        My.Settings.Save()
        My.Settings.Reload()

        FormMain.CreateNumbers()
    End Sub
End Class