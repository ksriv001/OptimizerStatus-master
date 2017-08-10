Imports System.Data.SqlClient


Public Class FlightTime

    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Dim ws As New coastalavtech.service.WebService1
        If Session("defaultemail") <> ws.getcypher(Session("cypher")) Then Response.Redirect("login.aspx")


        If IsNothing(Session("carrierid")) Then Response.Redirect("login.aspx")
        If Session("carrierid") = 0 Then Response.Redirect("login.aspx")

        If Drpactype.Items.Count = 0 Then loaddropdowns()


    End Sub

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


    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click

        Dim ws As New net.cloudapp.aviationwebservice.WebService1

        Dim wsd As New com.duats.servicesService

        Dim climbspeed As String = "200"
        Dim climbrate As String = "1500"
        Dim cruisespeed As String = "300"


        Dim ss As String = wsd.segmentPlanner("011491", "99999975", "duats1", Me.txtFrom.Text, Me.txtTo.Text, "*a", "300", "1000", "1", "S", "N", "G", climbspeed, climbrate, cruisespeed, cruisespeed, "1000", "200", "180", "160", "test")


        Dim sss As String = InBetween(1, ss, "Flight totals:", "Average")

        txtDuatsTime.Text = InBetween(1, sss, "time:", ",")
        ' txtDuats.Text = ss
        ' Dim sss As String = 
        '  time: 2:00, 

        Dim originaldistance As Double = ws.getdistance("pbaumgart@ctgi.com", "123", 65, Me.txtFrom.Text, Me.txtTo.Text)

        txtStatus.Text = "Distance is " & originaldistance & "NM" & vbNewLine

        Me.txtActual.Text = 0

        Dim fa As Double = findactual(Me.txtFrom.Text, Me.txtTo.Text, Me.Drpactype.SelectedItem.ToString)

        If fa <> -1 Then
            Me.txtActual.Text = fa
            Dim speedcheck As Double = (originaldistance / fa) * 60

            If speedcheck < (575 / 1.15) And speedcheck > 20 / 1.15 Then
                txtStatus.Text += "Found matching city pair and actual on first try" & vbNewLine
                txtStatus.Text += "Speed is " & CInt(speedcheck) & " kts" & vbNewLine
                txtStatus.Text += "Estimated Time is " & fa & " minutes (" & originaldistance / speedcheck & " hours)"
                Me.txtActual.Text = CInt(fa)

                Me.txtActualAVG.Text = CInt(findactualAVG(Me.txtFrom.Text, Me.txtTo.Text, Me.Drpactype.SelectedItem.ToString))

                Exit Sub

            End If


        End If








        'try a mtarix of flights
        Dim apinfo As DataSet
        apinfo = ws.GetAirportInformationByAirportCode("pbaumgart@ctgi.com", "123", 65, Me.txtTo.Text)

        Dim dt_d As DataTable

        dt_d = GetMajorAirportsByLatitudeLongitude(apinfo.Tables(0).Rows(0).Item("Latitude"), apinfo.Tables(0).Rows(0).Item("Longitude"), 4000, 100, 5)
        txtStatus.Text += vbNewLine
        txtStatus.Text += "Pin Origin, Check Major Destinations" & vbNewLine
        txtStatus.Text += "____________________________" & vbNewLine
        For i = 0 To dt_d.Rows.Count - 1
            Dim s As String = dt_d.Rows(i).Item(0).ToString

            txtStatus.Text = txtStatus.Text & "try " & Me.txtFrom.Text & " - " & s & vbLf
            fa = findactual(Me.txtFrom.Text, s, Me.Drpactype.SelectedItem.ToString)
            If fa <> -1 Then
                Me.txtActual.Text = fa
                txtStatus.Text = txtStatus.Text & "found " & Me.txtFrom.Text & " - " & s & " as " & fa & " minutes" & vbLf
                Dim reviseddistance As Double = ws.getdistance("pbaumgart@ctgi.com", "123", 65, Me.txtFrom.Text, s)
                txtStatus.Text += "Revised Distance is " & reviseddistance & vbNewLine
                Dim speed As Double = (reviseddistance / fa)

                If speed * 60 < (575 / 1.15) And speed * 60 > 20 / 1.15 Then

                    txtStatus.Text += "Speed is " & speed & vbNewLine
                    txtStatus.Text += "Estimated Time is " & originaldistance / speed
                    Me.txtActual.Text = CInt(originaldistance / speed)


                    Dim fa1 As Double = (findactualAVG(Me.txtFrom.Text, Me.txtTo.Text, Me.Drpactype.SelectedItem.ToString))
                    Dim speed1 As Double = (reviseddistance / fa1)
                    Me.txtActualAVG.Text = CInt(originaldistance / speed1)

                    txtStatus.Text += "Avg Speed is " & speed1 & vbNewLine
                    txtStatus.Text += "Estimated avg Time is " & originaldistance / speed1

                    Exit Sub

                End If

            End If

        Next i



        'try a mtarix of flights
        'Dim apinfo As DataSet
        apinfo = ws.GetAirportInformationByAirportCode("pbaumgart@ctgi.com", "123", 65, Me.txtFrom.Text)

        Dim dt_a As DataTable

        dt_a = GetMajorAirportsByLatitudeLongitude(apinfo.Tables(0).Rows(0).Item("Latitude"), apinfo.Tables(0).Rows(0).Item("Longitude"), 4000, 100, 5)
        '                 
        txtStatus.Text += vbNewLine
        txtStatus.Text += "Pin Destination, Check Major Origin Airports" & vbNewLine
        txtStatus.Text += "____________________________" & vbNewLine
        For i = 0 To dt_a.Rows.Count - 1
            Dim s As String = dt_a.Rows(i).Item(0).ToString

            txtStatus.Text = txtStatus.Text & "try " & s & " - " & Me.txtTo.Text & vbLf
            fa = findactual(s, Me.txtTo.Text, Me.Drpactype.SelectedItem.ToString)
            If fa <> -1 Then
                Me.txtActual.Text = fa
                txtStatus.Text = txtStatus.Text & "found " & s & " - " & Me.txtTo.Text & " as " & fa & " minutes" & vbLf
                Dim reviseddistance As Double = ws.getdistance("pbaumgart@ctgi.com", "123", 65, s, Me.txtTo.Text)
                txtStatus.Text += "Revised Distance is " & reviseddistance & vbNewLine
                Dim speed As Double = (reviseddistance / fa)

                If speed * 60 < (575 / 1.15) And speed * 60 > 20 / 1.15 Then
                    txtStatus.Text += "Speed is " & speed & vbNewLine
                    txtStatus.Text += "Estimated Time is " & originaldistance / speed
                    Me.txtActual.Text = CInt(originaldistance / speed)


                    Dim fa1 As Double = (findactualAVG(Me.txtFrom.Text, Me.txtTo.Text, Me.Drpactype.SelectedItem.ToString))
                    Dim speed1 As Double = (reviseddistance / fa1)
                    Me.txtActualAVG.Text = CInt(originaldistance / speed1)
                    txtStatus.Text += "Avg Speed is " & speed1 & vbNewLine
                    txtStatus.Text += "Estimated avg Time is " & originaldistance / speed1

                    Exit Sub
                End If


            End If

        Next i


        txtStatus.Text += vbNewLine
        txtStatus.Text += "Check 25 Origin and Destination Pairs" & vbNewLine
        txtStatus.Text += "____________________________" & vbNewLine

        For i = 0 To dt_a.Rows.Count - 1
            For ii = 0 To dt_d.Rows.Count - 1
                Dim a As String = dt_a.Rows(i).Item(0).ToString
                Dim b As String = dt_d.Rows(ii).Item(0).ToString

                txtStatus.Text = txtStatus.Text & "try " & a & " - " & b & vbLf
                fa = findactual(a, b, Me.Drpactype.SelectedItem.ToString)
                If fa <> -1 Then
                    Me.txtActual.Text = fa
                    txtStatus.Text = txtStatus.Text & "found " & a & " - " & b & " as " & fa & " minutes" & vbLf
                    Dim reviseddistance As Double = ws.getdistance("pbaumgart@ctgi.com", "123", 65, a, b)
                    txtStatus.Text += "Revised Distance is " & reviseddistance & vbNewLine
                    Dim speed As Double = (reviseddistance / fa)
                    If speed * 60 < (575 / 1.15) And speed * 60 > 20 / 1.15 Then
                        txtStatus.Text += "Speed is " & speed & vbNewLine
                        txtStatus.Text += "Estimated Time is " & originaldistance / speed
                        Me.txtActual.Text = CInt(originaldistance / speed)


                        Dim fa1 As Double = (findactualAVG(Me.txtFrom.Text, Me.txtTo.Text, Me.Drpactype.SelectedItem.ToString))
                        Dim speed1 As Double = (reviseddistance / fa1)
                        Me.txtActualAVG.Text = CInt(originaldistance / speed1)
                        txtStatus.Text += "Avg Speed is " & speed1 & vbNewLine
                        txtStatus.Text += "Estimated avg Time is " & originaldistance / speed1

                        Exit Sub
                    End If

                End If

            Next ii
        Next i


        txtStatus.Text += "Unable to Find "

    End Sub

    Function findactual(a As String, b As String, actype As String) As Double

        Dim cnoptimizerdataset As New ADODB.Connection

        If cnoptimizerdataset.State = 1 Then cnoptimizerdataset.Close()
        If cnoptimizerdataset.State = 0 Then
            cnoptimizerdataset.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDriver")
            cnoptimizerdataset.Open()
        End If

        Dim rs As New ADODB.Recordset


        Dim req As String
        req = "select top 1 * from CASFOSTripLegs where %Depart Airport ID% = 'abc' and %Arrival Airport ID% = 'def' and %Aircraft Type ID% = 'ghi' order by id desc"
        req = Replace(req, "%", Chr(34))

        req = Replace(req, "abc", a)
        req = Replace(req, "def", b)
        req = Replace(req, "ghi", actype)


        rs.Open(req, cnoptimizerdataset, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)


        findactual = -1
        If Not rs.EOF Then

            If rs.Fields("Flight Time Actual").Value <> 0 Then findactual = (rs.Fields("Flight Time Actual").Value)
            If rs.Fields("Flight Time Actual").Value = 0 Then findactual = (rs.Fields("ete").Value)


        End If


    End Function

    Function findactualAVG(a As String, b As String, actype As String) As Double

        Dim cnoptimizerdataset As New ADODB.Connection

        If cnoptimizerdataset.State = 1 Then cnoptimizerdataset.Close()
        If cnoptimizerdataset.State = 0 Then
            cnoptimizerdataset.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDriver")
            cnoptimizerdataset.Open()
        End If

        Dim rs As New ADODB.Recordset


        Dim req As String
        req = "select AVG(%FLIGHT TIME ACTUAL%) as %FLIGHT TIME AVG% , AVG(ETE) as ETEAVG from CASFOSTripLegs where %Depart Airport ID% = 'abc' and %Arrival Airport ID% = 'def' and %Aircraft Type ID% = 'ghi' AND %FLIGHT TIME ACTUAL% <> 0"
        req = Replace(req, "%", Chr(34))

        req = Replace(req, "abc", a)
        req = Replace(req, "def", b)
        req = Replace(req, "ghi", actype)


        rs.Open(req, cnoptimizerdataset, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)


        findactualAVG = -1
        If Not rs.EOF Then

            If Not (IsDBNull(rs.Fields("Flight Time avg").Value)) Then
                If rs.Fields("Flight Time avg").Value <> 0 Then findactualAVG = (rs.Fields("Flight Time avg").Value)
                If rs.Fields("Flight Time avg").Value = 0 Then findactualAVG = (rs.Fields("ETEAVG ").Value)
            Else
                findactualAVG = 0
            End If



        End If


    End Function



    Function loaddropdowns()

        Dim cnoptimizerdataset As New ADODB.Connection

        If cnoptimizerdataset.State = 1 Then cnoptimizerdataset.Close()
        If cnoptimizerdataset.State = 0 Then
            cnoptimizerdataset.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDriver")
            cnoptimizerdataset.Open()
        End If

        Dim rs As New ADODB.Recordset


        Dim req As String
        req = "SELECT [aircrafttype], cnt FROM [carrieractypes] order by cnt desc "
        req = Replace(req, "%", Chr(34))



        rs.Open(req, cnoptimizerdataset, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)

        Do While Not rs.EOF

            If rs.Fields("aircrafttype").Value <> "" Then

                Drpactype.Items.Add(rs.Fields("aircrafttype").Value)
            End If

            rs.MoveNext()

        Loop


        Drpactype.SelectedIndex = 2

    End Function

    Public Function GetMajorAirportsByLatitudeLongitude( _
       ByVal latitude As Double, _
       ByVal longitude As Double, _
       ByVal minimumRunwayLength As Integer, _
       ByVal miles As Integer, _
       ByVal count As Integer) As DataTable

        Dim oConn As SqlConnection = Nothing
        Dim oAdp As SqlDataAdapter = Nothing
        Dim oParam As SqlParameter = Nothing
        Dim dt As New DataTable

        Try
            oConn = New SqlConnection(ConnectionStringHelper.getglobalconnectionstring("OptimizerServer")) '("server=tcp:sg06v2b2hp.database.windows.net,1433;database=SuperPortalV31;uid=SFlaPilot@sg06v2b2hp;pwd=Nz9sg7!12;Trusted_Connection=False;Encrypt=True;")
            oAdp = New SqlDataAdapter("sp_GetMajorAirportsByLatitudeLongitudeWithinDistance", oConn)
            dt = New DataTable
            oParam = Nothing

            oAdp.SelectCommand.CommandType = CommandType.StoredProcedure

            oParam = New SqlParameter("@Latitude", SqlDbType.Float)
            oParam.Value = latitude
            oAdp.SelectCommand.Parameters.Add(oParam)

            oParam = New SqlParameter("@Longitude", SqlDbType.Float)
            oParam.Value = longitude
            oAdp.SelectCommand.Parameters.Add(oParam)

            oParam = New SqlParameter("@MinimumRunwayLength", SqlDbType.Int)
            oParam.Value = minimumRunwayLength
            oAdp.SelectCommand.Parameters.Add(oParam)

            oParam = New SqlParameter("@Miles", SqlDbType.Int)
            oParam.Value = miles
            oAdp.SelectCommand.Parameters.Add(oParam)

            oParam = New SqlParameter("@Count", SqlDbType.Int)
            oParam.Value = count
            oAdp.SelectCommand.Parameters.Add(oParam)

            oAdp.Fill(dt)

            Return dt
        Catch ex As Exception
            Return Nothing
        Finally
            If oConn.State = ConnectionState.Open Then
                oConn.Close()
            End If
            dt.Dispose()
            oAdp.Dispose()
            oConn.Dispose()
        End Try
    End Function


End Class