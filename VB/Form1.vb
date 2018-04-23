Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Button1.Click
        Dim report As New XtraReport1()
        report.ShowDesignerDialog()
    End Sub

End Class
