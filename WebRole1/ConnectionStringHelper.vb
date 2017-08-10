Public Class ConnectionStringHelper

    Public Shared ts As String = "IBMTEST"
    Public Shared testrun As Boolean = False
    Public Shared lastcheck As DateTime = CDate("4/8/2004 10:01AM")
    Public Shared Driver As String = ""
    Public Shared Server As String = ""
    Public Shared Servertest As String = ""
    Public Shared Drivertest As String = ""
    Public Shared DriverRO As String = ""
    Public Shared ServerRO As String = ""
    Public Shared ServerIBMtest As String = ""
    Public Shared ServerROtest As String = ""
    Public Shared DriverROIBMtest As String = ""
    Public Shared DriverIBMtest As String = ""
    Public Shared DriverROtest As String = ""
    Public Shared ServerROIBMtest As String = ""


    Public Sub New()

    End Sub
    '  "Test" ' "Test"
    '"Test"

    Public Shared Function ReadOnlyProdOnlyServerConnectionString() As String

        ' Return getglobalconnectionstring("OptimizerServer" & ts)
        Return getglobalconnectionstring("OptimizerServerRO")
    End Function

    Public Shared Function ReadOnlyProdOnlyDriverConnectionString() As String

        ' Return getglobalconnectionstring("OptimizerServer" & ts)
        Return getglobalconnectionstring("OptimizerDriverRO")
    End Function

    Public Shared Function GetProviderConnectionString() As String

        If Not testrun Then
            Return getglobalconnectionstring("OptimizerDriver" & ts)

            ' Return "Driver={SQL Server Native Client 11.0};server=tcp:optimizersqlvm.cloudapp.net,1433;database=OptimizerWest;uid=cas;Password=n621kf!12;Encrypt=no;"
        Else
            Return "Driver={SQL Server Native Client 11.0};Server=10.176.218.76,14441;Database=OptimizerWest;uid=cas;Password=n621kf!12;"
        End If

    End Function

    Public Shared Function GetConnectionStringByDBName(ByVal DBName As String) As String

        If Not testrun Then
            Return getglobalconnectionstring("OptimizerDriver" & ts)
            ' Return "Driver={SQL Server Native Client 11.0};server=tcp:optimizersqlvm.cloudapp.net,1433;database=OptimizerWest;uid=cas;Password=n621kf!12;Encrypt=no;"
        Else
            Return "Driver={SQL Server Native Client 11.0};Server=10.176.218.76,14441;Database=OptimizerWest;uid=cas;Password=n621kf!12;"
        End If
    End Function

    Public Shared Function GetConnectionStringByCarrierID(ByVal CarrierID As Integer) As String

        If Not testrun Then
            'If useSW Then
            '    Return "Driver={SQL Server Native Client 11.0};server=tcp:sg06v2b2hpxx.database.windows.net,1433;database=;uid=SFlaPilot@sg06v2b2hpxx;Pwd=Nz9sg7!12;Encrypt=yes;Connection Lifetime=600"
            'Else
            Return getglobalconnectionstring("OptimizerDriver" & ts)
            '    Return "Driver={SQL Server Native Client 11.0};server=tcp:optimizersqlvm.cloudapp.net,1433;database=OptimizerWest;uid=cas;Password=n621kf!12;Encrypt=no;"
            'End If
        Else
            Return "Driver={SQL Server Native Client 11.0};Server=10.176.218.76,14441;Database=OptimizerWest;uid=cas;Password=n621kf!12;"
        End If
    End Function

    '20101105 - pab - add code for aliases
    Public Shared Function GetCASConnectionString() As String

        'Return "Data Source=(local);Initial Catalog=SuperPortalV3;Persist Security Info=True;uid=cas;Password=CoastalPass1"
        If Not testrun Then
            Return getglobalconnectionstring("OptimizerDriver" & ts)
            '  Return "Driver={SQL Server Native Client 11.0};server=tcp:optimizersqlvm.cloudapp.net,1433;database=OptimizerWest;uid=cas;Password=n621kf!12;Encrypt=no;"
        Else
            Return "Driver={SQL Server Native Client 11.0};Server=10.176.218.76,14441;Database=OptimizerWest;uid=cas;Password=n621kf!12;"
        End If
    End Function

    Public Shared Function GetProdConnectionString() As String

        'Return "Data Source=(local);Initial Catalog=SuperPortalV3;Persist Security Info=True;uid=cas;Password=CoastalPass1"
        If Not testrun Then
            Return getglobalconnectionstring("OptimizerDriver")
            '  Return "Driver={SQL Server Native Client 11.0};server=tcp:optimizersqlvm.cloudapp.net,1433;database=OptimizerWest;uid=cas;Password=n621kf!12;Encrypt=no;"
        Else
            Return "Driver={SQL Server Native Client 11.0};Server=10.176.218.76,14441;Database=OptimizerWest;uid=cas;Password=n621kf!12;"
        End If
    End Function
    Public Shared Function GetConnectionString() As String

        If Not testrun Then
            Return getglobalconnectionstring("OptimizerServer")

            '  Return "server=tcp:optimizersqlvm.cloudapp.net,1433;database=OptimizerWest;uid=cas;pwd=n621kf!12;Trusted_Connection=False;Encrypt=False;Connection Lifetime=800"

        Else
            Return "server=10.176.218.76,14441;database=optimizerWEST;uid=sa;pwd=n621kf!12;Connection Lifetime=800"
        End If

    End Function

    Public Shared Function GetConnectionStringAPIFeed() As String

        'Return "Data Source=(local);Initial Catalog=SuperPortalV3;Persist Security Info=True;uid=cas;Password=CoastalPass1"
        If Not testrun Then
            Return getglobalconnectionstring("OptimizerServer")
            '  Return "Driver={SQL Server Native Client 11.0};server=tcp:optimizersqlvm.cloudapp.net,1433;database=OptimizerWest;uid=cas;Password=n621kf!12;Encrypt=no;"
        Else
            Return "Driver={SQL Server Native Client 11.0};Server=10.176.218.76,14441;Database=OptimizerWest;uid=cas;Password=n621kf!12;"
        End If
    End Function

    Public Shared Function GetConnectionStringOptimizer() As String

        If Not testrun Then
            Return getglobalconnectionstring("OptimizerServer" & ts)

            ' Return "server=tcp:optimizersqlvm.cloudapp.net,1433;database=OptimizerWest;uid=cas;pwd=n621kf!12;Trusted_Connection=False;Encrypt=False;Connection Lifetime=800"

        Else
            Return "server=10.176.218.76,14441;database=optimizerWEST;uid=sa;pwd=n621kf!12;Connection Lifetime=800"
        End If

    End Function

    Public Shared Function GetConnectionStringlocalado() As String
        '  Return "server=localhost;database=optimizerlocal;uid=sa;pwd=CoastalPass1;Connection Lifetime=800"
        ' Return "Driver={SQL Server Native Client 11.0};server=tcp:b2pqcffmjlxx.database.windows.net,1433;database=OptimizerWest;uid=OptimizerWest@b2pqcffmjlxx;Password=n621kf!12;Encrypt=yes;"
        'Return "server=(local);database=tmcstaging;uid=sa;pwd=nz9sg7!12;Trusted_Connection=False;Encrypt=True;"

        '     Return "Driver={SQL Server Native Client 11.0};server=tcp:b2pqcffmjlxx.database.windows.net,1433;database=OptimizerWest;uid=OptimizerWest@b2pqcffmjlxx;Password=n621kf!12;Encrypt=yes;"

        Return "Driver={SQL Server Native Client 11.0};Server=10.176.218.76,14441;Database=OptimizerWest;uid=cas;Password=n621kf!12;"

    End Function
    Public Shared Function GetConnectionStringlocal() As String
        Return "server=10.176.218.76,14441;database=optimizerWEST;uid=sa;pwd=n621kf!12;Connection Lifetime=800"
        ' Return "Driver={SQL Server Native Client 11.0};server=tcp:b2pqcffmjlxx.database.windows.net,1433;database=OptimizerWest;uid=OptimizerWest@b2pqcffmjlxx;Password=n621kf!12;Encrypt=yes;"
        'Return "server=(local);database=tmcstaging;uid=sa;pwd=nz9sg7!12;Trusted_Connection=False;Encrypt=True;"

        '     Return "Driver={SQL Server Native Client 11.0};server=tcp:b2pqcffmjlxx.database.windows.net,1433;database=OptimizerWest;uid=OptimizerWest@b2pqcffmjlxx;Password=n621kf!12;Encrypt=yes;"

    End Function

    Public Shared Function GetConnectionStringMKOptimizer() As String
        ' Return "Driver={SQL Server Native Client 11.0};server=tcp:b2pqcffmjlxx.database.windows.net,1433;database=OptimizerWest;uid=OptimizerWest@b2pqcffmjlxx;Password=n621kf!12;Encrypt=yes;"
        'Return "server=(local);database=tmcstaging;uid=sa;pwd=nz9sg7!12;Trusted_Connection=False;Encrypt=True;"

        If Not testrun Then
            Return getglobalconnectionstring("OptimizerDriver" & ts)

            ' Return "Driver={SQL Server Native Client 11.0};server=tcp:optimizersqlvm.cloudapp.net,1433;database=OptimizerWest;uid=cas;Password=n621kf!12;Encrypt=no;"

        Else
            'Return "Driver={SQL Server Native Client 11.0};Server=RICHARDdeskTOP;Database=OptimizerWest;uid=cas;Password=n621kf!12;"
            Return "Driver={SQL Server Native Client 11.0};Server=10.176.218.76,14441;Database=OptimizerWest;User ID=sa;Password=n621kf!12;"
        End If

    End Function

    Shared Function getglobalconnectionstring(connection As String) As String

        If DateDiff(DateInterval.Minute, lastcheck, Now) > 30 Then 'rk change from 10 to 30  10.2.16
            Driver = ""
            Server = ""
            Drivertest = ""
            Servertest = ""
            DriverRO = ""
            ServerRO = ""
            ServerIBMtest = ""
            ServerROtest = ""
            DriverROIBMtest = ""
            DriverIBMtest = ""
            DriverROtest = ""
            ServerROIBMtest = ""

            lastcheck = Now
        End If

        If UCase(connection) = "OPTIMIZERDRIVER" And Driver <> "" Then Return Driver
        If UCase(connection) = "OPTIMIZERSERVER" And Server <> "" Then Return Server

        If UCase(connection) = "OPTIMIZERDRIVERRO" And DriverRO <> "" Then Return DriverRO
        If UCase(connection) = "OPTIMIZERSERVERRO" And ServerRO <> "" Then Return ServerRO

        If UCase(connection) = "OPTIMIZERDRIVERTEST" And Drivertest <> "" Then Return Drivertest
        If UCase(connection) = "OPTIMIZERSERVERTEST" And Servertest <> "" Then Return Servertest

        If UCase(connection) = "OPTIMIZERDRIVERROTEST" And DriverROtest <> "" Then Return DriverROtest
        If UCase(connection) = "OPTIMIZERSERVERROTEST" And ServerROtest <> "" Then Return ServerROtest

        If UCase(connection) = "OPTIMIZERDRIVERIBMTEST" And Drivertest <> "" Then Return DriverIBMtest
        If UCase(connection) = "OPTIMIZERSERVERIBMTEST" And Servertest <> "" Then Return ServerIBMtest

        If UCase(connection) = "OPTIMIZERDRIVERROIBMTEST" And DriverROtest <> "" Then Return DriverROIBMtest
        If UCase(connection) = "OPTIMIZERSERVERROIBMTEST" And ServerROtest <> "" Then Return ServerROIBMtest

        Dim cnglobal As New ADODB.Connection
        Try
            Dim rs As New ADODB.Recordset

            If cnglobal.State = 1 Then cnglobal.Close()

            If cnglobal.State = 0 Then
                '.ConnectionString = "Driver={SQL Server Native Client 11.0};server=b2pqcffmjl.database.windows.net,1433;database=OptimizerWest;uid=OptimizerWest@b2pqcffmjl;Password=n621kf!12;Encrypt=no;max pool size=32767"

                '   cnglobal.ConnectionString = "Driver={SQL Server Native Client 11.0};server=xhmagkz1j8.database.windows.net,1433;database=OptimizerWest;uid=cas@xhmagkz1j8;Password=n621kf!12;Encrypt=no;Connection Timeout = 30"

                ' cnglobal.ConnectionString = "Driver={SQL Server Native Client 11.0};server=azureurlserver.database.windows.net,1433;database=AzureURLs;uid=cas@azureurlserver;Password=n621kf!12;Encrypt=no;Connection Timeout = 30"

                'cnglobal.ConnectionString = "Driver={SQL Server Native Client 11.0};server=10.176.218.77,14442;database=OptimizerWest;uid=cas;Password=n621kf!12;Encrypt=no;Connection Timeout = 30"
                'cnglobal.ConnectionString = "Driver={SQL Server Native Client 11.0};server=169.46.63.76,14441;database=AzureURLs;uid=cas;Password=n621kf!12;Encrypt=no;Connection Timeout = 30"
                cnglobal.ConnectionString = "Driver={SQL Server Native Client 11.0};server=169.46.63.77,14442;database=azureurls;uid=cas;Password=n621kf!12;Encrypt=no;Connection Timeout = 30"

                cnglobal.Open()

            End If

            If rs.State = 1 Then rs.Close()

            Dim req As String

            req = "Select * "
            req = req & "FROM url WHERE CType = '" & connection & "' "

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
                If UCase(connection) = "OPTIMIZERDRIVER" Then Driver = rs.Fields("CLOC").Value.ToString.Trim
                If UCase(connection) = "OPTIMIZERSERVER" Then Server = rs.Fields("CLOC").Value.ToString.Trim
                If UCase(connection) = "OPTIMIZERDRIVERTEST" Then Drivertest = rs.Fields("CLOC").Value.ToString.Trim
                If UCase(connection) = "OPTIMIZERSERVERTEST" Then Servertest = rs.Fields("CLOC").Value.ToString.Trim

                If UCase(connection) = "OPTIMIZERDRIVERRO" Then DriverRO = rs.Fields("CLOC").Value.ToString.Trim
                If UCase(connection) = "OPTIMIZERSERVERRO" Then ServerRO = rs.Fields("CLOC").Value.ToString.Trim
                If UCase(connection) = "OPTIMIZERDRIVERROTEST" Then DriverROtest = rs.Fields("CLOC").Value.ToString.Trim
                If UCase(connection) = "OPTIMIZERSERVERROTEST" Then ServerROtest = rs.Fields("CLOC").Value.ToString.Trim
            End If

            rs.Close()

            If cnglobal.State = 1 Then cnglobal.Close()

        Catch ex As Exception
            getglobalconnectionstring = ""

        End Try

    End Function

End Class

