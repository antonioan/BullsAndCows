Public Class Stone

    Const stoneSize As Integer = 20
    Private stoneNumber As Long, stoneColor As Color

    Public ReadOnly Property Number() As Integer
        Get
            Return stoneNumber
        End Get
    End Property

    Public ReadOnly Property Color() As Color
        Get
            Return stoneColor
        End Get
        'Set(ByVal NEWstoneColor As Color)
        '    stoneColor = NEWstoneColor
        'End Set
    End Property

    Public Sub Fall()
        Randomize()
        Dim newButton As New Button
        With newButton
            .Name = "st_" & stoneNumber
            .BackColor = stoneColor
            .Text = ""
            .Size = New Point(stoneSize, stoneSize)
            .Location = New Point(New Random().Next(0, FormGameM1.Width - stoneSize), -10)
            .Tag = "st"
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .FlatAppearance.CheckedBackColor = stoneColor
            .FlatAppearance.MouseDownBackColor = stoneColor
            .FlatAppearance.MouseOverBackColor = stoneColor
        End With
        FormGameM1.Controls.Add(newButton)
    End Sub

    'Private Function RandomLocation() As Point
    '    Dim ra As Integer = New Random().Next(0, FormGameM1.Width - stoneSize)
    '    Return New Point(-10, ra)
    'End Function

    Public Sub New(ByVal NEWstoneNumber As Integer, ByVal NEWstoneColor As Color)
        stoneNumber = NEWstoneNumber
        stoneColor = NEWstoneColor
    End Sub
End Class
