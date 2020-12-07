Public Class Form1

    Private smtpServer As String
    Private sender As String
    Private receiver As String
    Private obj As String
    Private content As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles SendButton.Click
        Console.WriteLine("Sendig mail to {0} from {1} at {2}", receiver, sender, smtpServer)
        Dim mailClient = New System.Net.Mail.SmtpClient(Me.smtpServer)
        'mailClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network
        'mailClient.EnableSsl = True
        'mailClient.Port = 993
        mailClient.Timeout = 5000 ' 15 secondi timeout
        Try
            StatusBox.Text = "Sending email...."
            Me.Refresh()
            mailClient.Send(Me.sender, Me.receiver, Me.obj, Me.content)
            StatusBox.Text = "Email successfully sent!"
        Catch ex As Exception
            StatusBox.Text = "Sending Timed Out!"
        End Try
        mailClient.Dispose()
        Me.Refresh()
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        Dim mailText = DirectCast(sender, RichTextBox)
        Dim content As String = mailText.Text
        Me.content = content
    End Sub

    Private Sub Mittente_TextChanged(sender As Object, e As EventArgs) Handles Mittente.TextChanged
        Dim senderBox = DirectCast(sender, TextBox)
        Me.sender = senderBox.Text
    End Sub

    Private Sub Destinatari_TextChanged(sender As Object, e As EventArgs) Handles Destinatari.TextChanged
        Dim receiversBox = DirectCast(sender, TextBox)
        Me.receiver = receiversBox.Text
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim serverBox = DirectCast(sender, TextBox)
        Me.smtpServer = serverBox.Text
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)

    End Sub

    Private Sub Oggetto_TextChanged(sender As Object, e As EventArgs) Handles Oggetto.TextChanged
        Dim objectBox = DirectCast(sender, TextBox)
        Me.obj = objectBox.Text
    End Sub
End Class
