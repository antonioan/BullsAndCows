Public Class Form1

    Private _img As Integer
    Public Property img As Integer
        Set(value As Integer)
            If value = imgs.Length Then value = 0
            _img = value
        End Set
        Get
            Return _img
        End Get
    End Property
    Private imgs() As Bitmap = {My.Resources.down_f1, My.Resources.down_f2, My.Resources.down_f3, My.Resources.down_f2}

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Timer1.Enabled = Not Timer1.Enabled
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        img += 1
        With PictureBox1
            .Image = imgs(img)
            .Refresh()
            Dim istep = img
            If img = 4 Then istep = 2
            .Left += istep * 15
            .Top += istep * 2
            If .Left >= .Parent.Width + .Width * 3 Then
                .Left = -.Width * 3
                .Top += 100
            End If

            If .Top >= .Parent.Height + .Height * 3 Then .Top = -.Height * 3
        End With
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Left = -PictureBox1.Width * 3
        Timer1.Start()
    End Sub
End Class
