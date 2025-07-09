Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim idno As String = textID.Text
        Dim FR As New HISHpaBhp.Form1(idno)
        Dim result As DialogResult = FR.ShowDialog()
        If result = DialogResult.OK Then
            Dim returnedData As String = FR.SelectedData
            ' 驗證成功
            MessageBox.Show("驗證成功")
            textMsg.Text = returnedData
        ElseIf result = DialogResult.Cancel Then
            ' 驗證失敗
            'MessageBox.Show("驗證失敗")
        End If
    End Sub
End Class
