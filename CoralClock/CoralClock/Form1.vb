Public Class Form1
    Dim myP As Point = New Point
    Dim Hour24 As Boolean = False
    Const SmallSize = 180, LargeSize = 204

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub Main_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseMove
        If e.Button = MouseButtons.Left Then Me.Location = Control.MousePosition - myP
    End Sub

    Private Sub Main_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown, Label1.MouseDown
        myP = Control.MousePosition - Me.Location
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Public Function FormatTimeString(ByVal TimeAsDate As Date, Optional ByVal To24Hour As Boolean = False) As String
        Dim a As String = "", d As Date = TimeAsDate, to24 As Boolean = False
        If Not To24Hour Then
            a = " AM"
            If d.Hour > 12 Or d.Hour = 0 Then
                to24 = True
                a = " PM"
            End If
        End If
        Dim h As Integer = If(to24, Math.Abs(d.Hour - 12), d.Hour)
        Return If(h.ToString.Length = 1, "0", "") & h & ":" & If(d.Minute.ToString.Length = 1, "0", "") & d.Minute & ":" & If(d.Second.ToString.Length = 1, "0", "") & d.Second & a
    End Function

    Private Sub Label1_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then Hour24 = Not Hour24
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = FormatTimeString(TimeOfDay, Hour24)
        If Not Me.DisplayRectangle.Contains(MousePosition - Me.Location) And Me.Width <> SmallSize Then
            If Not BackgroundWorker2.IsBusy Then BackgroundWorker2.RunWorkerAsync()
        End If
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        MainForm.Show()
    End Sub

    Private Sub Label1_MouseEnter(sender As System.Object, e As System.EventArgs) Handles Label1.MouseEnter
        If Me.Width = LargeSize Then Exit Sub
        If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        For i As Integer = SmallSize + 1 To LargeSize
            Threading.Thread.Sleep(10)
            Me.Width = i
        Next
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        For i As Integer = LargeSize - 1 To SmallSize Step -1
            Threading.Thread.Sleep(10)
            Me.Width = i
        Next
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        FrmStopper.Show()
        FrmStopper.Location = Location
        FrmStopper.Size = Size
        Hide()
    End Sub

    Private Sub SetAlarmToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SetAlarmToolStripMenuItem.Click
        FrmAlarm.Show()
        FrmAlarm.Location = Me.Location + New Point((SmallSize - FrmAlarm.Width) / 2, Me.Height)
        FrmAlarm.Size = New Point(124, 33)
    End Sub
End Class