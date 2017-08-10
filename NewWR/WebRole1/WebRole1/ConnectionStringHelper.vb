Public Class ConnectionStringHelper
    Public Shared Driver As String = ""
    Public Shared Server As String = ""
    Public Shared lastcheck As DateTime = CDate("4/8/2004 10:01AM")
    Public Shared testrun As Boolean = False


    Public Shared Function GetCASConnectionStringSQL() As String
        If Not testrun Then
            Return getglobalconnectionstring("OptimizerDriver")
        Else
            Return "Driver={SQL Server Native Client 11.0};Server=RICHARDdesktop;Database=OptimizerWest;User ID=sa;Password=n621kf!12;"
        End If
    End Function
    Public Shared Function GetConnectionStringServer() As String
        If Not testrun Then

            Return getglobalconnectionstring("OptimizerServer")
     

        Else
            Return "server=richarddesktop;database=optimizerwest;uid=sa;pwd=n621kf!12;Connection Lifetime=800"

        End If
    End Function

    Public Shared Function GetsqladapterWestConnectionString() As String

        If Not testrun Then

            Return getglobalconnectionstring("OptimizerDataSource")

       
            Return "Data Source=tcp:b2pqcffmjl.database.windows.net,1433;Initial Catalog=OptimizerWest;Persist Security Info=True;User ID=OptimizerWest@b2pqcffmjl;Password=n621kf!12"
            'providerName = "System.Data.SqlClient"
        Else
            Return "Data Source=richarddesktop;Initial Catalog=OptimizerWest;Persist Security Info=True;User ID=sa;Password=n621kf!12;"

        End If


    End Function
    Shared Function getglobalconnectionstring(connection As String) As String



        If DateDiff(DateInterval.Minute, lastcheck, Now) > 5 Then
            Driver = ""
            Server = ""
        End If

        If UCase(connection) = "OptimizerDriver" And Driver <> "" Then Return Driver
        If UCase(connection) = "OptimizerServer" And Server <> "" Then Return Server


        Dim cnglobal As New ADODB.Connection
        Try
            Dim rs As New ADODB.Recordset



            If cnglobal.State = 0 Then
                cnglobal.ConnectionString = "Driver={SQL Server Native Client 11.0};server=b2pqcffmjl.database.windows.net,1433;database=OptimizerWest;uid=OptimizerWest@b2pqcffmjl;Password=n621kf!12;Encrypt=no;"
                cnglobal.Open()

            End If

            If rs.State = 1 Then rs.Close()


            Dim req As String

            req = "SELECT * "
            req = req & "FROM url WHERE ctype = '" & connection & "' "

            'rk 11/1/2010 added self healing connection code
            Try
                rs.Open(req, cnglobal, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
            Catch ex As Exception
                cnglobal.Close()
                getglobalconnectionstring = ""
                Exit Function
            End Try


            If rs.EOF Then
                getglobalconnectionstring = ""
            Else
                getglobalconnectionstring = rs.Fields("CLOC").Value.ToString.Trim
                If UCase(connection) = "OptimizerDriver" Then Driver = rs.Fields("CLOC").Value.ToString.Trim
                If UCase(connection) = "OptimizerServer" Then Server = rs.Fields("CLOC").Value.ToString.Trim

            End If

            rs.Close()

        Catch ex As Exception
            getglobalconnectionstring = ""

        End Try

    End Function

End Class
