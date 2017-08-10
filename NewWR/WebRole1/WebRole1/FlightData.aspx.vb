Imports System.IO

Imports System.Data
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Configuration
Public Class FlightData
    Inherits Page


    Function getlatesttimestamp(fordate As Date) As String
        Dim req As String
        Dim tom As Date = DateAdd(DateInterval.Day, 1, fordate)


        Dim cnazureAutoBatch As New ADODB.Connection

        If cnazureAutoBatch.State = 1 Then cnazureAutoBatch.Close()
        If cnazureAutoBatch.State = 0 Then
            cnazureAutoBatch.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDriver")
            cnazureAutoBatch.Open()
        End If

        Dim rs As New ADODB.Recordset

        Dim timestamp As String

        req = "SELECT TOP 1 * FROM [FOSLOG] where carrierid = 65 and  foslastupdate < '10/9/2012'  order by id desc"
        req = Replace(req, "10/9/2012", tom.Month & "/" & tom.Day & "/" & tom.Year)
        req = Replace(req, "65", DrpCarrier.SelectedValue)

        rs.Open(req, cnazureAutoBatch, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)


        If Not rs.EOF Then
            timestamp = rs.Fields("FOSLastUpdate").Value
            If rs.State = 1 Then rs.Close()
        End If

        If rs.State = 1 Then rs.Close()

        getlatesttimestamp = timestamp

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'DrpCarrier.Items.Clear()



        'If Not (IsNothing(Session("C"))) Then
        '    If Session("C") = "TMC" Then


        '        Dim i As New ListItem
        '        i.Selected = False
        '        i.Text = "TMC"
        '        i.Value = 65
        '        DrpCarrier.Items.Add(i)



        '    End If
        'Else

        '    Dim i As New ListItem
        '    i.Selected = False

        '    i.Text = "All"
        '    i.Value = 0
        '    DrpCarrier.Items.Add(i)



        '    i.Text = "XO"
        '    i.Value = 49
        '    DrpCarrier.Items.Add(i)

        '    i.Text = "WU"
        '    i.Value = 100
        '    DrpCarrier.Items.Add(i)

        '    i.Text = "JLX"
        '    i.Value = 104
        '    DrpCarrier.Items.Add(i)

        'End If









        Dim ws As New coastalavtech.service.WebService1
        If Session("defaultemail") <> ws.getcypher(Session("cypher")) Then Response.Redirect("login.aspx")


        If Drpactype.Items.Count = 0 Then loaddropdowns()

        'If IsNothing(Session("carrierid")) Then Response.Redirect("login.aspx")
        'If Session("carrierid") = 0 Then Response.Redirect("login.aspx")

        '   If Not (Page.IsPostBack) Then
        '20151103 - pab - fix error - Conversion from string "defaultemail" to type 'Integer' is not valid 
        'Dim session As String = getlatesttimestamp(Now)


        '     End If



    End Sub

    'Private Sub ExportToExcel(ByVal strFileName As String, ByVal dg As GridView)
    '    Response.Clear()
    '    Response.Buffer = True
    '    Response.AddHeader("content-disposition", "attachment;filename=FileName.xls")
    '    Response.ContentType = "application/vnd.ms-excel"
    '    Response.Charset = ""
    '    Me.EnableViewState = False
    '    Dim oStringWriter As New System.IO.StringWriter
    '    Dim oHtmlTextWriter As New System.Web.UI.HtmlTextWriter(oStringWriter)

    '    GridView1.RenderControl(oHtmlTextWriter)

    '    Response.Write(oStringWriter.ToString())
    '    Response.[End]()




    'End Sub



    'Protected Sub ImagebttnExcel_Click1(sender As Object, e As EventArgs) Handles ImagebttnExcel.Click
    '    ExportToExcel("Report.xls", GridView1)
    'End Sub

    Protected Sub RadDatePickerFrom_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerFrom.SelectedDateChanged

        'Dim session As String = getlatesttimestamp(RadDatePickerFrom.SelectedDate)


        'Dim req As String


        'req = "SELECT 	tripnumber, AircraftID,  aircrafttype, carrierid, departureairport, arrivalairport, departuredategmt, departuretimegmt, flighttime, nauticalmiles, duration, deadhead, paxcount, legtypecode, legratecode, legpurposecode, tripstatus, legstate   FROM [FOSFlights] where carrierid = 'abc123' and departuredate => '10/8/2012' "



        ''   req = Replace(req, "2012-10-08 14:20:40.000", session)
        'req = Replace(req, "10/8/2012", RadDatePickerFrom.SelectedDate)
        'req = Replace(req, "abc123", DrpCarrier.SelectedValue)

        'SqlDataSource1.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDataSource")
        'SqlDataSource1.SelectCommand = req
        'SqlDataSource1.DataBind()


    End Sub

    '   Protected Sub DrpCarrier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DrpCarrier.SelectedIndexChanged
    '       Dim session As String = "2012-10-08 14:20:40.000"
    '       If Not (IsNothing(RadDatePicker1.SelectedDate)) Then
    '           session = getlatesttimestamp(RadDatePicker1.SelectedDate)
    '       End If


    '       Dim req As String
    '       req = "SELECT 		tripnumber, carrierid, AircraftID, aircrafttype, departureairport, arrivalairport, departuredategmt, departuretimegmt, flighttime, nauticalmiles, duration, deadhead, paxcount, legtypecode, legratecode, legpurposecode, tripstatus, legstate" & _
    '" FROM [FOSFlights] where carrierid = 65 and departuredategmt = '10/8/2012' "



    '       req = "SELECT 	tripnumber, AircraftID,  aircrafttype, carrierid, departureairport, arrivalairport, departuredategmt, departuretimegmt, flighttime, nauticalmiles, duration, deadhead, paxcount, legtypecode, legratecode, legpurposecode, tripstatus, legstate   FROM [FOSFlights] where  carrierid = abc123 and  departuredate = '10/8/2012' "


    '       '  req = Replace(req, "2012-10-08 14:20:40.000", session)
    '       If Not (IsNothing(RadDatePicker1.SelectedDate)) Then
    '           req = Replace(req, "10/8/2012", RadDatePicker1.SelectedDate)
    '       End If

    '       req = Replace(req, "abc123", DrpCarrier.SelectedValue)

    '       SqlDataSource1.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDataSource")
    '       SqlDataSource1.SelectCommand = req
    '       SqlDataSource1.DataBind()
    '   End Sub

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


        Drpactype.Items.Add("All")

        Do While Not rs.EOF

            If rs.Fields("aircrafttype").Value <> "" Then

                Drpactype.Items.Add(rs.Fields("aircrafttype").Value.ToString.Trim)
            End If

            rs.MoveNext()

        Loop


        Drpactype.SelectedIndex = 0

    End Function

    Protected Sub LinkSearch_Click(sender As Object, e As EventArgs) Handles LinkSearch.Click
        '   Dim session As String = getlatesttimestamp(RadDatePickerFrom.SelectedDate)



        Dim sessiondate As String = getlatesttimestamp(Now)



        Dim req, req1 As String
        '       req = "SELECT 		tripnumber, carrierid, AircraftID, aircrafttype, departureairport, arrivalairport, departuredategmt, departuretimegmt, flighttime, nauticalmiles, duration, deadhead, paxcount, legtypecode, legratecode, legpurposecode, tripstatus, legstate" & _
        '" FROM [FOSFlights] where departuredategmt = '10/8/2012'"

        req = ""

        req1 = "SELECT 	tripnumber, AircraftID,  aircrafttype, carrierid, departureairport, arrivalairport, departuredategmt, departuretimegmt, flighttime, nauticalmiles, duration, deadhead, paxcount, legtypecode, legratecode, legpurposecode, tripstatus, legstate   FROM [FOSFlights] where   " &
                "    "



        If chkHistorical.Checked Then
            req1 = Replace(req1, "[FOSFlights]", "[FOSFlightHistory]")

        End If

        '20160109 - pab - select distinct for asi to remove duplicates
        If DrpCarrier.SelectedValue = 107 Then
            req1 = Replace(req1, "select ", "select distinct ")
        End If

        '20151103 - pab - restrict carrier data if not coastal login
        If InStr(Session("defaultemail").ToString.ToLower, "coastalaviationsoftware") > 0 Or Session("defaultemail").ToString.ToLower = "rk" Then
            'select all except EAS (63)
            req &= "   carrierid <> " & 63

        Else
            req &= "  carrierid = " & Session("carrierid")

            DrpCarrier.Items.Clear()
            Dim li As New ListItem
            li.Value = Session("carrierid")
            Select Case Session("carrierid").ToString
                Case "49"
                    li.Text = "XO"
                Case "65"
                    li.Text = "TMC"
                Case "100"
                    li.Text = "WU"
                Case "104"
                    li.Text = "JLX"
                Case "107"
                    li.Text = "ASI"
                Case "108"
                    li.Text = "DELTA"
                Case Else
                    li.Text = "???"
            End Select
            DrpCarrier.Items.Add(li)

        End If

        ' req = Replace(req, "2012-10-08 14:20:40.000", session)


        Dim restrictdate As Boolean = True

        If IsDate(RadDatePickerFrom.SelectedDate) And Not (IsDate(RadDatePickerTo.SelectedDate)) Then
            req = req & " and CONVERT(date, departuredategmtkey	, 1)    = '10/8/2012'  "
            req = Replace(req, "10/8/2012", RadDatePickerFrom.SelectedDate)
            restrictdate = False
        End If

        If IsDate(RadDatePickerFrom.SelectedDate) And (IsDate(RadDatePickerTo.SelectedDate)) Then

            req = req & " and CONVERT(date, departuredategmtkey	, 1)    >= '10/8/2012'  "
            req = Replace(req, "10/8/2012", RadDatePickerFrom.SelectedDate)

            req = req & " and CONVERT(date, departuredategmtkey	, 1)    <= '10/8/2012'  "
            req = Replace(req, "10/8/2012", RadDatePickerTo.SelectedDate)
            restrictdate = False

        End If

        If restrictdate = True Then
            req = req & " and CONVERT(date, departuredategmtkey	, 1)    = '10/8/2012'  "
            req = Replace(req, "10/8/2012", Now.Month & "/" & Now.Day & "/" & Now.Year)
        End If

        '  req = Replace(req, "10/8/2012", Now.Month & "/" & Now.Day & "/" & Now.Year)






        If DrpCarrier.SelectedValue <> 0 And DrpCarrier.SelectedValue <> "All" Then
            req = req & " and carrierid = 'abc123' "
            req = Replace(req, "abc123", DrpCarrier.SelectedValue)
        End If


        If Drpactype.SelectedValue <> "All" Then

            If Drpactype.SelectedValue <> "H80H" Then

                req = req & " and aircrafttype = 'abc123' "

                req = Replace(req, "abc123", Drpactype.SelectedValue)

            Else

                req = req & " and (aircrafttype = 'H80H' or aircrafttype = 'H850') "



            End If


        End If



        If Chkmx.Checked = True Then
            req = req & " and departureairport <> arrivalairport "
            req = req & " and legtypecode <> 'MXSC' "
            req = req & " and tripstatus <> 'maint' "
        End If


        If CHKCancel.Checked = True Then
            req = req & " and cancelcode = '0' "
            req = req & " and tripstatus <> 'cancelled' "
            req = req & " and tripstatus <> '10' "
            req = req & " and tripstatus <> '23' "
        End If



        If drpDOW.SelectedValue <> "All" Then
            req = req & " and datename(weekday, departuredate) =  'Monday' "
            req = Replace(req, "Monday", drpDOW.SelectedValue)
        End If

        If txtRadiusFrom.Text = 0 Then
            If txtFrom.Text <> "" Then
                req = req & " and departureairport  =  'Monday' "
                req = Replace(req, "Monday", txtFrom.Text)
            End If
        Else
            Dim A As String = nearbyairports(txtFrom.Text, txtRadiusFrom.Text)
            A = Replace(A, "airport", "departureairport")
            req = req & A
        End If



        If txtRadiusTo.Text = 0 Then
            If txtTo.Text <> "" Then
                req = req & " and arrivalairport   =  'Monday' "
                req = Replace(req, "Monday", txtTo.Text)
            End If
        Else
            Dim A As String = nearbyairports(txtTo.Text, txtRadiusTo.Text)
            A = Replace(A, "airport", "arrivalairport")
            req = req & A
        End If





        If DrTimeOfDay.SelectedValue <> "All" Then
            If DrTimeOfDay.SelectedValue = "AM" Then
                req = req & " and datename(hour, [departuretime]) < 12 "

            End If


            If DrTimeOfDay.SelectedValue = "AMPM" Then
                req = req & " and datename(hour, [departuretime]) >= 12 and  datename(hour, [departuretime])  <= 17  "

            End If


            If DrTimeOfDay.SelectedValue = "PM" Then
                req = req & " and datename(hour, [departuretime]) > 17    "

            End If

        End If



        If DrFlightType.SelectedValue <> "All" Then
            If DrFlightType.SelectedValue = "R" Then
                req = req & " and deadhead = 'False'   "
            End If

            If DrFlightType.SelectedValue = "D" Then
                req = req & " and deadhead = 'True'   "
            End If

            If DrFlightType.SelectedValue = "M" Then
                req = req & " and tripstatus = 'Maint'   "
            End If
        End If


        'x         1. Date range from, to.
        'x    2, The ability to select days of the week, or all.
        'x    3. Equipment type...one, more than one, or all.
        '4. Revenue, DH or total flights.  If we could also track crew or maint flights that would be great but not essential.
        '5. From an airport and to an airport, including the ability to enter a radius from each.
        '6. Flight types:  completed?  Not sure we need this but we may need to ensure that it is only completed flights.
        '7. Selecting flight time bands:  Morning, Afternoon, Evening or total.  Not sure how we would handle this given time zones, but perhaps just key off of local departure?  If its easier to select GMT we can go with that.  If we use GMT, I guess we use EST for the am/pm/evening definition?
        '8. Ideally, if we could identify the number of planes in use at a given time slot vs the number available, to see the percentage of fleet utilized, that would be great.  If not, revenue departures vs available aircraft?  We can start the above searches first if this would take time to track or set up.

        'If chkdetail.Checked = True Then

        '    Dim req1 As String
        '    req1 = "SELECT 	tripnumber, AircraftID,  aircrafttype, carrierid, departureairport , arrivalairport , departuredategmt, departuretimegmt, departuredate , departuretime , flighttime, nauticalmiles, duration, deadhead, paxcount, legtypecode, legratecode, legpurposecode, tripstatus, legstate   FROM [FOSFlights] where 1 = 1   " & req

        '    If chkHistorical.Checked Then
        '        req1 = Replace(req1, "[FOSFlights]", "[FOSFlightHistory]")

        '    End If


        '    '20160109 - pab - select distinct for asi to remove duplicates
        '    If DrpCarrier.SelectedValue = 107 Then
        '        req1 = Replace(req1, "select ", "select distinct ")
        '    End If

        '    req = req & "  order by CAST([DepartureDateGMT] + ' ' + [DepartureTimeGMT] as datetime) "

        '    SqlDataSource1.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDataSource")
        '    SqlDataSource1.SelectCommand = req1
        '    SqlDataSource1.DataBind()

        '    '  GridView1.DataSourceID = SqlDataSource1
        '    GridView1.DataBind()


        'Else

        '    Dim req1 As String
        '    '20151103 - pab - fix query
        '    req1 = "SELECT 	tripnumber, AircraftID,  aircrafttype, carrierid, departureairport , arrivalairport , departuredategmt, departuretimegmt, departuredate , departuretime , flighttime, nauticalmiles, duration, deadhead, paxcount, legtypecode, legratecode, legpurposecode, tripstatus, legstate   FROM [FOSFlights] where 1 =  1  "
        '    req1 &= req

        '    req1 = req1 & "  order by CAST([DepartureDateGMT] + ' ' + [DepartureTimeGMT] as datetime) "


        '    If chkHistorical.Checked Then
        '        req1 = Replace(req1, "[FOSFlights]", "[FOSFlightHistory]")

        '    End If


        '    '20160109 - pab - select distinct for asi to remove duplicates
        '    If DrpCarrier.SelectedValue = 107 Then
        '        req1 = Replace(req1, "select ", "select distinct ")
        '    End If

        '    SqlDataSource1.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDataSource")
        '    SqlDataSource1.SelectCommand = req1
        '    SqlDataSource1.DataBind()

        '    '  GridView1.DataSourceID = SqlDataSource1
        '    GridView1.DataBind()



        'End If



        SqlDataSource1.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDataSource")
        SqlDataSource1.SelectCommand = req1 & req & "  order by CAST([DepartureDateGMT] + ' ' + [DepartureTimeGMT] as datetime) "

        SqlDataSource1.DataBind()

        '  GridView1.DataSourceID = SqlDataSource1
        GridView1.DataBind()




        Dim req2 As String
        req2 = "select count(*) as cnt, sum (CAST(duration as numeric(6,2) )) as duration from [FOSFlights] where     " & req
        lblsql.Text = req2


        If chkHistorical.Checked Then
            req2 = Replace(req2, "[FOSFlights]", "[FOSFlightHistory]")

        End If

        Dim cnoptimizerdataset As New ADODB.Connection

        If cnoptimizerdataset.State = 1 Then cnoptimizerdataset.Close()
        If cnoptimizerdataset.State = 0 Then
            cnoptimizerdataset.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDriver")
            cnoptimizerdataset.Open()
        End If

        Dim rs As New ADODB.Recordset



        rs.Open(req2, cnoptimizerdataset, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)

        If Not (IsDBNull(rs.Fields("cnt").Value)) Then
            txtcount.Text = FormatNumber(rs.Fields("cnt").Value, 0)
        End If

        If Not (IsDBNull(rs.Fields("duration").Value)) Then

            txtminutes.Text = FormatNumber(rs.Fields("duration").Value, 0)
        End If


    End Sub



    Function nearbyairports(apt As String, distance As Integer) As String

        Dim cnoptimizerdataset As New ADODB.Connection

        If cnoptimizerdataset.State = 1 Then cnoptimizerdataset.Close()
        If cnoptimizerdataset.State = 0 Then
            cnoptimizerdataset.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDriver")
            cnoptimizerdataset.Open()
        End If

        Dim rs As New ADODB.Recordset


        Dim req As String
        req = "SELECT [nearbyairport] FROM [NearbyAirports] where airport = 'aptx' and StatuteMiles <= dstx "
        req = Replace(req, "aptx", apt)
        req = Replace(req, "dstx", distance)


        rs.Open(req, cnoptimizerdataset, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)

        nearbyairports = "and (airport = '" & apt & "'  "



        Do While Not rs.EOF


            nearbyairports = nearbyairports & " or airport = '" & rs.Fields("nearbyairport").Value & "'"



            rs.MoveNext()

        Loop

        nearbyairports = nearbyairports & ") "



    End Function


    Protected Sub ExportToExcel_click(sender As Object, e As EventArgs) Handles ExportToExcel.Click
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            'To Export all pages
            GridView1.AllowPaging = False
            '   Me.BindGrid()

            GridView1.HeaderRow.BackColor = Color.White
            For Each cell As TableCell In GridView1.HeaderRow.Cells
                cell.BackColor = GridView1.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In GridView1.Rows
                row.BackColor = Color.White
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = GridView1.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = GridView1.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"
                Next
            Next

            GridView1.RenderControl(hw)
            'style to format numbers to string
            Dim style As String = "<style> .textmode { } </style>"
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.[End]()
        End Using
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        ' Verifies that the control is rendered
    End Sub

    Protected Sub RadDatePickerTo_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerTo.SelectedDateChanged

    End Sub
End Class