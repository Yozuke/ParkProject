Imports MySql.Data.MySqlClient

Module ConnectionDB

    Dim mysqlconn As MySqlConnection
    Sub Connect()
        Try
            mysqlconn = New MySqlConnection
            mysqlconn.ConnectionString = "Database=parking;Data Source=192.168.8.149;User Id=root;Password=apache123!"
            mysqlconn.Open()
            mysqlconn.Close()
            mysqlconn.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            My.Computer.Clipboard.SetText(ex.Message)
        End Try
    End Sub

End Module
