Imports System.Data
Imports MySql.Data.MySqlClient

Public Class MainMenu
    Public dtServerDateTime As DateTime
    Private Shared tmrLocalTimer As New System.Windows.Forms.Timer()
    Dim IsFirstTime As Boolean = True
    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click

    End Sub

    Private Sub AddUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddUserToolStripMenuItem.Click

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If IsFirstTime = True Then
            Dim cmd As MySqlCommand
            Dim tmpConnection As MySqlConnection
            Dim strConnectionString As String
            Try
                strConnectionString = "Database=parking;Data Source=192.168.8.149;User Id=root;Password=apache123!"
                tmpConnection = New MySqlConnection(strConnectionString)
                tmpConnection.Open()
                cmd = New MySqlCommand("Select Now()", tmpConnection)
                dtServerDateTime = cmd.ExecuteScalar
                ServerTime.Text = Format(dtServerDateTime, "hh:mm:ss tt")
                IsFirstTime = False
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If tmpConnection.State = ConnectionState.Open Then
                    cmd = Nothing
                    tmpConnection.Close()
                End If
            End Try
        Else
            dtServerDateTime = DateAdd(DateInterval.Second, 1, dtServerDateTime)
        End If
        tmrLocalTimer.Enabled = True
        ServerTime.Text = Format(dtServerDateTime, "dd/MM/yyyy hh:mm:ss tt")
    End Sub

End Class