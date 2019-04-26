Public Class FormGameM1

    Public paused As Boolean = False
    Public stoneCount As Integer = 1
    Private Sub FormGameM1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = If(My.Settings.WindowMode <> 1, FormBorderStyle.FixedSingle, FormBorderStyle.None)
        Me.Size = IIf(My.Settings.WindowMode <> 3, My.Computer.Screen.Bounds.Size, My.Settings.WindowCustom)
        If My.Settings.WindowMode <> 3 Then Me.Location = New Point(0, 0)
        FormSettings.Show()
    End Sub

    Private Sub FormGameM1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim c As Boolean = e.Control, s As Boolean = e.Shift, a As Boolean = e.Alt, k As String = e.KeyCode.ToString
        Dim h1 As String = My.Settings.HotStop, h2 As String = My.Settings.HotPause, h3 As String = My.Settings.HotChange
        If (k = "Escape" And My.Settings.EscStopsAsWell) Or (k = h1.Last And c = h1.Contains("Ctrl") And s = h1.Contains("Shift") And a = h1.Contains("Alt")) Then
            If My.Settings.ShowLauncherOnExit Then
                Close()
                Form1.Show()
            Else
                Form1.Close()
            End If
        ElseIf k = h2.Last And c = h2.Contains("Ctrl") And s = h2.Contains("Shift") And a = h2.Contains("Alt") Then
            paused = True
        ElseIf k = h3.Last And c = h3.Contains("Ctrl") And s = h3.Contains("Shift") And a = h3.Contains("Alt") Then
            FormSettings.Show()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Select Case My.Settings.GameSpeed
            Case 0
                Timer1.Interval = 1200
            Case 1
                Timer1.Interval = 850
            Case 2
                Timer1.Interval = 500
            Case 3
                Timer1.Interval = 200
            Case 4
                Timer1.Interval = 150
            Case 5
                Timer1.Interval = 100
            Case 6
                Timer1.Interval = 50
        End Select
        If paused Then Exit Sub
        Dim myStone As New Stone(stoneCount, RandomColor())
        myStone.Fall()
    End Sub

    Public Function RandomColor() As Color
        Randomize()
        Dim r As Random = New Random()
        Select Case r.Next(1, My.Settings.DiffColors + 1)
            Case 1
                Return Color.Red
            Case 2
                Return Color.White
            Case 3
                Return Color.Blue
            Case 4
                Return Color.Yellow
            Case 5
                Return Color.Cyan
            Case 6
                Return Color.Purple
            Case 7
                Return Color.Pink
            Case 8
                Return Color.Orange
            Case 9
                Return Color.Green
            Case 10
                Return Color.Brown
        End Select
    End Function

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If paused Then Exit Sub
        For Each st In Me.Controls
            If TypeOf st Is Button Then
                If st.Tag = "st" Then
                    st.top += 1
                End If
            End If
        Next
        stoneCount += 1
    End Sub
End Class