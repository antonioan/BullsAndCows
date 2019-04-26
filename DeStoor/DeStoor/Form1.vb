Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim a As Integer = TextBox1.Text, b As Integer = TextBox2.Text, c As Integer = TextBox3.Text
        'Dim d() = {(0 - b + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / 2 * a, (0 - b - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / 2 * a}
        'MsgBox(d(0) & "|" & d(1))

        With RichTextBox1
            .Clear()
            .AppendText("            -b +/- Sqrt[b^2 - 4 * a * c]" & vbCrLf)
            .AppendText("X1,2 = --------------------------------------------------" & vbCrLf)
            .AppendText("                            2 * a" & vbCrLf)
            .AppendText(vbCrLf)

            .AppendText("            -(" & b & ") +/- Sqrt[(" & b & ")^2 - 4 * (" & a & ") * (" & c & ")]" & vbCrLf)
            .AppendText("X1,2 = --------------------------------------------------" & vbCrLf)
            .AppendText("                            2 * (" & a & ")" & vbCrLf)
            .AppendText(vbCrLf)

            .AppendText("            " & -b & " +/- " & "Sqrt[" & Math.Pow(b, 2) & " - " & 4 * a * c & "]" & vbCrLf)
            .AppendText("X1,2 = --------------------------------------------------" & vbCrLf)
            .AppendText("                            " & 2 * a & vbCrLf)
            .AppendText(vbCrLf)

            .AppendText("            " & -b & " +/- " & "Sqrt[" & ((Math.Pow(b, 2)) - (4 * a * c)) & "]" & vbCrLf)
            .AppendText("X1,2 = --------------------------------------------------" & vbCrLf)
            .AppendText("                            " & 2 * a & vbCrLf)
            .AppendText(vbCrLf)

            .AppendText("            " & -b & " +/- " & Math.Sqrt(((Math.Pow(b, 2)) - (4 * a * c))) & vbCrLf)
            .AppendText("X1,2 = --------------------------------------------------" & vbCrLf)
            .AppendText("                            " & 2 * a & vbCrLf)
            .AppendText(vbCrLf)

            .AppendText("          " & (-b + Math.Sqrt(((Math.Pow(b, 2)) - (4 * a * c)))) & vbCrLf)
            .AppendText("X1 = --------------------------------------------------" & vbCrLf)
            .AppendText("                         " & 2 * a & vbCrLf)
            .AppendText(vbCrLf)

            .AppendText("          " & (-b - Math.Sqrt(((Math.Pow(b, 2)) - (4 * a * c)))) & vbCrLf)
            .AppendText("X2 = --------------------------------------------------" & vbCrLf)
            .AppendText("                         " & 2 * a & vbCrLf)
            .AppendText(vbCrLf)

            .AppendText("X1 = " & (-b + Math.Sqrt(((Math.Pow(b, 2)) - (4 * a * c)))) / 2 * a & vbCrLf)
            .AppendText(vbCrLf)

            .AppendText("X2 = " & (-b - Math.Sqrt(((Math.Pow(b, 2)) - (4 * a * c)))) / 2 * a & vbCrLf)
            .AppendText(vbCrLf)
        End With
    End Sub
End Class
