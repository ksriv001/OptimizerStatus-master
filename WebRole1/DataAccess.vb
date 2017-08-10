Imports System.Data.SqlClient

'20140224 - pab - add threading
Imports System.Threading


Public Class DataAccess

    Shared Function GetUserPBNoCarrier(ByRef UserID As String, ByRef UserPW As String) As DataTable

        Dim dt As DataTable = New DataTable()

        Try
            Using conn As New SqlConnection()
                conn.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OPTIMIZERSERVER")
                Using cmd As New SqlCommand
                    cmd.Connection = conn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_GetUserPBNoCarrier"

                    Dim sqlParam As SqlParameter

                    sqlParam = New SqlParameter("@UserID", SqlDbType.VarChar)
                    sqlParam.Value = UserID
                    cmd.Parameters.Add(sqlParam)

                    sqlParam = New SqlParameter("@UserPW", SqlDbType.VarChar)
                    sqlParam.Value = UserPW
                    cmd.Parameters.Add(sqlParam)

                    conn.Open()

                    Using rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        dt.Load(rdr)
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Dim s As String = "parms UserID " & UserID & "; " & UserPW & vbCr & vblf & ex.Message
            If Not IsNothing(ex.InnerException) Then s &= vbNewLine & ex.InnerException.ToString
            If Not IsNothing(ex.StackTrace) Then s &= vbNewLine & ex.StackTrace.ToString
            Insertsys_log(0, "optimzerstatus", s, "GetUserPBNoCarrier", "DataAccess.vb")
            'SendEmail("CharterSales@coastalavtech.com", "pbaumgart@coastalaviationsoftware.com", "", appName & " DataAccess.vb GetUserPBNoCarrier Error", s, _carrierid)
        End Try

        Return dt

    End Function

    Shared Function Insertsys_log( _
     ByVal CarrierID As Integer, _
     ByVal UserID As String, _
     ByVal Message As String, _
     ByVal CallingParty As String, _
     ByVal IP As String) As Integer

        Dim oConn As SqlConnection = Nothing
        Dim oCmd As SqlCommand = Nothing
        Dim oParam As SqlParameter = Nothing

        Try
            '20120501 - pab - keep hardcoded connectionstrings in one location
            oConn = New SqlConnection(ConnectionStringHelper.getglobalconnectionstring("OPTIMIZERSERVER"))

            oConn.Open()
            oCmd = New SqlCommand("sp_Insertsys_log", oConn)
            oCmd.CommandType = CommandType.StoredProcedure

            oParam = New SqlParameter("@CarrierID", SqlDbType.Int)
            oParam.Value = CarrierID
            oCmd.Parameters.Add(oParam)

            oParam = New SqlParameter("@UserID", SqlDbType.VarChar, 60)
            oParam.Value = UserID
            oCmd.Parameters.Add(oParam)

            oParam = New SqlParameter("@Message", SqlDbType.VarChar, 500)
            oParam.Value = Message
            oCmd.Parameters.Add(oParam)

            oParam = New SqlParameter("@CallingParty", SqlDbType.VarChar, 500)
            oParam.Value = CallingParty
            oCmd.Parameters.Add(oParam)

            oParam = New SqlParameter("@IP", SqlDbType.VarChar, 60)
            oParam.Value = IP
            oCmd.Parameters.Add(oParam)

            oParam = New SqlParameter()
            oParam.Direction = ParameterDirection.ReturnValue
            oCmd.Parameters.Add(oParam)

            oCmd.ExecuteNonQuery()

            Return CInt(oParam.Value)

        Catch ex As Exception
            Dim s As String = ex.Message
            If Not IsNothing(ex.InnerException) Then s &= vbNewLine & ex.InnerException.ToString
            If Not IsNothing(ex.StackTrace) Then s &= vbNewLine & ex.StackTrace.ToString
            SendEmail("CharterSales@coastalavtech.com", "pbaumgart@coastalaviationsoftware.com", "",
                      "OptimizerStatus DataAccess.vb Insertsys_log Error", s, 0)
            Return 0
        Finally
            If oConn.State = ConnectionState.Open Then
                oConn.Close()
            End If
            oCmd.Dispose()
            oConn.Dispose()
        End Try

    End Function

    Shared Function SendEmail(ByVal emailFrom As String, ByVal emailTo As String, ByVal emailcc As String, ByVal emailSubject As String, ByVal emailBody As String,
                              ByVal CarrierID As Integer) As Boolean

        SendEmail = False

        Dim da As New DataAccess

        Try
            '20120807 - pab - write to email queue
            'Dim eMsg As Net.Mail.MailMessage = Nothing


            ''define smtp server client
            'Dim client As New SmtpClient(da.GetSetting(_carrierid, "smtpServer"))

            'eMsg = New MailMessage(emailFrom, emailTo, emailSubject, emailBody)


            'eMsg.IsBodyHtml = True

            ''AirTaxi.post_timing(emailBody)

            ''Send the message
            'client.Send(eMsg)

            '20131024 - pab - fix duplicate emails
            'Dim emailcc As String = String.Empty
            'If emailTo = "rkane@coastalaviationsoftware.com" Then
            '    emailcc = "pbaumgart@coastalaviationsoftware.com"
            'ElseIf emailTo = "pbaumgart@coastalaviationsoftware.com" Then
            '    emailcc = "rkane@coastalaviationsoftware.com"
            'End If
            'If emailSubject = "getsetting error" Then
            '    Exit Function

            'ElseIf emailSubject = "Optimizer Error 1" Or InStr(emailSubject, " Error!") > 0 Then
            '    SendEmail = InsertEmailQueue(CarrierID, emailFrom, "5612397068@txt.att.net", emailcc, "", emailSubject, emailBody, _
            '                                             False, "", "", "", False)

            '    'ElseIf InStr(emailSubject, "Timing Email ! Price Request from ") > 0 Then
            '    '    eMsg = New MailMessage(emailFrom, "pbaumgart@coastalaviationsoftware.com", emailSubject, emailBody)
            '    '    client.Send(eMsg)
            'ElseIf InStr(emailSubject, "Price Request from ") > 0 Then
            '    '20130614 - pab - fix invalid email
            '    'emailTo = "casquoter@coastalaviationsoftware.com; " & emailTo
            '    emailTo = "CharterSales@coastalavtech.com; " & emailTo

            'End If
            If InStr(emailTo, "rkane@coastalaviationsoftware.com") = 0 And InStr(emailTo, "pbaumgart@coastalaviationsoftware.com") = 0 Then
                If emailcc = "" Then
                    emailcc = "rkane@coastalaviationsoftware.com; pbaumgart@coastalaviationsoftware.com"
                Else
                    emailcc &= "; rkane@coastalaviationsoftware.com; pbaumgart@coastalaviationsoftware.com"
                End If
            ElseIf InStr(emailTo, "pbaumgart@coastalaviationsoftware.com") = 0 Then
                If emailcc = "" Then
                    emailcc = "pbaumgart@coastalaviationsoftware.com"
                Else
                    emailcc &= "; pbaumgart@coastalaviationsoftware.com"
                End If
            ElseIf InStr(emailTo, "rkane@coastalaviationsoftware.com") = 0 Then
                If emailcc = "" Then
                    emailcc = "rkane@coastalaviationsoftware.com"
                Else
                    emailcc &= "; rkane@coastalaviationsoftware.com"
                End If
            End If

            InsertEmailQueue(CarrierID, emailFrom, emailTo, emailcc, "", emailSubject, emailBody, False, "", "", "", False)

            SendEmail = True

        Catch ex As Exception

            Dim s As String = ex.Message
            If Not IsNothing(ex.InnerException) Then
                s &= " - " & ex.InnerException.ToString
            End If
            If Not IsNothing(ex.StackTrace) Then
                s &= vbNewLine & vbNewLine & ex.StackTrace.ToString
            End If
            'Insertsys_log(CarrierID, appName, s, "SendEmail", "AirTaxi.vb")

        End Try
    End Function

    '20140224 - pab - add threading
    Public Shared Sub InsertEmailQueue(
             ByVal CarrierID As Integer,
             ByVal EmailFrom As String,
             ByVal EmailTo As String,
             ByVal EmailCC As String,
             ByVal EmailBCC As String,
             ByVal EmailSubject As String,
             ByVal EmailBody As String,
             ByVal IsBodyHtml As Boolean,
             ByVal Attachment As String,
             ByVal CompanyLogo As String,
             ByVal AircraftLogo As String,
             ByVal ShowCarrier As Boolean)

        Dim tu As Thread
        Dim tup As String

        tu = New Thread(AddressOf InsertEmailQueue_thread)
        '20141211 - pab - fix messages getting truncated
        tup = "CarrierID|||" & CarrierID & "|||"
        tup = tup & "EmailFrom|||" & EmailFrom & "H"
        tup = tup & "EmailTo|||" & EmailTo & "|||"
        tup = tup & "EmailCC|||" & EmailCC & "|||"
        tup = tup & "EmailBCC|||" & EmailBCC & "|||"
        tup = tup & "EmailSubject|||" & EmailSubject & "|||"
        tup = tup & "EmailBody|||" & EmailBody & "|||"
        tup = tup & "IsBodyHtml|||" & IsBodyHtml & "|||"
        tup = tup & "Attachment|||" & Attachment & "|||"
        tup = tup & "CompanyLogo|||" & CompanyLogo & "|||"
        tup = tup & "AircraftLogo|||" & AircraftLogo & "|||"
        tup = tup & "ShowCarrier|||" & ShowCarrier & "|||"
        tu.Start(tup)

    End Sub

    '20140224 - pab - add threading
    Public Shared Sub InsertEmailQueue_thread(a As String)

        '20141211 - pab - fix messages getting truncated
        Dim CarrierID As String = InBetween(1, a, "CarrierID|||", "|||")
        Dim EmailFrom As String = InBetween(1, a, "EmailFrom|||", "|||")
        Dim EmailTo As String = InBetween(1, a, "EmailTo|||", "|||")
        Dim EmailCC As String = InBetween(1, a, "EmailCC|||", "|||")
        Dim EmailBCC As String = InBetween(1, a, "EmailBCC|||", "|||")
        Dim EmailSubject As String = InBetween(1, a, "EmailSubject|||", "|||")
        Dim EmailBody As String = InBetween(1, a, "EmailBody|||", "|||")
        Dim IsBodyHtml As String = InBetween(1, a, "IsBodyHtml|||", "|||")
        Dim Attachment As String = InBetween(1, a, "Attachment|||", "|||")
        Dim CompanyLogo As String = InBetween(1, a, "CompanyLogo|||", "|||")
        Dim AircraftLogo As String = InBetween(1, a, "AircraftLogo|||", "|||")
        Dim ShowCarrier As String = InBetween(1, a, "ShowCarrier|||", "|||")

        Try
            DataAccess.Insert_Email_Queue(CarrierID, EmailFrom, EmailTo, EmailCC, EmailBCC, EmailSubject, EmailBody, IsBodyHtml, Attachment, CompanyLogo,
                                        AircraftLogo, ShowCarrier)

        Catch ex As Exception
            Dim s As String = ex.Message
            If Not IsNothing(ex.InnerException) Then s &= " - " & ex.InnerException.ToString
            If Not IsNothing(ex.StackTrace) Then s &= vbNewLine & vbNewLine & ex.StackTrace.ToString
            'Insertsys_log(0, appName, s, "InsertEmailQueue_thread", "AirTaxi.vb")
        End Try

    End Sub

    '20140224 - pab - add threading
    Shared Function Insert_Email_Queue(
             ByVal CarrierID As Integer,
             ByVal EmailFrom As String,
             ByVal EmailTo As String,
             ByVal EmailCC As String,
             ByVal EmailBCC As String,
             ByVal EmailSubject As String,
             ByVal EmailBody As String,
             ByVal IsBodyHtml As Boolean,
             ByVal Attachment As String,
             ByVal CompanyLogo As String,
             ByVal AircraftLogo As String,
             ByVal ShowCarrier As Boolean) As Integer

        Dim oConn As SqlConnection = Nothing
        Dim oCmd As SqlCommand = Nothing
        Dim oParam As SqlParameter = Nothing

        Try
            '20120830 - pab - fix connection string error
            'oConn = New SqlConnection(ConnectionStringHelper.GetConnectionString)
            '20130702 - pab - remove duplicate connection strings
            'oConn = New SqlConnection(ConnectionStringHelper.GetD2DConnectionString)
            oConn = New SqlConnection(ConnectionStringHelper.getglobalconnectionstring("ProdPortalServer"))

            oConn.Open()
            oCmd = New SqlCommand("sp_InsertEmailQueue", oConn)
            oCmd.CommandType = CommandType.StoredProcedure

            oParam = New SqlParameter("@CarrierID", SqlDbType.Int)
            oParam.Value = CarrierID
            oCmd.Parameters.Add(oParam)

            oParam = New SqlParameter("@EmailFrom", SqlDbType.VarChar, 60)
            oParam.Value = EmailFrom
            oCmd.Parameters.Add(oParam)

            oParam = New SqlParameter("@EmailTo", SqlDbType.VarChar, 500)
            oParam.Value = EmailTo
            oCmd.Parameters.Add(oParam)

            oParam = New SqlParameter("@EmailCC", SqlDbType.VarChar, 500)
            oParam.Value = EmailCC
            oCmd.Parameters.Add(oParam)

            oParam = New SqlParameter("@EmailBCC", SqlDbType.VarChar, 500)
            oParam.Value = EmailBCC
            oCmd.Parameters.Add(oParam)

            oParam = New SqlParameter("@EmailSubject", SqlDbType.VarChar, 500)
            oParam.Value = EmailSubject
            oCmd.Parameters.Add(oParam)

            oParam = New SqlParameter("@EmailBody", SqlDbType.VarChar)
            oParam.Value = EmailBody
            oCmd.Parameters.Add(oParam)

            oParam = New SqlParameter("@IsBodyHtml", SqlDbType.Bit)
            oParam.Value = IsBodyHtml.GetHashCode
            oCmd.Parameters.Add(oParam)

            oParam = New SqlParameter("@Attachment", SqlDbType.VarChar, 500)
            oParam.Value = Attachment
            oCmd.Parameters.Add(oParam)

            oParam = New SqlParameter("@CompanyLogo", SqlDbType.VarChar, 200)
            oParam.Value = CompanyLogo
            oCmd.Parameters.Add(oParam)

            oParam = New SqlParameter("@AircraftLogo", SqlDbType.VarChar, 200)
            oParam.Value = AircraftLogo
            oCmd.Parameters.Add(oParam)

            oParam = New SqlParameter("@ShowCarrier", SqlDbType.Bit)
            oParam.Value = ShowCarrier.GetHashCode
            oCmd.Parameters.Add(oParam)

            oParam = New SqlParameter()
            oParam.Direction = ParameterDirection.ReturnValue
            oCmd.Parameters.Add(oParam)

            oCmd.ExecuteNonQuery()

            Return CInt(oParam.Value)

        Catch ex As Exception
            Dim s As String = ex.Message
            If Not IsNothing(ex.InnerException) Then s &= vbNewLine & ex.InnerException.ToString
            If Not IsNothing(ex.StackTrace) Then s &= vbNewLine & ex.StackTrace.ToString
            'Insertsys_log(_carrierid, appName, s, "Insert_Email_Queue", "DataAccess.vb")
            Return 0
        Finally
            If oConn.State = ConnectionState.Open Then
                oConn.Close()
            End If
            oCmd.Dispose()
            oConn.Dispose()
        End Try

    End Function

    Shared Function InBetween(ByVal Start As Integer, ByVal work As String, ByVal target As String, ByVal target2 As String) As String

        Dim pos As Integer
        Dim pos2 As Integer
        Dim work1 As String


        If Start = 0 Then
            InBetween = ""
            Exit Function
        End If

        pos = InStr(Start, work, target, vbTextCompare)

        pos = pos + Len(target)
        pos2 = InStr(pos, work, target2, vbTextCompare)

        If pos = 0 + Len(target) Or pos2 = 0 Then
            InBetween = ""
            Exit Function
        End If


        work1 = Mid(work, pos, pos2 - pos)

        InBetween = work1

    End Function

    Shared Function isdtnullorempty(ByRef dt As DataTable) As Boolean

        isdtnullorempty = True
        If IsNothing(dt) Then Exit Function
        If dt.Rows.Count > 0 Then isdtnullorempty = False

    End Function

    '20161023 - pab - use icao because iata not always populated in fosflights
    Shared Function GetICAOcodebyIATA(ByVal IATA As String) As String

        Dim dt As New DataTable

        Try
            Using conn As New SqlConnection()
                conn.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("ProdPortalServer")
                Using cmd As New SqlCommand
                    cmd.Connection = conn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_GetICAOcodebyIATA"

                    Dim sqlParam As SqlParameter

                    sqlParam = New SqlParameter("@IATA", SqlDbType.VarChar)
                    sqlParam.Value = IATA
                    cmd.Parameters.Add(sqlParam)

                    conn.Open()

                    Using rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        dt.Load(rdr)
                    End Using

                    '20160816 - pab - fix timeouts - pooling issues?
                    conn.Close()

                    If Not isdtnullorempty(dt) Then
                        GetICAOcodebyIATA = dt.Rows(0).Item("icao").ToString
                    End If

                End Using
            End Using

        Catch ex As Exception
            Dim s As String = "parms - IATA " & IATA & vbCr & vbLf & ex.Message
            If Not IsNothing(ex.InnerException) Then s &= " - " & ex.InnerException.ToString
            If Not IsNothing(ex.StackTrace) Then s &= vbNewLine & vbNewLine & ex.StackTrace.ToString
            'AirTaxiClass.Insertsys_log(0, AirTaxiClass.appName, s, "GetICAOcodebyIATA", "DataAccess.vb")

        End Try

        Return GetICAOcodebyIATA

    End Function

    Shared Function GetAirportInformationByICAO(ByRef icao As String) As DataTable

        Dim dt As DataTable = New DataTable()

        Try
            Using conn As New SqlConnection()
                conn.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("ProdPortalServer")
                Using cmd As New SqlCommand
                    cmd.Connection = conn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_GetAirportInformationByICAO"

                    Dim sqlParam As SqlParameter

                    sqlParam = New SqlParameter("@icao", SqlDbType.VarChar)
                    sqlParam.Value = icao
                    cmd.Parameters.Add(sqlParam)

                    conn.Open()

                    Using rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        dt.Load(rdr)
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Dim s As String = ex.Message
            If Not IsNothing(ex.InnerException) Then s &= vbNewLine & ex.InnerException.ToString
            If Not IsNothing(ex.StackTrace) Then s &= vbNewLine & ex.StackTrace.ToString
            'Insertsys_log(_carrierid, appName, s, "GetAirportInformationByICAO", "DataAccess.vb")
            'SendEmail("CharterSales@coastalavtech.com", "pbaumgart@coastalaviationsoftware.com", "", appName & " DataAccess.vb GetAirportInformationByICAO Error", s, _carrierid)
        End Try

        Return dt

    End Function
    Public Function GetAirportNameByLocationID(ByRef airportCode As String) As String

        Dim oConn As SqlConnection = Nothing
        Dim oCmd As SqlCommand = Nothing
        Dim oParam As SqlParameter = Nothing

        Try
            oConn = New SqlConnection(ConnectionStringHelper.getglobalconnectionstring("ProdPortalServer"))
            oConn.Open()
            oCmd = New SqlCommand("sp_GetAirportNameByLocationID", oConn)

            oCmd.CommandType = CommandType.StoredProcedure

            oParam = New SqlParameter("@LocationID", SqlDbType.VarChar, 255)
            oParam.Value = airportCode
            oCmd.Parameters.Add(oParam)

            Return CStr(oCmd.ExecuteScalar)

        Catch ex As Exception
            Dim s As String = ex.Message
            Return String.Empty
        Finally
            If oConn.State = ConnectionState.Open Then
                oConn.Close()
            End If
            oCmd.Dispose()
            oConn.Dispose()
        End Try

    End Function

End Class
