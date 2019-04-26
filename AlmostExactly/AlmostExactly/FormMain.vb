Public Class FormMain

    Public masterNums() As Integer, totaltries As Integer = 0, totalalmosts As Integer = 0, totalexactlies As Integer = 0
    Public FAILSOLVING_TriesEnd As Integer = 0, GaveUp As Boolean = False, HelpEnabled As Boolean = False, SolvingWin As Boolean = False, SolvingLose As Integer = 0

    '>>>>For Testing Only! After Testing, Return to False!<<<<'
    Public TestMePl0x As Boolean = False

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Stats.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Insert()
        If Button2.ForeColor = Color.Red Then Button2.ForeColor = Color.Black
        If Button2.Text = "Solve It! (Activated)" Then Button2.Text = "Solve It!"
        If Button1.Text = "I GUESSED THEM!" Then Button1.Text = "Insert Numbers!"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Button2.ForeColor = Color.Red Then Button2.ForeColor = Color.Black Else Button2.ForeColor = Color.Red
        If Button2.Text = "Solve It! (Activated)" Then Button2.Text = "Solve It!" Else Button2.Text = "Solve It! (Activated)"
        If Button1.Text = "I GUESSED THEM!" Then Button1.Text = "Insert Numbers!" Else Button1.Text = "I GUESSED THEM!"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        GiveUpConfirm.Show()
    End Sub

    Public Sub GiveUp()
        TextBox1.Text = masterNums(1)
        TextBox2.Text = masterNums(2)
        TextBox3.Text = masterNums(3)
        TextBox4.Text = masterNums(4)
        GaveUp = True
        Label13.Text *= 0.7
        Over_GAVEUP.Show()
        My.Settings.todaygiveups += 1
        My.Settings.alltimegiveups += 1
        My.Settings.todayrounds += 1
        My.Settings.alltimerounds += 1
        My.Settings.Save()
        My.Settings.Reload()
        Me.Enabled = False
    End Sub

    Public Sub Insert()
        totaltries += 1
        My.Settings.todaytries += 1
        My.Settings.alltimetries += 1
        My.Settings.Save()
        My.Settings.Reload()
        Dim x1 As Integer = masterNums(1), x2 As Integer = masterNums(2), x3 As Integer = masterNums(3), x4 As Integer = masterNums(4)
        Dim n1 As Integer = TextBox5.Text, n2 As Integer = TextBox6.Text, n3 As Integer = TextBox7.Text, n4 As Integer = TextBox8.Text
        Dim tempalmost As Integer = 0, tempexactly As Integer = 0
        Dim Solving As Boolean = (Button2.ForeColor = Color.Red)
        Dim n1_help As String = "---------------", n2_help As String = "---------------", _
            n3_help As String = "---------------", n4_help As String = "---------------"
        If n1 = x1 Then
            tempexactly += 1
            x1 = -1
            n1_help = "Exactly"
        ElseIf n1 = x2 Or n1 = x3 Or n1 = x4 Then
            tempalmost += 1
            n1_help = "Almost"
        End If

        If n1_help = "---------------" Then
            If n1 > x1 Then n1_help = "Smaller" Else n1_help = "Larger"
        End If
        n1 = -1

        If n2 = x2 Then
            tempexactly += 1
            x2 = -1
            n2_help = "Exactly"
        ElseIf n2 = x1 Or n2 = x3 Or n2 = x4 Then
            tempalmost += 1
            n2_help = "Almost"
        End If

        If n2_help = "---------------" Then
            If n2 > x2 Then n2_help = "Smaller" Else n2_help = "Larger"
        End If
        n2 = -1

        If n3 = x3 Then
            tempexactly += 1
            x3 = -1
            n3_help = "Exactly"
        ElseIf n3 = x1 Or n3 = x2 Or n3 = x4 Then
            tempalmost += 1
            n3_help = "Almost"
        End If

        If n3_help = "---------------" Then
            If n3 > x3 Then n3_help = "Smaller" Else n3_help = "Larger"
        End If
        n3 = -1

        If n4 = x4 Then
            tempexactly += 1
            x4 = -1
            n4_help = "Exactly"
        ElseIf n4 = x1 Or n4 = x2 Or n4 = x3 Then
            tempalmost += 1
            n4_help = "Almost"
        End If

        If n4_help = "---------------" Then
            If n4 > x4 Then n4_help = "Smaller" Else n4_help = "Larger"
        End If
        n4 = -1

        Label11.Text = tempalmost
        Label12.Text = tempexactly
        totalexactlies += tempexactly
        totalalmosts += tempalmost

        If HelpEnabled = True Then
            Label1.Text = n1_help
            Label2.Text = n2_help
            Label3.Text = n3_help
            Label4.Text = n4_help
        Else
            Label1.Text = "---------------"
            Label2.Text = "---------------"
            Label3.Text = "---------------"
            Label4.Text = "---------------"
        End If

        If Solving = True Then
            If tempexactly = 4 Then
                SolvingWin = True
                TextBox1.Text = masterNums(1)
                TextBox2.Text = masterNums(2)
                TextBox3.Text = masterNums(3)
                TextBox4.Text = masterNums(4)
                SOLVED(True)
            Else
                SolvingLose += 1
                FAILSOLVING()
            End If
        Else
            If tempexactly = 4 Then
                TextBox1.Text = masterNums(1)
                TextBox2.Text = masterNums(2)
                TextBox3.Text = masterNums(3)
                TextBox4.Text = masterNums(4)
                SOLVED(False)
            End If
        End If
    End Sub

    Sub FAILSOLVING()
        Label13.Text *= 0.8
        Button2.Enabled = False
        Button2.Text = "WRONG SOLUTION! Wait 5 Tries"
        FAILSOLVING_TriesEnd = totaltries + 5
    End Sub

    Sub SOLVED(ByVal WithSolveIt As Boolean)
        If WithSolveIt = True Then
            'Score * Difficulty's_Max_Number * (50 / totaltries)
            SolvWinAdd(Label13.Text)
            Over_WINNER.Text = "YES"
        Else
            Over_WINNER.Text = "NO"
        End If

        If HelpEnabled = True And diff() <> 1 And diff() <> 8 Then Label13.Text *= 0.5
        Over_WINNER.Show()
        My.Settings.todaywins += 1
        My.Settings.alltimewins += 1
        My.Settings.todayrounds += 1
        My.Settings.alltimerounds += 1
        My.Settings.Save()
        My.Settings.Reload()
        Me.Enabled = False
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.BackgroundImage = My.Resources.Theme1
        For Each Label In Me.Controls
            If Label.Tag = "lbl" Then Label.BackColor = Color.FromArgb(224, 255, 165)
        Next
        Label14.Text = fc(1)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.BackgroundImage = My.Resources.Theme2
        For Each Label In Me.Controls
            If Label.Tag = "lbl" Then Label.BackColor = Color.FromArgb(32, 37, 23)
        Next
        Label14.Text = fc(2)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.BackgroundImage = My.Resources.Theme3
        For Each Label In Me.Controls
            If Label.Tag = "lbl" Then Label.BackColor = Color.FromArgb(224, 255, 165)
        Next
        Label14.Text = fc(3)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.BackgroundImage = My.Resources.Theme4
        For Each Label In Me.Controls
            If Label.Tag = "lbl" Then Label.BackColor = Color.FromArgb(224, 255, 165)
        Next
        Label14.Text = fc(4)
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.BackgroundImage = My.Resources.Theme5
        For Each Label In Me.Controls
            If Label.Tag = "lbl" Then Label.BackColor = Color.FromArgb(88, 101, 65)
        Next
        Label14.Text = fc(5)
    End Sub

    Function fc(ByVal i)
        Return "Selected Theme: Theme" & i
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If TextBox1.Focused Then
            TextBox5.Focus()
            TextBox5.SelectAll()
        End If
        If TextBox2.Focused Then
            TextBox6.Focus()
            TextBox6.SelectAll()
        End If

        If TextBox3.Focused Then
            TextBox7.Focus()
            TextBox7.SelectAll()
        End If

        If TextBox4.Focused Then
            TextBox8.Focus()
            TextBox8.SelectAll()
        End If

        With Button3
            Select Case totaltries
                Case 0
                    .Enabled = False
                    .Text = "5 Tries Left"
                Case 1
                    .Enabled = False
                    .Text = "4 Tries Left"
                Case 2
                    .Enabled = False
                    .Text = "3 Tries Left"
                Case 3
                    .Enabled = False
                    .Text = "2 Tries Left"
                Case 4
                    .Enabled = False
                    .Text = "1 Try Left"
                Case Is >= 5
                    .Enabled = True
                    .Text = "Give Up!"
            End Select
        End With

        If Button2.Text.Contains("WRONG") = False Then GoTo Skip_FAILSOLVING_TriesLeft
        With Button2
            Select Case FAILSOLVING_TriesEnd
                Case totaltries + 5
                    .Enabled = False
                    .Text = "WRONG SOLUTION! Wait 5 Tries"
                Case totaltries + 4
                    .Enabled = False
                    .Text = "WRONG SOLUTION! Wait 4 Tries"
                Case totaltries + 3
                    .Enabled = False
                    .Text = "WRONG SOLUTION! Wait 3 Tries"
                Case totaltries + 2
                    .Enabled = False
                    .Text = "WRONG SOLUTION! Wait 2 Tries"
                Case totaltries + 1
                    .Enabled = False
                    .Text = "WRONG SOLUTION! Wait 1 Try"
                Case totaltries
                    .Enabled = True
                    .Text = "Solve It!"
            End Select
        End With
