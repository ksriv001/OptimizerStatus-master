Imports System.IO

Imports System.Data
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Configuration
Imports Telerik.Web.UI.Calendar

Public Class AdvanceBooking
    Inherits Page
    Dim kkk As String


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

        req = "SELECT TOP 1 * FROM [FOSLOG]  WITH (NOLOCK)  where carrierid = 65 and  foslastupdate < '10/9/2012'  order by id desc"
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


        '20160329 - pab - add requester and total cost
        If InStr(Session("defaultemail").ToString, "@coastalav") = 0 Then
            DrpCarrier.Items.Clear()

            Dim i As New ListItem
            i.Selected = True
            i.Text = ""
            i.Value = 0

            Select Case Session("carrierid")
                Case 65
                    i.Text = "TMC"
                    i.Value = 65

                Case 104
                    i.Text = "JLX"
                    i.Value = 104

                Case 100
                    i.Text = "WU"
                    i.Value = 100

                Case 49
                    i.Text = "XO"
                    i.Value = 49

                Case 107
                    i.Text = "ASI"
                    i.Value = 107

                Case 108
                    i.Text = "Delta"
                    i.Value = 108

            End Select

            DrpCarrier.Items.Add(i)
        End If







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


    'Private Sub RadDatePickerFrom_SelectedDateChanged(sender As Object, e As SelectedDateChangedEventArgs) Handles RadDatePickerFrom.SelectedDateChanged

    '    'Dim session As String = getlatesttimestamp(RadDatePickerFrom.SelectedDate)


    '    'Dim req As String


    '    'req = "SELECT 	tripnumber, AircraftID,  aircrafttype, carrierid, departureairport, arrivalairport, departuredategmt, departuretimegmt, flighttime, nauticalmiles, duration, deadhead, paxcount, legtypecode, legratecode, legpurposecode, tripstatus, legstate   FROM [FOSFlights] where carrierid = 'abc123' and departuredate => '10/8/2012' "



    '    ''   req = Replace(req, "2012-10-08 14:20:40.000", session)
    '    'req = Replace(req, "10/8/2012", RadDatePickerFrom.SelectedDate)
    '    'req = Replace(req, "abc123", DrpCarrier.SelectedValue)

    '    'SqlDataSource1.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDataSource")
    '    'SqlDataSource1.SelectCommand = req
    '    'SqlDataSource1.DataBind()


    'End Sub

    Function loaddropdowns()

        Dim cnoptimizerdataset As New ADODB.Connection

        If cnoptimizerdataset.State = 1 Then cnoptimizerdataset.Close()
        If cnoptimizerdataset.State = 0 Then
            cnoptimizerdataset.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDriver")

            '20161209 - pab - increase timeout
            'cnoptimizerdataset.CommandTimeout = 30
            cnoptimizerdataset.ConnectionTimeout = 30

            cnoptimizerdataset.Open()
        End If

        Dim rs As New ADODB.Recordset


        Dim req As String
        req = "SELECT distinct([aircrafttype]), cnt FROM [carrieractypes]  WITH (NOLOCK)  order by aircrafttype   "
        req = Replace(req, "%", Chr(34))

        If Not (IsNothing(DrpCarrier.SelectedValue)) Then

            If DrpCarrier.SelectedValue <> 0 Then
                req = "SELECT [aircrafttype] FROM [carrieractypes]  WITH (NOLOCK)  where carrierid = " & DrpCarrier.SelectedValue & " order by aircrafttype "
            End If
        End If

        rs.Open(req, cnoptimizerdataset, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)

        Drpactype.Items.Clear()

        Drpactype.Items.Add("All")

        Do While Not rs.EOF

            If rs.Fields("aircrafttype").Value <> "" Then

                Drpactype.Items.Add(rs.Fields("aircrafttype").Value.ToString.Trim)
            End If

            rs.MoveNext()

        Loop


        Drpactype.SelectedIndex = 0






        req = "SELECT distinct([legtypecode])  FROM [carrierlegtypes]   WITH (NOLOCK)  order by legtypecode "
        req = Replace(req, "%", Chr(34))


        If Not (IsNothing(DrpCarrier.SelectedValue)) Then

            If DrpCarrier.SelectedValue <> 0 Then
                req = "SELECT [legtypecode]  FROM [carrierlegtypes]  WITH (NOLOCK)  where carrierid = " & DrpCarrier.SelectedValue & " order by legtypecode "
            End If
        End If


        If rs.State = 1 Then rs.Close()
        rs.Open(req, cnoptimizerdataset, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)

        RadLegTypeInclude.Items.Clear()
        RadLegTypeExclude.Items.Clear()
        RadLegTypeInclude.Items.Add("All")
        RadLegTypeExclude.Items.Add("None")
        RadLegTypeInclude.Items.Add("JF*")
        RadLegTypeExclude.Items.Add("JF*")





        Do While Not rs.EOF

            If rs.Fields("legtypecode").Value <> "" Then

                RadLegTypeInclude.Items.Add(rs.Fields("legtypecode").Value.ToString.Trim)
                RadLegTypeExclude.Items.Add(rs.Fields("legtypecode").Value.ToString.Trim)
            End If

            rs.MoveNext()

        Loop


        RadLegTypeInclude.SelectedIndex = 0
        RadLegTypeExclude.SelectedIndex = 0







        req = "SELECT [legstatecode], cnt FROM [carrierlegstate]  WITH (NOLOCK)  order by legstatecode "
        req = Replace(req, "%", Chr(34))


        If Not (IsNothing(DrpCarrier.SelectedValue)) Then

            If DrpCarrier.SelectedValue <> 0 Then
                req = "SELECT [legstatecode], cnt FROM [carrierlegstate]  WITH (NOLOCK)  where carrierid = " & DrpCarrier.SelectedValue & " order by legstatecode "
            End If
        End If


        If rs.State = 1 Then rs.Close()
        rs.Open(req, cnoptimizerdataset, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)

        RadLegStateInclude.Items.Clear()
        RadLegStateExclude.Items.Clear()

        RadLegStateInclude.Items.Add("All")
        RadLegStateExclude.Items.Add("None")

        Do While Not rs.EOF

            If rs.Fields("legstatecode").Value <> "" Then

                RadLegStateInclude.Items.Add(rs.Fields("legstatecode").Value.ToString.Trim)
                RadLegStateExclude.Items.Add(rs.Fields("legstatecode").Value.ToString.Trim)
            End If

            rs.MoveNext()

        Loop






        req = "SELECT distinct [AircraftWeightClass] FROM [AircraftWeightClass]  WITH (NOLOCK)  order by AircraftWeightClass "
        req = Replace(req, "%", Chr(34))
        If rs.State = 1 Then rs.Close()
        rs.Open(req, cnoptimizerdataset, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)

        DrpWeight.Items.Clear()

        DrpWeight.Items.Add("All")

        Do While Not rs.EOF

            If rs.Fields("AircraftWeightClass").Value <> "" Then

                DrpWeight.Items.Add(rs.Fields("AircraftWeightClass").Value.ToString.Trim)

            End If

            rs.MoveNext()

        Loop

    End Function

    Protected Sub AdvSearch_Click(sender As Object, e As EventArgs) Handles AdvSearch.Click
        '   Dim session As String = getlatesttimestamp(RadDatePickerFrom.SelectedDate)



        Dim sessiondate As String = getlatesttimestamp(Now)

        '20160329 - pab - check from and to locations for radius searches to make sure they are iata codes
        Dim da As New DataAccess
        Dim dt As DataTable
        Dim sfrom As String = ""
        Dim sto As String = ""
        '20161023 - pab - use icao because iata not always populated in fosflights
        Dim siatafrom As String = ""
        Dim siatato As String = ""
        If txtFrom.Text <> "" Then
            'sfrom = da.GetAirportNameByLocationID(txtFrom.Text)
            ''airport not found - look by icao
            'If sfrom = "" Then
            '    dt = da.GetAirportInformationByICAO(txtFrom.Text)
            '    If Not da.isdtnullorempty(dt) Then
            '        sfrom = dt.Rows(0).Item("locationid")
            '        txtFrom.Text = sfrom
            '    End If
            'End If
            dt = DataAccess.GetAirportInformationByICAO(txtFrom.Text)
            If Not IsNothing(dt) Then
                If dt.Rows.Count > 0 Then
                    sfrom = dt.Rows(0).Item("icao")
                    siatafrom = dt.Rows(0).Item("locationid")
                    txtFrom.Text = sfrom
                Else
                    If Len(txtFrom.Text.Trim) > 3 Then da.SendEmail("CharterSales@coastalavtech.com", "pbaumgart@coastalaviationsoftware.com", "", "OptimizerStatus (dmt)" & " FlightData.aspx.vb Advsearch_click Error",
                        "GetAirportInformationByICAO " & txtFrom.Text & " returned 0 results", 0)
                End If
            End If
            'not found - search by iata
            If sfrom = "" Then
                sfrom = DataAccess.GetICAOcodebyIATA(txtFrom.Text)
                siatafrom = txtFrom.Text
                If Not IsNothing(sfrom) Then txtFrom.Text = sfrom.ToString.Trim
            End If
        End If
        If txtTo.Text <> "" Then
            'sto = da.GetAirportNameByLocationID(txtTo.Text)
            ''airport not found - look by icao
            'If sto = "" Then
            '    dt = da.GetAirportInformationByICAO(txtTo.Text)
            '    If Not da.isdtnullorempty(dt) Then
            '        sto = dt.Rows(0).Item("locationid")
            '        txtTo.Text = sto
            '    End If
            'End If
            dt = DataAccess.GetAirportInformationByICAO(txtTo.Text)
            If Not IsNothing(dt) Then
                If dt.Rows.Count > 0 Then
                    sto = dt.Rows(0).Item("icao")
                    siatato = dt.Rows(0).Item("locationid")
                    txtTo.Text = sto
                Else
                    If Len(txtTo.Text.Trim) > 3 Then da.SendEmail("CharterSales@coastalavtech.com", "pbaumgart@coastalaviationsoftware.com", "", "OptimizerStatus (dmt)" & " FlightData.aspx.vb Advsearch_click Error",
                        "GetAirportInformationByICAO " & txtTo.Text & " returned 0 results", 0)
                End If
            End If
            'not found - search by iata
            If sto = "" Then
                sto = DataAccess.GetICAOcodebyIATA(txtTo.Text)
                siatato = txtTo.Text
                If Not IsNothing(sto) Then txtTo.Text = sto.ToString.Trim
            End If
        End If

        Dim req, req1 As String
        '       req = "Select 		tripnumber, carrierid, AircraftID, aircrafttype, departureairport, arrivalairport, departuredategmt, departuretimegmt, flighttime, nauticalmiles, duration, deadhead, paxcount, legtypecode, legratecode, legpurposecode, tripstatus, legstate" & _
        '" FROM [FOSFlights] where departuredategmt = '10/8/2012'"

        req = ""

        '20160329 - pab - add requester and total cost
        '20160429 - pab - fix error - Conversion failed when converting the nvarchar value
        req1 = "SELECT Snapdate,SnapDay, RequesterName, AircraftWeightClass, cast(ltrim(rtrim(quotedtotalcost)) as money)/100 as quotedtotalcost, f_tripnumber, f_AircraftID,  f_aircrafttype, "
        '20161023 - pab - use icao because iata not always populated in fosflights
        'req1 &= "f_carrierid, departureairport, arrivalairport, f_departuredategmt, departuretimegmt, flighttime, nauticalmiles, "
        req1 &= "carrierid, f_departureairporticao, f_arrivalairporticao, f_departuredategmt, departuretimegmt, flighttime, nauticalmiles, "
        req1 &= "duration, deadhead, paxcount, legtypecode, legratecode, legpurposecode, tripstatus, legstate, proratedrevenue, PIC, SIC  FROM [AdvanceBookings] "



        'If chkHistorical.Checked Then
        '    req1 = Replace(req1, "[AdvanceBookings]", "[FOSFlightHistory]")

        'End If

        '20160109 - pab - select distinct for asi to remove duplicates
        If DrpCarrier.SelectedValue = 107 Then
            req1 = Replace(req1, "select ", "select distinct ")
        End If

        '20160329 - pab - add requester and total cost
        req1 &= " where "

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

        If IsDate(SnapDatePicker.SelectedDate) Then
            req = req & " and CONVERT(date,SnapDate, 1)    = '10/8/2012'  "
            req = Replace(req, "10/8/2012", SnapDatePicker.SelectedDate)
        End If

        '  req = Replace(req, "10/8/2012", Now.Month & "/" & Now.Day & "/" & Now.Year)






        If DrpCarrier.SelectedValue <> 0 And DrpCarrier.SelectedValue <> "All" Then
            req = req & " and carrierid = 'abc123' "
            req = Replace(req, "abc123", DrpCarrier.SelectedValue)
        End If

        If requestertxt.Text <> "" Then
            req = req & "and RequesterName LIKE '%def123%' "
            req = Replace(req, "def123", requestertxt.Text)
        End If




        If Drpactype.SelectedValue <> "All" Then

            '20170207 - pab - fix lookups for wheels up
            'If Drpactype.SelectedValue <> "H80H" Then

            '    req = req & " and aircrafttype = 'abc123' "

            '    req = Replace(req, "abc123", Drpactype.SelectedValue)

            'Else

            '    req = req & " and (aircrafttype = 'H80H' or aircrafttype = 'H850') "



            'End If
            Select Case Drpactype.SelectedValue
                Case "H80H"
                    req = req & " and (f_aircrafttype = 'H80H' or f_aircrafttype = 'H850') "

                Case "B350F", "B350I"
                    req = req & " and (f_aircrafttype = 'B350F' or f_aircrafttype = 'B350I') "

                Case Else
                    req = req & " and f_aircrafttype = 'abc123' "

                    req = Replace(req, "abc123", Drpactype.SelectedValue)

            End Select
            'adding weight class condition
        Else
            If DrpWeight.SelectedValue <> "All" Then
                req = req & " and aircraftweightclass = 'kan123' "
                req = Replace(req, "kan123", DrpWeight.SelectedValue)
            End If

        End If



        If Chkmx.Checked = True Then
            If DrFlightType.SelectedValue = "S" Then
                req = req & " and f_departureairporticao = f_arrivalairporticao "
                req = req & " and legtypecode <> 'MXSC' "
                req = req & " and legtypecode <> '7' "
                req = req & " and legtypecode <> 'MAIN' "
                req = req & " and tripstatus <> 'maint' "
            ElseIf DrFlightType.SelectedValue = "MX" Then
                req = req & " and (f_departureairporticao = f_arrivalairporticao "
                req = req & " or legtypecode = 'MXSC' "
                req = req & " or legtypecode <> '7' "
                req = req & " or legtypecode <> 'MAIN' "
                req = req & " or tripstatus <> 'maint') "
            ElseIf DrFlightType.SelectedValue = "N" Then
                req = req & " and f_departureairporticao = f_arrivalairporticao "
                req = req & " and legtypecode <> 'MXSC' "
                req = req & " and legtypecode <> '7' "
                req = req & " and legtypecode <> 'MAIN' "
                req = req & " and tripstatus <> 'maint' "
            ElseIf DrFlightType.SelectedValue = "A" Then
                req = req & " and f_departureairporticao = f_arrivalairporticao "
                req = req & " and legtypecode <> 'MXSC' "
                req = req & " and legtypecode <> '7' "
                req = req & " and legtypecode <> 'MAIN' "
                req = req & " and tripstatus <> 'maint' "
            ElseIf DrFlightType.SelectedValue = "AV" Then
                req = req & " and f_departureairporticao = f_arrivalairporticao "
                req = req & " and legtypecode <> 'MXSC' "
                req = req & " and legtypecode <> '7' "
                req = req & " and legtypecode <> 'MAIN' "
                req = req & " and tripstatus <> 'maint' "
            ElseIf DrFlightType.SelectedValue = "OCF" Then
                req = req & " and f_departureairporticao = f_arrivalairporticao "
                req = req & " and legtypecode <> 'MXSC' "
                req = req & " and legtypecode <> '7' "
                req = req & " and legtypecode <> 'MAIN' "
                req = req & " and tripstatus <> 'maint' "
            ElseIf DrFlightType.SelectedValue = "SICK" Then
                req = req & " and f_departureairporticao = f_arrivalairporticao "
                req = req & " and legtypecode <> 'MXSC' "
                req = req & " and legtypecode <> '7' "
                req = req & " and legtypecode <> 'MAIN' "
                req = req & " and tripstatus <> 'maint' "
            ElseIf DrFlightType.SelectedValue = "Y" Then
                req = req & " and f_departureairporticao = f_arrivalairporticao "
                req = req & " and legtypecode <> 'MXSC' "
                req = req & " and legtypecode <> '7' "
                req = req & " and legtypecode <> 'MAIN' "
                req = req & " and tripstatus <> 'maint' "

            Else
                '20161023 - pab - use icao because iata not always populated in fosflights
                'req = req & " and departureairport <> arrivalairport "
                req = req & " and f_departureairporticao <> f_arrivalairporticao "
                req = req & " and legtypecode <> 'MXSC' "
                req = req & " and legtypecode <> '7' "
                req = req & " and legtypecode <> 'MAIN' "
                req = req & " and tripstatus <> 'maint' "
            End If
        End If



        If CHKCancel.Checked = True Then
            req = req & " and f_cancelcode = '0' "
            req = req & " and tripstatus <> 'cancelled' "
            req = req & " and tripstatus <> '10' "
            req = req & " and tripstatus <> '23' "
            'req = req & " and legstate <> '5' "
            'req = req & " and legstate <> '0' "


        End If

        If CHKstale1.Checked = True Then
            req = req & " and t_casupdate > DateAdd(hh, -1, SYSUTCDATETIME()) "
            req = req & " and f_casupdate > DateAdd(hh, -1, SYSUTCDATETIME()) "
        End If



        If drpDOW.SelectedValue <> "All" Then
            req = req & " and datename(weekday, f_departuredate) =  'Monday' "
            req = Replace(req, "Monday", drpDOW.SelectedValue)
        End If

        If txtRadiusFrom.Text = 0 Then
            If txtFrom.Text <> "" Then
                '20161023 - pab - use icao because iata not always populated in fosflights
                'req = req & " and departureairport  =  'Monday' "
                req = req & " and f_departureairporticao  =  'Monday' "
                req = Replace(req, "Monday", txtFrom.Text)
            End If
        Else
            '20161023 - pab - use icao because iata not always populated in fosflights
            'Dim A As String = nearbyairports(txtFrom.Text, txtRadiusFrom.Text)
            Dim A As String = nearbyairports(txtFrom.Text, txtRadiusFrom.Text, siatafrom)
            '20161023 - pab - use icao because iata not always populated in fosflights
            'A = Replace(A, "airport", "departureairport")
            A = Replace(A, "airport", "f_departureairporticao")
            req = req & A
        End If



        If txtRadiusTo.Text = 0 Then
            If txtTo.Text <> "" Then
                '20161023 - pab - use icao because iata not always populated in fosflights
                'req = req & " and arrivalairport   =  'Monday' "
                req = req & " and f_arrivalairporticao   =  'Monday' "
                req = Replace(req, "Monday", txtTo.Text)
            End If
        Else
            '20161023 - pab - use icao because iata not always populated in fosflights
            'Dim A As String = nearbyairports(txtTo.Text, txtRadiusTo.Text)
            Dim A As String = nearbyairports(txtTo.Text, txtRadiusTo.Text, siatato)
            '20161023 - pab - use icao because iata not always populated in fosflights
            'A = Replace(A, "airport", "arrivalairport")
            A = Replace(A, "airport", "f_arrivalairporticao")
            req = req & A
        End If





        If DrTimeOfDay.SelectedValue <> "All" Then
            If DrTimeOfDay.SelectedValue = "AM" Then
                req = req & " and datename(hour, [departuretime]) <12 "

            End If


            If DrTimeOfDay.SelectedValue = " AMPM" Then
                req = req & " and datename(hour, [departuretime]) >= 12 and  datename(hour, [departuretime])  <= 17  "

            End If


            If DrTimeOfDay.SelectedValue = " PM" Then
                req = req & " and datename(hour, [departuretime]) > 17    "

            End If

        End If



        If DrFlightType.SelectedValue <> "All" Then

            If DrFlightType.SelectedValue = "R" Then
                'Revenue logic for WU
                If DrpCarrier.SelectedValue = "100" Then
                    req = req & " and legtypecode in ('CONT','R135','R','SHTL','TECH','HOT')    "
                    'Revenue logic for Delta
                ElseIf DrpCarrier.SelectedValue = "108" Then
                    req = req & " and (legtypecode in ('CHRE','CHWH','CHTR','181','COMP','179','JLDS') or legtypecode like 'JF%' )   "
                Else
                    req = req & " and deadhead = 'False'   "
                End If
            End If

            If DrFlightType.SelectedValue = "D" Then
                If DrpCarrier.SelectedValue = "100" Then
                    req = req & " and legtypecode not in ('CONT','R135','R','SHTL','TECH','HOT')    "
                Else
                    req = req & " and deadhead = 'True'   "
                End If
            End If

            If DrFlightType.SelectedValue = "M" Then
                req = req & " and tripstatus = 'Maint'   "
            End If
            If DrFlightType.SelectedValue = "S" Then
                req = req & " and legtypecode = 'SWAP' and  f_arrivalairporticao=f_departureairporticao "
            End If
            If DrFlightType.SelectedValue = "MX" Then
                req = req & " and legtypecode = 'MXSC' and  f_arrivalairporticao=f_departureairporticao "
            End If
            If DrFlightType.SelectedValue = "N" Then
                req = req & " and legtypecode = 'NC' and  f_arrivalairporticao=f_departureairporticao "
            End If
            If DrFlightType.SelectedValue = "A" Then
                req = req & " and legtypecode = 'AOG' and  f_arrivalairporticao=f_departureairporticao "
            End If
            If DrFlightType.SelectedValue = "AV" Then
                req = req & " and legtypecode = 'AVAI' and  f_arrivalairporticao=f_departureairporticao "
            End If
            If DrFlightType.SelectedValue = "OCF" Then
                req = req & " and legtypecode = 'OCF' and  f_arrivalairporticao=f_departureairporticao "
            End If
            If DrFlightType.SelectedValue = "SICK" Then
                req = req & " and legtypecode = 'SICK' and  f_arrivalairporticao=f_departureairporticao "
            End If
            If DrFlightType.SelectedValue = "Y" Then
                req = req & " and legtypecode = 'Y' and  f_arrivalairporticao=f_departureairporticao "
            End If


        End If

        '20160329 - pab - add requester and total cost
        If txtTripNumber.Text <> "" Then
            'If IsNumeric(txtTripNumber.Text) Then
            req = req & " and f_TripNumber = " & "'" & txtTripNumber.Text & "'"
            'End If
        End If


        If RadLegTypeInclude.Text <> "" And RadLegTypeInclude.Text <> "All" Then


            Dim works As String

            works = " legtypecode = '' "

            For i = 0 To RadLegTypeInclude.Items.Count - 1




                If RadLegTypeInclude.Items.Item(i).Checked = True Then

                    works = works & " or legtypecode = '" & RadLegTypeInclude.Items.Item(i).Text & "'"

                End If



            Next


            req = req & " and (" & works & ")"

            If DrpCarrier.SelectedValue = "108" And RadLegTypeInclude.Items.FindItemByText("JF*").Selected = True Then
                'And RadLegTypeInclude.Items.Item(1).Checked = True 


                req = Replace(req, "legtypecode = 'JF*'", "legtypecode like'JF%'")

            End If

        End If







        If RadLegTypeExclude.Text <> "" And RadLegTypeExclude.Text <> "None" Then


            Dim works As String

            works = " legtypecode <> '' "

            For i = 0 To RadLegTypeExclude.Items.Count - 1




                If RadLegTypeExclude.Items.Item(i).Checked = True Then

                    works = works & " and legtypecode <> '" & RadLegTypeExclude.Items.Item(i).Text & "'"

                End If



            Next


            req = req & " and (" & works & ")"

        End If







        If RadLegStateInclude.Text <> "" And RadLegStateInclude.Text <> "All" Then


            Dim works As String

            works = " legstate  = '' "

            For i = 0 To RadLegStateInclude.Items.Count - 1




                If RadLegStateInclude.Items.Item(i).Checked = True Then

                    works = works & " or legstate  = '" & RadLegStateInclude.Items.Item(i).Text & "'"

                End If



            Next


            req = req & " and (" & works & ")"






        End If




        If RadLegStateExclude.Text <> "" And RadLegStateExclude.Text <> "None" Then


            Dim works As String

            works = " legstate <> '' "

            For i = 0 To RadLegStateExclude.Items.Count - 1




                If RadLegStateExclude.Items.Item(i).Checked = True Then

                    works = works & " and legstate  <> '" & RadLegStateExclude.Items.Item(i).Text & "'"

                End If



            Next


            req = req & " and (" & works & ")"

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

        '    sqldatasource1.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDataSource")
        '    sqldatasource1.SelectCommand = req1
        '    sqldatasource1.DataBind()

        '    '  GridView1.DataSourceID = sqldatasource1
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

        '    sqldatasource1.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDataSource")
        '    sqldatasource1.SelectCommand = req1
        '    sqldatasource1.DataBind()

        '    '  GridView1.DataSourceID = sqldatasource1
        '    GridView1.DataBind()



        'End If


        kkk = req1 & req & "  order by CAST([f_DepartureDateGMT] + ' ' + [DepartureTimeGMT] as datetime) "
        SqlDataSource1.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDataSource")
        SqlDataSource1.SelectCommand = req1 & req & "  order by CAST([f_DepartureDateGMT] + ' ' + [DepartureTimeGMT] as datetime) "


        SqlDataSource1.DataBind()

        '  GridView1.DataSourceID = sqldatasource1
        GridView1.DataBind()

        '20160329 - pab - add requester and total cost
        If InStr(Session("defaultemail").ToString, "@coastalav") > 0 Then
            GridView1.Columns(0).Visible = True
            GridView1.Columns(1).Visible = True
        Else
            'hide new columns if not coastal user
            GridView1.Columns(0).Visible = False
            GridView1.Columns(1).Visible = False
        End If


        Dim req2 As String
        '20160329 - pab - add requester and total cost
        req2 = "select count(*) as cnt, sum (CAST(nauticalmiles as numeric(10,2) )) as nauticalmiles, sum (CAST(duration as numeric(10,2) )) as duration, sum(ProRatedRevenue) as prev from [AdvanceBookings] where     " & req
        lblsql.Text = kkk

        'If chkHistorical.Checked Then
        '    req2 = Replace(req2, "[AdvanceBookings]", "[FOSFlightHistory]")

        'End If

        Dim cnoptimizerdataset As New ADODB.Connection

        If cnoptimizerdataset.State = 1 Then cnoptimizerdataset.Close()
        If cnoptimizerdataset.State = 0 Then
            cnoptimizerdataset.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDriver")

            '20161209 - pab - increase timeout
            'cnoptimizerdataset.CommandTimeout = 30
            cnoptimizerdataset.ConnectionTimeout = 30

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
        If Not (IsDBNull(rs.Fields("nauticalmiles").Value)) Then

            txtNM1.Text = FormatNumber(rs.Fields("nauticalmiles").Value, 0)
        End If


        If Not (IsDBNull(rs.Fields("prev").Value)) Then

            txtproratecosts.Text = FormatNumber(rs.Fields("prev").Value, 0)
        End If



    End Sub



    Function nearbyairports(apt As String, distance As Integer, iata As String) As String

        Dim cnoptimizerdataset As New ADODB.Connection

        If cnoptimizerdataset.State = 1 Then cnoptimizerdataset.Close()
        If cnoptimizerdataset.State = 0 Then
            cnoptimizerdataset.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDriver")

            '20161209 - pab - increase timeout
            'cnoptimizerdataset.CommandTimeout = 30
            cnoptimizerdataset.ConnectionTimeout = 30

            cnoptimizerdataset.Open()
        End If

        Dim rs As New ADODB.Recordset


        Dim req As String
        '20161023 - pab - use icao because iata not always populated in fosfligths
        'req = "SELECT [nearbyairport] FROM [NearbyAirports]  WITH (NOLOCK)  where airport = 'aptx' and StatuteMiles <= dstx "
        req = " SELECT ltrim(rtrim(i2.ICAO)) as NearbyAirport FROM NearbyAirports a WITH (NOLOCK) join ICAO_IATA i2 WITH (NOLOCK) on a.NearbyAirport = i2.IATA where Airport = 'aptx' and NearbyAirport <> '' and StatuteMiles <= dstx"
        req = Replace(req, "aptx", iata)
        req = Replace(req, "dstx", distance)

        rs.Open(req, cnoptimizerdataset, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)

        nearbyairports = "and airport in ('" & apt & "'  "



        Do While Not rs.EOF


            nearbyairports = nearbyairports & ",'" & rs.Fields("nearbyairport").Value.ToString.Trim & "'"



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



    Protected Sub DrpCarrier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DrpCarrier.SelectedIndexChanged
        loaddropdowns()
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DrpWeight.SelectedIndexChanged

    End Sub

    Protected Sub Drpactype_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class