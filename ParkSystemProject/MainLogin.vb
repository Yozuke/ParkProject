Public Class FormLogin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String
        Dim password As String
        username = TextBox1.Text
        password = TextBox2.Text
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
        Dim conn As New MySql.Data.MySqlClient.MySqlConnection
        conn.ConnectionString = "Database=parking;Data Source=192.168.8.149;User Id=root;Password=apache123!"
        conn.Open()
        cmd.Connection = conn
        cmd.CommandText = "SELECT * from mstaff where username = '" & username & "' and password = '" & password & "'"
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader
        reader = cmd.ExecuteReader()
        If reader.HasRows Then
            conn.Close()
            conn.Open()
            Dim loginstart As String
            loginstart = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            Dim loginupd As New MySql.Data.MySqlClient.MySqlCommand
            loginupd.Connection = conn
            loginupd.CommandText = "UPDATE mstaff set lastlogin = '" & loginstart & "' where username = '" & username & "' and password = '" & password & "'"
            loginupd.ExecuteNonQuery()
            conn.Close()
            Me.Hide()
            MainMenu.Show()
        Else
            My.Computer.Clipboard.SetText("Wrong Username / Password")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()

    End Sub
End Class