Skip_FAILSOLVING_TriesLeft:

        Select Case diff()
            Case 1
                TextBox5.MaxLength = 1
                TextBox6.MaxLength = 1
                TextBox7.MaxLength = 1
                TextBox8.MaxLength = 1
            Case 2, 3, 4, 5
                TextBox5.MaxLength = 2
                TextBox6.MaxLength = 2
                TextBox7.MaxLength = 2
                TextBox8.MaxLength = 2
            Case 6
                TextBox5.MaxLength = 3
                TextBox6.MaxLength = 3
                TextBox7.MaxLength = 3
                TextBox8.MaxLength = 3
            Case 7
                TextBox5.MaxLength = 4
                TextBox6.MaxLength = 4
                TextBox7.MaxLength = 4
                TextBox8.MaxLength = 4
            Case 8
                TextBox5.MaxLength = 6
                TextBox6.MaxLength = 6
                TextBox7.MaxLength = 6
                TextBox8.MaxLength = 6
        End Select

        If TextBox8.Text = "" Then func(TextBox8)
        If TextBox7.Text = "" Then func(TextBox7)
        If TextBox6.Text = "" Then func(TextBox6)
        If TextBox5.Text = "" Then func(TextBox5)

        Try
            Dim x As Integer = CInt(TextBox8.Text)
        Catch
            func(TextBox8)
        End Try
        Try
            Dim x As Integer = CInt(TextBox7.Text)
        Catch
            func(TextBox7)
        End Try
        Try
            Dim x As Integer = CInt(TextBox6.Text)
        Catch
            func(TextBox6)
        End Try
        Try
            Dim x As Integer = CInt(TextBox5.Text)
        Catch
            func(TextBox5)
        End Try

        Dim i As Integer = 0
        If My.Settings.AdvancedBool.Split("|").First = "F" Then i = 1
        If TextBox5.Text <> "" And TextBox6.Text <> "" And TextBox7.Text <> "" And TextBox8.Text <> "" And _
            (TextBox5.Text <= diff(True) And TextBox5.Text >= i) And (TextBox6.Text <= diff(True) And TextBox6.Text >= i) And _
            (TextBox7.Text <= diff(True) And TextBox7.Text >= i) And (TextBox8.Text <= diff(True) And TextBox8.Text >= i) Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If

        Label7.Text = totaltries

        If totaltries = 0 Then
            Label13.Text = 0
        Else
            Dim sum As Int64
            sum = CInt((totalalmosts * 5 + totalexactlies * 10) / totaltries * diff(True))
            If SolvingLose <> 0 Then
                For count As Integer = 1 To SolvingLose
                    sum *= 0.8
                Next
            End If
            If GaveUp Then sum *= 0.3

            If SolvingWin Then SolvWinAdd(sum)
            Label13.Text = sum
        End If
    End Sub

    Sub SolvWinAdd(ByRef sum As Int64)
        Dim var As Int64 = sum
        Const halfmax As Integer = 1073000000
        Dim r As Random = New Random()
        Dim temp = r.Next(2000000000, Integer.MaxValue) '2147483647
        Select Case diff()
            Case 1 'Beginner
                Select Case var
                    Case Is < 500
                        var *= 4
                    Case 500 To 1000
                        var *= 3.5
                    Case 1000 To 10000
                        var *= 3
                    Case 10000 To 50000
                        var *= 2.5
                    Case 50000 To halfmax
                        var *= 2
                    Case Is > halfmax
                        var = temp
                End Select
            Case 2 'Amateur (Default)
                Select Case var
                    Case Is < 1000
                        var *= 4
                    Case 1000 To 10000
                        var *= 3.5
                    Case 10000 To 50000
                        var *= 3
                    Case 50000 To 100000
                        var *= 2.5
                    Case 100000 To halfmax
                        var *= 2
                    Case Is > halfmax
                        var = temp
                End Select
            Case 3 'Intermediate
                Select Case var
                    Case Is < 1500
                        var *= 4
                    Case 1500 To 15000
                        var *= 3.5
                    Case 15000 To 75000
                        var *= 3
                    Case 75000 To 150000
                        var *= 2.5
                    Case 150000 To halfmax
                        var *= 2
                    Case Is > halfmax
                        var = temp
                End Select
            Case 4 'Expert
                Select Case var
                    Case Is < 2000
                        var *= 4
                    Case 2000 To 20000
                        var *= 3.5
                    Case 20000 To 200000
                        var *= 3
                    Case 200000 To 500000
                        var *= 2.5
                    Case 500000 To halfmax
                        var *= 2
                    Case Is > halfmax
                        var = temp
                End Select
            Case 5 'Professional
                Select Case var
                    Case Is < 5000
                        var *= 4
                    Case 5000 To 50000
                        var *= 3.5
                    Case 50000 To 250000
                        var *= 3
                    Case 250000 To 750000
                        var *= 2.5
                    Case 750000 To halfmax
                        var *= 2
                    Case Is > halfmax
                        var = temp
                End Select
            Case 6 'H3LL
                Select Case var
                    Case Is < 20000
                        var *= 4
                    Case 20000 To 200000
                        var *= 3.5
                    Case 200000 To 1000000
                        var *= 3
                    Case 1000000 To 2500000
                        var *= 2.5
                    Case 2500000 To halfmax
                        var *= 2
                    Case Is > halfmax
                        var = temp
                End Select
            Case 7 'SUP3RN0VA
                Select Case var
                    Case Is < 100000
                        var *= 4
                    Case 100000 To 500000
                        var *= 3.5
                    Case 500000 To 1500000
                        var *= 3
                    Case 1500000 To 5000000
                        var *= 2.5
                    Case 5000000 To halfmax
                        var *= 2
                    Case Is > halfmax
                        var = temp
                End Select
            Case 8 'Mario
                Select Case var
                    Case Is < 1000000
                        var *= 4
                    Case 1000000 To 10000000
                        var *= 3.5
                    Case 10000000 To 100000000
                        var *= 3
                    Case 100000000 To 1000000000
                        var *= 2.5
                    Case 1000000000 To halfmax
                        var *= 2
                    Case Is > halfmax
                        var = temp
                End Select
        End Select
    End Sub

    Sub func(ByRef txt As TextBox)
        txt.Text = "0"
        txt.SelectAll()
    End Sub

    Sub AcHelp(Optional ByVal ToDisable As Boolean = False)
        If ToDisable = False Then
            HelpEnabled = True
            Button10.Enabled = False
            Button10.ForeColor = Color.Red
            Button10.Text = "Help Enabled"
            Button10.Font = New System.Drawing.Font(Button10.Font.FontFamily, Button10.Font.Size, FontStyle.Italic)
        Else
            HelpEnabled = False
            Button10.Enabled = True
            Button10.ForeColor = Color.Black
            Button10.Text = "Enable Help"
            Button10.Font = New System.Drawing.Font(Button10.Font.FontFamily, Button10.Font.Size, FontStyle.Bold)
        End If
    End Sub

    Public Function diff(Optional ByVal MaxNumber As Boolean = False) As Integer
        If MaxNumber = False Then
            Select Case My.Settings.Difficulty
                Case "Beginner"
                    Return 1
                Case "Amateur (Default)"
                    Return 2
                Case "Intermediate"
                    Return 3
                Case "Expert"
                    Return 4
                Case "Professional"
                    Return 5
                Case "H3LL"
                    Return 6
                Case "SUP3RN0VA"
                    Return 7
                Case "Mario"
                    Return 8
                Case Else
                    Return 0
            End Select
        Else
            Select Case My.Settings.Difficulty
                Case "Beginner"
                    Return 5
                Case "Amateur (Default)"
                    Return 10
                Case "Intermediate"
                    Return 20
                Case "Expert"
                    Return 30
                Case "Professional"
                    Return 50
                Case "H3LL"
                    Return 100
                Case "SUP3RN0VA"
                    Return 1000
                Case "Mario"
                    Return 999999
                Case Else
                    Return 0
            End Select
        End If
    End Function

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        mySettings.Show()
    End Sub

    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateNumbers()
    End Sub

    Sub CreateNumbers()
        Dim a1, a2, a3, a4 As Integer
        Dim i As Integer = 1
        If My.Settings.AdvancedBool.Split("|").First = "T" Then i = 0
        Dim snum As Boolean = True, samenum As String = My.Settings.AdvancedBool.Split("|").Last
        If samenum = "T" Then snum = False
        Select Case My.Settings.Difficulty
            Case "Beginner"
                Dim iAr() = Rand(i, 5, snum)
                a1 = iAr(1)
                a2 = iAr(2)
                a3 = iAr(3)
                a4 = iAr(4)
            Case "Amateur (Default)"
                Dim iAr() = Rand(i, 10, snum)
                a1 = iAr(1)
                a2 = iAr(2)
                a3 = iAr(3)
                a4 = iAr(4)
            Case "Intermediate"
                Dim iAr() = Rand(i, 20, snum)
                a1 = iAr(1)
                a2 = iAr(2)
                a3 = iAr(3)
                a4 = iAr(4)
            Case "Expert"
                Dim iAr() = Rand(i, 30, snum)
                a1 = iAr(1)
                a2 = iAr(2)
                a3 = iAr(3)
                a4 = iAr(4)
            Case "Professional"
                Dim iAr() = Rand(i, 50, snum)
                a1 = iAr(1)
                a2 = iAr(2)
                a3 = iAr(3)
                a4 = iAr(4)
            Case "H3LL"
                Dim iAr() = Rand(i, 100, snum)
                a1 = iAr(1)
                a2 = iAr(2)
                a3 = iAr(3)
                a4 = iAr(4)
            Case "SUP3RN0VA"
                Dim iAr() = Rand(i, 1000, snum)
                a1 = iAr(1)
                a2 = iAr(2)
                a3 = iAr(3)
                a4 = iAr(4)
            Case "Mario"
                Dim iAr() = Rand(i, 999999, snum)
                a1 = iAr(1)
                a2 = iAr(2)
                a3 = iAr(3)
                a4 = iAr(4)

                ''For Fun: How many tries does it need for 'a1' to equal 0?
                'Dim count As Integer = 1
                'Dim n1 As Random = New Random()
                'While (a1 <> 0)
                '    a1 = n1.Next(i, 999999)
                '    count += 1
                'End While
                'MsgBox(count)
        End Select
        masterNums = {0, a1, a2, a3, a4}
        TextBox1.Text = "X"
        TextBox2.Text = "X"
        TextBox3.Text = "X"
        TextBox4.Text = "X"
        TextBox5.Text = "0"
        TextBox6.Text = "0"
        TextBox7.Text = "0"
        TextBox8.Text = "0"
        Label11.Text = 0
        Label12.Text = 0
        Label7.Text = 0
        TextBox5.SelectAll()

        totaltries = 0
        totalalmosts = 0
        totalexactlies = 0
        GaveUp = False
        SolvingWin = False
        SolvingLose = 0
        AcHelp(True)
        Label1.Text = "---------------"
        Label2.Text = "---------------"
        Label3.Text = "---------------"
        Label4.Text = "---------------"

        If TestMePl0x = True Then
            TextBox1.Text = a1
            TextBox2.Text = a2
            TextBox3.Text = a3
            TextBox4.Text = a4
        End If
    End Sub

    Function Rand(ByVal range1 As Integer, ByVal range2 As Integer, ByVal SameNumAllowed As String) As Integer()
        Dim r As Random = New Random()
        Dim n1 As Integer, n2 As Integer, n3 As Integer, n4 As Integer
        n1 = r.Next(range1, range2)
        If SameNumAllowed = False Then
            Dim i As Integer = 0
            While i < 3
                If i = 0 Then
                    n2 = r.Next(range1, range2)
                    While n1 = n2
                        n2 = r.Next(range1, range2)
                    End While
                End If

                If i = 1 Then
                    n3 = r.Next(range1, range2)
                    While n1 = n3 Or n2 = n3
                        n3 = r.Next(range1, range2)
                    End While
                End If

                If i = 2 Then
                    n4 = r.Next(range1, range2)
                    While n1 = n4 Or n2 = n4 Or n3 = n4
                        n4 = r.Next(range1, range2)
                    End While
                End If
                i += 1
            End While
        Else
            n2 = r.Next(range1, range2)
            n3 = r.Next(range1, range2)
            n4 = r.Next(range1, range2)
        End If
        Dim n() As Integer = {0, n1, n2, n3, n4}
        Return n
    End Function

    Private Sub TextBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.Click
        TextBox5.Focus()
        TextBox5.SelectAll()
    End Sub

    Private Sub TextBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.Click
        TextBox6.Focus()
        TextBox6.SelectAll()
    End Sub

    Private Sub TextBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.Click
        TextBox7.Focus()
        TextBox7.SelectAll()
    End Sub

    Private Sub TextBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.Click
        TextBox8.Focus()
        TextBox8.SelectAll()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        HelpConfirm.Show()
    End Sub
End Class