Public Class FrmTimer
    Dim myP As Point = New Point
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

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
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
        FrmStopper.Show()
        FrmStopper.Location = Location
        FrmStopper.Size = Size
        Hide()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Form1.Show()
        Form1.Location = Location
        Form1.Size = Size
        Hide()
    End Sub

    Private Sub Label1_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDoubleClick
        Dim g As Long = InputBox("")
        FrmStopper.FormatTime(g)
        Label1.Text = FrmStopper.Label1.Text
    End Sub
End Class